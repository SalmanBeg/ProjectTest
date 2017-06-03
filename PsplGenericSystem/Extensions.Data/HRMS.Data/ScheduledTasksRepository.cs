using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class ScheduledTasksRepository : IScheduledTasksRepository
    {
        public class ScheduledTasksFields 
        {
            public const string ScheduledTaskId = "ScheduledTaskId";
            public const string UserId = "UserId";
            public const string CompanyId = "CompanyId";
            public const string Title = "Title";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
            public const string BackgroundColor = "BackgroundColor";
            public const string BorderColor = "BorderColor";
            public const string AllDay = "AllDay";
            public const string CreatedOn = "CreatedOn";
            public const string ModifiedOn = "ModifiedOn";
            public const string CreatedBy = "CreatedBy";
            public const string ModifiedBy = "ModifiedBy";          
        }
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
        public bool CreateScheduledTasks(ScheduledTasks scheduledTasksObj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserId", scheduledTasksObj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyId", scheduledTasksObj.CompanyId);
                _oDatabaseHelper.AddParameter("@Title", scheduledTasksObj.Title);
                _oDatabaseHelper.AddParameter("@StartDate", scheduledTasksObj.StartDate);
                _oDatabaseHelper.AddParameter("@EndDate", scheduledTasksObj.EndDate);
                _oDatabaseHelper.AddParameter("@BackgroundColor", scheduledTasksObj.BackgroundColor);
                _oDatabaseHelper.AddParameter("@BorderColor", scheduledTasksObj.BorderColor);
                _oDatabaseHelper.AddParameter("@AllDay", scheduledTasksObj.AllDay);
                _oDatabaseHelper.AddParameter("@CreatedOn", scheduledTasksObj.CreatedOn);
                _oDatabaseHelper.AddParameter("@ModifiedOn", scheduledTasksObj.ModifiedOn);
                _oDatabaseHelper.AddParameter("@CreatedBy", scheduledTasksObj.CreatedBy);
                _oDatabaseHelper.AddParameter("@ModifiedBy", scheduledTasksObj.ModifiedBy);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_ScheduledTasksInsert", ref executionState);
                _oDatabaseHelper.Dispose();
                return executionState;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
           
        }
        public bool UpdateScheduledTasks(ScheduledTasks scheduledTasksObj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper.AddParameter("@UserId", scheduledTasksObj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyId", scheduledTasksObj.CompanyId);
                _oDatabaseHelper.AddParameter("@Title", scheduledTasksObj.Title);
                _oDatabaseHelper.AddParameter("@StartDate", scheduledTasksObj.StartDate);
                _oDatabaseHelper.AddParameter("@EndDate", scheduledTasksObj.EndDate);
                _oDatabaseHelper.AddParameter("@BackgroundColor", scheduledTasksObj.BackgroundColor);
                _oDatabaseHelper.AddParameter("@BorderColor", scheduledTasksObj.BorderColor);
                _oDatabaseHelper.AddParameter("@AllDay", scheduledTasksObj.AllDay);
                _oDatabaseHelper.AddParameter("@CreatedOn", scheduledTasksObj.CreatedOn);
                _oDatabaseHelper.AddParameter("@ModifiedOn", scheduledTasksObj.ModifiedOn);
                _oDatabaseHelper.AddParameter("@CreatedBy", scheduledTasksObj.CreatedBy);
                _oDatabaseHelper.AddParameter("@ModifiedBy", scheduledTasksObj.ModifiedBy);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_ScheduledTasksUpdate", ref executionState);
                _oDatabaseHelper.Dispose();
                return executionState;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
        public List<ScheduledTasks> SelectScheduledTasks(int scheduledTaskId)
        {
            try
            {
                _oDatabaseHelper = new DatabaseHelper();
                var scheduledTasksList = new List<ScheduledTasks>();
                bool executionState = false;
                _oDatabaseHelper.AddParameter("@ScheduledTaskId", scheduledTaskId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_ScheduledTasksSelect", ref executionState);
                while (rdr.Read())
                {
                    var scheduledTasksObj = new ScheduledTasks();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScheduledTasksFields.ScheduledTaskId)))
                        scheduledTasksObj.ScheduledTaskId = rdr.GetInt32(rdr.GetOrdinal(ScheduledTasksFields.ScheduledTaskId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScheduledTasksFields.UserId)))
                        scheduledTasksObj.UserId = rdr.GetInt32(rdr.GetOrdinal(ScheduledTasksFields.UserId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScheduledTasksFields.CompanyId)))
                        scheduledTasksObj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(ScheduledTasksFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScheduledTasksFields.Title)))
                        scheduledTasksObj.Title = rdr.GetString(rdr.GetOrdinal(ScheduledTasksFields.Title));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScheduledTasksFields.StartDate)))
                        scheduledTasksObj.StartDate = rdr.GetDateTime(rdr.GetOrdinal(ScheduledTasksFields.StartDate));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScheduledTasksFields.EndDate)))
                        scheduledTasksObj.EndDate = rdr.GetDateTime(rdr.GetOrdinal(ScheduledTasksFields.EndDate));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScheduledTasksFields.BackgroundColor)))
                        scheduledTasksObj.BackgroundColor = rdr.GetString(rdr.GetOrdinal(ScheduledTasksFields.BackgroundColor));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScheduledTasksFields.BorderColor)))
                        scheduledTasksObj.BorderColor = rdr.GetString(rdr.GetOrdinal(ScheduledTasksFields.BorderColor));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScheduledTasksFields.AllDay)))
                        scheduledTasksObj.AllDay = rdr.GetBoolean(rdr.GetOrdinal(ScheduledTasksFields.AllDay));
                    scheduledTasksList.Add(scheduledTasksObj);
                }
                rdr.Close();
                return scheduledTasksList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
    }
}
