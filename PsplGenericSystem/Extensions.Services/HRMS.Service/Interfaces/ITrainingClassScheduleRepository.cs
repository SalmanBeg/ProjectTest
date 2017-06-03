using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Service.AOP;
using System.Data;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Interfaces
{
    public interface ITrainingClassScheduleRepository
    {
        [Logger]
        [ExceptionLogger]
        int InsertAndUpdateTrainingSchedule(TrainingClassSchedule trainingClassScheduleObj);

        [Logger]
        [ExceptionLogger]
        List<TrainingClassSchedule> GetTrainingClassSchedules(int companyId);

        [Logger]
        [ExceptionLogger]
        TrainingClassSchedule GetTrainingClassSchedulesById(int trainingClassScheduleId,int companyId);

        [Logger]
        [ExceptionLogger]
        List<TrainingClassSchedule> GetTrainingClassSchedulesByClassId(int trainingClassId, int companyId);

        [Logger]
        [ExceptionLogger]
        bool InsertTrainingClassScheduleContentBulk(DataTable dtTrainigclassSchedule);

        //[Logger]
        //[ExceptionLogger]
        //bool UpdateTrainingScheduleDates(TrainingClassScheduleDate trainingClassScheduleDateObj);

        //[Logger]
        //[ExceptionLogger]
        //List<TrainingClassScheduleDate> GetTrainingClassScheduleDate(int companyId, int trainingClassscheduleId);

        //[Logger]
        //[ExceptionLogger]
        //bool DeleteTrainingClassSchedule(int trainingClassScheduleId, int companyId);

        [Logger]
        [ExceptionLogger]
        bool DeleteTrainingClassSchedule(int trainingClassScheduleId, int companyId);



        
    }
}
