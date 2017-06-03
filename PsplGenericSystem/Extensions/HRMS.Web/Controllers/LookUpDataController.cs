using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using HRMS.Data;
//using HRMS.BusinessLayer;
using HRMS.Web.Helper;
using HRMS.Common.Helpers;
using HRMS.Web.ViewModels;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;

namespace HRMS.Web.Controllers
{
    public class LookUpDataController : Controller
    {
        #region Class Level Variables and constructor

        private readonly ILookUpTableRepository _lookUpTablerepo;

        public LookUpDataController(ILookUpTableRepository lookUpTablerepo)
        {
            _lookUpTablerepo = lookUpTablerepo;
        }

        protected ILookUpTableRepository LookUpTableRepository
        {
            get { return _lookUpTablerepo; }
        }

        #endregion
        /// <summary>
        /// View to show all the look up data entities
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult CreateLookUpData(string TableName)
        {
            var lookupFormModelobj = new LookupFormModel();
            if (TableName == null)
                TableName = "Department";
            lookupFormModelobj.TableName = TableName;
            string fullTableName = getTableWithSchema(TableName);
            lookupFormModelobj.LookUpDataEntitylist = _lookUpTablerepo.SelectLookUpData(fullTableName, Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).ToList();
            return View(lookupFormModelobj);
        }
        /// <summary>
        /// Partial view to add a new record to selected master table record
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddLookUpPartialView()
        {
            string tableName = Request.QueryString["TableName"];
            var LookUpDataObj = new LookUpDataEntity();
            if (tableName != null)
                LookUpDataObj.TableName = tableName;
            LookUpDataObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            return PartialView(LookUpDataObj);
        }
        /// <summary>
        ///  Partial view to add a new record to selected master table record(POST Method)
        /// </summary>
        /// <param name="lookUpDataEntityObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddLookUpPartialView(LookUpDataEntity lookUpDataEntityObj)
        {
            string tableName;
            if (!string.IsNullOrEmpty(Request.QueryString["TableName"]))
                tableName = getTableWithSchema(Request.QueryString["TableName"]);
            else
            {
                tableName = lookUpDataEntityObj.TableName;
            }

            lookUpDataEntityObj.Status = true;
            bool success = _lookUpTablerepo.AddLookUpData(lookUpDataEntityObj, tableName);

            return RedirectToAction("CreateLookUpData", new { @TableName = Request.QueryString["TableName"] });

        }
        /// <summary>
        /// Partial view to update existing record based on record Id and table name
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult UpdateLookUpPartialView(string TableName)
        {
            int PrimaryId = Convert.ToInt32(Request.QueryString["primaryColumnId"]);
            string fullTableName = getTableWithSchema(TableName);
            var LookUpDataObj = _lookUpTablerepo.SelectLookUpDataById(fullTableName, Convert.ToInt32(GlobalsVariables.CurrentCompanyId), PrimaryId);

            LookUpDataObj.TableName = TableName;
            return PartialView(LookUpDataObj);
        }
        /// <summary>
        /// Partial view to update existing record based on record Id and table name
        /// </summary>
        /// <param name="lookUpDataEntityObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult UpdateLookUpPartialView(LookUpDataEntity lookUpDataEntityObj)
        {
            string tableName = getTableWithSchema(Request.QueryString["TableName"]);

            bool success = _lookUpTablerepo.UpdateLookUpData(lookUpDataEntityObj, tableName);

            return RedirectToAction("CreateLookUpData", new { @TableName = Request.QueryString["TableName"] });

        }
        /// <summary>
        /// Returns table name of an schema with the table name supplied
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        [Authorize]
        public string getTableWithSchema(string tableName)
        {
            string tableNameWithSchema = LocalizedStrings.Department;
            switch (tableName)
            {
                case "Department":
                    tableNameWithSchema = LocalizedStrings.Department;
                    break;
                case "Division":
                    tableNameWithSchema = LocalizedStrings.Division;
                    break;
                case "ChangeReason":
                    tableNameWithSchema = LocalizedStrings.ChangeReason;
                    break;
                case "EmploymentStatus":
                    tableNameWithSchema = LocalizedStrings.EmploymentStatus;
                    break;
                case "EmploymentTypes":
                    tableNameWithSchema = LocalizedStrings.EmploymentTypes;
                    break;
                case "Location":
                    tableNameWithSchema = LocalizedStrings.Location;
                    break;
                case "Position":
                    tableNameWithSchema = LocalizedStrings.Position;
                    break;
                case "JobCategory":
                    tableNameWithSchema = LocalizedStrings.JobCategory;
                    break;
                case "TerminationReason":
                    tableNameWithSchema = LocalizedStrings.TerminationReason;
                    break;
                case "FLSAStatus":
                    tableNameWithSchema = LocalizedStrings.FLSAStatus;
                    break;
                case "UnionType":
                    tableNameWithSchema = LocalizedStrings.UnionType;
                    break;
                case "Relationship":
                    tableNameWithSchema = LocalizedStrings.Relationship;
                    break;
                case "FederalBlock":
                    tableNameWithSchema = LocalizedStrings.FederalBlock;
                    break;
                case "SSMedBlock":
                    tableNameWithSchema = LocalizedStrings.SSMedBlock;
                    break;
                case "WithholdingStatus":
                    tableNameWithSchema = LocalizedStrings.WithholdingStatus;
                    break;
                case "TaxBlock":
                    tableNameWithSchema = LocalizedStrings.TaxBlock;
                    break;
                case "SUISDIBlock":
                    tableNameWithSchema = LocalizedStrings.SUISDIBlock;
                    break;
                case "SchoolDistrict":
                    tableNameWithSchema = LocalizedStrings.SchoolDistrict;
                    break;
                case "SchoolBlock":
                    tableNameWithSchema = LocalizedStrings.SchoolBlock;
                    break;
                case "PayType":
                    tableNameWithSchema = LocalizedStrings.PayType;
                    break;
                case "PayGrade":
                    tableNameWithSchema = LocalizedStrings.PayGrade;
                    break;
                case "ClaimType":
                    tableNameWithSchema = LocalizedStrings.ClaimType;
                    break;
                case "OutCome":
                    tableNameWithSchema = LocalizedStrings.OutCome;
                    break;
                case "RecruitingProfile":
                    tableNameWithSchema = LocalizedStrings.RecruitingProfile;
                    break;
                case "TrainingTracks":
                    tableNameWithSchema = LocalizedStrings.TrainingTracks;
                    break;
                case "WorkProfile":
                    tableNameWithSchema = LocalizedStrings.WorkProfile;
                    break;
                case "WorkersCompCode":
                    tableNameWithSchema = LocalizedStrings.WorkersCompCode;
                    break;
                case "ContractStatus":
                    tableNameWithSchema = LocalizedStrings.ContractStatus;
                    break;
                case "DegreeLevel":
                    tableNameWithSchema = LocalizedStrings.DegreeLevel;
                    break;
                case "HonoraryRecognition":
                    tableNameWithSchema = LocalizedStrings.HonoraryRecognition;
                    break;
                case "Graduated":
                    tableNameWithSchema = LocalizedStrings.Graduated;
                    break;
                case "CertificationLicenseType":
                    tableNameWithSchema = LocalizedStrings.CertificationLicenseType;
                    break;
                case "Endorsements":
                    tableNameWithSchema = LocalizedStrings.Endorsements;
                    break;
                case "CertificationLicenseAreas":
                    tableNameWithSchema = LocalizedStrings.CertificationLicenseAreas;
                    break;
                case "CertificationLicenseSchool":
                    tableNameWithSchema = LocalizedStrings.CertificationLicenseSchool;
                    break;
                case "CertificationLicenseJobAssignment":
                    tableNameWithSchema = LocalizedStrings.CertificationLicenseJobAssignment;
                    break;
                case "PayFrequency":
                    tableNameWithSchema = LocalizedStrings.PayFrequency;
                    break;
                case "CertificationLicenseCertification":
                    tableNameWithSchema = LocalizedStrings.CertificationLicenseCertification;
                    break;
                case "DocumentCategory":
                    tableNameWithSchema = LocalizedStrings.DocumentCategory;
                    break;
                case "PayStatus":
                    tableNameWithSchema = LocalizedStrings.PayStatus;
                    break;
                case "WageUnit":
                    tableNameWithSchema = LocalizedStrings.WageUnit;
                    break;
                case "WageType":
                    tableNameWithSchema = LocalizedStrings.WageType;
                    break;
                case "Priority":
                    tableNameWithSchema = LocalizedStrings.Priority;
                    break;
                case "Frequency":
                    tableNameWithSchema = LocalizedStrings.Frequency;
                    break;
                case "Essential":
                    tableNameWithSchema = LocalizedStrings.Essential;
                    break;
                case "Other":
                    tableNameWithSchema = LocalizedStrings.Other;
                    break;
                case "JobQualificationType":
                    tableNameWithSchema = LocalizedStrings.JobQualificationType;
                    break;
                case "QuestionType":
                    tableNameWithSchema = LocalizedStrings.QuestionType;
                    break;
                case "InterviewType":
                    tableNameWithSchema = LocalizedStrings.InterviewType;
                    break;
                case "InterviewRoom":
                    tableNameWithSchema = LocalizedStrings.InterviewRoom;
                    break;
                case "InterviewStatus":
                    tableNameWithSchema = LocalizedStrings.InterviewStatus;
                    break;
                case "DirectDepositAccountType":
                    tableNameWithSchema = LocalizedStrings.AccountType;
                    break;
                case "EmployeePayJobAssignment":
                    tableNameWithSchema = LocalizedStrings.JobAssignment;
                    break;
            }
            return tableNameWithSchema;
        }
        /// <summary>
        /// Action method to delete a record based on table name
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="recordIds"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteLookUpDataById(string tableName, string recordIds, int companyId)
        {
            /* Commented because should not delete record which are already in use. Need to add validation and uncomment*/
            string tableFullName = getTableWithSchema(tableName);
            if (recordIds != null)
            {
                foreach (var recordId in recordIds.Split(','))
                {
                    var deleteLookUp = _lookUpTablerepo.DeleteLookUpDataById(Convert.ToInt32(recordId), tableFullName,Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                }
            }

            return true;

        }
    }
}
