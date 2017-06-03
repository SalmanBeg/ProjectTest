using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
   public  class JobCompensationRepository:IJobCompensationRepository
    {
       private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
       public class JobCompensationFields
       {
           public const string CompensationID = "CompensationID";
           public const string CompanyId = "CompanyId";
           public const string PlanDescription = "PlanDescription";
           public const string Location = "Location";
           public const string PayRange = "PayRange";
           public const string PayRangeTo = "PayRangeTo";
           public const string PayRangePer = "PayRangePer";
           public const string VariablePay = "VariablePay";
           public const string VariablePayTo = "VariablePayTo";
           public const string VariablePayPer = "VariablePayPer";
           public const string HoursPerWeek = "HoursPerWeek";
           public const string Exempt = "Exempt";
           public const string BenfitClass = "BenfitClass";
           public const string CreatedOn = "CreatedOn";
           public const string ModifiedOn = "ModifiedOn";
           public const string CreatedBy = "CreatedBy";
           public const string ModifiedBy = "ModifiedBy";

       }
       public bool CreateJobCompensationDetails(JobCompensationDetail jobcompensationobj)
       {
           try
           {
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();
               _oDatabaseHelper.AddParameter("@CompensationID", jobcompensationobj.CompensationID);
               _oDatabaseHelper.AddParameter("@CompanyId", jobcompensationobj.CompanyId);
               _oDatabaseHelper.AddParameter("@PlanDescription", jobcompensationobj.PlanDescription);
               _oDatabaseHelper.AddParameter("@Location", jobcompensationobj.Location);
               _oDatabaseHelper.AddParameter("@PayRange",jobcompensationobj.PayRange);
               _oDatabaseHelper.AddParameter("@PayRangeTo", jobcompensationobj.PayRangeTo);
               _oDatabaseHelper.AddParameter("@PayRangePer", jobcompensationobj.PayRangePer);
               _oDatabaseHelper.AddParameter("@variablePay", jobcompensationobj.VaraiblePay);
               _oDatabaseHelper.AddParameter("@VariablePayTo", jobcompensationobj.VariablePayTo);
               _oDatabaseHelper.AddParameter("@VariablePayPer", jobcompensationobj.VariablePayPer);
               _oDatabaseHelper.AddParameter("@HoursPerWeek", jobcompensationobj.HoursPerWeek);
               _oDatabaseHelper.AddParameter("@Exempt", jobcompensationobj.Exempt);
               _oDatabaseHelper.AddParameter("@BenfitClass", jobcompensationobj.BenfitClass);
               _oDatabaseHelper.AddParameter("@Exempt", jobcompensationobj.Exempt);
               _oDatabaseHelper.AddParameter("@CreatedBy", jobcompensationobj.CreatedBy);
               _oDatabaseHelper.AddParameter("@CreatedOn", jobcompensationobj.CreatedOn);
               _oDatabaseHelper.ExecuteScalar("HumanResources.usp_JobCompensationPlanInsertORUpdate", ref executionState);
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
       public JobCompensationDetail SelectJobCompensationDetailById(int compensationID, int companyId)
       
       {
           try
           {

               bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                _oDatabaseHelper.AddParameter("@CompensationID", compensationID);
                IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_CompensationPlanSelect", ref executionState);

                var jobcompensationobj = new JobCompensationDetail();
                while (emergencyContactredr.Read())
                {

                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.CompensationID)))
                        jobcompensationobj.CompensationID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.CompensationID));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.CompanyId)))
                        jobcompensationobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.CompanyId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.PlanDescription)))
                        jobcompensationobj.PlanDescription = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobCompensationFields.PlanDescription));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.Location)))
                        jobcompensationobj.Location = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobCompensationFields.Location));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRange)))
                        jobcompensationobj.PayRange = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRange));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRangeTo)))
                        jobcompensationobj.PayRangeTo = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRangeTo));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRangePer)))
                        jobcompensationobj.PayRangePer = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRangePer));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePay)))
                        jobcompensationobj.VaraiblePay = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePay));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePayTo)))
                        jobcompensationobj.VariablePayTo = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePayTo));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePayPer)))
                        jobcompensationobj.VariablePayPer = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePayPer));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.HoursPerWeek)))
                        jobcompensationobj.HoursPerWeek = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobCompensationFields.HoursPerWeek));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.BenfitClass)))
                        jobcompensationobj.BenfitClass = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.BenfitClass));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.Exempt)))
                        jobcompensationobj.Exempt = emergencyContactredr.GetBoolean(emergencyContactredr.GetOrdinal(JobCompensationFields.Exempt));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.CreatedOn)))
                        jobcompensationobj.CreatedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobCompensationFields.CreatedOn));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.ModifiedOn)))
                        jobcompensationobj.ModifiedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobCompensationFields.ModifiedOn));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.CreatedBy)))
                        jobcompensationobj.CreatedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.CreatedBy));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.ModifiedBy)))
                        jobcompensationobj.ModifiedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.ModifiedBy));

                }
                emergencyContactredr.Close();
                return jobcompensationobj;
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
       public List<JobCompensationDetail> SelectAllJobCompensationDetailByCompanyId(int companyId)
       {
           try
           {
               var jobcompensationList = new List<JobCompensationDetail>();
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();
               _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                 IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_usp_CompensationPlanSelectAll", ref executionState);

                
                while (emergencyContactredr.Read())
                {
                    var jobcompensationobj = new JobCompensationDetail();
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.CompensationID)))
                        jobcompensationobj.CompensationID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.CompensationID));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.CompanyId)))
                        jobcompensationobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.CompanyId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.PlanDescription)))
                        jobcompensationobj.PlanDescription = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobCompensationFields.PlanDescription));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.Location)))
                        jobcompensationobj.Location = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobCompensationFields.Location));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRange)))
                        jobcompensationobj.PayRange = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRange));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRangeTo)))
                        jobcompensationobj.PayRangeTo = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRangeTo));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRangePer)))
                        jobcompensationobj.PayRangePer = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.PayRangePer));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePay)))
                        jobcompensationobj.VaraiblePay = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePay));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePayTo)))
                        jobcompensationobj.VariablePayTo = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePayTo));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePayPer)))
                        jobcompensationobj.VariablePayPer = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.VariablePayPer));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.HoursPerWeek)))
                        jobcompensationobj.HoursPerWeek = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(JobCompensationFields.HoursPerWeek));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.BenfitClass)))
                        jobcompensationobj.BenfitClass = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.BenfitClass));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.Exempt)))
                        jobcompensationobj.Exempt = emergencyContactredr.GetBoolean(emergencyContactredr.GetOrdinal(JobCompensationFields.Exempt));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.CreatedOn)))
                        jobcompensationobj.CreatedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobCompensationFields.CreatedOn));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.ModifiedOn)))
                        jobcompensationobj.ModifiedOn = emergencyContactredr.GetDateTime(emergencyContactredr.GetOrdinal(JobCompensationFields.ModifiedOn));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.CreatedBy)))
                        jobcompensationobj.CreatedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.CreatedBy));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(JobCompensationFields.ModifiedBy)))
                        jobcompensationobj.ModifiedBy = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(JobCompensationFields.ModifiedBy));

                }
                return jobcompensationList;
               
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
