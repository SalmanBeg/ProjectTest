using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class TrainingEmployeeRepository : ITrainingEmployeeRepository
    {
        public bool TrainingEmployeeView(TrainingEmployeeView trainingEmployeeViewobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_TrainingEmployeeViewInsert(trainingEmployeeViewobj.CompanyId, trainingEmployeeViewobj.ClassName
                               , trainingEmployeeViewobj.CompletionDate, trainingEmployeeViewobj.ExpirationDate, trainingEmployeeViewobj.CertificateFile
                               , trainingEmployeeViewobj.CreatedBy, trainingEmployeeViewobj.CreatedOn);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateTrainingEmployee(TrainingEmployeeView trainingEmployeeViewobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_TrainingEmployeeViewUpdate(trainingEmployeeViewobj.TrainingEmployeeViewId, trainingEmployeeViewobj.CompanyId
                               , trainingEmployeeViewobj.ClassName, trainingEmployeeViewobj.CompletionDate, trainingEmployeeViewobj.ExpirationDate
                               , trainingEmployeeViewobj.CertificateFile, trainingEmployeeViewobj.CreatedBy, trainingEmployeeViewobj.ModifiedBy);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool DeleteTrainingEmployee(int trainingEmployeeViewId, int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_TrainingEmployeeViewDelete(trainingEmployeeViewId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<TrainingEmployeeView> SelectAllTrainingEmployee(int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingEmployeeViewResult = hrmsEntity.usp_TrainingEmployeeViewSelectAll(companyId).ToList();
                    return lstTrainingEmployeeViewResult.Select(trainingEmployeeViewObj => new TrainingEmployeeView
                    // return lstTrainingEmployeeViewResult.Select(trainingEmployeeViewObj => new TrainingEmployeeView
                    {
                        TrainingEmployeeViewId = trainingEmployeeViewObj.TrainingEmployeeViewId,
                        CompanyId = trainingEmployeeViewObj.CompanyId,
                        ClassName = trainingEmployeeViewObj.ClassName,
                        CompletionDate = trainingEmployeeViewObj.CompletionDate,
                        ExpirationDate = trainingEmployeeViewObj.ExpirationDate,
                        CertificateFile = trainingEmployeeViewObj.CertificateFile,
                        CreatedOn = trainingEmployeeViewObj.CreatedOn,
                        ModifiedOn = trainingEmployeeViewObj.ModifiedOn
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
