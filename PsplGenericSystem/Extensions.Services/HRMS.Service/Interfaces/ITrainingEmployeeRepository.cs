using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public  interface ITrainingEmployeeRepository
    {
        [Logger]
        [ExceptionLogger]
        bool TrainingEmployeeView(TrainingEmployeeView trainingEmployeeViewobj);

        [Logger]
        [ExceptionLogger]
        List<TrainingEmployeeView> SelectAllTrainingEmployee(int companyId);

        [Logger]
        [ExceptionLogger]
        bool UpdateTrainingEmployee(TrainingEmployeeView trainingEmployeeViewobj);

        [Logger]
        [ExceptionLogger]
        bool DeleteTrainingEmployee(int trainingEmployeeViewId, int companyId);
    }
}
