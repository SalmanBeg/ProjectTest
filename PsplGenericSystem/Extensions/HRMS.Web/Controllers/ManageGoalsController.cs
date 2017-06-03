using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using System.Web;
using System.Web.Mvc;
using HRMS.Web.Helper;

namespace HRMS.Web.Controllers
{
    public class ManageGoalsController : Controller
    {
        // GET: ManageGoals
        public ActionResult AddManageGoals()
        {
            var employeeGoalFormModelObj = new EmployeeGoalFormModel();
            employeeGoalFormModelObj.EmployeeGoal = new EmployeeGoal();

            return View(employeeGoalFormModelObj);
        }
        [HttpPost]
        public ActionResult AddManageGoals(EmployeeGoalFormModel employeeGoalFormModelObj)
        {
            employeeGoalFormModelObj.EmployeeGoal.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            return View();
        }

    }
}