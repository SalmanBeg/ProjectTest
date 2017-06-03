using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
   public interface ICompanyRepository
    {
       List<CompanyInfo> GetCompanyInfo(int roleId);

       CompanyInfo GetEditCompanyInfo(int companyId);

       bool UpdateCompanyById(CompanyInfo companyInfoobj);

       bool CreateCompany(CompanyInfo companyInfoobj,int UserId);
    }
}
