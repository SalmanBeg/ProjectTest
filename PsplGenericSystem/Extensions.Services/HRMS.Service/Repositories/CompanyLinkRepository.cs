using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class CompanyLinkRepository : ICompanyLinkRepository
    {
        /// <summary>
        /// Returns all Company Links by CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<CompanyLink> SelectAllCompanyLink(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_CompanyLinkSelectAll_Result> lstCompanyLinkResult = hrmsEntity.usp_CompanyLinkSelectAll(companyId).ToList();
                    var companyLinkList = lstCompanyLinkResult.Select(companyLinkObj => new CompanyLink
                    {
                        CompanyLinkId = companyLinkObj.CompanyLinkId,
                        Name = companyLinkObj.Name,
                        Url = companyLinkObj.Url,
                        CreatedBy = companyLinkObj.CreatedBy,
                        CreatedDate = companyLinkObj.CreatedDate,
                        ModifiedBy = companyLinkObj.ModifiedBy,
                        ModifiedDate = companyLinkObj.ModifiedDate
                    }).ToList();
                    return companyLinkList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns only selecte company link by companyId and companyLinkId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="companyLinkId"></param>
        /// <returns></returns>
        public List<CompanyLink> SelectCompanyLinkById(int companyLinkId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_CompanyLinkSelect_Result> lstCompanyLinkResult = hrmsEntity.usp_CompanyLinkSelect(companyLinkId).ToList();
                    var companyLinkList = lstCompanyLinkResult.Select(companyLinkObj => new CompanyLink
                    {
                        CompanyLinkId = companyLinkObj.CompanyLinkId,
                        Name = companyLinkObj.Name,
                        Url = companyLinkObj.Url,
                        CreatedBy = companyLinkObj.CreatedBy,
                        CreatedDate = companyLinkObj.CreatedDate,
                        ModifiedBy = companyLinkObj.ModifiedBy,
                        ModifiedDate = companyLinkObj.ModifiedDate
                    }).ToList();
                    return companyLinkList;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Creates New Company Link
        /// </summary>
        /// <param name="companyLinkobj"></param>
        /// <returns></returns>
        public bool CreateCompanyLink(CompanyLink companyLinkobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_CompanyLinkInsert(
                    companyLinkobj.Name,
                    companyLinkobj.Url,
                    companyLinkobj.CreatedBy,
                    companyLinkobj.CreatedDate,
                    companyLinkobj.CompanyId
                        //companyLinkobj.ModifiedBy,
                        //companyLinkobj.ModifiedDate
                    );
                    hrmsEntity.Dispose();
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the Selected Company Link
        /// </summary>
        /// <param name="companyLinkobj"></param>
        /// <returns></returns>
        public bool UpdateCompanyLink(CompanyLink companyLinkobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_CompanyLinkUpdate(
                        companyLinkobj.CompanyLinkId,
                        companyLinkobj.Name,
                        companyLinkobj.Url,
                        //companyLinkobj.CreatedBy,
                        //companyLinkobj.CreatedDate,
                        companyLinkobj.ModifiedBy,
                        companyLinkobj.ModifiedDate
                        );
                    hrmsEntity.Dispose();
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the Company Link
        /// </summary>
        /// <param name="companyLinkId"></param>
        /// <returns></returns>
        public bool DeleteCompanyLink(int companyLinkId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var result = hrmsEntity.usp_CompanyLinkDelete(companyLinkId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
