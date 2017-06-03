using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
   public class JobComplainceCodeRepository:IJobComplainceCodeRepository
    {
       private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
       public class JobComplainceCodeFields
       {
           public const string ComplainceID = "ComplainceID";
           public const string CompanyId = "CompanyId";
           public const string Description = "Description";
           public const string Type = "Type";
           public const string Code = "Code";
           
           public const string CreatedOn = "CreatedOn";
           public const string ModifiedOn = "ModifiedOn";
           public const string CreatedBy = "CreatedBy";
           public const string ModifiedBy = "ModifiedBy";

        
       }
       public bool CreateComplainceCodeDetails(JobComplianceCode jobcomplaincecodeobj)
       {
           try
           {
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();
               _oDatabaseHelper.AddParameter("@ComplainceID",jobcomplaincecodeobj.ComplainceID);
               _oDatabaseHelper.AddParameter("@CompanyId", jobcomplaincecodeobj.CompanyId);
               _oDatabaseHelper.AddParameter("@Description", jobcomplaincecodeobj.Description);
               _oDatabaseHelper.AddParameter("@Type", jobcomplaincecodeobj.Type);
               _oDatabaseHelper.AddParameter("@Code", jobcomplaincecodeobj.Code);
           
               _oDatabaseHelper.ExecuteScalar("HumanResources.usp_JobComplainceCodeDetailInsertORUpdate", ref executionState);
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
       public JobComplianceCode SelectJobComplainceCodeDetailById(int ComplainceID,int CompanyId)
       {
           try
           {
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();
               _oDatabaseHelper.AddParameter("@CompanyId",CompanyId);
               _oDatabaseHelper.AddParameter("@ComplainceID",ComplainceID);
                    IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_ComplianceCodeSelect", ref executionState);

               var jobcomplaincecodeobj=new JobComplianceCode();
               while(emergencyContactredr.Read())
               {
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ComplainceID)))
                        jobcomplaincecodeobj.ComplainceID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ComplainceID));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CompanyId)))
                        jobcomplaincecodeobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CompanyId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Description)))
                        jobcomplaincecodeobj.Description = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Description));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Type)))
                        jobcomplaincecodeobj.Type = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Type));
                     if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Code)))
                        jobcomplaincecodeobj.Code = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Code));
                   
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CreatedOn)))
                        jobcomplaincecodeobj.CreatedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CreatedOn));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ModifiedOn)))
                        jobcomplaincecodeobj.ModifiedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ModifiedOn));
                     if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CreatedBy)))
                        jobcomplaincecodeobj.CreatedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CreatedBy));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ModifiedBy)))
                        jobcomplaincecodeobj.ModifiedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ModifiedBy));
               }
               emergencyContactredr.Close();
               return jobcomplaincecodeobj;
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

       public List<JobComplianceCode> SelectAllJobComplainceCodeByCompanyId(int companyId)
       {
           try
           {
               var jobcomplaincecodeList = new List<JobComplianceCode>();
                bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();
               _oDatabaseHelper.AddParameter("@CompanyId",companyId);
                 IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_ComplianceCodeSelectAll", ref executionState);

               
               while(emergencyContactredr.Read())
               {
                   var jobcomplaincecodeobj = new JobComplianceCode();
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ComplainceID)))
                       jobcomplaincecodeobj.ComplainceID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ComplainceID));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CompanyId)))
                       jobcomplaincecodeobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CompanyId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Description)))
                       jobcomplaincecodeobj.Description = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Description));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Type)))
                       jobcomplaincecodeobj.Type = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Type));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Code)))
                       jobcomplaincecodeobj.Code = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.Code));

                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CreatedOn)))
                       jobcomplaincecodeobj.CreatedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CreatedOn));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ModifiedOn)))
                       jobcomplaincecodeobj.ModifiedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ModifiedOn));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CreatedBy)))
                       jobcomplaincecodeobj.CreatedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.CreatedBy));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ModifiedBy)))
                       jobcomplaincecodeobj.ModifiedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobComplainceCodeFields.ModifiedBy));

               }
               return jobcomplaincecodeList;
               

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
