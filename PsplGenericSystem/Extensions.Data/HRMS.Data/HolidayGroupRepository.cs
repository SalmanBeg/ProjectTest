using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
namespace HRMS.Data
{
    public class HolidayGroupRepository:IHolidayGroupRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class HolidayGroupFields
        {
            public const string HolidayGroupId = "HolidayGroupId";
            public const string HolidayGroupCode = "HolidayGroupCode";
            public const string HolidayGroupName = "HolidayGroupName";
            public const string HolidayDescription = "HolidayDescription";
            public const string CompanyId = "CompanyId";
        }


        /// <summary>
        /// Returns All HolidayGroup Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<HolidayGroupInfo> SelectAllHolidayGroupDetails(int CompanyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                List<HolidayGroupInfo> holidayGroupInfoList = new List<HolidayGroupInfo>();
                _oDatabaseHelper.AddParameter("@CompanyId", CompanyId);

                IDataReader rdr = _oDatabaseHelper.ExecuteReader("TimeAttendance.usp_HolidayGroupSelectAll", ref executionState);
                while (rdr.Read())
                {
                    var holidayGroupInfoobj = new HolidayGroupInfo();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupId)))
                        holidayGroupInfoobj.HolidayGroupId = rdr.GetInt32(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupCode)))
                        holidayGroupInfoobj.HolidayGroupCode = rdr.GetGuid(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupCode));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupName)))
                        holidayGroupInfoobj.HolidayGroupName = rdr.GetString(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayGroupFields.HolidayDescription)))
                        holidayGroupInfoobj.HolidayDescription = rdr.GetString(rdr.GetOrdinal(HolidayGroupFields.HolidayDescription));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayGroupFields.CompanyId)))
                        holidayGroupInfoobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(HolidayGroupFields.CompanyId));

                    holidayGroupInfoList.Add(holidayGroupInfoobj);
                }
                rdr.Close();
                return holidayGroupInfoList;
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


        /// <summary>
        /// Returns Selected HolidayGroup Details By HolidayGroupId and CompanyId
        /// </summary>
        /// <param name="HolidayGroupId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<HolidayGroupInfo> SelectHolidayGroupDetail(int HolidayGroupId, int CompanyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                List<HolidayGroupInfo> holidayGroupInfoList = new List<HolidayGroupInfo>();
                _oDatabaseHelper.AddParameter("@HolidayGroupId", HolidayGroupId);
                _oDatabaseHelper.AddParameter("@CompanyId", CompanyId);

                IDataReader rdr = _oDatabaseHelper.ExecuteReader("TimeAttendance.usp_HolidayGroupSelect", ref executionState);
                while (rdr.Read())
                {
                    var holidayGroupInfoobj = new HolidayGroupInfo();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupId)))
                        holidayGroupInfoobj.HolidayGroupId = rdr.GetInt32(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupCode)))
                        holidayGroupInfoobj.HolidayGroupCode = rdr.GetGuid(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupCode));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupName)))
                        holidayGroupInfoobj.HolidayGroupName = rdr.GetString(rdr.GetOrdinal(HolidayGroupFields.HolidayGroupName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayGroupFields.HolidayDescription)))
                        holidayGroupInfoobj.HolidayDescription = rdr.GetString(rdr.GetOrdinal(HolidayGroupFields.HolidayDescription));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayGroupFields.CompanyId)))
                        holidayGroupInfoobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(HolidayGroupFields.CompanyId));

                    holidayGroupInfoList.Add(holidayGroupInfoobj);
                }
                rdr.Close();
                return holidayGroupInfoList;
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


        /// <summary>
        /// Insert holidayGroup Information
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
        public bool InsertHolidayGroup(HolidayGroupInfo holidayGroupInfoobj)
        {
            bool executionState = false;
            _oDatabaseHelper = new DatabaseHelper();
            _oDatabaseHelper.AddParameter("@HolidayGroupName", holidayGroupInfoobj.HolidayGroupName);
            _oDatabaseHelper.AddParameter("@HolidayDescription", holidayGroupInfoobj.HolidayDescription);
            _oDatabaseHelper.AddParameter("@CompanyId", holidayGroupInfoobj.CompanyId);
            _oDatabaseHelper.ExecuteScalar("TimeAttendance.usp_HolidayGroupInsert", ref executionState);
            _oDatabaseHelper.Dispose();
            return executionState;
        }


        /// <summary>
        /// Update HolidayGroup Infomation
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
        public bool UpdateHolidayGroup(HolidayGroupInfo holidayGroupInfoobj)
        {
            bool executionState = false;
            _oDatabaseHelper = new DatabaseHelper();
            _oDatabaseHelper.AddParameter("@HolidayGroupId", holidayGroupInfoobj.HolidayGroupId);
            _oDatabaseHelper.AddParameter("@HolidayGroupName", holidayGroupInfoobj.HolidayGroupName);
            _oDatabaseHelper.AddParameter("@HolidayDescription", holidayGroupInfoobj.HolidayDescription);
            _oDatabaseHelper.AddParameter("@CompanyId", holidayGroupInfoobj.CompanyId);
            _oDatabaseHelper.ExecuteScalar("TimeAttendance.usp_HolidayGroupUpdate", ref executionState);
            _oDatabaseHelper.Dispose();
            return executionState;
        }


        /// <summary>
        /// Delete HolidayGroup Detail by HolidayGroupId and CompanyId
        /// </summary>
        /// <param name="HolidayGroupId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public bool DeleteHolidayGroupDetail(int HolidayGroupId, int CompanyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@HolidayGroupId", HolidayGroupId);
                _oDatabaseHelper.AddParameter("@CompanyId", CompanyId);

                _oDatabaseHelper.ExecuteScalar("TimeAttendance.usp_HolidayGroupDelete", ref executionState);
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

    }
}
