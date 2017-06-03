using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;
using HRMS.Web.Helper;
using System.Configuration;
using HRMS.Common.Enums;
using HRMS.Service.Models.ExtensionProc;

namespace HRMS.Web.Controllers
{
    public class TrainingClassResourcesController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        private readonly ITrainingClassResourcesRepository _trainingClassResourcesRepository;
        public TrainingClassResourcesController(IUtilityRepository utilityRepository, IFilesDBRepository filesDBRepository, ITrainingClassResourcesRepository trainingClassResourcesRepository)
        {
            _utilityRepository = utilityRepository;
            _trainingClassResourcesRepository = trainingClassResourcesRepository;
            _filesDBRepository = filesDBRepository;
        }
        #endregion
       [HttpGet]
        public ActionResult TrainingClassResources()
        {
            int TrainingClassId = Convert.ToInt32(Request.QueryString["TrainingClassId"]);
            List<TrainingClassResource> lstTrainingClassResource = new List<TrainingClassResource>();
            if (TrainingClassId > 0)
                lstTrainingClassResource = _trainingClassResourcesRepository.GetTrainingClassResourcesByClassId(TrainingClassId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            TempData["TrainingClassId"] = TrainingClassId;
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var trainingClassResourceobj = new TrainingClassResource();
            trainingClassResourceobj.TrainingClassId = TrainingClassId;
          
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            return View(trainingClassResourceobj);
         
        }
       [HttpPost]
       public ActionResult TrainingClassResources(FormCollection fc)
       {
           int TrainingClassId = Convert.ToInt32(Request.QueryString["TrainingClassId"]);
           int fileId = 0;
            List<ExtendedStoredProcedures.UdtResourceIdTable> list=new List<ExtendedStoredProcedures.UdtResourceIdTable>();
           TrainingClassResource trainingClassResourceobj = new TrainingClassResource();
           trainingClassResourceobj.TrainingClassId = TrainingClassId;
           int CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
           int CurrentUserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
           String Filepath = ConfigurationManager.AppSettings["ScannedDocuments"];
           /* Add attachment file if exists */
           if ((Request.Files.Count > 0) && (Request.Files[0].ContentLength > 0))
           {
               string filename = System.IO.Path.GetFileName(Request.Files[0].FileName);
               FilesDB filesDBobj = new FilesDB();
               System.IO.Stream filestream = Request.Files[0].InputStream;
               byte[] bytesInStream = new byte[filestream.Length];
               filestream.Read(bytesInStream, 0, bytesInStream.Length);
               string extension = System.IO.Path.GetExtension(filename);
               filesDBobj.FileName = filename.ToString() ;
               filesDBobj.FileExtension = extension;
               filesDBobj.FileBytes = bytesInStream;
               filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
               filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
               filesDBobj.FileType = GeneralEnum.FileType.TrainingClassImage.ToString();
                 fileId = _filesDBRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.CurrentUserId));

                 
             ExtendedStoredProcedures.UdtResourceIdTable obj=new ExtendedStoredProcedures.UdtResourceIdTable();
                   obj.Filename=filename.ToString();
                   obj.ContentType=extension;
                   obj.Attachment = fileId ;
                   //obj.TrainingClassId =Convert.ToInt32(TempData["TrainingClassId"]);
                   list.Add(obj);
                   
               }
               

  
           trainingClassResourceobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);

         //  var TrainingClassId = TempData["TrainingClassId"];
           TempData["TrainingClassId"] = TrainingClassId;
         ////  trainingClassResourceobj.Attachment =Convert.ToByte(fc[0].ToString());
         //  trainingClassResourceobj.ContentType = fc[0].ToString();
         //  trainingClassResourceobj.FileName = fc[1].ToString();
         ////  List<ExtendedStoredProcedures.UdtResourceIdTable> list=new List<ExtendedStoredProcedures.UdtResourceIdTable>();
           //foreach(var obj in list)
           //{
           //    ExtendedStoredProcedures.UdtResourceIdTable obj=new ExtendedStoredProcedures.UdtResourceIdTable();
           //    obj.Filename=fileId.ToString();
           //    obj.ContentType=extension,
               
           //}
          
           //if (rtnTrainingClassResourceId != -1)
           //{
               //  int Attachment = Convert.ToInt32(fc[0].ToString());
                 //string ContentType = fc[0].ToString();
                 //string FileName = fc[1].ToString();

            //   DataTable dt = ClassResources();

          //     //Default row Bind
          //     DataRow defaultRow = dt.NewRow();
          ////     defaultRow["Attachment"] = Attachment.ToString();
          //     defaultRow["ContentType"] = ContentType.ToString();
          //     defaultRow["FileName"] = FileName;
          //  //   defaultRow["CompanyID"] = CompanyId;
          //     defaultRow["CreatedBy"] = CurrentUserId;
          //     defaultRow["CreatedOn"] = DateTime.UtcNow;
          //     dt.Rows.Add(defaultRow);

               //Loop Grid Logic


               //int i = 0;
               //if (fc.Count > 1)
               //{

                 ////  string[] strAttachment = fc[3].Split(',');
                 //  string strContentType = Convert.ToString(fc[0].Split(','));
                 //  string strFileName = Convert.ToString(fc[1].Split(','));


                   //foreach (var stFileName in strFileName)
                   //{
                   //    //DataRow row = dt.NewRow();
                   //    //row["Attachment"] = strAttachment[i].ToString();
                   //    //row["ContentType"] = strContentType.ToString();
                   //    //row["FileName"] = strFileName.ToString(); ;
                   //    //row["CompanyID"] = CompanyId;
                   //    //row["CreatedBy"] = CurrentUserId;
                   //    //row["CreatedOn"] = DateTime.UtcNow; ;

                   //    //dt.Rows.Add(row);
                   //    //dt.AcceptChanges();
                   //    ExtendedStoredProcedures.UdtResourceIdTable obj=new ExtendedStoredProcedures.UdtResourceIdTable();
                   //    obj.ContentType= strContentType.ToString();
                   //    obj.Filename=strFileName.ToString();
                   //    list.Add(obj);
                   //    i++;
                   //}
               //}
           _trainingClassResourcesRepository.AddTrainingResources(trainingClassResourceobj.CreatedBy, list);
          //   _trainingClassResourcesRepository.AddTrainingResources(GlobalsVariables.CurrentUserId, list);
               //Bulk Insert

             //  bool status = _trainingClassResourcesRepository.InsertTrainingClassResourcesContentBulk(dt);

           //}


           return RedirectToAction("SelectAllClasses");
       }

       public DataTable ClassResources()
       {
           DataTable dt = new DataTable();
           dt.Columns.Add("TrainingClassResourceId", typeof(Int32));
           dt.Columns.Add("FileName", typeof(string));
           dt.Columns.Add("Attachment", typeof(byte[]));
           dt.Columns.Add("ContentType", typeof(string));
           dt.Columns.Add("CreatedBy", typeof(int));
           dt.Columns.Add("CreatedOn", typeof(DateTime));

           return dt;
       }
         public ActionResult SelectAllTrainingClassResources()
       {
           List<TrainingClassResource> lstTrainingClassResources = new List<TrainingClassResource>();
           lstTrainingClassResources = _trainingClassResourcesRepository.GetTrainingClassResources(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
           return View(lstTrainingClassResources);
       }
	}
}


