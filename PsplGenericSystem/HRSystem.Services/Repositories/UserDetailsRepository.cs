using HRSystem.Services.Interfaces;
using HRSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HRSystem.Services.Repositories
{
    public class UserDetailsRepository : IAccounts
    {
        public MainEmployee GetUserDetails(string userName, string connectionString)
        {
            MainEmployee objUserVariables = new MainEmployee();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ValidateUser";
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!dr.IsDBNull(dr.GetOrdinal("RoleName")))
                {
                    objUserVariables.RoleName = dr.GetString(dr.GetOrdinal("RoleName"));
                }
                if (!dr.IsDBNull(dr.GetOrdinal("FirstName")))
                {
                    objUserVariables.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                }
                if (!dr.IsDBNull(dr.GetOrdinal("LastName")))
                {
                    objUserVariables.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                }
                if (!dr.IsDBNull(dr.GetOrdinal("Email")))
                {
                    objUserVariables.Email = dr.GetString(dr.GetOrdinal("Email"));
                }
                if (!dr.IsDBNull(dr.GetOrdinal("UserID")))
                {
                    objUserVariables.UserId = dr.GetGuid(dr.GetOrdinal("UserID")).ToString();
                }
                if (!dr.IsDBNull(dr.GetOrdinal("RoleId")))
                {
                    objUserVariables.RoleId = dr.GetGuid(dr.GetOrdinal("RoleId")).ToString();
                }
            }
            con.Close();
            return objUserVariables;
        }
        public MainEmployee GetEmployeePhotoByuserID(string userId, string companyId, string connectionString)
        {
            MainEmployee objEmployeePhoto = new MainEmployee();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetEmployeeHomePhoto";
            cmd.Parameters.AddWithValue("@UserID", userId);
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
                if (!dr.IsDBNull(dr.GetOrdinal("PHOTO")))
                {
                    objEmployeePhoto.Image = (Byte[])dr.GetValue(dr.GetOrdinal("PHOTO"));
                }
            }
            con.Close();
            return objEmployeePhoto;
        }
        public MainEmployee GetEmployeePersonalInfo(string userId, string connectionString)
        {
            MainEmployee objUserDetails = new MainEmployee();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spGetPersonalInformationByUserId";
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!dr.IsDBNull(dr.GetOrdinal("STREET2")))
                {
                    objUserDetails.Address = dr.GetString(dr.GetOrdinal("STREET2")).Trim();
                }
                if (!dr.IsDBNull(dr.GetOrdinal("HPHONE")))
                {
                    objUserDetails.HomePhone = dr.GetString(dr.GetOrdinal("HPHONE")).Trim();
                }
                if (!dr.IsDBNull(dr.GetOrdinal("WPHONE")))
                {
                    objUserDetails.CellPhone = dr.GetString(dr.GetOrdinal("WPHONE")).Trim();
                }
            }
            con.Close();
            return objUserDetails;
        }
        public List<Employee> GetRecentHireEmployeeInfo(string companyId, string connectionString)
        {
            List<Employee> objListEmployee = new List<Employee>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spEmployeeStats";
            cmd.Parameters.AddWithValue("@Action", "RecentHires");
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Employee objEmployee = new Employee();
                objEmployee.FirstName = Convert.ToString(row.ItemArray[1]);
                objEmployee.LastName = Convert.ToString(row.ItemArray[2]);
                objListEmployee.Add(objEmployee);
            }
            return objListEmployee;
        }
        public List<Employee> GetTerminationEmployeeInfo(string companyId, string connectionString)
        {
            List<Employee> objListEmployee = new List<Employee>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spEmployeeStats";
            cmd.Parameters.AddWithValue("@Action", "Terminations");
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Employee objEmployee = new Employee();
                objEmployee.FirstName = Convert.ToString(row.ItemArray[1]);
                objEmployee.LastName = Convert.ToString(row.ItemArray[2]);
                objListEmployee.Add(objEmployee);
            }
            return objListEmployee;
        }
        public List<Employee> GetOpenEnrollmentEmployeeInfo(string companyId, string connectionString)
        {
            List<Employee> objListEmployee = new List<Employee>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spEmployeeStats";
            cmd.Parameters.AddWithValue("@Action", "Enrollments");
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Employee objEmployee = new Employee();
                objEmployee.FirstName = Convert.ToString(row.ItemArray[1]);
                objEmployee.LastName = Convert.ToString(row.ItemArray[2]);
                objListEmployee.Add(objEmployee);
            }
            return objListEmployee;
        }
    }
}
