using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Models.ExtensionProc;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkExtras.EF6;

namespace HRMS.Service.Repositories
{
    public class TrainingClassResourcesRepository : ITrainingClassResourcesRepository
    {

        public bool AddTrainingResources(int UserId, List<ExtendedStoredProcedures.UdtResourceIdTable> lstUdtTrainingClassResourceIds)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var proc = new ExtendedStoredProcedures.UspTrainingClassResourceInsert()
                           {

                               CreateOrModifyUserId = UserId,
                               ResourceIdTable = lstUdtTrainingClassResourceIds.Select(classResourceIds => new ExtendedStoredProcedures.UdtResourceIdTable
                               {
                                   TrainingClassResourceId = classResourceIds.TrainingClassResourceId,
                                   TrainingClassId = classResourceIds.TrainingClassId,
                                   ContentType = classResourceIds.ContentType,
                                   Attachment = classResourceIds.Attachment,
                                   Filename = classResourceIds.Filename
                               }).ToList()


                           };
                    hrmsEntity.Database.ExecuteStoredProcedure(proc);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
        public List<TrainingClassResource> GetTrainingClassResources(int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingClassResourcesResult = hrmsEntity.usp_GetTrainingClassResources(companyId).ToList();
                    return lstTrainingClassResourcesResult.Select(trainingClassResourceObj => new TrainingClassResource
                    {
                        Attachment = Convert.ToInt32(trainingClassResourceObj.Attachment),
                        FileName = trainingClassResourceObj.FileName,
                        ContentType = trainingClassResourceObj.ContentType,
                        TrainingClassId = trainingClassResourceObj.TrainingClassId,
                        TrainingClassResourceId = trainingClassResourceObj.TrainingClassResourceId
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<TrainingClassResource> GetTrainingClassResourcesByClassId(int trainingClassId, int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingClassResourcesResult = hrmsEntity.usp_GetTrainingClassResourcesByClassId(trainingClassId, companyId).ToList();
                    return lstTrainingClassResourcesResult.Select(trainingClassResourceObj => new TrainingClassResource
                    {
                        Attachment = Convert.ToInt32(trainingClassResourceObj.Attachment),
                        FileName = trainingClassResourceObj.FileName,
                        ContentType = trainingClassResourceObj.ContentType,
                        TrainingClassId = trainingClassResourceObj.TrainingClassId,
                        TrainingClassResourceId = trainingClassResourceObj.TrainingClassResourceId
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool InsertTrainingClassResourcesContentBulk(DataTable dtTrainingClassResource)
        {

            try
            {
                var parameter = new SqlParameter("@udt_TrainingClassResources", SqlDbType.Structured);
                parameter.Value = dtTrainingClassResource;
                parameter.TypeName = "HumanResources.TrainingClassResources";
                using (var db = new HRMSEntities1())
                {
                    db.Database.ExecuteSqlCommand("exec HumanResources.usp_InsertTrainingClassResourcesContentBulk @udt_TrainingClassResources", parameter);
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateTrainingClassResourcesContentBulk(DataTable dtTrainingClassResource)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var parameter = new SqlParameter("@udt_TrainingClassResources", SqlDbType.Structured);
                    parameter.Value = dtTrainingClassResource;
                    parameter.TypeName = "HumanResources.TrainingClassResources";
                    using (var db = new HRMSEntities1())
                    {
                        db.Database.ExecuteSqlCommand("exec HumanResources.usp_UpdateTrainingClassResourcesContentBulk @udt_TrainingClassResources", parameter);
                    }

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
