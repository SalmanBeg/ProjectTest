using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using System.Web.Security;
using Newtonsoft.Json;
using HRMS.Web.Helper;
using System.Data;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;
namespace HRMS.Web.Controllers
{
    public class ConsentFormsController : Controller
    {
      #region Class Level Variables and constructor

        private readonly IConsentFormRepository _consentFormRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        DataTable consentDocTable = new DataTable();
        public ConsentFormsController(IConsentFormRepository consentFormRepository, IFilesDBRepository filesDBRepository)
        {
            _consentFormRepository = consentFormRepository;
            _filesDBRepository = filesDBRepository;
        }


        //[HttpGet]
        //public ActionResult AddOnBoarding(OnBoardingFormModel onBoardingModelobj)
        //{
        //    onBoardingModelobj.FilesDB = _filesDBRepository.SelectAllFilesByCompanyId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
        //    return View(onBoardingModelobj);
        //}

        //[HttpPost]
        //public ActionResult AddOnBoarding(string ListIds, OnBoarding onBoardingobj)
        //{
        //    if (ListIds.Length > 0)
        //    {
        //        string[] idstring;
        //        idstring = ListIds.Split(',');
        //        if (idstring.Length > 0)
        //        {
        //            for (int i = 0; i < idstring.Length; i++)
        //            {
        //                DynamicTable(Convert.ToInt32(idstring[i]));
        //            }
        //        }
        //    }

        //    DataTable dt = consentDocTable;

        //    if (consentDocTable.Rows.Count > 0)
        //    {
        //        _consentFormRepository.CreateOnBoarding(consentDocTable, onBoardingobj);
        //    }

        //    return View();
        //}

        //public void TStructure()
        //{
        //    if (consentDocTable.Columns.Count == 0)
        //    {
        //        consentDocTable.Columns.Add("ConsentdocId", typeof(System.Int32));
        //    }
        //}

        //public void DynamicTable(int consentdocId)
        //{
        //    DataRow dr;
        //    dr = consentDocTable.NewRow();
        //    dr["ConsentdocId"] = consentdocId;
        //    consentDocTable.Rows.Add(dr);
        //}
        #endregion
        /// <summary>
        /// View to list consent documents by companyid
        /// </summary>
        /// <param name="employeeW4FormDetailsobj"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult SelectAllConsentFormsbyCompanyId(EmployeeW4Form employeeW4FormDetailsobj)
        {
            return View(employeeW4FormDetailsobj);
        }
    }
}
