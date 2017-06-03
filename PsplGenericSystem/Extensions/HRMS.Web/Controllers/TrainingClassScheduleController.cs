using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;


namespace HRMS.Web.Controllers
{
    public class TrainingClassScheduleController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly ITrainingClassScheduleRepository _trainingClassScheduleRepository;
        private readonly ITrainingClassRepository _trainingClassRepository;
        public TrainingClassScheduleController(IUtilityRepository utilityRepository, ITrainingClassScheduleRepository trainingClassScheduleRepository, ITrainingClassRepository trainingClassRepository)
        {
            _utilityRepository = utilityRepository;
            _trainingClassScheduleRepository = trainingClassScheduleRepository;
            _trainingClassRepository = trainingClassRepository;
        }
        #endregion
        public ActionResult EnrollSchedule()
        {
            int trainingClassScheduleId = Convert.ToInt32(Request.QueryString["TrainingClassScheduleId"]);
            int trainingClassId = Convert.ToInt32(Request.QueryString["TrainingClassId"]);
           var trainingClassFormModelobj = new TrainingClassFormModel();
            trainingClassFormModelobj.TrainingClassSchedule = new TrainingClassSchedule();
            if (trainingClassScheduleId > 0)
                trainingClassFormModelobj.TrainingClassSchedule = _trainingClassScheduleRepository.GetTrainingClassSchedulesById(trainingClassScheduleId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            
            trainingClassFormModelobj.TrainingClassScheduleDate = new TrainingClassScheduleDate();
            if (trainingClassId > 0)
                trainingClassFormModelobj.TrainingClassSchedule.TrainingClassId = trainingClassId;
            return View(trainingClassFormModelobj);
           
        }
        [HttpPost]
        public ActionResult EnrollSchedule(FormCollection fc)
        {
            try
            {
                TrainingClassFormModel trainingClassFormModelobj = new TrainingClassFormModel();
                int CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                int CurrentUserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);


                TrainingClassSchedule trainingClassScheduleobj = new TrainingClassSchedule();
                TrainingClass trainingClassobj = new TrainingClass();
                trainingClassobj.TrainingClassName = _trainingClassRepository.addTrainingClass(trainingClassobj).ToString();
                //trainingClassobj.TrainingClassName = fc[0].ToString();
                trainingClassScheduleobj.EnrollmentStartDate = Convert.ToDateTime(fc[1]);
                trainingClassScheduleobj.EnrollmentEndDate = Convert.ToDateTime(fc[2]);
                trainingClassScheduleobj.CompanyId = CompanyId;
                trainingClassScheduleobj.TrainingClassId = Convert.ToInt32(fc[0]);
                TrainingClassScheduleDate trainingClassScheduleDateobj = new TrainingClassScheduleDate();
                trainingClassScheduleDateobj.StartDate = Convert.ToDateTime(fc[3].ToString());
                trainingClassScheduleDateobj.EndDate = Convert.ToDateTime(fc[4].ToString());
                trainingClassScheduleDateobj.Location = fc[5].ToString();
                trainingClassScheduleDateobj.MaximumClassSize = Convert.ToInt32(fc[6]);

                trainingClassScheduleDateobj.CompanyId = CompanyId;
                trainingClassScheduleDateobj.CreatedBy = CurrentUserId;
                trainingClassScheduleDateobj.ModifiedBy = CurrentUserId;
                trainingClassFormModelobj.TrainingClassScheduleDate = trainingClassScheduleDateobj;
                trainingClassFormModelobj.TrainingClassSchedule = trainingClassScheduleobj;
                ////  lstTrainingclass.EnrollmentStartDate;

                int rtnTrainingClassScheduleId = _trainingClassScheduleRepository.InsertAndUpdateTrainingSchedule(trainingClassFormModelobj.TrainingClassSchedule);
                if (rtnTrainingClassScheduleId != -1)
                {
                    string TrainingClassName = fc[1].ToString();
                    DateTime EnrollmentStartDate = Convert.ToDateTime(fc[2].ToString());
                    DateTime EnrollmentEndDate = Convert.ToDateTime(fc[3].ToString());              
                    DateTime StartDate = Convert.ToDateTime(fc[4].ToString());
                    DateTime EndDate = Convert.ToDateTime(fc[5].ToString());
                    string Location = fc[6].ToString();
                    int MaximumClassSize = Convert.ToInt32(fc[7]);

                    DataTable dt = EnrollScheduleSchema();

                    //Default row Bind
                    DataRow defaultRow = dt.NewRow();
                    // defaultRow["TrainingClassName"] = TrainingClassName.ToString();
                    defaultRow["TrainingClassName"] = TrainingClassName;
                    defaultRow["EnrollmentStartDate"] = EnrollmentStartDate;
                    defaultRow["EnrollmentEndDate"] = EnrollmentEndDate;
                    defaultRow["StartDate"] = StartDate;
                    defaultRow["EndDate"] = EndDate;
                    defaultRow["Location"] = Location;
                    defaultRow["MaximumClassSize"] = MaximumClassSize;
                    defaultRow["CompanyId"] = CompanyId;
                    defaultRow["CreatedBy"] = CurrentUserId;
                  
                    dt.Rows.Add(defaultRow);

                    //Loop Grid Logic


                    int i = 0;
                    if (fc.Count > 8)
                    {

                        string[] strClassName = fc[0].Split(',');
                        DateTime dteEnrollmentStartDate = Convert.ToDateTime(fc[1].Split(','));
                        DateTime dteEnrollmentEndDate = Convert.ToDateTime(fc[2].Split(','));

                        foreach (var ClassName in strClassName)
                        {
                            DataRow row = dt.NewRow();
                            row["TrainingClassName"] = ClassName.ToString();
                            row["EnrollmentStartDate"] = EnrollmentStartDate;
                            row["EnrollmentEndDate"] = EnrollmentEndDate;                       
                            row["StartDate"] = StartDate;
                            row["EndDate"] = EndDate;
                            row["Location"] = Location;
                            row["MaximumClassSize"] = MaximumClassSize;
                            row["CompanyID"] = CompanyId;
                            row["CreatedBy"] = CurrentUserId;
                         
                            dt.Rows.Add(row);
                            dt.AcceptChanges();
                            i++;
                        }
                    }


                    //  Bulk Insert

                      bool status = _trainingClassScheduleRepository.InsertTrainingClassScheduleContentBulk(dt);

                }
            }
            catch (Exception )
            {

            }
            return RedirectToAction("SelectAllTraingClassSchedule", new { @TrainingClassId=Convert.ToInt32(fc[0])});
        }
        public DataTable EnrollScheduleSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EnrollmentStartDate", typeof(DateTime));
            dt.Columns.Add("EnrollmentEndDate", typeof(DateTime));
            dt.Columns.Add("TrainingClassId", typeof(Int32));
            dt.Columns.Add("StartDate", typeof(DateTime));
            dt.Columns.Add("EndDate", typeof(DateTime));
            dt.Columns.Add("Location", typeof(string));
            dt.Columns.Add("MaximumClassSize", typeof(string));
            dt.Columns.Add("CompanyId", typeof(int));
            dt.Columns.Add("CreatedBy", typeof(int));
            return dt;
        }
        public ActionResult SelectAllTraingClassSchedule()
        {
            int trainingClassId = Convert.ToInt32(Request.QueryString["TrainingClassId"]);

            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<TrainingClassSchedule> trainingClassScheduleList =new List<TrainingClassSchedule>();
            if (trainingClassId > 0)
                trainingClassScheduleList = _trainingClassScheduleRepository.GetTrainingClassSchedulesByClassId(trainingClassId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            
            return View(trainingClassScheduleList);
        }
        public bool DeleteTrainingClassSchedule(string trainingClassScheduleIds)
        {
            if (trainingClassScheduleIds != null)
            {
                foreach (var trainingClassScheduleId in trainingClassScheduleIds.Split(','))
                {
                    var deleteTraingClassSchedule =
                        _trainingClassScheduleRepository.DeleteTrainingClassSchedule(Int32.Parse(trainingClassScheduleId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }

	}
}