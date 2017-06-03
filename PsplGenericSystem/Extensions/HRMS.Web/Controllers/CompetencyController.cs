using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;
using HRMS.Service.Interfaces;
namespace HRMS.Web.Controllers
{
    public class CompetencyController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly ICompetencyRepository _competencyRepository;
        public CompetencyController(IUtilityRepository utilityRepository, ICompetencyRepository competencyRepository)
        {
            _utilityRepository = utilityRepository;
            _competencyRepository = competencyRepository;
        }
        #endregion
        /// <summary>
        /// View to add a new competency record
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddCompetency()
        {
            var competencyFormModelobj = new CompetencyFormModel();
            competencyFormModelobj.Competency = new Competency();
            competencyFormModelobj.Competency.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            return View(competencyFormModelobj);
        }
        /// <summary>
        /// View to add a new competency record
        /// </summary>
        /// <param name="competencyFormModelobj"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddCompetency(CompetencyFormModel competencyFormModelobj, FormCollection fc)
        {
            competencyFormModelobj.Competency.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
         //   int rtnCompetencyId = competencyFormModelobj == null ? 0 : competencyFormModelobj.Competency.CompetencyId;
            int currentUserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            int rtncmp = _competencyRepository.AddCompetency(competencyFormModelobj.Competency);
            int CompetencyId = 1;
            competencyFormModelobj.Competency.CompetencyId = CompetencyId;

            if (CompetencyId != -1)
            {
                string category = fc[1];
                string points = fc[2];


                DataTable dt = CompetencySchema();

                //Default row Bind.....

                DataRow defaultRow = dt.NewRow();
                defaultRow["Category"] = category;
                defaultRow["Points"] = points;
                defaultRow["CompetencyId"] = CompetencyId;
                defaultRow["CompanyId"] = companyId;
                defaultRow["CreatedBy"] = currentUserId;
                defaultRow["CreatedOn"] = DateTime.UtcNow;

                dt.Rows.Add(defaultRow);

                //Loop Grid Logic code......


                int i = 0;
                if (fc.Count > 4)
                {
                    string[] strSplitCategory = fc[4].Split(',');
                    string[] strSplitPoints = fc[5].Split(',');
                    foreach (var listname in strSplitCategory)
                    {
                        DataRow row = dt.NewRow();
                        row["Category"] = listname;
                        row["Points"] = strSplitPoints[i];
                        row["CompetencyId"] = CompetencyId;
                        row["CompanyId"] = companyId;
                        row["CreatedBy"] = currentUserId;
                        row["CreatedOn"] = DateTime.UtcNow;
                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                        i++;
                    }
                }


                //Bulk Insert

                bool status = _competencyRepository.InsertCompetencyContentBulk(dt);

            }

            return RedirectToAction("SelectAllCompetency");
        }
        /// <summary>
        /// function to return competency schema datatable
        /// </summary>
        /// <returns></returns>
        public DataTable CompetencySchema()
        {
            var dt = new DataTable();
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Points", typeof(float));
            dt.Columns.Add("CompetencyId", typeof(int));
            dt.Columns.Add("CompanyId", typeof(int));
            dt.Columns.Add("CreatedBy", typeof(int));
            dt.Columns.Add("CreatedOn", typeof(DateTime));
            return dt;
        }
        /// <summary>
        /// View to show all the competency records in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllCompetency()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<Competency> competencyList = _competencyRepository.SelectAllCompetency(companyId);
            return View(competencyList);
        }
        /// <summary>
        /// View to update existing record of a competency
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult UpdateCompetency()
        {
            var competencyFormModelobj = new CompetencyFormModel();
            var id = Request.QueryString["CompetencyId"];
            competencyFormModelobj.Competency = _competencyRepository.SelectCompetencyById(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(id));
            return View(competencyFormModelobj);
        }
        /// <summary>
        /// View to update existing record of a competency
        /// </summary>
        /// <param name="competencyFormModelobj"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult UpdateCompetency(CompetencyFormModel competencyFormModelobj, FormCollection fc)
        {
            //int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            //int currentUserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            //competencyFormModelobj.Competency.CompanyId = companyId;
            //bool rtnStatus = _competencyRepository.UpdateCompetency(competencyFormModelobj.Competency);
            //if (rtnStatus && fc.Count > 3)
            //{
            //    string category = fc[3];
            //    string points = fc[4];
            //    DataTable dt = CompetencySchema();
            //    //Default row Bind..

            //    DataRow defaultRow = dt.NewRow();
            //    defaultRow["Category"] = category;
            //    defaultRow["Points"] = points;
            //    defaultRow["CompanyId"] = companyId;
            //    defaultRow["CreatedBy"] = currentUserId;
            //    defaultRow["CreatedOn"] = DateTime.UtcNow;
            //    dt.Rows.Add(defaultRow);

            //    //Loop Grid Logic code..........



            //    int i = 0;
            //    if (fc.Count > 4)
            //    {
            //        string[] strSplitCategory = fc[4].Split(',');
            //        string[] strSplitPoints = fc[5].Split(',');
            //        foreach (var listname in strSplitCategory)
            //        {
            //            DataRow row = dt.NewRow();
            //            row["Category"] = listname;
            //            row["Points"] = strSplitPoints[i];
            //            row["CompanyId"] = companyId;
            //            row["CreatedBy"] = currentUserId;
            //            row["CreatedOn"] = DateTime.UtcNow;
            //            dt.Rows.Add(row);
            //            dt.AcceptChanges();
            //            i++;
            //        }
            //    }


            //    //Bulk Insert

            //    bool status = _competencyRepository.UpdateCompetencyContentBulk(dt);

            //}

            //return View(competencyFormModelobj);

            bool success = _competencyRepository.UpdateCompetency(competencyFormModelobj.Competency);
            if (success)
            {
                ModelState.AddModelError("", "Competency Detail(s) Updated Successfully.");
            }
            else
            {
                ModelState.AddModelError("", "Competency Detail(s) cannot be updated, Please try again.");
            }
            return RedirectToAction("SelectAllCompetency");
        }
        /// <summary>
        /// Function to delete records from competency record set
        /// </summary>
        /// <param name="competencyIds"></param>
        /// <returns></returns>
        [Authorize]
        public bool DeleteCompetency(string competencyIds)
        {
            if (competencyIds != null)
            {
                foreach (var competencyId in competencyIds.Split(','))
                {
                    var deleteCompetency =
                        _competencyRepository.DeleteCompetency(Int32.Parse(competencyId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
    }
}