using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using System.Web.Security;
using Newtonsoft.Json;
using HRMS.Web.Helper;
using System.Configuration;
using System.IO;
using HRMS.Common.Enums;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace HRMS.Web.Controllers
{
    public class FilesController : Controller
    {
        #region Class Level Variables and constructor

        private readonly IConsentFormRepository _consentFormRepository;
        private readonly IFilesDBRepository _filesDbRepository;
        private readonly IEmployeeSignRepository _employeeSignRepository;
        private readonly string Filepath = ConfigurationManager.AppSettings["scannedfilepath"];
        int fileId = 0;
        public FilesController(IConsentFormRepository consentFormRepository, IFilesDBRepository filesDbRepository, IEmployeeSignRepository employeeSignRepository)
        {
            _consentFormRepository = consentFormRepository;
            _filesDbRepository = filesDbRepository;
            _employeeSignRepository = employeeSignRepository;
        }
        #endregion
       /// <summary>
       /// View to show all the files in the company
       /// </summary>
       /// <returns></returns>
        public ActionResult SelectAllFiles()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<FilesDB> filesDBobj = _filesDbRepository.SelectAllFilesByCompanyId(companyId);
            return View(filesDBobj);
        }
        /// <summary>
        /// Function to add a new file to the application based on category
        /// </summary>
        /// <returns></returns>
        public bool AddFiles()
        {
            const bool isUploaded = false;
            var consentFormobj = new ConsentForms();
            var postedFileBase = Request.Files[0];
            if (postedFileBase != null && ((Request.Files.Count > 0) && (postedFileBase.ContentLength > 0)))
            {
                var httpPostedFileBase = Request.Files[0];
                if (httpPostedFileBase != null)
                {
                    var filename = Path.GetFileName(httpPostedFileBase.FileName);
                    var filesDBobj = new FilesDB();
                    var filestream = httpPostedFileBase.InputStream;
                    var bytesInStream = new byte[filestream.Length];
                    filestream.Read(bytesInStream, 0, bytesInStream.Length);
                    var extension = Path.GetExtension(filename);
                    filesDBobj.FileName = filename;
                    filesDBobj.FileExtension = extension;
                    filesDBobj.FileBytes = bytesInStream;
                    filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                    filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                    filesDBobj.FileType = GeneralEnum.FileType.consentdocuments.ToString();
                    fileId = _filesDbRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.SelectedUserId));
                    consentFormobj.AttachmentFileId = fileId;
                    consentFormobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                    consentFormobj.DocumentName = filename;
                }
                consentFormobj.CreatedOn = System.DateTime.UtcNow;
                var result = _consentFormRepository.CreateConsentForm(consentFormobj);
            }
            return isUploaded;
        }
        /// <summary>
        /// To retreive files based on companyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public ActionResult SelectAllFilesByCompanyId(int companyId)
        {
            var result = _filesDbRepository.SelectAllFilesByCompanyId(companyId);
            return View();
        }
        /// <summary>
        /// saving signature related information to consent documents in onboarding process
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="eSign"></param>
        /// <param name="consentDocumentId"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public int SignConsentFiles(string fileName, string eSign, string consentDocumentId, string filePath)
        {
            //const bool isUploaded = false;
            var employeeSignobj = new EmployeeSign();
            int employeeSignId = 0;
            string path = Server.MapPath(Filepath);
            if (eSign.Length > 0)
            {
                var bytes = System.Convert.FromBase64String(eSign);
                string signimagepath = path + "employeeSign.png";
                System.IO.File.WriteAllBytes(signimagepath, bytes);
                var filesDBobj = new FilesDB();
                byte[] bytesInStream = System.Convert.FromBase64String(eSign);
                filesDBobj.FileName = fileName;
                filesDBobj.FileExtension = "jpg";
                filesDBobj.FileBytes = bytesInStream;
                filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                filesDBobj.FileType = GeneralEnum.FileType.EmployeeSign.ToString();
                fileId = _filesDbRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.SelectedUserId));
                //TempData["I9SignImageId"] = fileId;
                TempData["consentDocumentId"] = consentDocumentId;
                employeeSignobj.UserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                employeeSignobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                employeeSignobj.Name = fileName;
                employeeSignobj.EmployeeSignFileId = fileId;
                var success = _employeeSignRepository.CreateEmployeeSign(employeeSignobj);
                var employeeSignList=_employeeSignRepository.GetAllEmployeeSignByUserId(Convert.ToInt32(GlobalsVariables.CurrentUserId));
                var employeesigndata = (from slist in employeeSignList
                                      where slist.EmployeeSignFileId == fileId
                                      select slist.EmployeeSignId).SingleOrDefault();
                employeeSignId = Convert.ToInt32(employeesigndata);
                var fileDetails = _filesDbRepository.SelectFileByFileDBId(Convert.ToInt32(consentDocumentId));
                var filebytes = fileDetails[0].FileBytes;
                var signFileDetails = _filesDbRepository.SelectFileByFileDBId(fileId);
                var signFilebytes = signFileDetails[0].FileBytes;
                TempData["consentDocument"] = "data:image/jpg;base64," + Convert.ToBase64String(filebytes);
                TempData["consentSignImage"] = "data:image/jpg;base64," + Convert.ToBase64String(signFilebytes);
            }
            return employeeSignId;
        }
        /// <summary>
        /// saving signature related information to I9 form in onboarding process 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="eSign"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public int SignI9Form(string fileName, string eSign, string filePath)
        {

            var employeeSignobj = new EmployeeSign();
            var path = Server.MapPath(Filepath);
            if (eSign.Length > 0)
            {
                var bytes = Convert.FromBase64String(eSign);
                string signimagepath = path + "employeeSign.png";
                System.IO.File.WriteAllBytes(signimagepath, bytes);
                var filesDBobj = new FilesDB();
                byte[] bytesInStream = Convert.FromBase64String(eSign);
                filesDBobj.FileName = fileName;
                filesDBobj.FileExtension = "jpg";
                filesDBobj.FileBytes = bytesInStream;
                filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                filesDBobj.FileType = GeneralEnum.FileType.EmployeeSign.ToString();
                fileId = _filesDbRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.SelectedUserId));
                TempData["SignImageId"] = fileId;
                employeeSignobj.UserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                employeeSignobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                employeeSignobj.Name = fileName;
                employeeSignobj.EmployeeSignFileId = fileId;
                var success = _employeeSignRepository.CreateEmployeeSign(employeeSignobj);
               
            }
            return fileId;
        }

        //public bool CreatePDF(List<string> SourcePaths, string filename, string rootpath,int fileId, int CompanyId)
        //{
        //    bool IsSuccesful = false;
        //    Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //    string pdffilename = filename;
        //    string pdffilepath = rootpath + pdffilename;
        //    PdfWriter writer = PdfAWriter.GetInstance(doc, new FileStream(pdffilepath, FileMode.Create));
        //    doc.Open();
        //    try
        //    {
        //        List<PdfReader> readerList = new List<PdfReader>();
        //        foreach (string filepath in SourcePaths)
        //        {
        //            Paragraph paragraph = new Paragraph(filename);
        //            string imageURL = filepath;
        //            var valueArray = filepath.Split('.');

        //            string extension = Path.GetExtension(filepath);
        //            if (extension == ".pdf")
        //            {
        //                PdfReader pdfReader = new PdfReader(filepath);
        //                readerList.Add(pdfReader);
        //            }
        //            else
        //            {
        //                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
        //                //jpg.RotationDegrees = 90;
        //                //Resize image depend upon your need
        //                jpg.ScaleAbsolute(550, 500);
        //                //Give space before image
        //                jpg.SpacingBefore = 10f;
        //                //Give some space after the image
        //                jpg.SpacingAfter = 1f;
        //                //doc.Add(paragraph);
        //                doc.Add(jpg);
        //                //File.Delete(filepath);
        //                doc.NewPage();
        //            }
        //            //File.Delete(filepath);  
        //        }
        //        if (readerList.Count > 0)
        //        {
        //            foreach (PdfReader reader in readerList)
        //            {
        //                for (int i = 1; i <= reader.NumberOfPages; i++)
        //                {
        //                    PdfImportedPage page = writer.GetImportedPage(reader, i);
        //                    doc.Add(iTextSharp.text.Image.GetInstance(page));
        //                }
        //            }
        //        }
        //           FilesDB filesDBobj = new FilesDB();
        //            System.IO.Stream filestream = new FileStream(pdffilepath, FileMode.Open, FileAccess.Read);
        //            FileInfo fInfo = new FileInfo(pdffilepath);
        //            byte[] bytesInStream =  new byte[fInfo.Length];
        //            filestream.Read(bytesInStream, 0, bytesInStream.Length);
        //            string fileextension = System.IO.Path.GetExtension(pdffilename);
        //            filesDBobj.FileName = pdffilename;
        //            filesDBobj.FileExtension = fileextension;
        //            filesDBobj.FileBytes = bytesInStream;
        //            filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
        //            filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
        //            filesDBobj.FileType = "SignedDocument";
        //            // fileId = _filesDBRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.CurrentUserId));

        //        doc.Close();
        //    }
        //    catch (Exception ex)
        //    { }
        //    finally
        //    {
        //        doc.Close();

        //      //  IsSuccesful = InsertMergedDocuments(pdffilepath, fileIds, pdffilename, CompanyId);
        //    }
        //    return IsSuccesful;
        //}


        /// <summary>
        /// Method to return content result of file saved from database in the application
        /// </summary>
        /// <param name="fileid"></param>
        /// <param name="fileMode"></param>
        /// <returns>file content</returns>
        public FileContentResult Showfile(int fileid, string fileMode)
        {
            var fileDetails = _filesDbRepository.SelectFileByFileDBId(fileid);
            var filebytes = fileDetails[0].FileBytes;
            if (filebytes != null)
            {
                if (fileDetails[0].FileExtension.ToLower() == "png" || fileDetails[0].FileExtension.ToLower() == "jpeg" || fileDetails[0].FileExtension.ToLower() == "jpg" || fileDetails[0].FileExtension.ToLower() == "gif")
                {
                    if (fileMode.Equals("thumbnail"))
                    {
                        filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 100, 100);
                    }
                    if (fileMode.Equals("normal"))
                    {
                        filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 700, 320);
                    }
                    if (fileMode.Equals("fullview"))
                    {
                        filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 700, 1800);
                    }
                    if (fileMode.Equals("approvalview"))
                    {
                        filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 500, 900);
                    }
                    return new FileContentResult(filebytes, ReturnExtension(fileDetails[0].FileExtension.ToLower()));
                }
                else if (fileDetails[0].FileExtension.ToLower() == "bmp")
                {
                    if (fileMode.Equals("thumbnail"))
                    {
                        filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 100, 100);
                    }
                    if (fileMode.Equals("normal"))
                    {
                        filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 450, 500);
                    }
                    if (fileMode.Equals("fullview"))
                    {
                        filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 1280, 1800);
                    }
                    if (fileMode.Equals("approvalview"))
                    {
                        filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 500, 900);
                    }
                    return new FileContentResult(filebytes, ReturnExtension(fileDetails[0].FileExtension.ToLower()));
                }
                else if (fileDetails[0].FileExtension.ToLower() == ".pdf" && !(fileMode.Equals("thumbnail")))
                {
                    if (fileDetails[0].FileExtension.ToLower() == ".pdf" && fileMode.Equals("normal"))
                    {
                        var filename = fileDetails[0].FileName;
                        filebytes = Extract_Pdf_Pages_As_Png(filename, filebytes);
                        //if (filebytes != null)
                        //    filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 400, 400);
                        return new FileContentResult(filebytes, ReturnExtension(".pdf"));
                    }
                    else
                        return new FileContentResult(filebytes, ReturnExtension(".pdf"));
                }
                else if (fileDetails[0].FileExtension.ToLower() == ".pdf" && fileMode.Equals("thumbnail"))
                {
                    var filename = fileDetails[0].FileName;
                    filebytes = Extract_Pdf_Pages_As_Png(filename, filebytes);
                    //if (filebytes != null)
                    //    filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 100, 100);
                    return new FileContentResult(filebytes, ReturnExtension("png"));
                }

                else if (fileDetails[0].FileExtension.ToLower() == "txt")
                {
                    filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 100, 100);
                    return new FileContentResult(filebytes, ReturnExtension("png"));
                }
            }
            //return array of bytes as the image's data to action's response. We set the image's content mime type to image/jpeg
            return null;
        }
        /// <summary>
        /// Function to return extension depending on file type
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".docx":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".png": return "image/png";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        private byte[] Extract_Pdf_Pages_As_Png(string filename, byte[] sourcebytes)
        {
            byte[] filebytes = null;
            string sourcepath;
            string rootpath = Server.MapPath(Filepath);
            if (filename.Split('.').Count() < 2)
            {
                sourcepath = rootpath + filename + ".pdf";
            }
            else
            {
                sourcepath = rootpath + filename;
            }

            if (!System.IO.File.Exists(sourcepath))
            {
                System.IO.File.WriteAllBytes(sourcepath, sourcebytes);
            }
            string outputfilename = System.IO.Path.GetFileNameWithoutExtension(sourcepath) + ".pdf";
            string outputPath = rootpath + outputfilename;
            var info = new FileInfo(outputPath);

            if (!IsFileLocked(info))
            {
                filebytes = System.IO.File.ReadAllBytes(outputPath);
            }

            return filebytes != null ? filebytes : sourcebytes;
        }
        /// <summary> /// This function is used to check specified file being used or not        
        /// </summary> /// <param name="file">FileInfo of required file</param>
        /// <returns>If that specified file is being processed /// or not found is return true</returns> 
        public static Boolean IsFileLocked(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                //Don't change FileAccess to ReadWrite,
                //because if a file is in readOnly, it fails. 
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is: //still being written to //or being processed by another thread //or does not exist (has already been processed) 
                return true;
            }
            finally { if (stream != null) stream.Close(); }
            //file is not locked
            return false;
        }
    }
}
