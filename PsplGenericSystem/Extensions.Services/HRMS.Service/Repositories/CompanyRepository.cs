using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public bool CreateCompany(CompanyInfo companyInfoobj, int userId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_CompanyInfoInsert(companyInfoobj.CompanyName, companyInfoobj.Address1, companyInfoobj.Address2, companyInfoobj.City
                        , companyInfoobj.ZIP, companyInfoobj.CountryId, companyInfoobj.StateId, companyInfoobj.Phone
                            , companyInfoobj.CompanyEmail, companyInfoobj.ControlType, companyInfoobj.ConnectionString, companyInfoobj.PrimaryControlId
                            , companyInfoobj.ControlId, companyInfoobj.CorporateStructureId,
                            companyInfoobj.LegalStructureId, companyInfoobj.ParentId, companyInfoobj.Description, companyInfoobj.FEIN, companyInfoobj.Status
                            , companyInfoobj.FromDate, companyInfoobj.ToDate, companyInfoobj.Activity,
                            companyInfoobj.Website, companyInfoobj.FISCYear, companyInfoobj.Currency, companyInfoobj.Language, companyInfoobj.TimeZone
                            , companyInfoobj.Association, companyInfoobj.SubscriptionCode, companyInfoobj.Type,
                            companyInfoobj.DatabaseName, companyInfoobj.ServerName, companyInfoobj.IsPositionManaged, companyInfoobj.TimeProvider
                            , companyInfoobj.PayrollProvider, userId, output).ToList();
                    hrmsEntity.Dispose();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateCompanyById(CompanyInfo companyInfoobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_CompanyInfoUpdate(companyInfoobj.CompanyId, companyInfoobj.CompanyName, companyInfoobj.Address1, companyInfoobj.Address2
                                , companyInfoobj.City, companyInfoobj.ZIP, companyInfoobj.CountryId, companyInfoobj.StateId, companyInfoobj.Phone
                                    , companyInfoobj.CompanyEmail, companyInfoobj.ControlType, companyInfoobj.ConnectionString, companyInfoobj.PrimaryControlId, companyInfoobj.ControlId
                                    , companyInfoobj.CorporateStructureId,
                                    companyInfoobj.LegalStructureId, companyInfoobj.ParentId, companyInfoobj.Description, companyInfoobj.FEIN, companyInfoobj.Status
                                    , companyInfoobj.FromDate, companyInfoobj.ToDate, companyInfoobj.Activity,
                                    companyInfoobj.Website, companyInfoobj.FISCYear, companyInfoobj.Currency, companyInfoobj.Language, companyInfoobj.TimeZone
                                    , companyInfoobj.Association, companyInfoobj.SubscriptionCode, companyInfoobj.Type,
                                    companyInfoobj.DatabaseName, companyInfoobj.ServerName, companyInfoobj.IsPositionManaged, companyInfoobj.TimeProvider
                                    , companyInfoobj.PayrollProvider, companyInfoobj.CreatedBy, companyInfoobj.ModifiedBy, companyInfoobj.CreatedOn, companyInfoobj.ModifiedOn).ToList();

                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<CompanyInfo> GetCompanyInfo(int roleId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_CompanyInfoSelectAllByRoleId_Result> lstCompanyInfoResult = hrmsEntity.usp_CompanyInfoSelectAllByRoleId(roleId).ToList();

                    return lstCompanyInfoResult.Select(companyinfo => new CompanyInfo
                    {
                        CompanyId = companyinfo.CompanyID,
                        CompanyName = companyinfo.CompanyName,
                        Address1 = companyinfo.Address1,
                        Address2 = companyinfo.Address2,
                        City = companyinfo.City,
                        ZIP = companyinfo.ZIP,
                        CountryId = companyinfo.CountryID,
                        StateId = companyinfo.StateID,
                        Phone = companyinfo.Phone,
                        CompanyEmail = companyinfo.CompanyEmail,
                        Status = companyinfo.Status,
                        CompanyCode = companyinfo.CompanyCode
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CompanyInfo GetEditCompanyInfo(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_CompanyInfoSelectAllByCompanyId_Result> lstCompanyInfoResult = hrmsEntity.usp_CompanyInfoSelectAllByCompanyId(companyId).ToList();
                    var companyInfoList = lstCompanyInfoResult.Select(companyinfo => new CompanyInfo
                    {
                        CompanyId = companyinfo.CompanyID,
                        CompanyName = companyinfo.CompanyName,
                        Address1 = companyinfo.Address1,
                        Address2 = companyinfo.Address2,
                        City = companyinfo.City,
                        ZIP = companyinfo.ZIP,
                        CountryId = companyinfo.CountryID,
                        StateId = companyinfo.StateID,
                        Phone = companyinfo.Phone,
                        CompanyEmail = companyinfo.CompanyEmail,
                        Status = companyinfo.Status,
                        CompanyCode = companyinfo.CompanyCode,
                        ControlType = companyinfo.ControlType,
                        CorporateStructureId = companyinfo.CorporateStructureID,
                        LegalStructureId = companyinfo.LegalStructureID,
                        ParentId = companyinfo.ParentID,
                        Description = companyinfo.Description,
                        FEIN = companyinfo.FEIN,
                        FromDate = companyinfo.FromDate,
                        ToDate = companyinfo.ToDate,
                        Activity = companyinfo.Activity,
                        Website = companyinfo.Website,
                        FISCYear = companyinfo.FISCYear,
                        Currency = companyinfo.Currency,
                        Language = companyinfo.Language,
                        TimeZone = companyinfo.TimeZone,
                        Association = companyinfo.Association,
                        SubscriptionCode = companyinfo.SubscriptionCode,
                        DatabaseName = companyinfo.DatabaseName,
                        ServerName = companyinfo.ServerName,
                        IsPositionManaged = companyinfo.IsPositionManaged,
                        TimeProvider = companyinfo.TimeProvider,
                        PayrollProvider = companyinfo.PayrollProvider
                    }).ToList();
                    return companyInfoList.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CompanyInfo> GetAllCompanyInfo()
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_CompanyInfoSelectAllCompanies_Result> lstCompanyInfoResult = hrmsEntity.usp_CompanyInfoSelectAllCompanies().ToList();
                    var companyInfoList = lstCompanyInfoResult.Select(companyInfoObj => new CompanyInfo
                    {
                        CompanyId = companyInfoObj.CompanyId,
                        CompanyName = companyInfoObj.CompanyName,
                        Address1 = companyInfoObj.Address1,
                        Address2 = companyInfoObj.Address2,
                        City = companyInfoObj.City,
                        ZIP = companyInfoObj.ZIP,
                        CountryId = companyInfoObj.CountryId
                    }).ToList();
                    return companyInfoList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsTitleExists(CompanyInfo companyInfoObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var companyInfoObjList = hrmsEntity.CompanyInfo.ToList();
                    CompanyInfo companyInfoObj1 = companyInfoObjList.Where(m => m.CompanyId != companyInfoObj.CompanyId && m.CompanyName.ToLower() == companyInfoObj.CompanyName.ToLower()).FirstOrDefault();
                    if (companyInfoObj1 != null)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
