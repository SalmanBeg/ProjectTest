using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Models.ExtensionProc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkExtras.EF6;

namespace HRMS.Service.Repositories
{
    public class TrainingTrackRepository : ITrainingTrackRepository
    {
        public List<TrainingTrack> SelectAllTrainingTrack(int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingTrackResult = hrmsEntity.usp_TrainingTrackSelect(companyId).ToList();
                    return lstTrainingTrackResult.Select(trainingTrack => new TrainingTrack
                    {
                        CompanyId = trainingTrack.CompanyId,
                        TrainingTrackName = trainingTrack.TrainingTrackName,
                        TrainingTrackDescription = trainingTrack.TrainingTrackDescription,
                        TrainingTrackId = trainingTrack.TrainingTrackId
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TrainingTrack SelectTrainingTrackById(int companyId, int trainingTrackId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingTrackResult = hrmsEntity.usp_TrainingTrackSelectById(companyId, trainingTrackId).ToList();
                    return lstTrainingTrackResult.Select(trainingTrack => new TrainingTrack
                    {
                        CompanyId = trainingTrack.CompanyId,
                        TrainingTrackName = trainingTrack.TrainingTrackName,
                        TrainingTrackDescription = trainingTrack.TrainingTrackDescription,
                        TrainingTrackId = trainingTrack.TrainingTrackId
                    }).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddTrainingTrack(TrainingTrack trainingTrackObj, List<ExtendedStoredProcedures.UdtTrainingClassIds> lstUdtTrainingClassIds)
        {

            try
            {

                using (var hrmsEntity = new HRMSEntities1())
                {
                    var proc = new ExtendedStoredProcedures.UspTrainingTrackInsert()
                            {
                                TrainingTrackName = trainingTrackObj.TrainingTrackName,
                                TrainingTrackDescription = trainingTrackObj.TrainingTrackDescription,
                                CompanyId = trainingTrackObj.CompanyId,
                                CreatedBy = trainingTrackObj.CreatedBy,
                                TrainingTrackId = trainingTrackObj.TrainingTrackId,

                                ClassIdTable = lstUdtTrainingClassIds.Select(classIds => new ExtendedStoredProcedures.UdtTrainingClassIds
                                {
                                    TrainingTrackId = classIds.TrainingTrackId,
                                    TrainingClassId = classIds.TrainingClassId
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

        public bool UpdateTrainingTrack(TrainingTrack trainingTrackObj, List<ExtendedStoredProcedures.UdtTrainingClassIds> lstUdtTrainingClassIds)
        {

            try
            {

                using (var hrmsEntity = new HRMSEntities1())
                {
                    var proc = new ExtendedStoredProcedures.UspTrainingTrackUpdate()
                          {
                              TrainingTrackName = trainingTrackObj.TrainingTrackName,
                              TrainingTrackDescription = trainingTrackObj.TrainingTrackDescription,
                              CompanyId = trainingTrackObj.CompanyId,
                              ModifiedBy = trainingTrackObj.CreatedBy,
                              TrainingTrackId = trainingTrackObj.TrainingTrackId,

                              ClassIdTable = lstUdtTrainingClassIds.Select(classIds => new ExtendedStoredProcedures.UdtTrainingClassIds
                              {
                                  TrainingTrackId = classIds.TrainingTrackId,
                                  TrainingClassId = classIds.TrainingClassId,
                                  TrainingTrackClassId = classIds.TrainingTrackClassId
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


        public List<TrainingTrackClass> SelectAllTrainingTrackClass()
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingTrackClassResult = hrmsEntity.usp_TrainingTrackClassSelectAll().ToList();
                    return lstTrainingTrackClassResult.Select(trainingTrackClass => new TrainingTrackClass
                    {
                        TrainingTrackClassId = trainingTrackClass.TrainingTrackClassId,
                        TrainingTrackId = trainingTrackClass.TrainingTrackId,
                        TrainingClassId = trainingTrackClass.TrainingClassId
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TrainingTrackClass SelectTrainingTrackClassById(int trainingTrackClassId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstTrainingTrackClassResult = hrmsEntity.usp_TrainingTrackClassSelectById(trainingTrackClassId).ToList();
                    return lstTrainingTrackClassResult.Select(trainingTrackClass => new TrainingTrackClass
                    {
                        TrainingTrackClassId = trainingTrackClass.TrainingTrackClassId,
                        TrainingTrackId = trainingTrackClass.TrainingTrackId,
                        TrainingClassId = trainingTrackClass.TrainingClassId
                    }).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeletTrainingTrack(int companyId, int trainingTrackId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    int result = hrmsEntity.usp_TrainingTrackDelete(companyId, trainingTrackId);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
