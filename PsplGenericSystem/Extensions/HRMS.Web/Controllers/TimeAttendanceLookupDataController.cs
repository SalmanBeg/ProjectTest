using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using HRMS.Common.Helpers;
using HRMS.Web.Areas.HireWizard.Models;
using HRMS.Service.Interfaces;
using HRMS.Web.ViewModels;

namespace HRMS.Web.Controllers
{
    public class TimeAttendanceLookupDataController : Controller
    {
        #region Class Level Variables and constructor
        //  private readonly ITAMasterTableRepository _taMasterTableRepository;
        private readonly IRoundMinuteRepository _roundMinuteRepository;
        private readonly IRoundTypeRepository _roundTypeRepository;
         private readonly IOTPayTypeRepository _otPayTypeRepository;
         private readonly IOTPolicyTypeRepository _otPolicyTypeRepository;

        public TimeAttendanceLookupDataController(IRoundMinuteRepository roundMinuteRepository, IRoundTypeRepository roundTypeRepository,
        //ITAMasterTableRepository taMasterTableRepository, 
                                                 IOTPayTypeRepository otPayTypeRepository, IOTPolicyTypeRepository otPolicyTypeRepository)
        {
            // _taMasterTableRepository = taMasterTableRepository;
            _roundMinuteRepository = roundMinuteRepository;
            _roundTypeRepository = roundTypeRepository;
              _otPayTypeRepository = otPayTypeRepository;
             _otPolicyTypeRepository = otPolicyTypeRepository;

        }

        //protected ITAMasterTableRepository TAMasterTableRepository
        //{
        //    get { return _taMasterTableRepository; }
        //}
        protected IRoundMinuteRepository RoundMinuteRepository
        {
            get { return _roundMinuteRepository; }
        }
        protected IRoundTypeRepository RoundTypeRepository
        {
            get { return _roundTypeRepository; }
        }
        protected IOTPayTypeRepository OTPayTypeRepository
        {
            get { return _otPayTypeRepository; }
        }
        protected IOTPolicyTypeRepository OTPolicyTypeRepository
        {
            get { return _otPolicyTypeRepository; }
        }

        #endregion



        public ActionResult SelectTimeAttendanceLookupData(string TableName)
        {
            TimeAttendanceLookupDataFormModel TALookupdataFormModelobj = new TimeAttendanceLookupDataFormModel();
            if (TableName == null)
                TableName = "RoundType";

            List<TimeAttendanceLookupData> taLookupdataList = new List<TimeAttendanceLookupData>();

            switch (TableName)
            {
                case "RoundType":
                    List<RoundType> RoundType = _roundTypeRepository.SelectAllRoundTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

                    for (int i = 0; i < RoundType.Count; i++)
                    {
                        TimeAttendanceLookupData taLookupdataObj = new TimeAttendanceLookupData();
                        taLookupdataObj.Name = RoundType[i].Name;
                        taLookupdataObj.Value = RoundType[i].Value;
                        taLookupdataObj.Status = RoundType[i].Status;
                        taLookupdataList.Add(taLookupdataObj);
                    }

                    break;
                case "RoundMinutes":
                    List<RoundMinute> RoundMinute = _roundMinuteRepository.SelectAllRoundMinuteDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

                    for (int i = 0; i < RoundMinute.Count; i++)
                    {
                        TimeAttendanceLookupData taLookupdataObj = new TimeAttendanceLookupData();
                        taLookupdataObj.Name = RoundMinute[i].Name;
                        taLookupdataObj.Value = RoundMinute[i].Value;
                        taLookupdataObj.Status = RoundMinute[i].Status;
                        taLookupdataList.Add(taLookupdataObj);
                    }
                    break;
                case "OTPolicyType":
                    List<OTPolicyType> OTPolicyType = _otPolicyTypeRepository.SelectAllOTPolicyTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

                    for (int i = 0; i < OTPolicyType.Count; i++)
                    {
                        TimeAttendanceLookupData taLookupdataObj = new TimeAttendanceLookupData();
                        taLookupdataObj.Name = OTPolicyType[i].Name;
                        taLookupdataObj.Value = OTPolicyType[i].Value;
                        taLookupdataObj.Status = OTPolicyType[i].Status;
                        taLookupdataList.Add(taLookupdataObj);
                    }
                    break;
                case "OTPayType":
                    List<OTPayType> OTPayType = _otPayTypeRepository.SelectAllOTPayTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                    for (int i = 0; i < OTPayType.Count; i++)
                    {
                        TimeAttendanceLookupData taLookupdataObj = new TimeAttendanceLookupData();
                        taLookupdataObj.Name = OTPayType[i].Name;
                        taLookupdataObj.Value = OTPayType[i].Value;
                        taLookupdataObj.Status = OTPayType[i].Status;
                        taLookupdataList.Add(taLookupdataObj);
                    }
                    break;
                default:
                    break;
            }

            TALookupdataFormModelobj.TableName = TableName;

            TALookupdataFormModelobj.TAMasterTableList = taLookupdataList;


            //    TAMasterFormModelobj.TableName = TableName;
            //    string fullTableName = getTableWithSchema(TableName);
            //    TAMasterFormModelobj.TAMasterTableList = _taMasterTableRepository.SelectTAMasterTable(fullTableName, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(TALookupdataFormModelobj);
        }

        public ActionResult AddTAMasterTable()
        {
            string tableName = Request.QueryString["TableName"];
            var taMasterObj = new TimeAttendanceLookupData();
            if (tableName != null)
                taMasterObj.TableName = tableName;
            taMasterObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            return View(taMasterObj);
        }

        //[HttpPost]
        //public ActionResult AddTAMasterTable(TAMasterTable taMasterObj)
        //{
        //    bool success = false;

        //    switch (taMasterObj.TableName)
        //    {
        //        case "RoundType":
        //            success = _roundTypeRepository.InsertRoundType(taMasterObj);
        //            break;
        //        case "RoundMinutes":
        //            success = _roundMinutesRepository.InsertRoundMinutes(taMasterObj);
        //            break;
        //        case "OTPolicyType":
        //            success = _otPolicyTypeRepository.InsertOTPolicyType(taMasterObj);
        //            break;
        //        case "OTPayType":
        //            success = _otPayTypeRepository.InsertOTPayType(taMasterObj);
        //            break;
        //        default:
        //            success = true;
        //            break;

        //    }

        //    if (success)
        //        return RedirectToAction("SelectTAMasterTable", new { @TableName = Request.QueryString["TableName"] });
        //    else
        //        return PartialView();
        //}

        //public ActionResult EditTAMasterTable(int Id, string TableName)
        //{
        //    bool success = false;
        //    TAMasterTable taMasterObj = new TAMasterTable();

        //    switch (TableName)
        //    {
        //        case "RoundType":
        //            taMasterObj = _roundTypeRepository.SelectRoundTypeDetail(Id, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
        //            taMasterObj.TableName = "RoundType";
        //            success = true;
        //            break;
        //        case "RoundMinutes":
        //            taMasterObj = _roundMinutesRepository.SelectRoundMinuteDetail(Id, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
        //            taMasterObj.TableName = "RoundMinutes";
        //            success = true;
        //            break;
        //        case "OTPolicyType":
        //            taMasterObj = _otPolicyTypeRepository.SelectOTPolicyTypeDetail(Id, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
        //            taMasterObj.TableName = "OTPolicyType";
        //            success = true;
        //            break;
        //        case "OTPayType":
        //            taMasterObj = _otPayTypeRepository.SelectOTPayTypeDetail(Id, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
        //            taMasterObj.TableName = "OTPayType";
        //            success = true;
        //            break;
        //        default:
        //            success = true;
        //            break;
        //    }

        //    if (success)
        //        return View(taMasterObj);
        //    return RedirectToAction("SelectTAMasterTable");
        //}

        //[HttpPost]
        //public ActionResult EditTAMasterTable(TAMasterTable taMasterObj)
        //{
        //    bool success = false;

        //    switch (taMasterObj.TableName)
        //    {
        //        case "RoundType":
        //            success = _roundTypeRepository.UpdateRoundType(taMasterObj);
        //            success = true;
        //            break;
        //        case "RoundMinutes":
        //            success = _roundMinutesRepository.UpdateRoundMinutes(taMasterObj);
        //            taMasterObj.TableName = "RoundMinutes";
        //            success = true;
        //            break;
        //        case "OTPolicyType":
        //            success = _otPolicyTypeRepository.UpdateOTPolicyType(taMasterObj);
        //            taMasterObj.TableName = "OTPolicyType";
        //            success = true;
        //            break;
        //        case "OTPayType":
        //            success = _otPayTypeRepository.UpdateOTPayType(taMasterObj);
        //            taMasterObj.TableName = "OTPayType";
        //            success = true;
        //            break;
        //        default:
        //            success = true;
        //            break;
        //    }

        //    if (success)
        //        return RedirectToAction("SelectTAMasterTable", new { @TableName = taMasterObj.TableName });
        //    return View(taMasterObj);

        //}

        public string getTableWithSchema(string tableName)
        {
            string tableNameWithSchema = LocalizedStrings.Department;
            switch (tableName)
            {
                case "OTPolicyType":
                    tableNameWithSchema = LocalizedStrings.OTPolicyType;
                    break;
                case "OTPayType":
                    tableNameWithSchema = LocalizedStrings.OTPayType;
                    break;
                case "RoundType":
                    tableNameWithSchema = LocalizedStrings.RoundType;
                    break;
                case "RoundMinutes":
                    tableNameWithSchema = LocalizedStrings.RoundMinutes;
                    break;
            }
            return tableNameWithSchema;
        }


        ///// <summary>
        ///// DeleteHoliday - Post Method: Deletes the Holiday Information 
        ///// </summary>
        ///// <param name="HolidayIds"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[ActionName("DeleteTAMasterTableDetail")]
        //public bool DeleteTAMasterTableDetail(TAMasterTableFormModel taMasterFormModelObj)
        //{

        //    //if (Ids != null)
        //    //{
        //    //    foreach (var Id in Ids.Split(','))
        //    //    {
        //    //bool success = false;

        //    //switch (TableName)
        //    //{
        //    //    case "RoundType":
        //    //        success = _roundTypeRepository.UpdateRoundType(Id);
        //    //        success = true;
        //    //        break;
        //    //    case "RoundMinutes":
        //    //        success = _roundMinutesRepository.UpdateRoundMinutes(Id);
        //    //        taMasterObj.TableName = "RoundMinutes";
        //    //        success = true;
        //    //        break;
        //    //    case "OTPolicyType":
        //    //        success = _otPolicyTypeRepository.UpdateOTPolicyType(Id);
        //    //        taMasterObj.TableName = "OTPolicyType";
        //    //        success = true;
        //    //        break;
        //    //    case "OTPayType":
        //    //        success = _otPayTypeRepository.UpdateOTPayType(Id);
        //    //        taMasterObj.TableName = "OTPayType";
        //    //        success = true;
        //    //        break;
        //    //    default:
        //    //        success = true;
        //    //        break;
        //    //}

        //    //if (success)
        //    //    return RedirectToAction("SelectTAMasterTable", new { @TableName = TableName });
        //    //        return View();
        //    //    }
        //    //}
        //    return true;
        //}

    }
}