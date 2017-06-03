using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
   public class JobDutiesDetailRepository:IJobDutiesDetailRepository
    {
       DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
       public class JobDutiesDetailFields
       {
           public const string JobDutyID = "JobDutyID";
           public const string CompanyId = "CompanyId";
           public const string Description = "Description";
           public const string Category = "Category";
           public const string Priority = "Priority";
           public const string PercentageOfTime = "PercentageOfTime";                    
           public const string Frequency = "Frequency";
           public const string Essential = "Essential";
           public const string Other = "Other";    
           public const string CreatedOn = "CreatedOn";
           public const string ModifiedOn = "ModifiedOn";
           public const string CreatedBy = "CreatedBy";
           public const string ModifiedBy = "ModifiedBy";
       }
       public bool CreateJobDutiesDetails(JobDutiesDetail jobdutiesDetailobj)
       {
           try
           {
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();
               _oDatabaseHelper.AddParameter("@JobDutyID",jobdutiesDetailobj.JobDutyID);
               _oDatabaseHelper.AddParameter("@CompanyId", jobdutiesDetailobj.CompanyId);
               _oDatabaseHelper.AddParameter("@Description", jobdutiesDetailobj.Description);
               _oDatabaseHelper.AddParameter("@Category", jobdutiesDetailobj.Category);
               _oDatabaseHelper.AddParameter("@Priority", jobdutiesDetailobj.Priority);
               _oDatabaseHelper.AddParameter("PercentageOfTime", jobdutiesDetailobj.PercentageOfTime);              
               _oDatabaseHelper.AddParameter("@Frequency", jobdutiesDetailobj.Frequency);
               _oDatabaseHelper.AddParameter("@Essential", jobdutiesDetailobj.Essential);              
               _oDatabaseHelper.AddParameter("@Other", jobdutiesDetailobj.Other);
               _oDatabaseHelper.AddParameter("@CreatedOn", jobdutiesDetailobj.CreatedOn);
               _oDatabaseHelper.AddParameter("@ModifiedOn", jobdutiesDetailobj.ModifiedOn);
               _oDatabaseHelper.AddParameter("@CreatedBy", jobdutiesDetailobj.CreatedBy);
               _oDatabaseHelper.AddParameter("@ModifiedBy", jobdutiesDetailobj.ModifiedBy);
               _oDatabaseHelper.ExecuteScalar("HumanResources.usp_JobDutiesInsertORUpdate", ref executionState);
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
       public List<JobDutiesDetail> SelectAllJobDutiesDetail( int companyId)
       {
           try
           {
               var jobdutiesDetailList=new List<JobDutiesDetail>();
               bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
               // _oDatabaseHelper.AddParameter("@JobDutyID", JobDutyID);
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_JobDutiesSelectAll", ref executionState);

                while (emergencyContactredr.Read())
                {
                    var jobdutiesDetailobj = new JobDutiesDetail();
                   if(!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.JobDutyID))) 
                   jobdutiesDetailobj.JobDutyID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.JobDutyID));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CompanyId))) 
                   jobdutiesDetailobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CompanyId));
                  
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Description)))
                       jobdutiesDetailobj.Description = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Description));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Category)))
                       jobdutiesDetailobj.Category = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Category));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Priority)))
                       jobdutiesDetailobj.Priority = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Priority));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.PercentageOfTime)))
                       jobdutiesDetailobj.PercentageOfTime = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.PercentageOfTime));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Frequency)))
                       jobdutiesDetailobj.Frequency = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Frequency));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Essential))) 
                   jobdutiesDetailobj.Essential = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Essential));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Other)))
                       jobdutiesDetailobj.Other = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Other));                   
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CreatedOn))) 
                   jobdutiesDetailobj.CreatedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CreatedOn));                  
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.ModifiedOn))) 
                   jobdutiesDetailobj.ModifiedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.ModifiedOn));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CreatedBy))) 
                   jobdutiesDetailobj.CreatedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CreatedBy));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.ModifiedBy)))
                       jobdutiesDetailobj.ModifiedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.ModifiedBy));

                    jobdutiesDetailList.Add(jobdutiesDetailobj);
                }
               emergencyContactredr.Close();
               return jobdutiesDetailList;
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
       public JobDutiesDetail SelectJobDutiesDetailById(int jobdutiesDetailId, int companyId)
       {
           try
           {
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();
             //  _oDatabaseHelper.AddParameter("@JobDutyID", jobdutiesDetailId);
               _oDatabaseHelper.AddParameter("CompanyId", companyId);
               IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_JobDutiesSelectAll", ref executionState);
               var jobdutiesDetailobj = new JobDutiesDetail();
               while(emergencyContactredr.Read())
               {
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.JobDutyID))) 
                   jobdutiesDetailobj.JobDutyID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.JobDutyID));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CompanyId))) 
                   jobdutiesDetailobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CompanyId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Description)))
                       jobdutiesDetailobj.Description = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Description));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Category))) 
                   jobdutiesDetailobj.Category = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Category));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Priority)))
                       jobdutiesDetailobj.Priority = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Priority));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.PercentageOfTime)))
                       jobdutiesDetailobj.PercentageOfTime = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.PercentageOfTime));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Frequency)))
                       jobdutiesDetailobj.Frequency = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Frequency));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Essential))) 
                   jobdutiesDetailobj.Essential = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.Essential));
                               
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CreatedOn))) 
                   jobdutiesDetailobj.CreatedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CreatedOn));                
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.ModifiedOn))) 
                   jobdutiesDetailobj.ModifiedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.ModifiedOn));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CreatedBy))) 
                   jobdutiesDetailobj.CreatedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.CreatedBy));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.ModifiedBy)))
                       jobdutiesDetailobj.ModifiedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobDutiesDetailFields.ModifiedBy));
               }
               emergencyContactredr.Close();
               return jobdutiesDetailobj;
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


       public object JobDutyID { get; set; }
    }
}
