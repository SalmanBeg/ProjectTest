using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;
using HRMS.Service.Models.ExtendedModels;

namespace HRMS.Web.ViewModels
{
    public class EmployeeSnapshotFormModel
    {
        public EmployeeSnapshotFormModel()
        {
            
        }

        public EmployeeSnapshot EmployeeSnapshot { get; set; }
        public EmployeeEmergencyContact EmployeeEmergencyContact { get; set; }
        public EmployeeTax EmployeeTax { get; set; }

        //Virtual Properties
        public string Alias { get; set; }
        public int JobProfileId { get; set; }
        public string JobProfileName { get; set; }
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public int DepartmentId { get; set; }
        public int DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string Rootstock { get; set; }
        public string Name { get; set; }
        public string EEOClass { get; set; }

        #region Dropdown Properties
        
        #endregion
    }
}