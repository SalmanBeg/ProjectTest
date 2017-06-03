using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;
using HRMS.Service.Interfaces;

namespace HRMS.Web.Controllers
{
    public class TalentManagementController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly ITalentManagementRepository _talentManagementRepository;
        public TalentManagementController(IUtilityRepository utilityRepo, ITalentManagementRepository talentManagementRepository)
        {
            _talentManagementRepository = talentManagementRepository;
            _utilityRepository = utilityRepo;
        }
        #endregion
        /// <summary>
        /// View to add a new talent management record in a company
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult ViewTalentManagements()
        {
            var lookUpDataEntityObj = new LookUpDataEntity { Name= LocalizedStrings.AddNew, Id = 0};
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var talentManagementFormModelobj = new TalentManagementFormModel();
              if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
              talentManagementFormModelobj.LevelList = lstlookup.Where(j => j.TableName == LocalizedStrings.DegreeLevel).ToList();
              talentManagementFormModelobj.LevelList.Insert(0, lookUpDataEntityObj);
              talentManagementFormModelobj.GraduatedList = lstlookup.Where(j => j.TableName == LocalizedStrings.Graduated).ToList();
              talentManagementFormModelobj.GraduatedList.Insert(0, lookUpDataEntityObj);
              talentManagementFormModelobj.HonoraryRecognitionList = lstlookup.Where(j => j.TableName == LocalizedStrings.HonoraryRecognition).ToList();
              talentManagementFormModelobj.HonoraryRecognitionList.Insert(0, lookUpDataEntityObj);
              return View(talentManagementFormModelobj);
        }
        /// <summary>
        /// View to add a new talent management record in a company
        /// </summary>
        /// <param name="talentManagementFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult ViewTalentManagements(TalentManagementFormModel talentManagementFormModelobj)
        {
            var lookUpDataEntityObj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            talentManagementFormModelobj.TalentManagement.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            bool success = _talentManagementRepository.ViewTalentManagements(talentManagementFormModelobj.TalentManagement);
            talentManagementFormModelobj.LevelList = lstlookup.Where(j => j.TableName == LocalizedStrings.DegreeLevel).ToList();
            talentManagementFormModelobj.LevelList.Insert(0, lookUpDataEntityObj);
            talentManagementFormModelobj.GraduatedList = lstlookup.Where(j => j.TableName == LocalizedStrings.Graduated).ToList();
            talentManagementFormModelobj.GraduatedList.Insert(0, lookUpDataEntityObj);
            talentManagementFormModelobj.HonoraryRecognitionList = lstlookup.Where(j => j.TableName == LocalizedStrings.HonoraryRecognition).ToList();
            talentManagementFormModelobj.HonoraryRecognitionList.Insert(0, lookUpDataEntityObj);
            return RedirectToAction("SelectAllTalentManagement");
        }
        /// <summary>
        /// View to show all the talent management record in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllTalentManagement()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var talentManagementList = _talentManagementRepository.SelectAllTalentManagement(companyId);
            return View(talentManagementList);
        }
        /// <summary>
        /// View to update existing record for an talent management record based on record id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult UpdateTalentManagement()
        {
            var talentManagementFormModelobj = new TalentManagementFormModel();
            var id = Request.QueryString["TalentManagementId"];
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            talentManagementFormModelobj.TalentManagement = _talentManagementRepository.SelectTalentManagementById(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(id)).FirstOrDefault();
            talentManagementFormModelobj.LevelList = lstlookup.Where(j => j.TableName == LocalizedStrings.DegreeLevel).ToList();
            talentManagementFormModelobj.GraduatedList = lstlookup.Where(j => j.TableName == LocalizedStrings.Graduated).ToList();
            talentManagementFormModelobj.HonoraryRecognitionList = lstlookup.Where(j => j.TableName == LocalizedStrings.HonoraryRecognition).ToList();
            return View(talentManagementFormModelobj);
        }
        /// <summary>
        /// View to update existing record for an talent management record based on record id
        /// </summary>
        /// <param name="talentManagementFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult UpdateTalentManagement(TalentManagementFormModel talentManagementFormModelobj)
        {
            bool success = _talentManagementRepository.UpdateTalentManagement(talentManagementFormModelobj.TalentManagement);
            if (success)
            {
                ModelState.AddModelError("", "Talent Management Detail(s) Updated Successfully.");
            }
            else
            {
                ModelState.AddModelError("", "Talent Management(s) cannot be updated, Please try again.");
            }
            return RedirectToAction("SelectAllTalentManagement");

        }
        /// <summary>
        /// Method to delete an existing record based on record Id
        /// </summary>
        /// <param name="talentManagementIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteTalentManagement(string talentManagementIds)
        {
            if(talentManagementIds !=null)
            {
                foreach(var talentManagementId in talentManagementIds.Split(','))
                {
                    var deleteTalentManagement =
                        _talentManagementRepository.DeleteTalentManagement(Int32.Parse(talentManagementId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
	}
   
}