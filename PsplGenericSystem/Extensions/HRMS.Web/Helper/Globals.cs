using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.Helper
{
    public class GlobalsVariables
    {
        public static String CurrentCompanyId
        {
            get
            {
                return HttpContext.Current.Session["CurrentCompanyId"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["CurrentCompanyId"] = value;
            }
        }
        public static String CurrentUserId
        {
            get
            {
                return HttpContext.Current.Session["CurrentUserId"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["CurrentUserId"] = value;
            }
        }
        public static String CurrentUserRoleId
        {
            get
            {
                return HttpContext.Current.Session["CurrentUserRoleId"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["CurrentUserRoleId"] = value;
            }
        }       
        public static String SelectedUserId
        {
            get
            {
                return HttpContext.Current.Session["SelectedUserId"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["SelectedUserId"] = value;
            }
        }
        public static String SelectedCandidateId
        {
            get
            {
                return HttpContext.Current.Session["SelectedCandidateId"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["SelectedCandidateId"] = value;
            }
        }      
        public static String GlobalFormAuthenticationvalue
        {
            get
            {
                return HttpContext.Current.Session["GlobalFormAuthenticationvalue"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["GlobalFormAuthenticationvalue"] = value;
            }
        }
        public static String CurrentCompanyName
        {
            get
            {
                return HttpContext.Current.Session["CurrentCompanyName"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["CurrentCompanyName"] = value;
            }
        }
        public static String CurrentUserName
        {
            get
            {
                return HttpContext.Current.Session["CurrentUserName"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["CurrentUserName"] = value;
            }
        }
        public static String CurrentUserRoleName
        {
            get
            {
                return HttpContext.Current.Session["CurrentUserRoleName"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["CurrentUserRoleName"] = value;
            }
        }
        public static String SelectedUserCode
        {
            get
            {
                return HttpContext.Current.Session["SelectedUserCode"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["SelectedUserCode"] = value;
            }
        }
        public static String SelectedUserName
        {
            get
            {
                return HttpContext.Current.Session["SelectedUserName"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["SelectedUserName"] = value;
            }
        }
        public static String CurrentUserCode
        {
            get
            {
                return HttpContext.Current.Session["CurrentUserCode"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["CurrentUserCode"] = value;
            }
        }
        public static String HireWizardEmployeeId
        {
            get
            {
                return HttpContext.Current.Session["HireWizardEmployeeId"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["CurrentUserCode"] = value;
            }
        }
        public static String IsHireWizard
        {
            get
            {
                return HttpContext.Current.Session["IsHireWizard"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["IsHireWizard"] = value;
            }
        }

        public static String HireType
        {
            get { return HttpContext.Current.Session["HireType"] as string ?? string.Empty; }
            set { HttpContext.Current.Session["HireType"] = value; }
        }

        public static String LastLogin
        {
            get
            {
                return HttpContext.Current.Session["LastLogin"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["LastLogin"] = value;
            }
        
        }
        public static String ImageFileId
        {
            get
            {
                return HttpContext.Current.Session["ImageFileId"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["ImageFileId"] = value;
            }
        }
        public static String EmpImgValue
        {
            get
            {
                return HttpContext.Current.Session["EmpImgValue"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["EmpImgValue"] = value;
            }
        }
        public static String DirectDepositId
        {
            get
            {
                return HttpContext.Current.Session["DirectDepositId"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["DirectDepositId"] = value;
            }
        }
    }
}