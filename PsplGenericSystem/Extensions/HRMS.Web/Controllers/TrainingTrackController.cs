using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Web.ViewModels;
using HRMS.Service.Interfaces;
using HRMS.Web.Helper;
using System.Data;
using HRMS.Service.Models.ExtensionProc;
using System.Data.Entity;
using HRMS.Common.Enums;
using System.Configuration;
using System.Web.Security;
using System.Globalization;
using Newtonsoft.Json;

namespace HRMS.Web.Controllers
{
    public class TrainingTrackController : Controller
    {
        #region Class Level Variables and constructor
        private readonly ITrainingTrackRepository _trainingTrackRepository;
        private readonly ITrainingClassRepository _trainingClassRepository;
        public TrainingTrackController(ITrainingTrackRepository trainingTrackRepository, ITrainingClassRepository trainingClassRepository)
        {
            _trainingTrackRepository = trainingTrackRepository;
            _trainingClassRepository = trainingClassRepository;
        }
        #endregion

        // GET: /TrainingTrack/AddTrainingTrack
        [Authorize]
        public ActionResult AddTrainingTrack()
        {
            int trainingTrackId = Convert.ToInt32(Request.QueryString["TrainingTrackId"]);
            TrainingTrack trainingTrackObj = new TrainingTrack();
            TrainingTrackFormModel trainingTrackFormModelObj = new TrainingTrackFormModel();
            trainingTrackFormModelObj.TrainingTrackClassList = _trainingTrackRepository.SelectAllTrainingTrackClass();
            if (trainingTrackId > 0)
                trainingTrackFormModelObj.TrainingTrack = _trainingTrackRepository.SelectTrainingTrackById(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), trainingTrackId);
            else
                trainingTrackFormModelObj.TrainingTrack = trainingTrackObj;
            trainingTrackFormModelObj.TrainingClassList = _trainingClassRepository.SelectAllTrainingClass(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(trainingTrackFormModelObj);
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddTrainingTrack(TrainingTrackFormModel trainingTrackFormModelObj)
        {
            List<ExtendedStoredProcedures.UdtTrainingClassIds> lstUdtTrainingClassIds = new List<ExtendedStoredProcedures.UdtTrainingClassIds>();

            bool result = false;
            var trainingTrackObj = _trainingTrackRepository.SelectTrainingTrackById(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), trainingTrackFormModelObj.TrainingTrack.TrainingTrackId);

            if (trainingTrackObj == null)
            {
                trainingTrackObj = new TrainingTrack();
                trainingTrackObj.TrainingTrackId = 0;
            }
            var trainingTrackClassList = _trainingTrackRepository.SelectAllTrainingTrackClass();
            if (trainingTrackFormModelObj.TrainingTrack.classIds != null)
            {
                string[] trainingClassId = trainingTrackFormModelObj.TrainingTrack.classIds.Split(',');

                if (trainingClassId != null)
                    foreach (var id in trainingClassId)
                    {
                        ExtendedStoredProcedures.UdtTrainingClassIds obj = new ExtendedStoredProcedures.UdtTrainingClassIds();
                        obj.TrainingClassId = Convert.ToInt32(id);
                        obj.TrainingTrackId = trainingTrackObj.TrainingTrackId;
                        lstUdtTrainingClassIds.Add(obj);
                    }
            }


            //var query = from x in lstUdtTrainingClassIds
            //             join y in trainingTrackClassList
            //               on x.TrainingTrackId equals y.TrainingTrackId into sb
            //               from sublist in sb.DefaultIfEmpty()
            //            select new { TrainingTrackClassId = (sublist == null ? 0 : sublist.TrainingTrackClassId), TrainingTrackId = sublist.TrainingTrackId, TrainingClassId = sublist.TrainingClassId };



            trainingTrackFormModelObj.TrainingTrack.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            trainingTrackFormModelObj.TrainingTrack.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            if (trainingTrackFormModelObj.TrainingTrack.TrainingTrackId > 0)
            {
                result = _trainingTrackRepository.UpdateTrainingTrack(trainingTrackFormModelObj.TrainingTrack, lstUdtTrainingClassIds);
            }
            else
                result = _trainingTrackRepository.AddTrainingTrack(trainingTrackFormModelObj.TrainingTrack, lstUdtTrainingClassIds);
            if (result)
                return RedirectToAction("SelectAllTrainingTrack");


            return View(trainingTrackFormModelObj);
        }
        [Authorize]
        public ActionResult SelectAllTrainingTrack()
        {
            TrainingTrackFormModel trainingTrackFormModelObj = new TrainingTrackFormModel();
            trainingTrackFormModelObj.TrainingTrackList = _trainingTrackRepository.SelectAllTrainingTrack(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            trainingTrackFormModelObj.TrainingClassList = _trainingClassRepository.SelectAllTrainingClass(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            trainingTrackFormModelObj.TrainingTrackClassList = _trainingTrackRepository.SelectAllTrainingTrackClass();
            return View(trainingTrackFormModelObj);
        }

        [HttpPost]
        [Authorize]
        public bool DeleteTrainingTrack(string trackIds)
        {
            if (trackIds != null)
            {
                foreach (var trackId in trackIds.Split(','))
                {
                    var deleteTrack = _trainingTrackRepository.DeletTrainingTrack(Int32.Parse(GlobalsVariables.CurrentCompanyId), Int32.Parse(trackId));
                }
            }
            return true;
        }
    }
}