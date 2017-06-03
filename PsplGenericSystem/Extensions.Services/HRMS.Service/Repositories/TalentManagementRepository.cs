using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class TalentManagementRepository : ITalentManagementRepository
    {
        public bool ViewTalentManagements(TalentManagement talentManagementobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_TalentManagementInsert(talentManagementobj.CompanyId, talentManagementobj.SchoolName, talentManagementobj.Location
                              , talentManagementobj.StartDate, talentManagementobj.Graduated, talentManagementobj.GraduationDate, talentManagementobj.GPA
                              , talentManagementobj.HonoraryRecognition, talentManagementobj.Level, talentManagementobj.VerificationDate, talentManagementobj.Major
                              , talentManagementobj.SecondMajor, talentManagementobj.Minor, talentManagementobj.CreatedBy, talentManagementobj.CreatedOn);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateTalentManagement(TalentManagement talentManagementobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_TalentManagementUpdate(talentManagementobj.TalentManagementId, talentManagementobj.CompanyId, talentManagementobj.SchoolName
                              , talentManagementobj.Location, talentManagementobj.StartDate, talentManagementobj.Graduated, talentManagementobj.GraduationDate
                              , talentManagementobj.GPA, talentManagementobj.HonoraryRecognition, talentManagementobj.Level, talentManagementobj.VerificationDate
                              , talentManagementobj.Major, talentManagementobj.SecondMajor, talentManagementobj.Minor, talentManagementobj.ModifiedBy);
                    return result > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<TalentManagement> SelectAllTalentManagement(int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTalentManagementResult = hrmsEntity.usp_TalentManagementSelectAll(companyId).ToList();
                    return lstTalentManagementResult.Select(talentManagementObj => new TalentManagement
                    {
                        LevelName = talentManagementObj.LevelName,
                        CompanyId = talentManagementObj.CompanyId,
                        TalentManagementId = talentManagementObj.TalentManagementId,
                        TalentManagementCode = talentManagementObj.TalentManagementCode,
                        SchoolName = talentManagementObj.SchoolName,
                        Location = talentManagementObj.Location,
                        StartDate = talentManagementObj.StartDate,
                        Graduated = talentManagementObj.Graduated,
                        GraduationDate = talentManagementObj.GraduationDate,
                        GPA = talentManagementObj.GPA,
                        HonoraryRecognition = talentManagementObj.HonoraryRecognition,
                        Level = talentManagementObj.Level,
                        VerificationDate = talentManagementObj.VerificationDate,
                        Major = talentManagementObj.Major,
                        SecondMajor = talentManagementObj.SecondMajor,
                        Minor = talentManagementObj.Minor,
                        CreatedOn = talentManagementObj.CreatedOn,
                        ModifiedOn = talentManagementObj.ModifiedOn

                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<TalentManagement> SelectTalentManagementById( int companyId,int talentManagementId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                   List<usp_TalentManagementSelect_Result> lstTalentManagementResult = hrmsEntity.usp_TalentManagementSelect(companyId,talentManagementId).ToList();
                     return lstTalentManagementResult.Select(talentManagementObj => new TalentManagement
                     {
                        LevelName=talentManagementObj.LevelName,
                        CompanyId = talentManagementObj.CompanyId,
                        TalentManagementId = talentManagementObj.TalentManagementId,
                        TalentManagementCode = talentManagementObj.TalentManagementCode,
                        SchoolName = talentManagementObj.SchoolName,
                        Location = talentManagementObj.Location,
                        StartDate = talentManagementObj.StartDate,
                        Graduated = talentManagementObj.Graduated,
                        GraduationDate = talentManagementObj.GraduationDate,
                        GPA = talentManagementObj.GPA,
                        HonoraryRecognition = talentManagementObj.HonoraryRecognition,
                        Level = talentManagementObj.Level,
                        VerificationDate = talentManagementObj.VerificationDate,
                        Major = talentManagementObj.Major,
                        SecondMajor = talentManagementObj.SecondMajor,
                        Minor = talentManagementObj.Minor,
                        CreatedOn = talentManagementObj.CreatedOn,
                        ModifiedOn = talentManagementObj.ModifiedOn
                     }).ToList();

                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool DeleteTalentManagement(int talentManagementId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTalentManagementResult = hrmsEntity.usp_TalentManagementDelete(talentManagementId);
                    return lstTalentManagementResult > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
