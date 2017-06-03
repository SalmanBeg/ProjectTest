using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
  public  class JobQualificationDetailRepository : IJobQualificationDetailRepository
    {
      private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
      public class JobQualificationDetailFields
      {
          public const string JobQualificationID = "JobQualificationID";
          public const string CompanyId = "CompanyId";
          public const string Description = "Description";
          public const string Type = "Type";
          public const string SubjectArea = "SubjectArea";
          public const string Proficiency = "Proficiency";
          public const string Years = "Years";
          public const string LastUsed = "LastUsed";
          public const string Mandatory = "Mandatory";
        
          public const string CreatedOn = "CreatedOn";
          public const string ModifiedOn = "ModofiedOn";
          public const string CreatedBy = "CreatedBy";
          public const string ModifiedBy = "ModifiedBy";


          
      }
      public bool CreateJobQualificationDetails (JobQualification jobqualificationobj)
      {
          try {
              bool executionState = false;

          _oDatabaseHelper = new DatabaseHelper();
          _oDatabaseHelper.AddParameter("@JobQualificationID", jobqualificationobj.JobQualificationID);
          _oDatabaseHelper.AddParameter("@CompanyId", jobqualificationobj.CompanyId);
          _oDatabaseHelper.AddParameter("@Description", jobqualificationobj.Description);
          _oDatabaseHelper.AddParameter("@Type", jobqualificationobj.Type);
          _oDatabaseHelper.AddParameter("@SubjectArea", jobqualificationobj.SubjectArea);
          _oDatabaseHelper.AddParameter("@Proficiency", jobqualificationobj.Proficiency);
          _oDatabaseHelper.AddParameter("@Years", jobqualificationobj.Years);
          _oDatabaseHelper.AddParameter("@LastUsed", jobqualificationobj.LastUsed);
          _oDatabaseHelper.AddParameter("@Mandatory", jobqualificationobj.Mandatory);
          
          _oDatabaseHelper.ExecuteScalar("HumanResources.usp_JobQualificationDetailInsertORUpdate", ref executionState);
          _oDatabaseHelper.Dispose();
          return executionState;
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

      public JobQualification SelectJobQualificationDetailById(int JobQualificationID,int companyId)
      {
          try
          {
              bool executionState = false;
              _oDatabaseHelper = new DatabaseHelper();
              _oDatabaseHelper.AddParameter("@JobQualificationID", JobQualificationID);
              _oDatabaseHelper.AddParameter("@CompanyId", companyId);
              IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_JobQualificationSelect", ref executionState);
              var jobqualificationobj = new JobQualification();
              while(emergencyContactredr.Read())
              {
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.JobQualificationID)))
                      jobqualificationobj.JobQualificationID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.JobQualificationID));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CompanyId)))
                      jobqualificationobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CompanyId));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Description)))
                      jobqualificationobj.Description = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Description));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Type)))
                      jobqualificationobj.Type = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Type));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.SubjectArea)))
                      jobqualificationobj.SubjectArea = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.SubjectArea));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Proficiency)))
                      jobqualificationobj.Proficiency = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Proficiency));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Years)))
                      jobqualificationobj.Years = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Years));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.LastUsed)))
                      jobqualificationobj.LastUsed = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.LastUsed));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Mandatory)))
                      jobqualificationobj.Mandatory = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Mandatory));
                
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CreatedOn)))
                      jobqualificationobj.CreatedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CreatedOn));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.ModifiedOn)))
                      jobqualificationobj.ModifiedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.ModifiedOn));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CreatedBy)))
                      jobqualificationobj.CreatedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CreatedBy));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.ModifiedBy)))
                      jobqualificationobj.ModifiedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.ModifiedBy));



              }
              emergencyContactredr.Close();
              return jobqualificationobj;


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
      public List<JobQualification> SelectAllJobQualificationByCompanyId(int companyId)
      {
          try
          {
              var jobqualificationList = new List<JobQualification>();
              bool executionState = false;
              _oDatabaseHelper = new DatabaseHelper();
              _oDatabaseHelper.AddParameter("@CompanyId", companyId);
              IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_JobQualificationSelectAll", ref executionState);
              while (emergencyContactredr.Read())
              {
                  var jobqualificationobj = new JobQualification();
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.JobQualificationID)))
                      jobqualificationobj.JobQualificationID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.JobQualificationID));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CompanyId)))
                      jobqualificationobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CompanyId));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Description)))
                      jobqualificationobj.Description = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Description));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Type)))
                      jobqualificationobj.Type = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Type));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.SubjectArea)))
                      jobqualificationobj.SubjectArea = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.SubjectArea));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Proficiency)))
                      jobqualificationobj.Proficiency = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Proficiency));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Years)))
                      jobqualificationobj.Years = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Years));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.LastUsed)))
                      jobqualificationobj.LastUsed = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.LastUsed));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Mandatory)))
                      jobqualificationobj.Mandatory = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.Mandatory));

                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CreatedOn)))
                      jobqualificationobj.CreatedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CreatedOn));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.ModifiedOn)))
                      jobqualificationobj.ModifiedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.ModifiedOn));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CreatedBy)))
                      jobqualificationobj.CreatedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.CreatedBy));
                  if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.ModifiedBy)))
                      jobqualificationobj.ModifiedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobQualificationDetailFields.ModifiedBy));

              }
              return jobqualificationList;

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
