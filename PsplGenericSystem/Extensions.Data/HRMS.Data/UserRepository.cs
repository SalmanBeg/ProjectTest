using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public class UserRepository : IUserRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
        /// <summary>
        /// Class for the properties of the object
        /// </summary>
        public class UserSignUpFields
        {
            public const string UserSignUpId = "UserSignUpId";

            public const string UserSignUpCode = "UserSignUpCode";
            public const string Email = "Email";
            public const string LoweredEmail = "LoweredEmail";
            public const string UserName = "UserName";
            public const string Password = "Password";
            public const string PasswordQuestion = "PasswordQuestion";
            public const string PasswordAnswer = "PasswordAnswer";
            public const string IsApproved = "IsApproved";
            public const string IsLockedOut = "IsLockedOut";
            public const string CreateDate = "CreateDate";
            public const string LastLoginDate = "LastLoginDate";
            public const string LastPasswordChangedDate = "LastPasswordChangedDate";
            public const string LastLockoutDate = "LastLockoutDate";
            public const string FailedPasswordAttemptCount = "FailedPasswordAttemptCount";
            public const string FailedPasswordAnswerAttemptCount = "FailedPasswordAnswerAttemptCount";
            public const string CreatedOn = "CreatedOn";
            public const string ModifiedOn = "ModifiedOn";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string CompanyId = "CompanyId";
            public const string CompanyName = "CompanyName";
            public const string RoleId = "RoleId";
            public const string RoleName = "RoleName";

        }

        public class EmployeeFields
        {
            public const string UserSignUpId = "UserSignUpId";
            public const string UserSignUpCode = "UserSignUpCode";
            public const string Email = "Email";
            public const string UserName = "UserName";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string CompanyId = "CompanyId";
            public const string CompanyName = "CompanyName";
            public const string LastLoginDate = "LastLoginDate";
            public const string RoleId = "RoleId";
            public const string RoleName = "RoleName";
            public const string IsApproved = "IsApproved";
            public const string IsSubmitted = "IsSubmitted";
        }

        public class PendingEmployeeFields
        {
            public const string UserSignUpId = "UserSignUpId";
            public const string UserSignUpCode = "UserSignUpCode";
            public const string Email = "Email";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string CompanyId = "CompanyId";
            public const string IsSubmitted = "IsSubmitted";
        }

        public class HireApprovalSetupFields 
        {
            public const string UserId = "UserId";
            public const string HireApprovalSetupId = "HireApprovalSetupId";
            public const string HireConfigurationId = "HireConfigurationId";
            public const string StepName = "StepName";
            public const string IsActive = "IsActive";
            public const string IsApproved = "IsApproved";
            public const string ApprovedOn = "ApprovedOn";
            public const string ApprovedBy = "ApprovedBy";
            public const string RejectedOn = "RejectedOn";
            public const string RejectedBy = "RejectedBy";
        }


        public bool RegisterUser(UserSignUp userSignUpobj,Employee employeeobj, CompanyInfo companyInfoobj)
        {

            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();


                _oDatabaseHelper.AddParameter("@CompanyName", companyInfoobj.CompanyName);
                _oDatabaseHelper.AddParameter("@Address1", companyInfoobj.Address1);
                _oDatabaseHelper.AddParameter("@Address2", companyInfoobj.Address2);
                _oDatabaseHelper.AddParameter("@CITY", companyInfoobj.City);
                _oDatabaseHelper.AddParameter("@ZIP", companyInfoobj.ZIP);
                _oDatabaseHelper.AddParameter("@State", companyInfoobj.StateId);
                _oDatabaseHelper.AddParameter("@Country", companyInfoobj.CountryId);
                _oDatabaseHelper.AddParameter("@Phone", companyInfoobj.Phone);
                // Pass the value of '_email' as parameter 'Email' of the stored procedure.
                _oDatabaseHelper.AddParameter("@Email", userSignUpobj.Email);
                // Pass the value of '_userName' as parameter 'UserName' of the stored procedure.
                _oDatabaseHelper.AddParameter("@UserName", userSignUpobj.Email);
                // Pass the value of '_password' as parameter 'Password' of the stored procedure.
                _oDatabaseHelper.AddParameter("@Password", userSignUpobj.Password);
                // Pass the value of '_passwordQuestion' as parameter 'PasswordQuestion' of the stored procedure.
                _oDatabaseHelper.AddParameter("@PasswordQuestion", userSignUpobj.PasswordQuestion);
                // Pass the value of '_passwordAnswer' as parameter 'PasswordAnswer' of the stored procedure.
                _oDatabaseHelper.AddParameter("@PasswordAnswer", userSignUpobj.PasswordAnswer);
                // Pass the value of '_isApproved' as parameter 'IsApproved' of the stored procedure.
                _oDatabaseHelper.AddParameter("@IsApproved", userSignUpobj.IsApproved);
                // Pass the value of '_isLockedOut' as parameter 'IsLockedOut' of the stored procedure.
                _oDatabaseHelper.AddParameter("@IsLockedOut", userSignUpobj.IsLockedOut);
                // Pass the value of 'FirstName' as parameter 'FirstName' of the stored procedure.
                _oDatabaseHelper.AddParameter("@FirstName", employeeobj.FirstName);
                // Pass the value of 'LastName' as parameter 'LastName' of the stored procedure.
                _oDatabaseHelper.AddParameter("@LastName", employeeobj.LastName);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

                _oDatabaseHelper.ExecuteScalar("usp_CreateUserSignUp", ref executionState);
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

        public bool UpdateUser(UserSignUp userSignUpobj)
        {

            bool executionState = false;
            _oDatabaseHelper = new DatabaseHelper();

            // Pass the value of '_entityID' as parameter 'EntityID' of the stored procedure.
            _oDatabaseHelper.AddParameter("@UserID", userSignUpobj.UserID);
            // Pass the value of '_rowguid' as parameter 'Rowguid' of the stored procedure.
            _oDatabaseHelper.AddParameter("@UserCode", userSignUpobj.UserCode);
            // Pass the value of '_email' as parameter 'Email' of the stored procedure.
            _oDatabaseHelper.AddParameter("@Email", userSignUpobj.Email);
            // Pass the value of '_loweredEmail' as parameter 'LoweredEmail' of the stored procedure.
            _oDatabaseHelper.AddParameter("@LoweredEmail", userSignUpobj.LoweredEmail);
            // Pass the value of '_userName' as parameter 'UserName' of the stored procedure.
            _oDatabaseHelper.AddParameter("@UserName", userSignUpobj.UserName);
            // Pass the value of '_password' as parameter 'Password' of the stored procedure.
            _oDatabaseHelper.AddParameter("@Password", userSignUpobj.Password); 
            // Pass the value of '_passwordQuestion' as parameter 'PasswordQuestion' of the stored procedure.
            _oDatabaseHelper.AddParameter("@PasswordQuestion", userSignUpobj.PasswordQuestion);
            // Pass the value of '_passwordAnswer' as parameter 'PasswordAnswer' of the stored procedure.
            _oDatabaseHelper.AddParameter("@PasswordAnswer", userSignUpobj.PasswordAnswer);
            // Pass the value of '_isApproved' as parameter 'IsApproved' of the stored procedure.
            _oDatabaseHelper.AddParameter("@IsApproved", userSignUpobj.IsApproved);
            // Pass the value of '_isLockedOut' as parameter 'IsLockedOut' of the stored procedure.
            _oDatabaseHelper.AddParameter("@IsLockedOut", userSignUpobj.IsLockedOut);
            // Pass the value of '_createDate' as parameter 'CreateDate' of the stored procedure.
            _oDatabaseHelper.AddParameter("@CreateDate", userSignUpobj.CreateDate);
            // Pass the value of '_lastLoginDate' as parameter 'LastLoginDate' of the stored procedure.
            _oDatabaseHelper.AddParameter("@LastLoginDate", userSignUpobj.LastLoginDate);
            // Pass the value of '_lastPasswordChangedDate' as parameter 'LastPasswordChangedDate' of the stored procedure.
            _oDatabaseHelper.AddParameter("@LastPasswordChangedDate", userSignUpobj.LastPasswordChangedDate);
            // Pass the value of '_lastLockoutDate' as parameter 'LastLockoutDate' of the stored procedure.
            _oDatabaseHelper.AddParameter("@LastLockoutDate", userSignUpobj.LastLockoutDate);
            // Pass the value of '_failedPasswordAttemptCount' as parameter 'FailedPasswordAttemptCount' of the stored procedure.
            _oDatabaseHelper.AddParameter("@FailedPasswordAttemptCount", userSignUpobj.FailedPasswordAttemptCount);
            // Pass the value of '_failedPasswordAnswerAttemptCount' as parameter 'FailedPasswordAnswerAttemptCount' of the stored procedure.
            _oDatabaseHelper.AddParameter("@FailedPasswordAnswerAttemptCount", userSignUpobj.FailedPasswordAnswerAttemptCount);
           
            _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            _oDatabaseHelper.ExecuteScalar("HRMS_SP_UserSignUp_Update", ref executionState);
            _oDatabaseHelper.Dispose();
            return executionState;

        }

        internal static void PopulateObjectFromReader(UserSignUp obj, IDataReader rdr)
        {

            obj.UserID = rdr.GetInt32(rdr.GetOrdinal(UserSignUpFields.UserSignUpId));
            obj.UserCode = rdr.GetGuid(rdr.GetOrdinal(UserSignUpFields.UserSignUpCode)).ToString();
            obj.Email = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.Email));
            if (!rdr.IsDBNull(rdr.GetOrdinal(UserSignUpFields.LoweredEmail)))
            {
                obj.LoweredEmail = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.LoweredEmail));
            }

            obj.UserName = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.UserName));
            obj.Password = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.Password));


            if (!rdr.IsDBNull(rdr.GetOrdinal(UserSignUpFields.PasswordQuestion)))
            {
                obj.PasswordQuestion = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.PasswordQuestion));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(UserSignUpFields.PasswordAnswer)))
            {
                obj.PasswordAnswer = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.PasswordAnswer));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(UserSignUpFields.IsApproved)))
            {
                obj.IsApproved = rdr.GetBoolean(rdr.GetOrdinal(UserSignUpFields.IsApproved));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(UserSignUpFields.IsLockedOut)))
            {
                obj.IsLockedOut = rdr.GetBoolean(rdr.GetOrdinal(UserSignUpFields.IsLockedOut));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(UserSignUpFields.CreateDate)))
            {
                obj.CreateDate = rdr.GetDateTime(rdr.GetOrdinal(UserSignUpFields.CreateDate));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(UserSignUpFields.LastLoginDate)))
            {
                obj.LastLoginDate = rdr.GetDateTime(rdr.GetOrdinal(UserSignUpFields.LastLoginDate));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(UserSignUpFields.LastPasswordChangedDate)))
            {
                obj.LastPasswordChangedDate = rdr.GetDateTime(rdr.GetOrdinal(UserSignUpFields.LastPasswordChangedDate));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(UserSignUpFields.LastLockoutDate)))
            {
                obj.LastLockoutDate = rdr.GetDateTime(rdr.GetOrdinal(UserSignUpFields.LastLockoutDate));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(UserSignUpFields.FailedPasswordAttemptCount)))
            {
                obj.FailedPasswordAttemptCount = rdr.GetInt32(rdr.GetOrdinal(UserSignUpFields.FailedPasswordAttemptCount));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(UserSignUpFields.FailedPasswordAnswerAttemptCount)))
            {
                obj.FailedPasswordAnswerAttemptCount = rdr.GetInt32(rdr.GetOrdinal(UserSignUpFields.FailedPasswordAnswerAttemptCount));
            }

           


        }

        public UserLoginModel ValidateUser(string email, string password)
        {           

            try
            {               
                bool executionState = false;
                var objusersignup = new UserSignUp();
                var objuserlogin = new UserLoginModel();
                _oDatabaseHelper = new DatabaseHelper();
                // Pass the specified field and its value to the stored procedure.
                _oDatabaseHelper.AddParameter("@Email", email);
                _oDatabaseHelper.AddParameter("@Password", password);
                // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
                //oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

                IDataReader rdr = _oDatabaseHelper.ExecuteReader("usp_ValidateUser", ref executionState);
                while (rdr.Read())
                {
                    objuserlogin.UserSignUpId = rdr.GetInt32(rdr.GetOrdinal(UserSignUpFields.UserSignUpId));
                    objuserlogin.UserSignUpCode = rdr.GetGuid(rdr.GetOrdinal(UserSignUpFields.UserSignUpCode)).ToString();
                    objuserlogin.Email = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.Email));
                    objuserlogin.UserName = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.UserName));
                    objuserlogin.CompanyId = rdr.GetInt32(rdr.GetOrdinal(UserSignUpFields.CompanyId));
                    objuserlogin.CompanyName = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.CompanyName));
                    objuserlogin.FirstName = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.FirstName));
                    objuserlogin.LastName = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.LastName));
                    objuserlogin.LastLoginDate = rdr.GetDateTime(rdr.GetOrdinal(UserSignUpFields.LastLoginDate));
                    objuserlogin.RoleId = rdr.GetInt32(rdr.GetOrdinal(UserSignUpFields.RoleId));
                    objuserlogin.RoleName = rdr.GetString(rdr.GetOrdinal(UserSignUpFields.RoleName));
                    objuserlogin.IsApproved = rdr.GetBoolean(rdr.GetOrdinal(UserSignUpFields.IsApproved));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeFields.IsSubmitted)))
                        objuserlogin.IsSubmitted = rdr.GetBoolean(rdr.GetOrdinal(EmployeeFields.IsSubmitted));
                }
                rdr.Close();
                return objuserlogin;
                
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

        public bool ChangePassword(string oldPassword, String newPassword, int userId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserID", userId);
                _oDatabaseHelper.AddParameter("@OldPassword", oldPassword);
                _oDatabaseHelper.AddParameter("@NewPassword", newPassword);
                _oDatabaseHelper.ExecuteScalar("Security.usp_SetPassword", ref executionState);
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

        public bool UpdateNewHireStatus(int userId,bool Status)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserID", userId);
                _oDatabaseHelper.AddParameter("@Status", Status);

                _oDatabaseHelper.ExecuteScalar("Security.usp_UpdateNewHireStatus", ref executionState);
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

        public bool ResetPassword(string userEmail,string newPassword)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserEmail", userEmail);
                _oDatabaseHelper.AddParameter("@NewPassword", newPassword);
                _oDatabaseHelper.ExecuteScalar("Security.usp_ResetPassword", ref executionState);
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

        public bool CreateEmployeeConfigurationSetup(EmployeeConfigurationSetupModel employeeConfigurationSetupobj, string createdBy,DataTable hireWizardSteps)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", employeeConfigurationSetupobj.Employee.CompanyId);

                // Pass the value of '_email' as parameter 'Email' of the stored procedure.
                _oDatabaseHelper.AddParameter("@Email", employeeConfigurationSetupobj.Employee.Email);
                // Pass the value of '_userName' as parameter 'UserName' of the stored procedure.
                _oDatabaseHelper.AddParameter("@UserName", employeeConfigurationSetupobj.Employee.Email);
                // Pass the value of '_password' as parameter 'Password' of the stored procedure.
                _oDatabaseHelper.AddParameter("@Password", employeeConfigurationSetupobj.UserSignUp.Password);
                // Pass the value of '_passwordQuestion' as parameter 'PasswordQuestion' of the stored procedure.
                _oDatabaseHelper.AddParameter("@PasswordQuestion", employeeConfigurationSetupobj.UserSignUp.PasswordQuestion);
                // Pass the value of '_passwordAnswer' as parameter 'PasswordAnswer' of the stored procedure.
                _oDatabaseHelper.AddParameter("@PasswordAnswer", employeeConfigurationSetupobj.UserSignUp.PasswordAnswer);
                // Pass the value of '_isApproved' as parameter 'IsApproved' of the stored procedure.
                _oDatabaseHelper.AddParameter("@IsApproved", employeeConfigurationSetupobj.UserSignUp.IsApproved);
                // Pass the value of '_isLockedOut' as parameter 'IsLockedOut' of the stored procedure.
                _oDatabaseHelper.AddParameter("@IsLockedOut", employeeConfigurationSetupobj.UserSignUp.IsLockedOut);
                // Pass the value of 'FirstName' as parameter 'FirstName' of the stored procedure.
                _oDatabaseHelper.AddParameter("@FirstName", employeeConfigurationSetupobj.Employee.FirstName);
                // Pass the value of 'LastName' as parameter 'LastName' of the stored procedure.
                _oDatabaseHelper.AddParameter("@LastName", employeeConfigurationSetupobj.Employee.LastName);
                _oDatabaseHelper.AddParameter("@JobProfileID", employeeConfigurationSetupobj.Employee.JobProfile);
                _oDatabaseHelper.AddParameter("@HireDate", employeeConfigurationSetupobj.Employee.HireDate);
                _oDatabaseHelper.AddParameter("@OnBoardingId", employeeConfigurationSetupobj.OnBoardingSetup.OnBoardingId);
                _oDatabaseHelper.AddParameter("@CreatedBy", createdBy);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.AddParameter("@ust_stepName", hireWizardSteps);
                _oDatabaseHelper.ExecuteScalar("usp_CreateEmployeeConfigurationSetup", ref executionState);
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

        public List<UserLoginModel> SelectAllEmployeesList(int companyId)
        {
            try
            {
                var employeeDetailList = new List<UserLoginModel>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                IDataReader selectemployeesredr = _oDatabaseHelper.ExecuteReader("usp_SelectEmployeesByCompanyId", ref executionState);

                while (selectemployeesredr.Read())
                {
                    var userLoginModelobj = new UserLoginModel();
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.UserSignUpId)))
                        userLoginModelobj.UserSignUpId = selectemployeesredr.GetInt32(selectemployeesredr.GetOrdinal(EmployeeFields.UserSignUpId));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.UserSignUpCode)))
                        userLoginModelobj.UserSignUpCode = selectemployeesredr.GetGuid(selectemployeesredr.GetOrdinal(EmployeeFields.UserSignUpCode)).ToString();
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.UserName)))
                        userLoginModelobj.UserName = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(EmployeeFields.UserName));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.FirstName)))
                        userLoginModelobj.FirstName = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(EmployeeFields.FirstName));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.LastName)))
                        userLoginModelobj.LastName = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(EmployeeFields.LastName));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.RoleId)))
                        userLoginModelobj.RoleId = selectemployeesredr.GetInt32(selectemployeesredr.GetOrdinal(EmployeeFields.RoleId));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.RoleName)))
                        userLoginModelobj.RoleName = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(EmployeeFields.RoleName));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.IsApproved)))
                        userLoginModelobj.IsApproved = selectemployeesredr.GetBoolean(selectemployeesredr.GetOrdinal(EmployeeFields.IsApproved));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.LastLoginDate)))
                        userLoginModelobj.LastLoginDate = selectemployeesredr.GetDateTime(selectemployeesredr.GetOrdinal(EmployeeFields.LastLoginDate));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.Email)))
                        userLoginModelobj.Email = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(EmployeeFields.Email));

                    employeeDetailList.Add(userLoginModelobj);
                }
                selectemployeesredr.Close();
                return employeeDetailList;
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

        public List<UserLoginModel> ShowAllEmployeesPendingListByCompanyId(int companyId)
        {
            try
            {
                var employeeDetailList = new List<UserLoginModel>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                IDataReader selectemployeesredr = _oDatabaseHelper.ExecuteReader("usp_ShowAllEmployeesPendingListByCompanyId", ref executionState);

                while (selectemployeesredr.Read())
                {
                    var userLoginModelobj = new UserLoginModel();
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(PendingEmployeeFields.UserSignUpId)))
                        userLoginModelobj.UserSignUpId = selectemployeesredr.GetInt32(selectemployeesredr.GetOrdinal(PendingEmployeeFields.UserSignUpId));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(PendingEmployeeFields.UserSignUpCode)))
                        userLoginModelobj.UserSignUpCode = selectemployeesredr.GetGuid(selectemployeesredr.GetOrdinal(PendingEmployeeFields.UserSignUpCode)).ToString();
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(PendingEmployeeFields.CompanyId)))
                        userLoginModelobj.CompanyId = selectemployeesredr.GetInt32(selectemployeesredr.GetOrdinal(PendingEmployeeFields.CompanyId));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(PendingEmployeeFields.FirstName)))
                        userLoginModelobj.FirstName = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(PendingEmployeeFields.FirstName));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(PendingEmployeeFields.LastName)))
                        userLoginModelobj.LastName = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(PendingEmployeeFields.LastName));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(PendingEmployeeFields.IsSubmitted)))
                        userLoginModelobj.IsSubmitted = selectemployeesredr.GetBoolean(selectemployeesredr.GetOrdinal(PendingEmployeeFields.IsSubmitted));

                    employeeDetailList.Add(userLoginModelobj);
                }
                selectemployeesredr.Close();
                return employeeDetailList;
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
        public bool UpdateHireApprovalSetup(string StepName, int UserId)
        {
            try
            {
              bool executionState = false;
              _oDatabaseHelper = new DatabaseHelper();
              _oDatabaseHelper.AddParameter("@StepName", StepName);
              _oDatabaseHelper.AddParameter("@UserId", UserId);
              _oDatabaseHelper.ExecuteScalar("HumanResources.usp_HireApprovalSetupUpdate", ref executionState);
            return true;
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
        public List<HireApprovalSetup> HireApprovalStatusSelect(int UserId)
        {
            List<HireApprovalSetup> hireApprovalSetupList = new List<HireApprovalSetup>();
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserId", UserId);
                IDataReader hireApprovalRdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_HireApprovalSetupSelect", ref executionState);
                 
                while (hireApprovalRdr.Read())
                {
                    var HireApprovalSetupobj = new HireApprovalSetup();
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.StepName)))
                        HireApprovalSetupobj.StepName = hireApprovalRdr.GetString(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.StepName));
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.IsActive)))
                        HireApprovalSetupobj.IsActive = hireApprovalRdr.GetBoolean(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.IsActive));
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.IsApproved)))
                        HireApprovalSetupobj.IsApproved = hireApprovalRdr.GetBoolean(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.IsApproved));
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.ApprovedOn)))
                        HireApprovalSetupobj.ApprovedOn = hireApprovalRdr.GetDateTime(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.ApprovedOn));
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.ApprovedBy)))
                        HireApprovalSetupobj.ApprovedBy = hireApprovalRdr.GetInt32(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.ApprovedBy));
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.RejectedOn)))
                        HireApprovalSetupobj.RejectedOn = hireApprovalRdr.GetDateTime(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.RejectedOn));
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.RejectedBy)))
                        HireApprovalSetupobj.RejectedBy = hireApprovalRdr.GetInt32(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.RejectedBy));
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.UserId)))
                        HireApprovalSetupobj.UserId = hireApprovalRdr.GetInt32(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.UserId));
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.HireConfigurationId)))
                        HireApprovalSetupobj.HireConfigurationId = hireApprovalRdr.GetInt32(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.HireConfigurationId));
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.HireApprovalSetupId)))
                        HireApprovalSetupobj.HireApprovalSetupId = hireApprovalRdr.GetInt32(hireApprovalRdr.GetOrdinal(HireApprovalSetupFields.HireApprovalSetupId));
                    hireApprovalSetupList.Add(HireApprovalSetupobj);
                }
                hireApprovalRdr.Close();
                 return hireApprovalSetupList;
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

        public List<UserLoginModel> SelectAllUserList(string Username)
        {
            try
            {
                var employeeDetailList = new List<UserLoginModel>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@Username", Username);
                IDataReader selectemployeesredr = _oDatabaseHelper.ExecuteReader("[HumanResources].[usp_SelectUsersByUsername]", ref executionState);

                while (selectemployeesredr.Read())
                {

                    var userLoginModelobj = new UserLoginModel();
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.UserSignUpId)))
                        userLoginModelobj.UserSignUpId = selectemployeesredr.GetInt32(selectemployeesredr.GetOrdinal(EmployeeFields.UserSignUpId));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.UserSignUpCode)))
                        userLoginModelobj.UserSignUpCode = selectemployeesredr.GetGuid(selectemployeesredr.GetOrdinal(EmployeeFields.UserSignUpCode)).ToString();
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.UserName)))
                        userLoginModelobj.UserName = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(EmployeeFields.UserName));
                    //if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.FirstName)))
                    //    userLoginModelobj.FirstName = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(EmployeeFields.FirstName));
                    //if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.LastName)))
                    //    userLoginModelobj.LastName = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(EmployeeFields.LastName));
                    //if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.RoleId)))
                    //    userLoginModelobj.RoleId = selectemployeesredr.GetInt32(selectemployeesredr.GetOrdinal(EmployeeFields.RoleId));
                    //if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.RoleName)))
                    //    userLoginModelobj.RoleName = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(EmployeeFields.RoleName));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.IsApproved)))
                        userLoginModelobj.IsApproved = selectemployeesredr.GetBoolean(selectemployeesredr.GetOrdinal(EmployeeFields.IsApproved));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.LastLoginDate)))
                        userLoginModelobj.LastLoginDate = selectemployeesredr.GetDateTime(selectemployeesredr.GetOrdinal(EmployeeFields.LastLoginDate));
                    if (!selectemployeesredr.IsDBNull(selectemployeesredr.GetOrdinal(EmployeeFields.Email)))
                        userLoginModelobj.Email = selectemployeesredr.GetString(selectemployeesredr.GetOrdinal(EmployeeFields.Email));

                    employeeDetailList.Add(userLoginModelobj);
                }
                selectemployeesredr.Close();
                return employeeDetailList;
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

        public List<UserLoginModel> SelectAllManager(int companyId)
        {
            List<UserLoginModel> UserList = new List<UserLoginModel>();
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader hireApprovalRdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_SelectAllManagers", ref executionState);

                while (hireApprovalRdr.Read())
                {
                    var userLoginModelobj = new UserLoginModel();
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal("Email")))
                        userLoginModelobj.Email = hireApprovalRdr.GetString(hireApprovalRdr.GetOrdinal("Email"));
                    if (!hireApprovalRdr.IsDBNull(hireApprovalRdr.GetOrdinal("EmployeeName")))
                        userLoginModelobj.UserName = hireApprovalRdr.GetString(hireApprovalRdr.GetOrdinal("EmployeeName"));
                    UserList.Add(userLoginModelobj);
                }
                hireApprovalRdr.Close();
                return UserList;
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
        public List<Employee> SelectEmployeesByPosition(int positionId,int companyId)
        {
            try
            {
                var employeeList = new List<Employee>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@PositionId", positionId);
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader employeeRdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_SelectEmployeeByPosition", ref executionState);

                while (employeeRdr.Read())
                {
                    var employeeObj = new Employee();
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("Email")))
                        employeeObj.Email = employeeRdr.GetString(employeeRdr.GetOrdinal("Email"));
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("FirstName")))
                        employeeObj.FirstName = employeeRdr.GetString(employeeRdr.GetOrdinal("FirstName"));
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("UserId")))
                        employeeObj.UserId = employeeRdr.GetInt32(employeeRdr.GetOrdinal("UserId"));
                    employeeList.Add(employeeObj);
                }
                employeeRdr.Close();
                return employeeList;
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
        public List<Employee> SelectEmployeesByLocation(int locationId, int companyId)
        {
            try
            {
                var employeeList = new List<Employee>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@LocationId", locationId);
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader employeeRdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_SelectEmployeeByLocation", ref executionState);

                while (employeeRdr.Read())
                {
                    var employeeObj = new Employee();
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("Email")))
                        employeeObj.Email = employeeRdr.GetString(employeeRdr.GetOrdinal("Email"));
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("FirstName")))
                        employeeObj.FirstName = employeeRdr.GetString(employeeRdr.GetOrdinal("FirstName"));
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("UserId")))
                        employeeObj.UserId = employeeRdr.GetInt32(employeeRdr.GetOrdinal("UserId"));
                    employeeList.Add(employeeObj);
                }
                employeeRdr.Close();
                return employeeList;
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
        public List<Employee> SelectEmployeesByDepartment(int departmentId, int companyId)
        {
            try
            {
                var employeeList = new List<Employee>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@DepartmentId", departmentId);
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader employeeRdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_SelectEmployeeByDepartment", ref executionState);

                while (employeeRdr.Read())
                {
                    var employeeObj = new Employee();
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("Email")))
                        employeeObj.Email = employeeRdr.GetString(employeeRdr.GetOrdinal("Email"));
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("FirstName")))
                        employeeObj.FirstName = employeeRdr.GetString(employeeRdr.GetOrdinal("FirstName"));
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("UserId")))
                        employeeObj.UserId = employeeRdr.GetInt32(employeeRdr.GetOrdinal("UserId"));
                    employeeList.Add(employeeObj);
                }
                employeeRdr.Close();
                return employeeList;
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
        public List<Employee> SelectEmployeesByEmploymentStatus(int employmentStatusId, int companyId)
        {
            try
            {
                var employeeList = new List<Employee>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@EmploymentStatusId", employmentStatusId);
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader employeeRdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_SelectEmployeeByEmploymentStatus", ref executionState);

                while (employeeRdr.Read())
                {
                    var employeeObj = new Employee();
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("Email")))
                        employeeObj.Email = employeeRdr.GetString(employeeRdr.GetOrdinal("Email"));
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("FirstName")))
                        employeeObj.FirstName = employeeRdr.GetString(employeeRdr.GetOrdinal("FirstName"));
                    if (!employeeRdr.IsDBNull(employeeRdr.GetOrdinal("UserId")))
                        employeeObj.UserId = employeeRdr.GetInt32(employeeRdr.GetOrdinal("UserId"));
                    employeeList.Add(employeeObj);
                }
                employeeRdr.Close();
                return employeeList;
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

        public object departmentId { get; set; }
    }
}
