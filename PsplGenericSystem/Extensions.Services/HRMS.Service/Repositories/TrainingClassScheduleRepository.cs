using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class TrainingClassScheduleRepository : ITrainingClassScheduleRepository
    {
        public int InsertAndUpdateTrainingSchedule(TrainingClassSchedule trainingClassScheduleObj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_InsertAndUpdateTrainingClassSchedules(trainingClassScheduleObj.TrainingClassScheduleId, trainingClassScheduleObj.TrainingClassId
                               , trainingClassScheduleObj.EnrollmentStartDate, trainingClassScheduleObj.EnrollmentEndDate, trainingClassScheduleObj.CompanyId
                               , trainingClassScheduleObj.CreatedBy, trainingClassScheduleObj.ModifiedBy);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<TrainingClassSchedule> GetTrainingClassSchedules(int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingClassSchedulesResult = hrmsEntity.usp_GetTrainingClassSchedules(companyId).ToList();
                    return lstTrainingClassSchedulesResult.Select(trainingClassScheduleObj => new TrainingClassSchedule
                    {
                        TrainingClassScheduleId = trainingClassScheduleObj.TrainingClassScheduleId,
                        TrainingClassName = trainingClassScheduleObj.TrainingClassName,
                        TrainingClassId = trainingClassScheduleObj.TrainingClassId,
                        EnrollmentStartDate = Convert.ToDateTime(trainingClassScheduleObj.EnrollmentStartDate),
                        EnrollmentEndDate = Convert.ToDateTime(trainingClassScheduleObj.EnrollmentEndDate),
                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TrainingClassSchedule GetTrainingClassSchedulesById(int trainingClassScheduleId, int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingClassSchedulesResult = hrmsEntity.usp_GetTrainingClassSchedulesById(trainingClassScheduleId, companyId).ToList();
                    return lstTrainingClassSchedulesResult.Select(trainingClassScheduleObj => new TrainingClassSchedule
                    {
                        TrainingClassScheduleId = trainingClassScheduleObj.TrainingClassScheduleId,
                        TrainingClassName = trainingClassScheduleObj.TrainingClassName,
                        TrainingClassId = trainingClassScheduleObj.TrainingClassId,
                        EnrollmentStartDate = Convert.ToDateTime(trainingClassScheduleObj.EnrollmentStartDate),
                        EnrollmentEndDate = Convert.ToDateTime(trainingClassScheduleObj.EnrollmentEndDate),
                    }).SingleOrDefault(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TrainingClassSchedule> GetTrainingClassSchedulesByClassId(int trainingClassId, int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingClassSchedulesResult = hrmsEntity.usp_GetTrainingClassSchedulesByClassId(trainingClassId, companyId).ToList();
                    return lstTrainingClassSchedulesResult.Select(trainingClassScheduleObj => new TrainingClassSchedule
                    {
                        TrainingClassScheduleId = trainingClassScheduleObj.TrainingClassScheduleId,
                        TrainingClassName = trainingClassScheduleObj.TrainingClassName,
                        TrainingClassId = trainingClassScheduleObj.TrainingClassId,
                        EnrollmentStartDate = Convert.ToDateTime(trainingClassScheduleObj.EnrollmentStartDate),
                        EnrollmentEndDate = Convert.ToDateTime(trainingClassScheduleObj.EnrollmentEndDate),
                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertTrainingClassScheduleContentBulk(DataTable dtTrainigclassSchedule)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var parameter = new SqlParameter("@tblClassSchedule", SqlDbType.Structured);
                    parameter.Value = dtTrainigclassSchedule;
                    parameter.TypeName = "HumanResources.TrainingClassSchedule";
                    using (HRMSEntities1 db = new HRMSEntities1())
                    {
                        db.Database.ExecuteSqlCommand("exec HumanResources.usp_InsertTrainingClassScheduleContentBulk @tblClassSchedule", parameter);
                    }

                    return true; 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public bool DeleteTrainingClassSchedule(int trainingClassScheduleId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingClassScheduleResult = hrmsEntity.usp_TrainingClassScheduleDelete(trainingClassScheduleId, companyId);
                    return lstTrainingClassScheduleResult > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
          
        }
    }
}
