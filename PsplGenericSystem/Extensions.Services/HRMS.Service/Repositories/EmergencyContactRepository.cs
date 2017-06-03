using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class EmergencyContactRepository : IEmergencyContanctRepository
    {
        public bool AddEmergencyContact(EmployeeEmergencyContact employeeEmergencyContactobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeEmergencyContactInsert(employeeEmergencyContactobj.CompanyId, employeeEmergencyContactobj.UserId
                        , employeeEmergencyContactobj.Name, employeeEmergencyContactobj.HomePhone, employeeEmergencyContactobj.WorkPhone
                        , employeeEmergencyContactobj.CellPhone, employeeEmergencyContactobj.PersonalEmail, employeeEmergencyContactobj.WorkEmail
                        , employeeEmergencyContactobj.Relationship, employeeEmergencyContactobj.Street1, employeeEmergencyContactobj.Street2
                        , employeeEmergencyContactobj.City, employeeEmergencyContactobj.CountryId, employeeEmergencyContactobj.StateId
                        , employeeEmergencyContactobj.Zip, employeeEmergencyContactobj.IsPrimaryContact, employeeEmergencyContactobj.CreatedBy
                        , employeeEmergencyContactobj.ModifiedBy).ToList();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        public bool DeleteEmergencyContact(int employeeEmergencyContactId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_EmployeeEmergencyContactDelete(employeeEmergencyContactId, output);
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool UpdateEmergencyContact(EmployeeEmergencyContact employeeEmergencyContactobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeEmergencyContactUpdate(employeeEmergencyContactobj.CompanyId, employeeEmergencyContactobj.UserId
                               , employeeEmergencyContactobj.EmployeeEmergencyContactId, employeeEmergencyContactobj.Name, employeeEmergencyContactobj.HomePhone
                               , employeeEmergencyContactobj.WorkPhone, employeeEmergencyContactobj.CellPhone, employeeEmergencyContactobj.PersonalEmail
                               , employeeEmergencyContactobj.WorkEmail, employeeEmergencyContactobj.Relationship, employeeEmergencyContactobj.Street1
                               , employeeEmergencyContactobj.Street2, employeeEmergencyContactobj.City, employeeEmergencyContactobj.CountryId
                               , employeeEmergencyContactobj.StateId, employeeEmergencyContactobj.Zip, employeeEmergencyContactobj.IsPrimaryContact
                               , employeeEmergencyContactobj.ModifiedBy);
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<EmployeeEmergencyContact> SelectAllEmergencyContact(int userId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_EmployeeEmergencyContactSelectAll_Result> lstEmployeeEmergencyContactResult = hrmsEntity.usp_EmployeeEmergencyContactSelectAll(companyId, userId).ToList();
                    return lstEmployeeEmergencyContactResult.Select(employeEmergencyContact => new EmployeeEmergencyContact
                    {
                        EmployeeEmergencyContactId = employeEmergencyContact.EmployeeEmergencyContactId,
                        EmployeeEmergencyContactCode = employeEmergencyContact.EmployeeEmergencyContactCode,
                        CompanyId = employeEmergencyContact.CompanyId,
                        UserId = employeEmergencyContact.UserId,
                        Name = employeEmergencyContact.Name,
                        HomePhone = employeEmergencyContact.HomePhone,
                        CellPhone = employeEmergencyContact.CellPhone,
                        PersonalEmail = employeEmergencyContact.PersonalEmail,
                        WorkEmail = employeEmergencyContact.WorkEmail,
                        WorkPhone = employeEmergencyContact.WorkPhone,
                        Relationship = employeEmergencyContact.Relationship,
                        Street1 = employeEmergencyContact.Street1,
                        Street2 = employeEmergencyContact.Street2,
                        City = employeEmergencyContact.City,
                        CountryId = employeEmergencyContact.CountryId,
                        StateId = employeEmergencyContact.StateId,
                        Zip = employeEmergencyContact.Zip,
                        IsPrimaryContact = employeEmergencyContact.IsPrimaryContact,
                        RelationshipName = employeEmergencyContact.RelationshipName

                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<EmployeeEmergencyContact> SelectEmergencyContactByEmergencyContactId(int emergencyContactId, int companyId)
        {


            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeEmergencyContactResult = hrmsEntity.usp_EmployeeEmergencyContactSelect(companyId, emergencyContactId).ToList();
                    return lstEmployeeEmergencyContactResult.Select(employeEmergencyContact => new EmployeeEmergencyContact
                    {
                        EmployeeEmergencyContactId = employeEmergencyContact.EmployeeEmergencyContactId,
                        EmployeeEmergencyContactCode = employeEmergencyContact.EmployeeEmergencyContactCode,
                        CompanyId = employeEmergencyContact.CompanyId,
                        UserId = employeEmergencyContact.UserId,
                        Name = employeEmergencyContact.Name,
                        HomePhone = employeEmergencyContact.HomePhone,
                        CellPhone = employeEmergencyContact.CellPhone,
                        PersonalEmail = employeEmergencyContact.PersonalEmail,
                        WorkEmail = employeEmergencyContact.WorkEmail,
                        WorkPhone = employeEmergencyContact.WorkPhone,
                        Relationship = employeEmergencyContact.Relationship,
                        Street1 = employeEmergencyContact.Street1,
                        Street2 = employeEmergencyContact.Street2,
                        City = employeEmergencyContact.City,
                        CountryId = employeEmergencyContact.CountryId,
                        StateId = employeEmergencyContact.StateId,
                        Zip = employeEmergencyContact.Zip,
                        IsPrimaryContact = employeEmergencyContact.IsPrimaryContact
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
