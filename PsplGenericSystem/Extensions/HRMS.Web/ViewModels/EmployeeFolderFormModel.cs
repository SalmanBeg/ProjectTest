using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Web.ViewModels
{
    public class EmployeeFolderFormModel
    {
        public EmployeeFolderFormModel()
        {
           
            FilesDBList = new List<FilesDB>();
            DocumentCategoryList = new List<LookUpDataEntity>();
        }

        public EmployeeFolder EmployeeFolder { get; set; }
        #region Dropdown Properties
        //[Required(ErrorMessage = "File Name is required")]
        public List<FilesDB> FilesDBList { get; set; }
        public List<LookUpDataEntity> DocumentCategoryList { get; set; }
        #endregion
    }
}