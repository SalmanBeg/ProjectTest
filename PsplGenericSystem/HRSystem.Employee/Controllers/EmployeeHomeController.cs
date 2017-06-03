using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRSystem.Security.Authentication;
namespace HRSystem.Employee
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EmployeeHomeController : Controller
    {
        [Import]
        
        private IMyTest _myTest;
      
        public ActionResult Index()
        {
         
            ViewBag.Message = _myTest.GetMessage();

            return View("EmployeeHome");
        }
    }

    public interface IMyTest
    {
        String GetMessage();
    }

    [Export(typeof(IMyTest))]
    public class MyTest1 : IMyTest
    {
        public MyTest1()
        {
            creationDate = DateTime.Now;
        }

        public string GetMessage()
        {
            return String.Format("MyTest1 created at {0}", creationDate.ToString("hh:mm:ss")) ;
        }

        private DateTime creationDate;
    }
}
