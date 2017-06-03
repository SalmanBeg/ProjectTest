using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using System.Web.Security;
using HRMS.Web.Helper;
using System.Data;
using System.IO;
using System.Configuration;
using HRMS.Common.Enums;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;
using System.Drawing;
using iTextSharp.text;

namespace HRMS.Web.Controllers
{
    public class OnBoardingProfileController : Controller
    {
        #region Class Level Variables and constructor

        private readonly IConsentFormRepository _consentFormRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        private readonly IOnBoardingRepository _onBoardingRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IEmployeeSignRepository _employeeSignRepository;
        DataTable consentDocTable = new DataTable();
        private string Filepath = ConfigurationManager.AppSettings["scannedfilepath"];
        public OnBoardingProfileController(IConsentFormRepository consentFormRepository, IFilesDBRepository filesDBRepository
            , IOnBoardingRepository onBoardingRepository, IRegisteredUsersRepository registeredUsersRepository, IEmployeeSignRepository employeeSignRepository)
        {
            _consentFormRepository = consentFormRepository;
            _filesDBRepository = filesDBRepository;
            _onBoardingRepository = onBoardingRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _employeeSignRepository = employeeSignRepository;
        }
        #endregion
        /// <summary>
        /// View to show all the onboarding profile records in a company
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult SelectAllOnBoardingsbyCompanyId()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);

            List<OnBoarding> onBoardingobj = _onBoardingRepository.SelectAllOnBoardingByCompanyId(companyId);

            return View(onBoardingobj);
        }
        /// <summary>
        /// View to show the selected onbaording profile based on record Id
        /// </summary>
        /// <param name="onBoardingId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public List<OnBoarding> SelectOnBoardingByOnBoardingId(int onBoardingId)
        {
            return _onBoardingRepository.SelectOnBoardingByOnBoardingId(onBoardingId);
        }
        /// <summary>
        /// Retreiving consent files in an onboarding profile in a company
        /// </summary>
        /// <param name="onBoardingFormModelobj"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult ConsentFiles(OnBoardingFormModel onBoardingFormModelobj)
        {
            return PartialView(onBoardingFormModelobj);
        }
        /// <summary>
        /// View to add a new onboarding profile record with consent documents
        /// </summary>
        /// <param name="onBoardingFormModelobj"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult AddOnBoarding(OnBoardingFormModel onBoardingFormModelobj)
        {
            var onBoardingId = Request.QueryString["OnBoardingId"];
            if (Convert.ToInt32(onBoardingId) == 0)
                onBoardingFormModelobj.ConsentForm = _consentFormRepository.SelectAllConsentFormByCompanyId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            else
                onBoardingFormModelobj.ConsentForm = _consentFormRepository.SelectConsentFormsByOnBoardingId(Convert.ToInt32(onBoardingId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(onBoardingFormModelobj);
        }
        /// <summary>
        /// View to add a new onboarding profile record with consent documents(POST Method)
        /// </summary>
        /// <param name="consentIds"></param>
        /// <param name="onBoardingName"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool AddOnBoarding(string consentIds, string onBoardingName)
        {
            var onBoardingFormModelobj = new OnBoardingFormModel();
            onBoardingFormModelobj.OnBoarding.Active = true;
            bool success = false;
            if (consentIds != null)
            {
                var conSentList = new List<ConsentForms>();
                //TStructure();
                foreach (var consentId in consentIds.Split(','))
                {
                    var consentobj = new ConsentForms
                    {
                        ConsentFormId = Int32.Parse(consentId)
                    };
                    conSentList.Add(consentobj);
                    // DynamicTable(Int32.Parse(consentId));
                }


                onBoardingFormModelobj.OnBoarding.OnBoardingName = onBoardingName;
                onBoardingFormModelobj.OnBoarding.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);


                if (conSentList.Count > 0)
                {
                    success = _onBoardingRepository.CreateOnBoarding(onBoardingFormModelobj.OnBoarding, conSentList);
                }
            }
            return success;
        }

        public void TStructure()
        {
            if (consentDocTable.Columns.Count == 0)
            {
                consentDocTable.Columns.Add("ConsentdocId", typeof(System.Int32));
            }
        }
        /// <summary>
        /// Function to add new row to existing consent record
        /// </summary>
        /// <param name="consentdocId"></param>
        public void DynamicTable(int consentdocId)
        {
            DataRow dr;
            dr = consentDocTable.NewRow();
            dr["ConsentdocId"] = consentdocId;
            consentDocTable.Rows.Add(dr);
        }
        /// <summary>
        /// View to update existing record of consent document record
        /// </summary>
        /// <param name="consentFormId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult UpdateConsentFormById(int consentFormId)
        {
            var id = Request.QueryString["ConsentFormId"];

            List<ConsentForms> consentFormList = _consentFormRepository.SelectConsentFormById(consentFormId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            var consentFormobj = new ConsentForms
            {
                ConsentFormId = consentFormList[0].ConsentFormId,
                Description = consentFormList[0].Description,
                Active = consentFormList[0].Active,
                DisplayDocInConsent = consentFormList[0].DisplayDocInConsent,
                EnableUploadLink = consentFormList[0].EnableUploadLink,
                ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId)
            };
            return PartialView("ConsentFiles", consentFormobj);
        }
        /// <summary>
        /// View to update existing record of consent document record(POST Method)
        /// </summary>
        /// <param name="consentFormobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool UpdateConsentFormById(ConsentForms consentFormobj)
        {
            bool success = _consentFormRepository.UpdateConsentFormById(consentFormobj);
            return success;
        }

        /// <summary>
        /// Method to return to consent name
        /// </summary>
        /// <param name="onBoardingId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public string SelectConsentFormsByOnBoardingId(int onBoardingId)
        {
            var consertFormList = _consentFormRepository.SelectConsentFormsByOnBoardingId(onBoardingId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            string consentnamestr = "", consentname;
            for (int i = 0; i < consertFormList.Count; i++)
            {
                consentname = consertFormList[i].Description;
                consentnamestr += consentname + ',';
            }

            return consentnamestr;
        }
        [Authorize]
        public ActionResult _ConsentFormsView()
        {
            var consentFormsFormModelList = new List<ConsentFormsFormModel>();
            var consentFormList = _consentFormRepository.SelectConsentFormsByUserId(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            // var employeeSignList =  _employeeSignRepository.GetAllEmployeeSignByUserId(Convert.ToInt32(GlobalsVariables.SelectedUserId));
            if (consentFormList != null)
            {
                foreach (var consentformobj in consentFormList)
                {
                    var consentFormsFormModelobj = new ConsentFormsFormModel();
                    consentFormsFormModelobj.ConsentFormId = consentformobj.ConsentFormId;
                    consentFormsFormModelobj.AttachmentFileId = consentformobj.AttachmentFileId;
                    consentFormsFormModelobj.EmployeeSignId = Convert.ToInt32(consentformobj.EmployeeSignId);
                    consentFormsFormModelobj.DocumentName = consentformobj.DocumentName;
                    consentFormsFormModelobj.EmployeeSignList = _employeeSignRepository.GetAllEmployeeSignByUserId(Convert.ToInt32(GlobalsVariables.SelectedUserId));

                    consentFormsFormModelList.Add(consentFormsFormModelobj);
                }
                if (GlobalsVariables.IsHireWizard != "true")
                    _registeredUsersRepository.UpdateHireApprovalSetup("ConsentForms", Convert.ToInt32(GlobalsVariables.SelectedUserId));
                return PartialView(consentFormsFormModelList);
            }
            else
                return PartialView();
        }
        /// <summary>
        /// Functi to save e-signature id for an individaul consent form
        /// </summary>
        /// <param name="signId"></param>
        [HttpPost]
        [Authorize]
        public void signConsentForm(int signId, int consentFormId)
        {
            ConsentForms consentFormsObj = new ConsentForms();
            consentFormsObj.ConsentFormId = consentFormId;
            consentFormsObj.EmployeeSignId = signId;
            consentFormsObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var result = _consentFormRepository.UpdateEmployeeSignId(consentFormsObj);

        }
        public string getSignedImage(int signId)
        {
            EmployeeSign employeesignObj = _employeeSignRepository.GetEmployeeSign(signId);
            string signBytes = "";
            if (employeesignObj != null)
            {
                var imagedata = _filesDBRepository.SelectFileByFileDBId(Convert.ToInt32(employeesignObj.EmployeeSignFileId));
                var thePictureDataAsBytes = imagedata[0].FileBytes;
                var contentdata = new FileContentResult(thePictureDataAsBytes, "image/jpeg");
                var contentdatastring = Convert.ToBase64String(contentdata.FileContents);
                signBytes = "data:image/png;base64," + Convert.ToBase64String(contentdata.FileContents);
            }
            return signBytes;
        }
        /// <summary>
        /// Method to return the file content result depending on fileid
        /// </summary>
        /// <param name="fileid"></param>
        /// <param name="fileMode"></param>
        /// <returns></returns>
        [Authorize]
        public FileContentResult Showfile(int fileid, string fileMode)
        {
            var fileDetails = _filesDBRepository.SelectFileByFileDBId(fileid);
            var filebytes = fileDetails[0].FileBytes;
            if (filebytes != null)
            {
                if (fileDetails[0].FileExtension.ToLower() == ".png" || fileDetails[0].FileExtension.ToLower() == ".jpeg" || fileDetails[0].FileExtension.ToLower() == ".jpg" || fileDetails[0].FileExtension.ToLower() == ".gif")
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
                else if (fileDetails[0].FileExtension.ToLower() == ".bmp")
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
                        string filename = fileDetails[0].FileName;
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
                    string filename = fileDetails[0].FileName;
                    filebytes = Extract_Pdf_Pages_As_Png(filename, filebytes);
                    //if (filebytes != null)
                    //    filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 100, 100);
                    return new FileContentResult(filebytes, ReturnExtension(".png"));
                }

                else if (fileDetails[0].FileExtension.ToLower() == ".txt")
                {
                    filebytes = BitmapUtils.ResizeImageInByteArray(filebytes, 100, 100);
                    return new FileContentResult(filebytes, ReturnExtension(".png"));
                }
            }
            //return array of bytes as the image's data to action's response. We set the image's content mime type to image/jpeg
            return null;
        }

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
            var outputfilename = System.IO.Path.GetFileNameWithoutExtension(sourcepath) + ".pdf";
            var outputPath = rootpath + outputfilename;
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
        /// <summary>
        /// Function to delete an onboarding record based on recordId
        /// </summary>
        /// <param name="onBoardingIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteOnBoarding(string onBoardingIds)
        {
            if (!string.IsNullOrEmpty(onBoardingIds))
            {
                foreach (var onBoardingId in onBoardingIds.Split(','))
                {
                    var deleteOnBoarding = _onBoardingRepository.DeleteOnBoarding(Convert.ToInt32(onBoardingId));
                }
            }
            return true;
        }
        /// <summary>
        /// Function to delete an consentformId record based on recordId
        /// </summary>
        /// <param name="consentFormIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteConsentForm(string consentFormIds)
        {
            if (consentFormIds != null)
            {
                foreach (var consentFormId in consentFormIds.Split(','))
                {
                    var deleteOnBoarding = _onBoardingRepository.DeleteConsentForm(Convert.ToInt32(consentFormId));
                }
            }
            return true;
        }
        /// <summary>
        /// Method to show consent forms with e-signature
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult _SelectConsentFormWithESignById()
        {
            int signId = Convert.ToInt32(TempData["SignImageId"]);
            int consentDocumentId = Convert.ToInt32(TempData["consentDocumentId"]);
            TempData["consentDocument"] = Showfile(consentDocumentId, "normal");
            TempData["consentSignImage"] = Showfile(signId, "normal");
            return View();
        }

        /// <summary>
        /// Method to convert image to pdf
        /// </summary>
        /// <param name="byteTextFromCanvas"></param>
        /// <param name="consentDocumentId"></param>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        public void CanvastoPDF(string byteTextFromCanvas, string consentDocumentId)
        {
            var bytesInStream = System.Convert.FromBase64String(byteTextFromCanvas);
            var filepath = ConfigurationManager.AppSettings["scannedfilepath"];
            var timings = DateTime.Now.ToString("ddMMMyyyyHHmmss");
            var filename = "SignedConsentForm" + timings + ".pdf";
            var path = Server.MapPath(filepath) + filename;
            bool pdfdone = ByteArrayToFile(path, bytesInStream);

            string fileNamewithExt = Path.GetFileName(path);
            string extension = Path.GetExtension(path);
            int fileId = 0;
            var filesDBobj = new FilesDB();
            filesDBobj.FileName = fileNamewithExt;
            filesDBobj.FileExtension = extension;
            filesDBobj.FileBytes = bytesInStream;

            var employeeSignobj = new EmployeeSign();
            filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            filesDBobj.FileType = GeneralEnum.FileType.SignedConsentDocument.ToString();
            fileId = _filesDBRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.SelectedUserId));
            //TempData["SignImageId"] = fileId;
            //TempData["consentDocumentId"] = ConsentDocumentId;
            employeeSignobj.UserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            employeeSignobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            employeeSignobj.Name = filename;
            employeeSignobj.EmployeeSignFileId = fileId;
            var success = _employeeSignRepository.CreateEmployeeSign(employeeSignobj);
            var fileDetails = _filesDBRepository.SelectFileByFileDBId(Convert.ToInt32(consentDocumentId));
            var filebytes = fileDetails[0].FileBytes;
            TempData["signedDocument"] = "data:image/jpg;base64," + Convert.ToBase64String(filebytes);
        }

        /// <summary>
        /// Function to convert byte array to file content in hard drive
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                // Open file for reading
                var fileStream =
                   new System.IO.FileStream(fileName, FileMode.Create,
                                            System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                fileStream.Write(byteArray, 0, byteArray.Length);

                // close file stream
                fileStream.Close();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        /// <summary>
        /// Function to merge the files using sign image for pdf files
        /// </summary>
        /// <param name="byteTextFromCanvas"></param>
        /// <param name="signImage"></param>
        /// <returns></returns>
        public byte[] MergeFiles(string byteTextFromCanvas, string signImage)
        {
            byte[] bytesInStream = System.Convert.FromBase64String(byteTextFromCanvas);
            var imagebase64String = signImage.Replace(@"data:image/png;base64,", "");
            byte[] signBytesInStream = System.Convert.FromBase64String(imagebase64String);
            var pdfReader = new PdfReader(bytesInStream);
            using (var ms = new MemoryStream())
            {
                using (var stamp = new PdfStamper(pdfReader, ms))
                {
                    var filepath = ConfigurationManager.AppSettings["scannedfilepath"];
                    System.Drawing.Image image;
                    using (var mst = new MemoryStream(signBytesInStream))
                    {
                        image = System.Drawing.Image.FromStream(mst);
                    }
                    var size = pdfReader.GetPageSize(1);
                    var page = pdfReader.NumberOfPages + 1;
                    stamp.InsertPage(page, pdfReader.GetPageSize(1));
                    var format = image.PixelFormat == PixelFormat.Format1bppIndexed
                                         || image.PixelFormat == PixelFormat.Format4bppIndexed
                                         || image.PixelFormat == PixelFormat.Format8bppIndexed
                                             ? ImageFormat.Tiff
                                             : ImageFormat.Jpeg;
                    var pdfImage = iTextSharp.text.Image.GetInstance(image, format);
                    pdfImage.Alignment = Element.ALIGN_CENTER;
                    pdfImage.SetAbsolutePosition(0, size.Height - pdfImage.Height);
                    pdfImage.ScaleToFit(size.Width, size.Height);
                    stamp.GetOverContent(page).AddImage(pdfImage);
                }
                var imageData = ms.GetBuffer();
                TempData["mergedImage"] = "data:image/jpg;base64," + Convert.ToBase64String(imageData);
                ms.Flush();
                return ms.GetBuffer();
            }
        }

        //To get image file from filesdb
        //public void ShowPicture(int fileId)
        //{ //transform the picture's data from string to an array of bytes
        //    List<FilesDB> thePictureDataAsBytes = _filesDBRepository.SelectFileByFileDBId(fileId);
        //    var contentdata = new FileContentResult(thePictureDataAsBytes[0].FileBytes, "image/jpeg");
        //    var contentdatastring = Convert.ToBase64String(contentdata.FileContents);
        //    TempData["SignImage"] = "data:image/png;base64," + Convert.ToBase64String(contentdata.FileContents);
        //}
    }
}
