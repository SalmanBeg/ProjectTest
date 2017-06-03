using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class TrainingClassRepository : ITrainingClassRepository
    {
        public bool addTrainingClass(TrainingClass trainingClassObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var success = hrmsEntity.usp_TrainingClassInsert(trainingClassObj.TrainingClassName,
                               trainingClassObj.TrainingClassDescription,
                               trainingClassObj.TrainingClassCost,
                               trainingClassObj.TrainingClassHours,
                               trainingClassObj.TrainingClassImage,
                               trainingClassObj.CompanyId,
                               trainingClassObj.CreatedBy);

                    return success > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<TrainingClass> SelectAllTrainingClass(int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingClassResult = hrmsEntity.usp_TrainingClassSelectAll(companyId).ToList();
                    var trainingClassList = lstTrainingClassResult.Select(trainingClassObj => new TrainingClass
                    {
                        TrainingClassName = trainingClassObj.TrainingClassName,
                        TrainingClassCost = trainingClassObj.TrainingClassCost,
                        TrainingClassDescription = trainingClassObj.TrainingClassDescription,
                        TrainingClassImage = trainingClassObj.TrainingClassId,
                        CompanyId = trainingClassObj.CompanyId,
                        TrainingClassId = trainingClassObj.TrainingClassId
                    }).ToList();
                    return trainingClassList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TrainingClass SelectTrainingclassById(int companyId, int trainingClassId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var trainingClassResult = hrmsEntity.usp_TrainingClassSelectById(companyId, trainingClassId).SingleOrDefault();
                    var trainingClassObj = new TrainingClass
                    {
                        CompanyId = trainingClassResult.CompanyId,
                        TrainingClassId = trainingClassResult.TrainingClassId,
                        TrainingClassImage = trainingClassResult.TrainingClassImage,
                        TrainingClassName = trainingClassResult.TrainingClassName,
                        TrainingClassHours = trainingClassResult.TrainingClassHours,
                        TrainingClassCost = trainingClassResult.TrainingClassCost,
                        TrainingClassDescription = trainingClassResult.TrainingClassDescription
                    };

                    return trainingClassObj;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateTrainingClass(TrainingClass trainingClassObj)
        {
            var success = 0;
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    success = hrmsEntity.usp_TrainingClassUpdate(trainingClassObj.TrainingClassId,
                               trainingClassObj.TrainingClassName,
                               trainingClassObj.TrainingClassDescription,
                               trainingClassObj.TrainingClassCost,
                               trainingClassObj.TrainingClassHours,
                               trainingClassObj.TrainingClassImage,
                               trainingClassObj.CompanyId,
                               trainingClassObj.CreatedBy);
                    return (success > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteTrainingClass(int trainingClassId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingClassResult = hrmsEntity.usp_TrainingClassDelete(trainingClassId, companyId);
                    return lstTrainingClassResult > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

