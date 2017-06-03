using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class JobPMEDetailRepository : IJobPMEDetailRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
        public class JobPMEDetailFields
        {
            public const string PMEID = "PMEID";
            public const string CompanyId = "CompanyId";
            public const string Description = "Description";
            public const string Category = "Category";
            public const string Frequency = "Frequency";
            public const string Essential = "Essential";
            public const string CreatedOn = "CreatedOn";
            public const string ModifiedOn = "ModifiedOn";
            public const string CreatedBy = "CreatedBy";
            public const string ModifiedBy = "ModifiedBy";

        }
        public bool CreateJobPMEDetails(JobPMEDetails jobpmedetobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@PMEID", jobpmedetobj.PMEID);
                _oDatabaseHelper.AddParameter("@CompanyId", jobpmedetobj.CompanyId);
                _oDatabaseHelper.AddParameter("@Description", jobpmedetobj.Description);
                _oDatabaseHelper.AddParameter("@Category", jobpmedetobj.Category);
                _oDatabaseHelper.AddParameter("@Frequency", jobpmedetobj.Frequency);
                _oDatabaseHelper.AddParameter("@Essential", jobpmedetobj.Essential);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_JobPMEDetailInsertORUpdate", ref executionState);
                

                _oDatabaseHelper.Dispose();
                return executionState;


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
        public JobPMEDetails SelectJobPMEDetailById(int pmeId, int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                _oDatabaseHelper.AddParameter("@PMEID", pmeId);
                IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_JobPMESelect", ref executionState);

                var jobpmedetobj = new JobPMEDetails();
                while (emergencyContactredr.Read())
                {
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.PMEID)))
                        jobpmedetobj.PMEID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobPMEDetailFields.PMEID));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.CompanyId)))
                        jobpmedetobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobPMEDetailFields.CompanyId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Description)))
                        jobpmedetobj.Description = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Description));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Category)))
                        jobpmedetobj.Category = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Category));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Frequency)))
                        jobpmedetobj.Frequency = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Frequency));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Essential)))
                        jobpmedetobj.Essential = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Essential));
                    
                }
                emergencyContactredr.Close();
                return jobpmedetobj;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }

        }
        public List<JobPMEDetails> SelectAllJobPMEDetailByCompanyId(int companyId)
        {
            try
            {
                var jobpmedetList = new List<JobPMEDetails>();
                  bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
              
                IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_JobPMESelectAll", ref executionState);

                
                while (emergencyContactredr.Read())
                {
                    var jobpmedetobj = new JobPMEDetails();
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.PMEID)))
                        jobpmedetobj.PMEID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobPMEDetailFields.PMEID));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.CompanyId)))
                        jobpmedetobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobPMEDetailFields.CompanyId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Description)))
                        jobpmedetobj.Description = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Description));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Category)))
                        jobpmedetobj.Category = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Category));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Frequency)))
                        jobpmedetobj.Frequency = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Frequency));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Essential)))
                        jobpmedetobj.Essential = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobPMEDetailFields.Essential));

                }
                return jobpmedetList;

            }
            catch(Exception ex)
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