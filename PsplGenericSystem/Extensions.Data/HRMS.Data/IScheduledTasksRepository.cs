using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IScheduledTasksRepository
    {
        bool CreateScheduledTasks(ScheduledTasks scheduledTasksObj);
        bool UpdateScheduledTasks(ScheduledTasks scheduledTasksObj);
        List<ScheduledTasks> SelectScheduledTasks(int scheduledTaskId);
    }
}
