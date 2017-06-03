using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using System.Data;
using HRMS.Service.Interfaces;

namespace HRMS.Web.Controllers
{
    public class EmployeeEmergencyContactController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IEmergencyContanctRepository _emergencyContactRepository;
        private readonly IUtilityRepository _utilityRepository;
        public EmployeeEmergencyContactController(IEmergencyContanctRepository emergencyContactRepository, IUtilityRepository utilityRepository)
        {
            _emergencyContactRepository = emergencyContactRepository;
            _utilityRepository = utilityRepository;
        }

        #endregion
        /// <summary>
        /// View to add an emergency contact record for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddEmergencyContact()
        {
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var emergencyContactFormModelobj = new EmergencyContactFormModel
            {
                CountryList = _utilityRepository.GetCountry(),
                //StateList = _utilityRepo.GetStateProvince(CountryRegionId),

            };
            emergencyContactFormModelobj.RelationShipList = lstlookup.Where(j => j.TableName == LocalizedStrings.Relationship).ToList();
            emergencyContactFormModelobj.RelationShipList.Insert(0, lookUpDataEntityobj);
            return View(emergencyContactFormModelobj);
        }
        /// <summary>
        /// View to add an emergency contact record for an employee
        /// </summary>
        /// <param name="emergencyContactFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddEmergencyContact(EmergencyContactFormModel emergencyContactFormModelobj)
        {
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var lstlookup = new List<LookUpDataEntity>();
            emergencyContactFormModelobj.EmployeeEmergencyContact.IsPrimaryContact = Convert.ToBoolean(emergencyContactFormModelobj.IsPrimaryContact);   
            emergencyContactFormModelobj.EmployeeEmergencyContact.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            emergencyContactFormModelobj.EmployeeEmergencyContact.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            emergencyContactFormModelobj.EmployeeEmergencyContact.CreatedBy = GlobalsVariables.CurrentUserId;
            emergencyContactFormModelobj.RelationShipList = lstlookup.Where(j => j.TableName == LocalizedStrings.Relationship).ToList();
            emergencyContactFormModelobj.RelationShipList.Insert(0, lookUpDataEntityobj);
            bool success = _emergencyContactRepository.AddEmergencyContact(emergencyContactFormModelobj.EmployeeEmergencyContact);
            if (success)
            {
                ModelState.AddModelError("", "Emergency contact created.");
                return RedirectToAction("SelectAllEmergencyContact");
            }
            else
            {
                ModelState.AddModelError("", "Emergency contact cannot be created, Please try again.");
                return RedirectToAction("SelectAllEmergencyContact");
            }
        }
        /// <summary>
        /// Action method to delete emergency contact record
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteEmergencyContact(string emergencyContactIds, FormCollection fc)
        {
            if (emergencyContactIds != null)
            {
                foreach (var emergencyContactId in emergencyContactIds.Split(','))
                {
                    ViewBag.SuccessMessage = "File was successfully deleted";
                    bool success = _emergencyContactRepository.DeleteEmergencyContact(Convert.ToInt32(emergencyContactId));

                }
            }
            // return ("Record deleted successfully!");
            ViewBag.Message = "Successfully Deleted";
            return true;

        }
        /// <summary>
        /// View to update existing emergency contact record
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult UpdateEmergencyContact()
        {
            var lookUpDataEntityObj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var emergencyContactFormModelobj = new EmergencyContactFormModel();
            emergencyContactFormModelobj.EmployeeEmergencyContact = new EmployeeEmergencyContact();
            var id = Request.QueryString["EmployeeEmergencyContactId"];
            emergencyContactFormModelobj.EmployeeEmergencyContact.IsPrimaryContact = emergencyContactFormModelobj.IsPrimaryContact;
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            emergencyContactFormModelobj.EmployeeEmergencyContact = _emergencyContactRepository.SelectEmergencyContactByEmergencyContactId(Convert.ToInt32(id), Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).FirstOrDefault();
            emergencyContactFormModelobj.CountryList = _utilityRepository.GetCountry();
            if (emergencyContactFormModelobj.EmployeeEmergencyContact == null)
                emergencyContactFormModelobj.EmployeeEmergencyContact = new EmployeeEmergencyContact();
            if (emergencyContactFormModelobj.EmployeeEmergencyContact.CountryId != 0)
                emergencyContactFormModelobj.StateList = _utilityRepository.GetStateProvince(emergencyContactFormModelobj.EmployeeEmergencyContact.CountryId);
            emergencyContactFormModelobj.RelationShipList = lstlookup.Where(j => j.TableName == LocalizedStrings.Relationship).ToList();
            emergencyContactFormModelobj.RelationShipList.Insert(0, lookUpDataEntityObj);
            return View(emergencyContactFormModelobj);
        }
        /// <summary>
        /// View to udpate existing emergency contact record
        /// </summary>
        /// <param name="emergencyContactFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult UpdateEmergencyContact(EmergencyContactFormModel emergencyContactFormModelobj)
        {
            emergencyContactFormModelobj.EmployeeEmergencyContact.IsPrimaryContact = emergencyContactFormModelobj.IsPrimaryContact;
            bool success = _emergencyContactRepository.UpdateEmergencyContact(emergencyContactFormModelobj.EmployeeEmergencyContact);
            if (success)
            {
                ModelState.AddModelError("", "emergency contact successfully updated.");
                return RedirectToAction("SelectAllEmergencyContact");
            }
            else
            {
                ModelState.AddModelError("", "Emergency contact cannot be updated, Please try again.");
                return RedirectToAction("SelectAllEmergencyContact");
            }
        }
        /// <summary>
        /// View to show all the records of emergency contacts of an employee in a company
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllEmergencyContact(FormCollection fc)
        {
            int userId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var employeeEmergencyContactDetailobj = new List<EmployeeEmergencyContact>();
            //  ViewBag.SuccessMessage = "File was successfully deleted";
            //ViewBag.Message = "Successfully Deleted";
            employeeEmergencyContactDetailobj = _emergencyContactRepository.SelectAllEmergencyContact(userId, companyId);
            //   ViewBag.SuccessMessage = "File was successfully deleted";
            return View(employeeEmergencyContactDetailobj);
        }
    }
}
