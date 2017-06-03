using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class ReviewReviewerFormModel
    {
        // ManagerList = new List<UserLoginModel>();
        public List<ReviewCriteriaFill> lstReviewer1 { get; set; }
        public List<ReviewCriteriaFill> lstReviewer2 { get; set; }
        public List<ReviewCriteriaFill> lstReviewer3 { get; set; }
        public List<ReviewReviewerOtherEmployee> lstOtherEmployee3 { get; set; }
        public List<ReviewReviewerOtherEmployee> lstOtherEmployeeSelect { get; set; }
        public int HRManagerId { get; set; }
        public Employee Employee { get; set; }
        public Review  Review { get; set; }
        public ReviewReviewerOtherEmployee ReviewReviewerOtherEmployee { get; set; }
       
       // public Employee Employee { get; set; }
        public List<UserLoginModel> ManagerList { get; set; }
        
    }
  
}