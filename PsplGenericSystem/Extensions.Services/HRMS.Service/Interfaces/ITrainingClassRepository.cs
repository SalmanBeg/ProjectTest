using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Interfaces
{
    public interface ITrainingClassRepository
    {
        [Logger]
        [ExceptionLogger]
        bool addTrainingClass(TrainingClass trainingClassObj);

        [Logger]
        [ExceptionLogger]
        List<TrainingClass> SelectAllTrainingClass(int companyId);

        [Logger]
        [ExceptionLogger]
        TrainingClass SelectTrainingclassById(int companyId, int trainingClassId);

        [Logger]
        [ExceptionLogger]
        bool UpdateTrainingClass(TrainingClass trainingClassObj);

        [Logger]
        [ExceptionLogger]
        bool DeleteTrainingClass(int trainingClassId, int companyId);
    }
}
