using HRSystem.Services.Interfaces;
using HRSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HRSystem.Services.Repositories
{
    public class CompanyDashboard : ICompanyDashboard
    {
        public List<CompanyDashboards> GetCompanyDashboard(int CompanyId, string connectionString)
        {
            List<CompanyDashboards> obj = new List<CompanyDashboards>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spCompanyDashBoardList";
            cmd.Parameters.AddWithValue("@CompanyID", CompanyId);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CompanyDashboards objDashboard = new CompanyDashboards();
                objDashboard.Count = Convert.ToInt32(row.ItemArray[1]);
                objDashboard.label = Convert.ToString(row.ItemArray[0]);
                obj.Add(objDashboard);
            }
            return obj;
        }


        public List<DOB> GetDOBBasedOnCompanyId(int companyId, string connectionString)
        {
            var obj = new List<DOB>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetDOBBasedOnCompanyId";
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var objDOB = new DOB();
                objDOB.FName = Convert.ToString(row.ItemArray[0]);
                objDOB.LName = Convert.ToString(row.ItemArray[1]);
                objDOB.Email = Convert.ToString(row.ItemArray[2]);
                if (Convert.ToString(row.ItemArray[3]) != "")
                {
                    objDOB.Photo = (Byte[])row.ItemArray[3];
                }
                obj.Add(objDOB);
            }
            return obj;
        }


        public List<CompanyDashboards> GetOpenEnrollmentStatuses(int companyId, string connectionString)
        {
            List<CompanyDashboards> obj = new List<CompanyDashboards>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetOpenEnrollmentStatuses";
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CompanyDashboards objDashboard = new CompanyDashboards();
                objDashboard.Count = Convert.ToInt32(row.ItemArray[1]);
                objDashboard.label = Convert.ToString(row.ItemArray[0]);
                obj.Add(objDashboard);
            }
            return obj;
        }


        public List<CompanyDashboards> GetEnrollmentsByType(int companyId, string connectionString)
        {
            List<CompanyDashboards> obj = new List<CompanyDashboards>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetEnrollmentsByType";
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CompanyDashboards objDashboard = new CompanyDashboards();
                objDashboard.Count = Convert.ToInt32(row.ItemArray[1]);
                objDashboard.label = Convert.ToString(row.ItemArray[0]);
                obj.Add(objDashboard);
            }
            return obj;
        }


        public List<RecentActivity> GetRecentActivityList(int companyId, string connectionString)
        {
            List<RecentActivity> objListRecentActivity = new List<RecentActivity>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RecentActivity";            
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RecentActivity objRecent = new RecentActivity();
                if (!dr.IsDBNull(dr.GetOrdinal("FLName")))
                {
                    objRecent.FLName = dr.GetString(dr.GetOrdinal("FLName"));
                }
                if (!dr.IsDBNull(dr.GetOrdinal("DisplayName")))
                {
                    objRecent.DisplayName = dr.GetString(dr.GetOrdinal("DisplayName"));
                }
                if (!dr.IsDBNull(dr.GetOrdinal("PHOTO")))
                {
                    objRecent.Photo = (Byte[])dr.GetValue(dr.GetOrdinal("PHOTO"));
                }
                if (!dr.IsDBNull(dr.GetOrdinal("TimeinAgo")))
                {
                    objRecent.TimeinAgo = dr.GetString(dr.GetOrdinal("TimeinAgo"));
                }
                objListRecentActivity.Add(objRecent);
            }
            con.Close();
            return objListRecentActivity;
        }


        public List<Employee> GetEmployeeList(string userId, int companyId, string roleId, bool isPositionEnabled, bool showConcealded, string connectionString)
        {
            List<Employee> objListEmployee = new List<Employee>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "STFilterEmployeeListForSchedule";
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            cmd.Parameters.AddWithValue("@RoleID", roleId);
            cmd.Parameters.AddWithValue("@IsPositionEnabled", isPositionEnabled);
            cmd.Parameters.AddWithValue("@ShowConcealed", showConcealded);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee objEmployee = new Employee();
                if (!dr.IsDBNull(dr.GetOrdinal("UserId")))
                {
                    objEmployee.UserId = Convert.ToString(dr.GetGuid(dr.GetOrdinal("UserId")));
                }
                if (!dr.IsDBNull(dr.GetOrdinal("LastName")))
                {
                    objEmployee.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                }
                if (!dr.IsDBNull(dr.GetOrdinal("FirstName")))
                {
                    objEmployee.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                } 
                objListEmployee.Add(objEmployee);
            }
            con.Close();
            return objListEmployee;
        }


        public List<Plan> GetAllPlanList(int companyId, string connectionString)
        {
            List<Plan> objListPlan = new List<Plan>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetAllPlanType";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Plan objPlan = new Plan();
                if (!dr.IsDBNull(dr.GetOrdinal("HTABLES_DESC")))
                {
                    objPlan.PlanType = dr.GetString(dr.GetOrdinal("HTABLES_DESC")).Trim();
                }
                objListPlan.Add(objPlan);
            }
            con.Close();
            return objListPlan;
        }

        public List<CompanyDashboards> OpenEnrollmentStatusesByPlanType(int companyId,string planType, string connectionString)
        {
            List<CompanyDashboards> obj = new List<CompanyDashboards>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetOpenEnrollmentStatusesByPlanType";
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            cmd.Parameters.AddWithValue("@PlanType", planType);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CompanyDashboards objDashboard = new CompanyDashboards();
                objDashboard.Count = Convert.ToInt32(row.ItemArray[1]);
                objDashboard.label = Convert.ToString(row.ItemArray[0]);
                obj.Add(objDashboard);
            }
            return obj;
        }

        public List<EnrollmentType> GetAllEnrollmentList()
        {
            List<EnrollmentType> objListEnrollmentType = new List<EnrollmentType>();

            EnrollmentType objOE = new EnrollmentType();
            objOE.Type = "Open Enrollments";
            EnrollmentType objNH = new EnrollmentType();
            objNH.Type = "New Hire";
            EnrollmentType objLE = new EnrollmentType();
            objLE.Type = "Life Event";

            objListEnrollmentType.Add(objOE);
            objListEnrollmentType.Add(objNH);
            objListEnrollmentType.Add(objLE);
            return objListEnrollmentType;
        }


        public List<CompanyDashboards> GetEnrollmentByTypeByEnrollmentType(int companyId, string EnrollType, string connectionString)
        {
            List<CompanyDashboards> obj = new List<CompanyDashboards>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetEnrollmentByTypeByEnrollmentType";
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            cmd.Parameters.AddWithValue("@EnrollType", EnrollType);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CompanyDashboards objDashboard = new CompanyDashboards();
                objDashboard.Count = Convert.ToInt32(row.ItemArray[1]);
                objDashboard.label = Convert.ToString(row.ItemArray[0]);
                obj.Add(objDashboard);
            }
            return obj;
        }
        public List<MainEmployee> GetOpenEnrollmentEmployeeInfo(int companyId, string connectionString)
        {
            List<MainEmployee> objEmployee = new List<MainEmployee>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "	select hp.FNAME,hp.LNAME from HPERSNL hp inner join benEmployeeContribution bec on hp.UserId=bec.UserId and bec.CompanyId='" + companyId + "' and EnrollmentType='OE'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                MainEmployee objemp = new MainEmployee();
                objemp.FirstName = Convert.ToString(rows.ItemArray[0]);
                objemp.LastName = Convert.ToString(rows.ItemArray[1]);
                objEmployee.Add(objemp);
            }
            return objEmployee;
        }
        public List<MainEmployee> GetNewHireEmployeeInfo(int companyId, string connectionString)
        {
            List<MainEmployee> objEmployee = new List<MainEmployee>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "	select hp.FNAME,hp.LNAME from HPERSNL hp inner join benEmployeeContribution bec on hp.UserId=bec.UserId and bec.CompanyId='" + companyId + "' and EnrollmentType='NH'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                MainEmployee objemp = new MainEmployee();
                objemp.FirstName = Convert.ToString(rows.ItemArray[0]);
                objemp.LastName = Convert.ToString(rows.ItemArray[1]);
                objEmployee.Add(objemp);
            }
            return objEmployee;
        }
        public List<MainEmployee> GetLifeEventEmployeeInfo(int companyId, string connectionString)
        {
            List<MainEmployee> objEmployee = new List<MainEmployee>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "	select hp.FNAME,hp.LNAME from HPERSNL hp inner join benEmployeeContribution bec on hp.UserId=bec.UserId and bec.CompanyId='" + companyId + "' and EnrollmentType='LE'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                MainEmployee objemp = new MainEmployee();
                objemp.FirstName = Convert.ToString(rows.ItemArray[0]);
                objemp.LastName = Convert.ToString(rows.ItemArray[1]);
                objEmployee.Add(objemp);
            }
            return objEmployee;
        }


        public List<BenefitEnrollment> GetBenefitEnrollmentByLoc(int companyId, string connectionString)
        {
            List<BenefitEnrollment> objListPlan = new List<BenefitEnrollment>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EEBenefitEnrollment";
            cmd.Parameters.AddWithValue("@companyId", companyId);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                BenefitEnrollment objPlan = new BenefitEnrollment();
                if (!dr.IsDBNull(dr.GetOrdinal("StateName")))
                {
                    objPlan.StateName = dr.GetString(dr.GetOrdinal("StateName")).Trim();
                }
                if (!dr.IsDBNull(dr.GetOrdinal("PlanType")))
                {
                    objPlan.PlanType = dr.GetInt32(dr.GetOrdinal("PlanType"));
                }
                objListPlan.Add(objPlan);
            }
            con.Close();
            return objListPlan;
        }
    }
}
