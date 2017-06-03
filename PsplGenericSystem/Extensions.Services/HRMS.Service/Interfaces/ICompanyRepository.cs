using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
   public interface ICompanyRepository
   {
       /// <summary>
       /// To add a new company
       /// </summary>
       /// <param name="companyInfoobj"></param>
       /// <param name="userId"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       bool CreateCompany(CompanyInfo companyInfoobj, int userId);
       /// <summary>
       /// View to edit existing company
       /// </summary>
       /// <param name="companyInfoobj"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       bool UpdateCompanyById(CompanyInfo companyInfoobj);
       /// <summary>
       /// view to show the company info
       /// </summary>
       /// <param name="roleId"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       List<CompanyInfo> GetCompanyInfo(int roleId);
       /// <summary>
       /// view to update company info
       /// </summary>
       /// <param name="companyId"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       CompanyInfo GetEditCompanyInfo(int companyId);
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       List<CompanyInfo> GetAllCompanyInfo();
       /// <summary>
       /// show all company info
       /// </summary>
       /// <param name="companyInfoObj"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       bool IsTitleExists(CompanyInfo companyInfoObj);

    }
}
