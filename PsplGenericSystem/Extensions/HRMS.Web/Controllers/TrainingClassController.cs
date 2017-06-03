using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;
using HRMS.Web.Helper;
using System.Configuration;
using HRMS.Common.Enums;

namespace HRMS.Web.Controllers
{
    public class TrainingClassController : Controller
    {
        #region Class Level Variables and constructor
        private readonly ITrainingClassRepository _trainingClassRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        private readonly ITrainingClassResourcesRepository _trainingClassResourcesRepository;
        private readonly ITrainingClassScheduleRepository _trainingClassScheduleRepository;
        public TrainingClassController(ITrainingClassRepository trainingClassRepository, ITrainingClassResourcesRepository trainingClassResourcesRepository, IFilesDBRepository filesDBRepository, ITrainingClassScheduleRepository trainingClassScheduleRepository)
        {
            _trainingClassScheduleRepository = trainingClassScheduleRepository;
            _trainingClassRepository = trainingClassRepository;
            _filesDBRepository = filesDBRepository;
            _trainingClassResourcesRepository = trainingClassResourcesRepository;
        }
        #endregion
        /// <summary>
        /// View to add new training class related to training tracks
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddNewClass()
        {
            int trainingClassId =Convert.ToInt32(Request.QueryString["TrainingClassId"]);
            TrainingClass trainingClassObj = new TrainingClass();
            if (trainingClassId >0)
            {
               trainingClassObj= _trainingClassRepository.SelectTrainingclassById(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), trainingClassId);
            }
            return View(trainingClassObj);
        }
        /// <summary>
        /// View to add new training class related to training tracks
        /// </summary>
        /// <param name="trainingClassObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddNewClass(TrainingClass trainingClassObj)
        {
            int fileId = 0;
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
                filesDBobj.FileName = filename;
                filesDBobj.FileExtension = extension;
                filesDBobj.FileBytes = bytesInStream;
                filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                filesDBobj.FileType = GeneralEnum.FileType.TrainingClassImage.ToString();
                fileId = _filesDBRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.CurrentUserId));
            }
            trainingClassObj.TrainingClassImage = fileId;
            trainingClassObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            trainingClassObj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            bool result=false;
            if(trainingClassObj.TrainingClassId==0)
           result=_trainingClassRepository.addTrainingClass(trainingClassObj);
            else
            {
                result = _trainingClassRepository.UpdateTrainingClass(trainingClassObj);
            }
            return RedirectToAction("SelectAllClasses");
        }
        /// <summary>
        /// View to show all the training classes
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllClasses()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<TrainingClassSchedule> lstTrainingClassSchedule = _trainingClassScheduleRepository.GetTrainingClassSchedules(companyId);
            List<TrainingClassResource> lstTrainingClassResources=  _trainingClassResourcesRepository.GetTrainingClassResources(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            List<TrainingClass> lstTrainingClass = new List<TrainingClass>();
            lstTrainingClass=_trainingClassRepository.SelectAllTrainingClass(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var scheduleResult = from x in lstTrainingClassSchedule
                         join y in lstTrainingClass on x.TrainingClassId equals y.TrainingClassId
                         where x.TrainingClassId == y.TrainingClassId
                         select x.TrainingClassId;
            var resourceResult = from x in lstTrainingClassResources
                                 join y in lstTrainingClass on x.TrainingClassId equals y.TrainingClassId
                                 where x.TrainingClassId == y.TrainingClassId
                                 select x.TrainingClassId;

            foreach (var id in scheduleResult)
            {
                foreach (var item in lstTrainingClass.Where(w => w.TrainingClassId == id))
                {
                    item.hasSchedule = true;
                }
            }

            foreach (var id in resourceResult)
            {
                foreach (var item in lstTrainingClass.Where(w => w.TrainingClassId == id))
                {
                    item.hasResource = true;
                }
            }
            return View(lstTrainingClass);
        }
        /// <summary>
        /// Action method to delete an existing record based on record Id
        /// </summary>
        /// <param name="classIds"></param>
        /// <returns></returns>
        [Authorize]
        public bool DeleteTrainingClass(string classIds)
        {
            if (classIds != null)
            {
                foreach (var trainingClassId in classIds.Split(','))
                {
                    var deleteTraingClass =
                        _trainingClassRepository.DeleteTrainingClass(Int32.Parse(trainingClassId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }

        
	}
}