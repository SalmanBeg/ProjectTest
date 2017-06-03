using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
using HRMS.Service;

namespace HRMS.Service.Models.EDM
{

    public class ReviewCriteriaFill
    {

        #region Class variable
        public int RowId { get; set; }
        public int? ReviewCriteriaId { get; set; }
        public string CriteriaTypeId { get; set; }
        public string JobTitleId { get; set; }
        public string PositionId { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public string ResponseTypeId { get; set; }
        public int ReviewId { get; set; }
        public int ReviewerMasterId { get; set; }
        public string EmployeeName { get; set; }
        public string UserId { get; set; }
        public int CompanyId { get; set; }      
        public string Type { get; set; }
        public int? ReviewReviewerId { get; set; }
        public string ScoreId { get; set; }

        #endregion
    }
}
       