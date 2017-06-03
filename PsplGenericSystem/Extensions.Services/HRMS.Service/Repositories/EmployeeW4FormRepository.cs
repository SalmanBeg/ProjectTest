using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class EmployeeW4FormRepository
    {

        public bool AddEmployeeW4Form(EmployeeW4Form employeeW4formobj)
        {
            
            try
            {
                using ( var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));

                    var result = hrmsEntity.usp_Employeew4FormsInsert(employeeW4formobj.UserId, employeeW4formobj.CompanyId, employeeW4formobj.PersonalAllowancesA, employeeW4formobj.PersonalAllowancesB
                        , employeeW4formobj.PersonalAllowancesC, employeeW4formobj.PersonalAllowancesD, employeeW4formobj.PersonalAllowancesE, employeeW4formobj.PersonalAllowancesF
                            , employeeW4formobj.PersonalAllowancesG, employeeW4formobj.PersonalAllowancesH, employeeW4formobj.FirstName, employeeW4formobj.LastName
                            , employeeW4formobj.SSNNO, employeeW4formobj.HomeAddress, employeeW4formobj.CityTownStateZip, employeeW4formobj.EmployeesWithHolding3, employeeW4formobj.EmployeesWithHolding4
                            , employeeW4formobj.EmployeesWithHolding5, employeeW4formobj.EmployeesWithHolding6, employeeW4formobj.EmployeesWithHolding7, employeeW4formobj.EmployeeSignId, employeeW4formobj.SignDate
                            , employeeW4formobj.EmployerAddress, employeeW4formobj.EmployeeOfficeCode, employeeW4formobj.IdentificationNo, employeeW4formobj.Deductions1, employeeW4formobj.Deductions2
                            , employeeW4formobj.Deductions3, employeeW4formobj.Deductions4, employeeW4formobj.Deductions5, employeeW4formobj.Deductions6, employeeW4formobj.Deductions7
                            , employeeW4formobj.Deductions8, employeeW4formobj.Deductions9, employeeW4formobj.Deductions10, employeeW4formobj.Earnings1, employeeW4formobj.Earnings2
                            , employeeW4formobj.Earnings3, employeeW4formobj.Earnings4, employeeW4formobj.Earnings5, employeeW4formobj.Earnings6, employeeW4formobj.Earnings7
                            , employeeW4formobj.Earnings8, employeeW4formobj.Earnings9, employeeW4formobj.CreatedBy, output);

                    return result > 0; 
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public EmployeeW4Form SelectEmployeeW4FormDetailByUserId(int userId, int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeW4Result = hrmsEntity.usp_Employeew4FormsSelect(companyId, userId).ToList();
                    var employeeW4FormList = lstEmployeeW4Result.Select(employeeW4Obj => new EmployeeW4Form
                    {
                        Employeew4formId = employeeW4Obj.Employeew4formId,
                        FirstName = employeeW4Obj.FirstName,
                        LastName = employeeW4Obj.LastName,
                        UserId = employeeW4Obj.UserId,
                        CompanyId = employeeW4Obj.CompanyId,
                        PersonalAllowancesA = employeeW4Obj.PersonalAllowancesA,
                        PersonalAllowancesB = employeeW4Obj.PersonalAllowancesB,
                        PersonalAllowancesC = employeeW4Obj.PersonalAllowancesC,
                        PersonalAllowancesD = employeeW4Obj.PersonalAllowancesD,
                        PersonalAllowancesE = employeeW4Obj.PersonalAllowancesE,
                        PersonalAllowancesF = employeeW4Obj.PersonalAllowancesF,
                        PersonalAllowancesG = employeeW4Obj.PersonalAllowancesG,
                        PersonalAllowancesH = employeeW4Obj.PersonalAllowancesH,
                        SSNNO = employeeW4Obj.SSNNO,
                        HomeAddress = employeeW4Obj.HomeAddress,
                        CityTownStateZip = employeeW4Obj.CityTownStateZip,
                        EmployeesWithHolding3 = employeeW4Obj.EmployeesWithHolding3,
                        EmployeesWithHolding4 = employeeW4Obj.EmployeesWithHolding4,
                        EmployeesWithHolding5 = employeeW4Obj.EmployeesWithHolding5,
                        EmployeesWithHolding6 = employeeW4Obj.EmployeesWithHolding6,
                        EmployeesWithHolding7 = employeeW4Obj.EmployeesWithHolding7,
                        EmployeeSignId = employeeW4Obj.EmployeeSignId,
                        SignDate = employeeW4Obj.SignDate,
                        EmployerAddress = employeeW4Obj.EmployerAddress,
                        EmployeeOfficeCode = employeeW4Obj.EmployeeOfficeCode,
                        IdentificationNo = employeeW4Obj.IdentificationNo,
                        Deductions1 = employeeW4Obj.Deductions1,
                        Deductions2 = employeeW4Obj.Deductions2,
                        Deductions3 = employeeW4Obj.Deductions3,
                        Deductions4 = employeeW4Obj.Deductions4,
                        Deductions5 = employeeW4Obj.Deductions5,
                        Deductions6 = employeeW4Obj.Deductions6,
                        Deductions7 = employeeW4Obj.Deductions7,
                        Deductions8 = employeeW4Obj.Deductions8,
                        Deductions9 = employeeW4Obj.Deductions9,
                        Deductions10 = employeeW4Obj.Deductions10,
                        Earnings1 = employeeW4Obj.Earnings1,
                        Earnings2 = employeeW4Obj.Earnings2,
                        Earnings3 = employeeW4Obj.Earnings3,
                        Earnings4 = employeeW4Obj.Earnings4,
                        Earnings5 = employeeW4Obj.Earnings5,
                        Earnings6 = employeeW4Obj.Earnings6,
                        Earnings7 = employeeW4Obj.Earnings7,
                        Earnings8 = employeeW4Obj.Earnings8,
                        Earnings9 = employeeW4Obj.Earnings9
                    }).ToList();

                    return employeeW4FormList.FirstOrDefault();
                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public bool UpdateEmployeeW4FormDetail(EmployeeW4Form employeeW4formobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                   
                    var result = hrmsEntity.usp_Employeew4FormsUpdate(employeeW4formobj.Employeew4formId, employeeW4formobj.CompanyId, employeeW4formobj.PersonalAllowancesA, employeeW4formobj.PersonalAllowancesB
                        , employeeW4formobj.PersonalAllowancesC, employeeW4formobj.PersonalAllowancesD, employeeW4formobj.PersonalAllowancesE, employeeW4formobj.PersonalAllowancesF
                            , employeeW4formobj.PersonalAllowancesG, employeeW4formobj.PersonalAllowancesH, employeeW4formobj.FirstName, employeeW4formobj.LastName
                            , employeeW4formobj.SSNNO, employeeW4formobj.HomeAddress, employeeW4formobj.CityTownStateZip, employeeW4formobj.EmployeesWithHolding3, employeeW4formobj.EmployeesWithHolding4
                            , employeeW4formobj.EmployeesWithHolding5, employeeW4formobj.EmployeesWithHolding6, employeeW4formobj.EmployeesWithHolding7, employeeW4formobj.EmployeeSignId, employeeW4formobj.SignDate
                            , employeeW4formobj.EmployerAddress, employeeW4formobj.EmployeeOfficeCode, employeeW4formobj.IdentificationNo, employeeW4formobj.Deductions1, employeeW4formobj.Deductions2
                            , employeeW4formobj.Deductions3, employeeW4formobj.Deductions4, employeeW4formobj.Deductions5, employeeW4formobj.Deductions6, employeeW4formobj.Deductions7
                            , employeeW4formobj.Deductions8, employeeW4formobj.Deductions9, employeeW4formobj.Deductions10, employeeW4formobj.Earnings1, employeeW4formobj.Earnings2
                            , employeeW4formobj.Earnings3, employeeW4formobj.Earnings4, employeeW4formobj.Earnings5, employeeW4formobj.Earnings6, employeeW4formobj.Earnings7
                            , employeeW4formobj.Earnings8, employeeW4formobj.Earnings9, employeeW4formobj.ModifiedBy);

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
