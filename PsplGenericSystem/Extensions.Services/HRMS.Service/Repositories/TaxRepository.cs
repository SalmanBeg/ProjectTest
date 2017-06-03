using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class TaxRepository:ITaxRepository
    {
        public bool CreateEmployeeTax(EmployeeTax employeeTaxobj)
        {
           
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result =
                               hrmsEntity.usp_EmployeeTaxInsert(employeeTaxobj.UserId, employeeTaxobj.CompanyId,
                                   employeeTaxobj.FederalWithholdingStatus
                                   , employeeTaxobj.FederalExemptions, employeeTaxobj.FederalWithholdings,
                                   employeeTaxobj.FederalBlock, employeeTaxobj.FederalMedBlock
                                   , employeeTaxobj.StateTaxesLiveinCountryId, employeeTaxobj.StateTaxesLiveinStateId,
                                   employeeTaxobj.StateTaxesWorkinCountryId
                                   , employeeTaxobj.StateTaxesWorkinStateId, employeeTaxobj.StateTaxesWithholdingStatus,
                                   employeeTaxobj.StateTaxesExemptions
                                   , employeeTaxobj.StateTaxesAdditionalWithholding, employeeTaxobj.StateTaxesTaxBlock,
                                   employeeTaxobj.StateTaxesSUISDIBlock
                                   , employeeTaxobj.StateTaxesSchoolDistrict, employeeTaxobj.StateTaxesSchoolBlock,
                                   employeeTaxobj.LocalTaxesWithholdingStatus
                                   , employeeTaxobj.LocalTaxesAllowancesorExemptions,
                                   employeeTaxobj.LocalTaxesAdditionalWithholdingsAmount
                                   , employeeTaxobj.LocalTaxesAdditionalWithholdingsPercentage, employeeTaxobj.IsLocalTaxExempted,
                                   employeeTaxobj.CreatedBy
                                   , employeeTaxobj.ModifiedBy).ToList();
                    return result.Count > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public bool DeleteEmployeeTax(EmployeeTax employeeTaxobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeTaxDelete(employeeTaxobj.UserId, employeeTaxobj.CompanyId);
                    return result > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public bool UpdateEmployeeTax(EmployeeTax employeeTaxobj)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeTaxUpdate(employeeTaxobj.UserId, employeeTaxobj.CompanyId, employeeTaxobj.FederalWithholdingStatus
                                , employeeTaxobj.FederalExemptions, employeeTaxobj.FederalWithholdings, employeeTaxobj.FederalBlock, employeeTaxobj.FederalMedBlock
                                , employeeTaxobj.StateTaxesLiveinCountryId, employeeTaxobj.StateTaxesLiveinStateId, employeeTaxobj.StateTaxesWorkinCountryId
                                , employeeTaxobj.StateTaxesWorkinStateId, employeeTaxobj.StateTaxesWithholdingStatus, employeeTaxobj.StateTaxesExemptions
                                , employeeTaxobj.StateTaxesAdditionalWithholding, employeeTaxobj.StateTaxesTaxBlock, employeeTaxobj.StateTaxesSUISDIBlock
                                , employeeTaxobj.StateTaxesSchoolDistrict, employeeTaxobj.StateTaxesSchoolBlock, employeeTaxobj.LocalTaxesWithholdingStatus
                                , employeeTaxobj.LocalTaxesAllowancesorExemptions, employeeTaxobj.LocalTaxesAdditionalWithholdingsAmount
                                , employeeTaxobj.LocalTaxesAdditionalWithholdingsPercentage, employeeTaxobj.IsLocalTaxExempted, employeeTaxobj.CreatedBy
                                , employeeTaxobj.ModifiedBy).ToList();
                    return result.Count > 0; 
                }
            }
            catch(Exception)
            {
                throw;
            }
           
        
        }
        public EmployeeTax SelectEmployeeTax(int userId, int companyId)
        {
             
             try
             {
                 using (var hrmsEntity = new HRMSEntities1())
                 {
                     var lstResult = hrmsEntity.usp_EmployeeTaxSelect(userId, companyId).ToList();

                     var employeeTaxList = lstResult.Select(employeeTaxobj => new EmployeeTax
                     {
                         UserId = employeeTaxobj.UserId,
                         CompanyId = employeeTaxobj.CompanyId,
                         EmployeeTaxCode = employeeTaxobj.EmployeeTaxCode,
                         FederalWithholdingStatus = employeeTaxobj.FederalWithholdingStatus,
                         FederalExemptions = employeeTaxobj.FederalExemptions,
                         FederalWithholdings = employeeTaxobj.FederalWithholdings,
                         FederalBlock = employeeTaxobj.FederalBlock,
                         FederalMedBlock = employeeTaxobj.FederalMedBlock,
                         StateTaxesLiveinCountryId = employeeTaxobj.StateTaxesLiveinCountryId,
                         StateTaxesLiveinStateId = employeeTaxobj.StateTaxesLiveinStateId,
                         StateTaxesWorkinCountryId = employeeTaxobj.StateTaxesWorkinCountryId,
                         StateTaxesWorkinStateId = employeeTaxobj.StateTaxesWorkinStateId,
                         StateTaxesWithholdingStatus = employeeTaxobj.StateTaxesWithholdingStatus,
                         StateTaxesExemptions = employeeTaxobj.StateTaxesExemptions,
                         StateTaxesAdditionalWithholding = employeeTaxobj.StateTaxesAdditionalWithholding,
                         StateTaxesTaxBlock = employeeTaxobj.StateTaxesTaxBlock,
                         StateTaxesSUISDIBlock = employeeTaxobj.StateTaxesSUISDIBlock,
                         StateTaxesSchoolBlock = employeeTaxobj.StateTaxesSchoolBlock,
                         StateTaxesSchoolDistrict = employeeTaxobj.StateTaxesSchoolDistrict,
                         LocalTaxesWithholdingStatus = employeeTaxobj.LocalTaxesWithholdingStatus,
                         LocalTaxesAllowancesorExemptions = employeeTaxobj.LocalTaxesAllowancesorExemptions,
                         LocalTaxesAdditionalWithholdingsAmount = employeeTaxobj.LocalTaxesAdditionalWithholdingsAmount,
                         LocalTaxesAdditionalWithholdingsPercentage = employeeTaxobj.LocalTaxesAdditionalWithholdingsPercentage,
                         IsLocalTaxExempted = employeeTaxobj.IsLocalTaxExempted
                     }).ToList();

                     return employeeTaxList.FirstOrDefault(); 
                 }
             }
             catch (Exception)
             {
                 throw;
             }
           
        }
    }
}
