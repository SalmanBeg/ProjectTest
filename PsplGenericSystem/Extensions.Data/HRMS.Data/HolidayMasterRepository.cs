using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public class HolidayMasterRepository : IHolidayMasterRepository
    {

        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class HolidayMasterFields
        {
            public const string HolidayMasterId = "HolidayMasterId";
            public const string HolidayGroupId = "HolidayGroupId";
            public const string HolidayId = "HolidayId";
            public const string HoursBenefit = "HoursBenefit";
            public const string WorkBenefit = "WorkBenefit";
            public const string OverTimeBenefit = "OverTimeBenefit";
            public const string DoubleTimeBenefit = "DoubleTimeBenefit";
            public const string DaysBefore = "DaysBefore";
            public const string DaysAfter = "DaysAfter";
            public const string DollarPerHour = "DollarPerHour";
            public const string BankHoursIfWorked = "BankHoursIfWorked";
            public const string BankToAccount = "BankToAccount";
            public const string CompanyId = "CompanyId";
            public const string HolidayName = "HolidayName";

        }



        /// <summary>
        /// Returns All HolidayMaster Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<HolidayMasterInfo> SelectAllHolidayMasterDetails(int CompanyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                List<HolidayMasterInfo> holidaymasterInfoList = new List<HolidayMasterInfo>();
                _oDatabaseHelper.AddParameter("@CompanyId", CompanyId);

                IDataReader rdr = _oDatabaseHelper.ExecuteReader("TimeAttendance.usp_HolidayMasterSelectAll", ref executionState);
                while (rdr.Read())
                {
                    var holidaymasterInfoobj = new HolidayMasterInfo();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayMasterId)))
                        holidaymasterInfoobj.HolidayMasterId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.HolidayMasterId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayGroupId)))
                        holidaymasterInfoobj.HolidayGroupId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.HolidayGroupId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayId)))
                        holidaymasterInfoobj.HolidayId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.HolidayId));
                    //if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayName)))
                    //    holidaymasterInfoobj.HolidayName = rdr.GetString(rdr.GetOrdinal(HolidayMasterFields.HolidayName));
                    //if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayDate)))
                    //    holidaymasterInfoobj.HolidayDate = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.HolidayDate));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HoursBenefit)))
                        holidaymasterInfoobj.HoursBenefit = rdr.GetFloat(rdr.GetOrdinal(HolidayMasterFields.HoursBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.WorkBenefit)))
                        holidaymasterInfoobj.WorkBenefit = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.WorkBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.OverTimeBenefit)))
                        holidaymasterInfoobj.OverTimeBenefit = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.OverTimeBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DoubleTimeBenefit)))
                        holidaymasterInfoobj.DoubleTimeBenefit = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.DoubleTimeBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DaysBefore)))
                        holidaymasterInfoobj.DaysBefore = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.DaysBefore));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DaysAfter)))
                        holidaymasterInfoobj.DaysAfter = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.DaysAfter));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DollarPerHour)))
                        holidaymasterInfoobj.DollarPerHour = rdr.GetDecimal(rdr.GetOrdinal(HolidayMasterFields.DollarPerHour));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.BankHoursIfWorked)))
                        holidaymasterInfoobj.BankHoursIfWorked = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.BankHoursIfWorked));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.BankToAccount)))
                        holidaymasterInfoobj.BankToAccount = rdr.GetString(rdr.GetOrdinal(HolidayMasterFields.BankToAccount));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.CompanyId)))
                        holidaymasterInfoobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.CompanyId));


                    holidaymasterInfoList.Add(holidaymasterInfoobj);
                }
                rdr.Close();
                return holidaymasterInfoList;
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
        /// Returns Selected HolidayMaster Details By CompanyId
        /// </summary>
        /// <param name="HolidayMasterId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<HolidayMasterInfo> SelectHolidayMasterDetails(int HolidayMasterId,int CompanyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                List<HolidayMasterInfo> holidaymasterInfoList = new List<HolidayMasterInfo>();
                _oDatabaseHelper.AddParameter("@HolidayMasterId", HolidayMasterId);
                _oDatabaseHelper.AddParameter("@CompanyId", CompanyId);

                IDataReader rdr = _oDatabaseHelper.ExecuteReader("TimeAttendance.usp_HolidayMasterSelect", ref executionState);
                while (rdr.Read())
                {
                    var holidaymasterInfoobj = new HolidayMasterInfo();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayMasterId)))
                        holidaymasterInfoobj.HolidayMasterId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.HolidayMasterId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayGroupId)))
                        holidaymasterInfoobj.HolidayGroupId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.HolidayGroupId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayId)))
                        holidaymasterInfoobj.HolidayId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.HolidayId));
                    //if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayName)))
                    //    holidaymasterInfoobj.HolidayName = rdr.GetString(rdr.GetOrdinal(HolidayMasterFields.HolidayName));
                    //if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayDate)))
                    //    holidaymasterInfoobj.HolidayDate = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.HolidayDate));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HoursBenefit)))
                        holidaymasterInfoobj.HoursBenefit = rdr.GetFloat(rdr.GetOrdinal(HolidayMasterFields.HoursBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.WorkBenefit)))
                        holidaymasterInfoobj.WorkBenefit = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.WorkBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.OverTimeBenefit)))
                        holidaymasterInfoobj.OverTimeBenefit = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.OverTimeBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DoubleTimeBenefit)))
                        holidaymasterInfoobj.DoubleTimeBenefit = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.DoubleTimeBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DaysBefore)))
                        holidaymasterInfoobj.DaysBefore = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.DaysBefore));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DaysAfter)))
                        holidaymasterInfoobj.DaysAfter = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.DaysAfter));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DollarPerHour)))
                        holidaymasterInfoobj.DollarPerHour = rdr.GetDecimal(rdr.GetOrdinal(HolidayMasterFields.DollarPerHour));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.BankHoursIfWorked)))
                        holidaymasterInfoobj.BankHoursIfWorked = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.BankHoursIfWorked));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.BankToAccount)))
                        holidaymasterInfoobj.BankToAccount = rdr.GetString(rdr.GetOrdinal(HolidayMasterFields.BankToAccount));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.CompanyId)))
                        holidaymasterInfoobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.CompanyId));


                    holidaymasterInfoList.Add(holidaymasterInfoobj);
                }
                rdr.Close();
                return holidaymasterInfoList;
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
        /// Returns All Holiday List to Display In Holiday Master Grid   By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<HolidayMasterInfo> SelectHolidayMasterGridDetails(int HolidayGroupId,int CompanyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                List<HolidayMasterInfo> holidaymasterInfoList = new List<HolidayMasterInfo>();
                _oDatabaseHelper.AddParameter("@HolidayGroupId", HolidayGroupId);
                _oDatabaseHelper.AddParameter("@CompanyId", CompanyId);

                IDataReader rdr = _oDatabaseHelper.ExecuteReader("TimeAttendance.usp_HolidayMasterGridSelectList", ref executionState);
                while (rdr.Read())
                {
                    var holidaymasterInfoobj = new HolidayMasterInfo();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayId)))
                        holidaymasterInfoobj.HolidayId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.HolidayId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayName)))
                        holidaymasterInfoobj.HolidayName = rdr.GetString(rdr.GetOrdinal(HolidayMasterFields.HolidayName));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayMasterId)))
                        holidaymasterInfoobj.HolidayMasterId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.HolidayMasterId));
                    //if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HolidayGroupId)))
                    //    holidaymasterInfoobj.HolidayGroupId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.HolidayGroupId));


                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.HoursBenefit)))
                        holidaymasterInfoobj.HoursBenefit = rdr.GetDouble(rdr.GetOrdinal(HolidayMasterFields.HoursBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.WorkBenefit)))
                        holidaymasterInfoobj.WorkBenefit = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.WorkBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.OverTimeBenefit)))
                        holidaymasterInfoobj.OverTimeBenefit = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.OverTimeBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DoubleTimeBenefit)))
                        holidaymasterInfoobj.DoubleTimeBenefit = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.DoubleTimeBenefit));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DaysBefore)))
                        holidaymasterInfoobj.DaysBefore = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.DaysBefore));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DaysAfter)))
                        holidaymasterInfoobj.DaysAfter = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.DaysAfter));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.DollarPerHour)))
                        holidaymasterInfoobj.DollarPerHour = rdr.GetDecimal(rdr.GetOrdinal(HolidayMasterFields.DollarPerHour));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.BankHoursIfWorked)))
                        holidaymasterInfoobj.BankHoursIfWorked = rdr.GetBoolean(rdr.GetOrdinal(HolidayMasterFields.BankHoursIfWorked));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.BankToAccount)))
                        holidaymasterInfoobj.BankToAccount = rdr.GetString(rdr.GetOrdinal(HolidayMasterFields.BankToAccount));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HolidayMasterFields.CompanyId)))
                        holidaymasterInfoobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(HolidayMasterFields.CompanyId));


                    holidaymasterInfoList.Add(holidaymasterInfoobj);
                }
                rdr.Close();
                return holidaymasterInfoList;
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
        /// Insert holidayMaster Information
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        public bool InsertHolidayMaster(HolidayMasterInfo holidaymasterInfoobj)
        {
            bool executionState = false;
            _oDatabaseHelper = new DatabaseHelper();
            _oDatabaseHelper.AddParameter("@HolidayGroupId", holidaymasterInfoobj.HolidayGroupId);
            _oDatabaseHelper.AddParameter("@HolidayId", holidaymasterInfoobj.HolidayId);
            _oDatabaseHelper.AddParameter("@HoursBenefit", holidaymasterInfoobj.HoursBenefit);
            _oDatabaseHelper.AddParameter("@WorkBenefit", holidaymasterInfoobj.WorkBenefit);
            _oDatabaseHelper.AddParameter("@OverTimeBenefit", holidaymasterInfoobj.OverTimeBenefit);
            _oDatabaseHelper.AddParameter("@DoubleTimeBenefit", holidaymasterInfoobj.DoubleTimeBenefit);
            _oDatabaseHelper.AddParameter("@DaysBefore", holidaymasterInfoobj.DaysBefore);
            _oDatabaseHelper.AddParameter("@DaysAfter", holidaymasterInfoobj.DaysAfter);
            _oDatabaseHelper.AddParameter("@DollarPerHour", holidaymasterInfoobj.DollarPerHour);
            _oDatabaseHelper.AddParameter("@BankHoursIfWorked", holidaymasterInfoobj.BankHoursIfWorked);
            _oDatabaseHelper.AddParameter("@BankToAccount", holidaymasterInfoobj.BankToAccount);
            _oDatabaseHelper.AddParameter("@CompanyId", holidaymasterInfoobj.CompanyId);
            _oDatabaseHelper.ExecuteScalar("TimeAttendance.usp_HolidayMasterInsert", ref executionState);
            _oDatabaseHelper.Dispose();
            return executionState;
        }


        /// <summary>
        /// Update HolidayMaster Information
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        public bool UpdateHolidayMaster(HolidayMasterInfo holidaymasterInfoobj)
        {
            bool executionState = false;
            _oDatabaseHelper = new DatabaseHelper();
            _oDatabaseHelper.AddParameter("@HolidayMasterId", holidaymasterInfoobj.HolidayMasterId);
            _oDatabaseHelper.AddParameter("@HolidayGroupId", holidaymasterInfoobj.HolidayGroupId);
            _oDatabaseHelper.AddParameter("@HolidayId", holidaymasterInfoobj.HolidayId);
            _oDatabaseHelper.AddParameter("@HoursBenefit", holidaymasterInfoobj.HoursBenefit);
            _oDatabaseHelper.AddParameter("@WorkBenefit", holidaymasterInfoobj.WorkBenefit);
            _oDatabaseHelper.AddParameter("@OverTimeBenefit", holidaymasterInfoobj.OverTimeBenefit);
            _oDatabaseHelper.AddParameter("@DoubleTimeBenefit", holidaymasterInfoobj.DoubleTimeBenefit);
            _oDatabaseHelper.AddParameter("@DaysBefore", holidaymasterInfoobj.DaysBefore);
            _oDatabaseHelper.AddParameter("@DaysAfter", holidaymasterInfoobj.DaysAfter);
            _oDatabaseHelper.AddParameter("@DollarPerHour", holidaymasterInfoobj.DollarPerHour);
            _oDatabaseHelper.AddParameter("@BankHoursIfWorked", holidaymasterInfoobj.BankHoursIfWorked);
            _oDatabaseHelper.AddParameter("@BankToAccount", holidaymasterInfoobj.BankToAccount);
            _oDatabaseHelper.AddParameter("@CompanyId", holidaymasterInfoobj.CompanyId);
            _oDatabaseHelper.ExecuteScalar("TimeAttendance.usp_HolidayMasterUpdate", ref executionState);
            _oDatabaseHelper.Dispose();
            return executionState;
        }


        /// <summary>
        /// Delete HolidayMaster Detail by HolidayMasterId and CompanyId
        /// </summary>
        /// <param name="HolidayMasterId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public bool DeleteHolidayMasterDetail(int HolidayMasterId, int CompanyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@HolidayMasterId", HolidayMasterId);
                _oDatabaseHelper.AddParameter("@CompanyId", CompanyId);

                _oDatabaseHelper.ExecuteScalar("TimeAttendance.usp_HolidayMasterDelete", ref executionState);
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
