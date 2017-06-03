using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace HRMS.Service.Repositories
{
    public class W4FormRepository : IW4FormRepository
    {
        public bool AddEmployeeW4Form(EmployeeW4Form employeeW4Formobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_Employeew4FormsInsert(employeeW4Formobj.UserId, employeeW4Formobj.CompanyId, employeeW4Formobj.PersonalAllowancesA,
                        employeeW4Formobj.PersonalAllowancesB, employeeW4Formobj.PersonalAllowancesC, employeeW4Formobj.PersonalAllowancesD
                        , employeeW4Formobj.PersonalAllowancesE, employeeW4Formobj.PersonalAllowancesF, employeeW4Formobj.PersonalAllowancesG
                        , employeeW4Formobj.PersonalAllowancesH, employeeW4Formobj.FirstName, employeeW4Formobj.LastName, employeeW4Formobj.SSNNO
                        , employeeW4Formobj.HomeAddress, employeeW4Formobj.CityTownStateZip, employeeW4Formobj.EmployeesWithHolding3, employeeW4Formobj.EmployeesWithHolding4
                        , employeeW4Formobj.EmployeesWithHolding5, employeeW4Formobj.EmployeesWithHolding6, employeeW4Formobj.EmployeesWithHolding7
                        , employeeW4Formobj.EmployeeSignId, employeeW4Formobj.SignDate, employeeW4Formobj.EmployerAddress, employeeW4Formobj.EmployeeOfficeCode
                        , employeeW4Formobj.IdentificationNo, employeeW4Formobj.Deductions1, employeeW4Formobj.Deductions2, employeeW4Formobj.Deductions3
                        , employeeW4Formobj.Deductions4, employeeW4Formobj.Deductions5, employeeW4Formobj.Deductions6, employeeW4Formobj.Deductions7
                        , employeeW4Formobj.Deductions8, employeeW4Formobj.Deductions9, employeeW4Formobj.Deductions10, employeeW4Formobj.Earnings1
                        , employeeW4Formobj.Earnings2, employeeW4Formobj.Earnings3, employeeW4Formobj.Earnings4, employeeW4Formobj.Earnings5, employeeW4Formobj.Earnings6
                        , employeeW4Formobj.Earnings7, employeeW4Formobj.Earnings8, employeeW4Formobj.Earnings9, employeeW4Formobj.CreatedBy, output);

                    return result != 0;
                }
            }
            catch (Exception)
            {
                throw;
            }


        }
        public List<EmployeeW4Form> SelectEmployeeW4FormByUserId(int companyId, int userId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_Employeew4FormsSelect_Result> lstResult = hrmsEntity.usp_Employeew4FormsSelect(companyId, userId).ToList();
                    return lstResult.Select(employeeW4mobj => new EmployeeW4Form
                    {
                        Employeew4formId = employeeW4mobj.Employeew4formId,
                        CompanyId = employeeW4mobj.CompanyId,
                        UserId = employeeW4mobj.UserId,
                        PersonalAllowancesA = employeeW4mobj.PersonalAllowancesA,
                        PersonalAllowancesB = employeeW4mobj.PersonalAllowancesB,
                        PersonalAllowancesC = employeeW4mobj.PersonalAllowancesC,
                        PersonalAllowancesD = employeeW4mobj.PersonalAllowancesD,
                        PersonalAllowancesE = employeeW4mobj.PersonalAllowancesE,
                        PersonalAllowancesF = employeeW4mobj.PersonalAllowancesF,
                        PersonalAllowancesG = employeeW4mobj.PersonalAllowancesG,
                        PersonalAllowancesH = employeeW4mobj.PersonalAllowancesH,
                        LastName = employeeW4mobj.LastName,
                        FirstName = employeeW4mobj.FirstName,
                        SSNNO = employeeW4mobj.SSNNO,
                        HomeAddress = employeeW4mobj.HomeAddress,
                        CityTownStateZip = employeeW4mobj.CityTownStateZip,
                        EmployeesWithHolding3 = employeeW4mobj.EmployeesWithHolding3,
                        EmployeesWithHolding4 = employeeW4mobj.EmployeesWithHolding4,
                        EmployeesWithHolding5 = employeeW4mobj.EmployeesWithHolding5,
                        EmployeesWithHolding6 = employeeW4mobj.EmployeesWithHolding6,
                        EmployeesWithHolding7 = employeeW4mobj.EmployeesWithHolding7,
                        EmployeeSignId = employeeW4mobj.EmployeeSignId,
                        SignDate = employeeW4mobj.SignDate,
                        EmployerAddress = employeeW4mobj.EmployerAddress,
                        EmployeeOfficeCode = employeeW4mobj.EmployeeOfficeCode,
                        IdentificationNo = employeeW4mobj.IdentificationNo,
                        Deductions1 = employeeW4mobj.Deductions1,
                        Deductions2 = employeeW4mobj.Deductions2,
                        Deductions3 = employeeW4mobj.Deductions3,
                        Deductions4 = employeeW4mobj.Deductions4,
                        Deductions5 = employeeW4mobj.Deductions5,
                        Deductions6 = employeeW4mobj.Deductions6,
                        Deductions7 = employeeW4mobj.Deductions7,
                        Deductions8 = employeeW4mobj.Deductions8,
                        Deductions9 = employeeW4mobj.Deductions9,
                        Deductions10 = employeeW4mobj.Deductions10,
                        Earnings1 = employeeW4mobj.Earnings1,
                        Earnings2 = employeeW4mobj.Earnings2,
                        Earnings3 = employeeW4mobj.Earnings3,
                        Earnings4 = employeeW4mobj.Earnings4,
                        Earnings5 = employeeW4mobj.Earnings5,
                        Earnings6 = employeeW4mobj.Earnings6,
                        Earnings7 = employeeW4mobj.Earnings7,
                        Earnings8 = employeeW4mobj.Earnings8,
                        Earnings9 = employeeW4mobj.Earnings9
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool UpdateEmployeeW4Form(EmployeeW4Form employeeW4Formobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_Employeew4FormsUpdate(employeeW4Formobj.Employeew4formId,
                                employeeW4Formobj.CompanyId, employeeW4Formobj.PersonalAllowancesA,
                                employeeW4Formobj.PersonalAllowancesB, employeeW4Formobj.PersonalAllowancesC,
                                employeeW4Formobj.PersonalAllowancesD
                                , employeeW4Formobj.PersonalAllowancesE, employeeW4Formobj.PersonalAllowancesF,
                                employeeW4Formobj.PersonalAllowancesG
                                , employeeW4Formobj.PersonalAllowancesH, employeeW4Formobj.FirstName, employeeW4Formobj.LastName,
                                employeeW4Formobj.SSNNO
                                , employeeW4Formobj.HomeAddress, employeeW4Formobj.CityTownStateZip,
                                employeeW4Formobj.EmployeesWithHolding3, employeeW4Formobj.EmployeesWithHolding4
                                , employeeW4Formobj.EmployeesWithHolding5, employeeW4Formobj.EmployeesWithHolding6,
                                employeeW4Formobj.EmployeesWithHolding7
                                , employeeW4Formobj.EmployeeSignId, employeeW4Formobj.SignDate, employeeW4Formobj.EmployerAddress,
                                employeeW4Formobj.EmployeeOfficeCode
                                , employeeW4Formobj.IdentificationNo, employeeW4Formobj.Deductions1, employeeW4Formobj.Deductions2,
                                employeeW4Formobj.Deductions3
                                , employeeW4Formobj.Deductions4, employeeW4Formobj.Deductions5, employeeW4Formobj.Deductions6,
                                employeeW4Formobj.Deductions7
                                , employeeW4Formobj.Deductions8, employeeW4Formobj.Deductions9, employeeW4Formobj.Deductions10,
                                employeeW4Formobj.Earnings1
                                , employeeW4Formobj.Earnings2, employeeW4Formobj.Earnings3, employeeW4Formobj.Earnings4,
                                employeeW4Formobj.Earnings5, employeeW4Formobj.Earnings6
                                , employeeW4Formobj.Earnings7, employeeW4Formobj.Earnings8, employeeW4Formobj.Earnings9,
                                employeeW4Formobj.ModifiedBy);

                    return result != 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void UpdateSignId(int signId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var result = hrmsEntity.usp_Employeew4FormsUpdate(employeeW4Formobj.Employeew4formId);

                    //return result != 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
