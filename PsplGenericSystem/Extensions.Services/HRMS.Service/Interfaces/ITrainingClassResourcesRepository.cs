using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRMS.Service.Models.ExtensionProc;
using System.Data;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public  interface ITrainingClassResourcesRepository
    {
        //[Logger]
        //[ExceptionLogger]
        //int InserAndUpdateTrainingClassResource(TrainingClassResource trainingClassScheduleObj);
        bool AddTrainingResources(int UserId, List<ExtendedStoredProcedures.UdtResourceIdTable> lstUdtTrainingClassResourceIds);

        [Logger]
        [ExceptionLogger]
        List<TrainingClassResource> GetTrainingClassResources(int companyId);

        [Logger]
        [ExceptionLogger]
        List<TrainingClassResource> GetTrainingClassResourcesByClassId(int trainingClassId, int companyId);

        [Logger]
        [ExceptionLogger]
        bool InsertTrainingClassResourcesContentBulk(DataTable dtTrainingClassResource);

        [Logger]
        [ExceptionLogger]
        bool UpdateTrainingClassResourcesContentBulk(DataTable dtTrainingClassResource);
      
    }
}
