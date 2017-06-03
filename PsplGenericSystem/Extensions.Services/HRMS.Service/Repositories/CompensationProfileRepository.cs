using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Repositories
{
    public class CompensationProfileRepository : ICompensationProfileRepository
    {


        public List<CompensationProfile> SelectAllCompensationProfiles(int intcompanyid)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    return hrmsEntity.CompensationProfile.Where(c => c.CompanyId == intcompanyid).ToList(); 
                }
            }
            catch (Exception)
            {               
                throw;
            }
        }

        public CompensationProfile SelectAllCompensationProfileById(int intCompensationProfileId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    return hrmsEntity.CompensationProfile.Where(c => c.CompensationProfileId == intCompensationProfileId).SingleOrDefault(); 
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }



        public int AddCompensationProfile(CompensationProfile objCompensation)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var res = hrmsEntity.usp_CompensationProfileInsert(objCompensation.SalaryGrade, objCompensation.BenefitGroup, objCompensation.Stock, objCompensation.OtherCashComp
                    , objCompensation.PTOPlan, objCompensation.OtherBenefits, objCompensation.CompanyId, objCompensation.WageType, objCompensation.WageUnit, objCompensation.WageAmount
                    , objCompensation.Commissions, objCompensation.Bonus, objCompensation.Amount, objCompensation.Type, objCompensation.AnnualizedPay, objCompensation.Title);

                    return res; 
                }
            }
            catch (Exception)
            {               
                throw;
            }
        }


        public int UpdateCompensationProfile(CompensationProfile objCompensation)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var res = hrmsEntity.usp_CompensationProfileUpdate(objCompensation.CompensationProfileId, objCompensation.SalaryGrade, objCompensation.BenefitGroup, objCompensation.Stock, objCompensation.OtherCashComp
                           , objCompensation.PTOPlan, objCompensation.OtherBenefits, objCompensation.CompanyId, objCompensation.WageType, objCompensation.WageUnit, objCompensation.WageAmount
                           , objCompensation.Commissions, objCompensation.Bonus, objCompensation.Amount, objCompensation.Type, objCompensation.AnnualizedPay, objCompensation.Title);

                    return res; 
                }
            }
            catch (Exception)
            {
               
                throw;
            }

        }


        public int DeleteCompensationProfile(string CompensationprofileIds)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    foreach (var CompProfileId in CompensationprofileIds.Split(','))
                    {
                        CompensationProfile objComp = SelectAllCompensationProfileById(Convert.ToInt32(CompProfileId));


                        hrmsEntity.CompensationProfile.Attach(objComp);
                        hrmsEntity.CompensationProfile.Remove(objComp);
                    }

                    var result = hrmsEntity.SaveChanges();
                    return result; 
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }


        public bool IsTitleExists(CompensationProfile compensationProfileObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var compensationProfileList = hrmsEntity.CompensationProfile.ToList();
                    CompensationProfile compensationProfileObj1 = compensationProfileList.Where(m => m.CompanyId == compensationProfileObj.CompanyId && m.Title.ToLower() == compensationProfileObj.Title.ToLower() && m.CompensationProfileId != compensationProfileObj.CompensationProfileId).FirstOrDefault();
                    if (compensationProfileObj1 != null)
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