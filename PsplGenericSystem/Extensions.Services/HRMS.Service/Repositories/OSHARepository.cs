using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class OSHARepository : IOSHARepository
    {
        public bool CreateEmployeeOSHA(EmployeeOSHA employeeoshaobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("OshaDetailId", typeof(int));
                    var result = hrmsEntity.usp_EmployeeOSHAInsert(employeeoshaobj.UserId, employeeoshaobj.CompanyId, employeeoshaobj.CaseNumber
                        , employeeoshaobj.IncidentDateTime, employeeoshaobj.IsNotReported, employeeoshaobj.MedicalCosts, employeeoshaobj.Advisor
                        , employeeoshaobj.CaseClosedOn, employeeoshaobj.CompletedBy, employeeoshaobj.WorkPhone, employeeoshaobj.FiledOn
                        , employeeoshaobj.ClaimType, employeeoshaobj.OutCome, employeeoshaobj.IsEmployeeinEmergency, employeeoshaobj.IsEmployeeInPatient
                        , employeeoshaobj.Physician, employeeoshaobj.Street, employeeoshaobj.Facility, employeeoshaobj.City, employeeoshaobj.CountryId
                        , employeeoshaobj.StateId, employeeoshaobj.Zip, employeeoshaobj.IncidentDetailsMisc1, employeeoshaobj.IncidentDetailsMisc2
                        , employeeoshaobj.IncidentDetailsMisc3, employeeoshaobj.InjuryDetailsMisc1, employeeoshaobj.InjuryDetailsMisc2
                        , employeeoshaobj.InjuryDetailsMisc3, employeeoshaobj.CreatedBy, employeeoshaobj.ModifiedBy, employeeoshaobj.JobTitle, output);
                    if (result != null)
                        return true;
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool UpdateEmployeeOSHA(EmployeeOSHA employeeoshaobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeOSHAUpdate(employeeoshaobj.UserId, employeeoshaobj.CompanyId, employeeoshaobj.CaseNumber
                               , employeeoshaobj.EmployeeOSHAId, employeeoshaobj.IncidentDateTime, employeeoshaobj.IsNotReported
                               , employeeoshaobj.MedicalCosts, employeeoshaobj.Advisor, employeeoshaobj.CaseClosedOn, employeeoshaobj.CompletedBy
                               , employeeoshaobj.WorkPhone, employeeoshaobj.FiledOn, employeeoshaobj.ClaimType, employeeoshaobj.OutCome
                               , employeeoshaobj.IsEmployeeinEmergency, employeeoshaobj.IsEmployeeInPatient, employeeoshaobj.Physician, employeeoshaobj.Street
                               , employeeoshaobj.Facility, employeeoshaobj.City, employeeoshaobj.CountryId, employeeoshaobj.StateId, employeeoshaobj.Zip
                               , employeeoshaobj.IncidentDetailsMisc1, employeeoshaobj.IncidentDetailsMisc2, employeeoshaobj.IncidentDetailsMisc3
                               , employeeoshaobj.InjuryDetailsMisc1, employeeoshaobj.InjuryDetailsMisc2, employeeoshaobj.InjuryDetailsMisc3
                               , employeeoshaobj.CreatedBy, employeeoshaobj.ModifiedBy, employeeoshaobj.JobTitle).ToList();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public EmployeeOSHA SelectEmployeeOSHAById(int employeeOSHAId, int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstOshaResult = hrmsEntity.usp_EmployeeOSHASelectById(employeeOSHAId, companyId).ToList();
                    var employeeoshaList = lstOshaResult.Select(employeeosha => new EmployeeOSHA
                    {
                        UserId = employeeosha.UserId,
                        CompanyId = employeeosha.CompanyId,
                        EmployeeOSHAId = employeeosha.EmployeeOSHAId,
                        EmployeeOSHACode = employeeosha.EmployeeOSHACode,
                        CaseClosedOn = employeeosha.CaseClosedOn,
                        IncidentDateTime = employeeosha.IncidentDateTime,
                        IsNotReported = employeeosha.IsNotReported,
                        MedicalCosts = employeeosha.MedicalCosts,
                        Advisor = employeeosha.Advisor,
                        CaseNumber = employeeosha.CaseNumber,
                        CompletedBy = employeeosha.CompletedBy,
                        WorkPhone = employeeosha.WorkPhone,
                        FiledOn = employeeosha.FiledOn,
                        ClaimType = employeeosha.ClaimType,
                        JobTitle = employeeosha.JobTitle,
                        OutCome = employeeosha.OutCome,
                        IsEmployeeinEmergency = employeeosha.IsEmployeeinEmergency,
                        IsEmployeeInPatient = employeeosha.IsEmployeeInPatient,
                        Physician = employeeosha.Physician,
                        Street = employeeosha.Street,
                        Facility = employeeosha.Facility,
                        City = employeeosha.City,
                        CountryId = employeeosha.CountryId,
                        StateId = employeeosha.StateId,
                        Zip = employeeosha.Zip,
                        IncidentDetailsMisc1 = employeeosha.IncidentDetailsMisc1,
                        IncidentDetailsMisc2 = employeeosha.IncidentDetailsMisc2,
                        IncidentDetailsMisc3 = employeeosha.IncidentDetailsMisc3,
                        InjuryDetailsMisc1 = employeeosha.InjuryDetailsMisc1,
                        InjuryDetailsMisc2 = employeeosha.InjuryDetailsMisc2,
                        InjuryDetailsMisc3 = employeeosha.InjuryDetailsMisc3,
                        CreatedBy = employeeosha.CreatedBy,
                        ModifiedBy = employeeosha.ModifiedBy
                    }).ToList();
                    return employeeoshaList.SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<EmployeeOSHA> SelectEmployeeOSHA(int userId, int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstOshaResult = hrmsEntity.usp_EmployeeOSHASelect(userId, companyId).ToList();
                    return lstOshaResult.Select(employeeosha => new EmployeeOSHA
                    {
                        UserId = employeeosha.UserId,
                        CompanyId = employeeosha.CompanyId,
                        EmployeeOSHAId = employeeosha.EmployeeOSHAId,
                        EmployeeOSHACode = employeeosha.EmployeeOSHACode,
                        CaseClosedOn = employeeosha.CaseClosedOn,
                        JobTitle = employeeosha.JobTitle,
                        IncidentDateTime = employeeosha.IncidentDateTime,
                        IsNotReported = employeeosha.IsNotReported,
                        MedicalCosts = employeeosha.MedicalCosts,
                        Advisor = employeeosha.Advisor,
                        CaseNumber = employeeosha.CaseNumber,
                        CompletedBy = employeeosha.CompletedBy,
                        WorkPhone = employeeosha.WorkPhone,
                        FiledOn = employeeosha.FiledOn,
                        ClaimType = employeeosha.ClaimType,
                        OutCome = employeeosha.OutCome,
                        IsEmployeeinEmergency = employeeosha.IsEmployeeinEmergency,
                        IsEmployeeInPatient = employeeosha.IsEmployeeInPatient,
                        Physician = employeeosha.Physician,
                        Street = employeeosha.Street,
                        Facility = employeeosha.Facility,
                        City = employeeosha.City,
                        CountryId = employeeosha.CountryId,
                        StateId = employeeosha.StateId,
                        Zip = employeeosha.Zip,
                        IncidentDetailsMisc1 = employeeosha.IncidentDetailsMisc1,
                        IncidentDetailsMisc2 = employeeosha.IncidentDetailsMisc2,
                        IncidentDetailsMisc3 = employeeosha.IncidentDetailsMisc3,
                        InjuryDetailsMisc1 = employeeosha.InjuryDetailsMisc1,
                        InjuryDetailsMisc2 = employeeosha.InjuryDetailsMisc2,
                        InjuryDetailsMisc3 = employeeosha.InjuryDetailsMisc3,
                        CreatedBy = employeeosha.CreatedBy,
                        ModifiedBy = employeeosha.ModifiedBy
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }


        }
        public bool DeleteOSHA(int oshaDetailId, int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeOSHADelete(oshaDetailId, companyId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool CaseNoExists(EmployeeOSHA employeeoshaobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var oshalist = hrmsEntity.EmployeeOSHAs.ToList();
                    var oshaObj1 = oshalist.SingleOrDefault(m => m.CompanyId == employeeoshaobj.CompanyId && m.CaseNumber == employeeoshaobj.CaseNumber && m.EmployeeOSHAId != employeeoshaobj.EmployeeOSHAId);
                    if (oshaObj1 != null)
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


