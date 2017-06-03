using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class SubmittedNewHiresRepository : ISubmittedNewHiresRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
        public class SubmittedNewHiresFields
        {
            public const string Email = "Email";
            public const string UserSignUpID = "UserSignUpID";
            public const string UserName = "UserName";
            public const string UserSignUpCode = "UserSignUpCode";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string CompanyID = "CompanyID";
            public const string IsApproved = "IsApproved";
            public const string IsSubmitted = "IsSubmitted";
        }
        public List<SubmittedNewHires> SelectAllNewHires(int companyId)
        {
            
            try
            {
                List<SubmittedNewHires> submittedNewHiresList = new List<SubmittedNewHires>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                IDataReader selectNewHiresrdr = _oDatabaseHelper.ExecuteReader("dbo.usp_SelectNewHires", ref executionState);

                while (selectNewHiresrdr.Read())
                {
                    var submittedNewHiresobj = new SubmittedNewHires();
                    if (!selectNewHiresrdr.IsDBNull(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.Email)))
                        submittedNewHiresobj.Email = selectNewHiresrdr.GetString(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.Email));
                    if (!selectNewHiresrdr.IsDBNull(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.UserSignUpCode)))
                        submittedNewHiresobj.UserSignUpCode = selectNewHiresrdr.GetGuid(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.UserSignUpCode)).ToString();
                    if (!selectNewHiresrdr.IsDBNull(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.UserSignUpID)))
                        submittedNewHiresobj.UserSignUpID = selectNewHiresrdr.GetInt32(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.UserSignUpID));
                    if (!selectNewHiresrdr.IsDBNull(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.UserName)))
                        submittedNewHiresobj.UserName = selectNewHiresrdr.GetString(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.UserName));
                    if (!selectNewHiresrdr.IsDBNull(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.CompanyID)))
                        submittedNewHiresobj.CompanyID = selectNewHiresrdr.GetInt32(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.CompanyID));
                    if (!selectNewHiresrdr.IsDBNull(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.FirstName)))
                        submittedNewHiresobj.FirstName = selectNewHiresrdr.GetString(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.FirstName));
                    if (!selectNewHiresrdr.IsDBNull(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.LastName)))
                        submittedNewHiresobj.LastName = selectNewHiresrdr.GetString(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.LastName));
                    if (!selectNewHiresrdr.IsDBNull(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.IsSubmitted)))
                        submittedNewHiresobj.IsSubmitted = selectNewHiresrdr.GetBoolean(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.IsSubmitted));
                    if (!selectNewHiresrdr.IsDBNull(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.IsApproved)))
                        submittedNewHiresobj.IsApproved = selectNewHiresrdr.GetBoolean(selectNewHiresrdr.GetOrdinal(SubmittedNewHiresFields.IsApproved));

                    submittedNewHiresList.Add(submittedNewHiresobj);
                }
                selectNewHiresrdr.Close();
                return submittedNewHiresList;
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
