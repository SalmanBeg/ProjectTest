using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;


namespace HRMS.Data
{
   public class PositionRepository:IPositionRepository
    {
       private DatabaseHelper _oDataBaseHelper = new DatabaseHelper();

       public class PositionDetailsFields
       {
           public const string PositionID = "PositionId";
           public const string CompanyID = "CompanyId";
           public const string PositionTitle = "PositionTitle";
           public const string PositionCode = "PositionCode";
           public const string JobProfileId = "JobProfileId";
           public const string RecruitingProfileId = "RecruitintProfileId";
           public const string OnBoardingProfileId = "OnBoardingProfileId";
           public const string CompensationProfileId = "CompensationProfileId";
           public const string TrainingTracksId = "TrainingTracksId";
           public const string TimeProfileId = "TimeProfileId";
           public const string WorkProfileId = "WorkProfileId";
           public const string BudgetId = "BudgetId";
           public const string SecurityRoleId = "SecurityRoleId";
           public const string LocationId = "LocationId";
           public const string DepartmentId = "DepartmentId";
           public const string DivisionId = "DivisionId";
           public const string CostCenter4Id = "CostCenter4Id";
           public const string CostCenter5Id = "CostCenter5Id";
           public const string EEOCodeId = "EEOCodeId";
           public const string FLSACodeId = "FLSACodeId";
           public const string WorkersCompCodeId = "WorkersCompCodeId";
           public const string ReportsToId = "ReportsToId";
           public const string HeadOfOrganization = "HeadOfOrganization";
           public const string PositionName = "PositionName";
           public const string Department="Department";
           public const string Incumbents = "Incumbents";
           public const string OpenFTES = "OpenFTES";
           public const string Action = "Action";

       }
       public bool CreatePositionDetails(PositionDetails posdetobj)
       {
           try
           {
               bool executionState = false;
               _oDataBaseHelper = new DatabaseHelper();
               _oDataBaseHelper.AddParameter("@PositionID",    posdetobj.PositionID);
               _oDataBaseHelper.AddParameter("@CompanyID", posdetobj.CompanyID);
               _oDataBaseHelper.AddParameter("@PositionTitle", posdetobj.PositionTitle);
               _oDataBaseHelper.AddParameter("@PositionCode", posdetobj.PositionCode);
               _oDataBaseHelper.AddParameter("@JobProfileId", posdetobj.JobProfileId);
               _oDataBaseHelper.AddParameter("@RecruitintProfileId", posdetobj.RecruitingProfileId);
               _oDataBaseHelper.AddParameter("@OnBoardingProfileId", posdetobj.OnBoardingProfileId);
               _oDataBaseHelper.AddParameter("@CompensationProfileId", posdetobj.CompensationProfileId);
               _oDataBaseHelper.AddParameter("@TrainingTracksId", posdetobj.TrainingTracksId);
               _oDataBaseHelper.AddParameter("@TimeProfileId", posdetobj.TimeProfileId);
               _oDataBaseHelper.AddParameter("@WorkProfileId", posdetobj.WorkProfileId);
               _oDataBaseHelper.AddParameter("@BudgetId", posdetobj.BudgetId);
               _oDataBaseHelper.AddParameter("@SecurityRoleId", posdetobj.SecurityId);
               _oDataBaseHelper.AddParameter("@LocationId", posdetobj.LocationId);
               _oDataBaseHelper.AddParameter("@DepartmentId", posdetobj.DepartmentId);
               _oDataBaseHelper.AddParameter("@DivisionId", posdetobj.DivisionId);
               _oDataBaseHelper.AddParameter("@CostCenter4Id", posdetobj.CostCenter4Id);
               _oDataBaseHelper.AddParameter("@CostCenter5Id", posdetobj.CostCenter5Id);
               _oDataBaseHelper.AddParameter("@EEOCodeId", posdetobj.EEOCodeId);
               _oDataBaseHelper.AddParameter("@FLSACodeId", posdetobj.FLSACodeId);
               _oDataBaseHelper.AddParameter("@WorkersCompCodeId", posdetobj.WorkersCompCodeId);
               _oDataBaseHelper.AddParameter("@ReportsToId", posdetobj.ReportsToId);
               _oDataBaseHelper.AddParameter("@HeadOfOrganization", posdetobj.HeadOfOrganization);
               _oDataBaseHelper.ExecuteScalar("", ref executionState);
               _oDataBaseHelper.Dispose();
               return executionState;
           }
           catch(Exception ex)
           {
               throw;
           }
           finally
           {
               _oDataBaseHelper.Dispose();
           }
       }
    
     public List<PositionDetails> SelectAllPositionDetailsByCompanyId(int CompanyId)
       {
           try
           {
               var PositionDetailList=new List<PositionDetails>();
               bool executionState = false;
               _oDataBaseHelper = new DatabaseHelper();
               
               _oDataBaseHelper.AddParameter("@CompanyID", CompanyId);
              
               IDataReader emergencyContactredr = _oDataBaseHelper.ExecuteReader("HumanResources.usp_PositionDetailSelectAll", ref executionState);
              // var positionDetailobj = new PositionDetails();
               while(emergencyContactredr.Read())
               {
                   var positionDetailobj = new PositionDetails();
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.PositionID)))
                       positionDetailobj.PositionID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.PositionID));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.CompanyID)))
                       positionDetailobj.CompanyID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.CompanyID));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.PositionTitle)))
                       positionDetailobj.PositionTitle = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(PositionDetailsFields.PositionTitle));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.JobProfileId)))
                       positionDetailobj.JobProfileId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.JobProfileId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.RecruitingProfileId)))
                       positionDetailobj.RecruitingProfileId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.RecruitingProfileId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.OnBoardingProfileId)))
                       positionDetailobj.OnBoardingProfileId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.OnBoardingProfileId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.CompensationProfileId)))
                       positionDetailobj.CompensationProfileId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.CompensationProfileId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.TrainingTracksId)))
                       positionDetailobj.TrainingTracksId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.TrainingTracksId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.TimeProfileId))))
                       positionDetailobj.TimeProfileId=emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.TimeProfileId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.WorkProfileId)))
                       positionDetailobj.WorkProfileId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.WorkProfileId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.BudgetId)))
                       positionDetailobj.BudgetId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.BudgetId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.SecurityRoleId))))
                       positionDetailobj.SecurityId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.SecurityRoleId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.LocationId)))
                       positionDetailobj.LocationId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.LocationId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.DepartmentId)))
                       positionDetailobj.DepartmentId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.DepartmentId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.DivisionId))))
                       positionDetailobj.DivisionId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.DivisionId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.CostCenter4Id)))
                       positionDetailobj.CostCenter4Id = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.CostCenter4Id));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.LocationId)))
                       positionDetailobj.CostCenter5Id = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.CostCenter5Id));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.EEOCodeId)))
                       positionDetailobj.EEOCodeId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.EEOCodeId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.FLSACodeId)))
                       positionDetailobj.FLSACodeId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.WorkersCompCodeId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.CostCenter4Id)))
                       positionDetailobj.WorkersCompCodeId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.WorkersCompCodeId));
                   if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.ReportsToId)))
                       positionDetailobj.ReportsToId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.ReportsToId));

                   PositionDetailList.Add(positionDetailobj);
               }
               emergencyContactredr.Close();
               return PositionDetailList;

           }
         catch(Exception ex)
           {
               throw;
           }
         finally
           {
               _oDataBaseHelper.Dispose();
           }

       }

     public List<PositionDetails> SelectPositionDetailsById(int PositionId, int CompanyId)
     {
         try
         {
             var PositionDetailList = new List<PositionDetails>();
             bool executionState = false;
             _oDataBaseHelper = new DatabaseHelper();
             _oDataBaseHelper.AddParameter("@PositionID", PositionId);
             _oDataBaseHelper.AddParameter("@CompanyID", CompanyId);
             IDataReader emergencyContactredr = _oDataBaseHelper.ExecuteReader("HumanResources.usp_PositionDetailSelect", ref executionState);
             
             while (emergencyContactredr.Read())
             {
                 var positionDetailobj = new PositionDetails();
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.PositionID)))
                     positionDetailobj.PositionID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.PositionID));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.CompanyID)))
                     positionDetailobj.CompanyID = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.CompanyID));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.PositionTitle)))
                     positionDetailobj.PositionTitle = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(PositionDetailsFields.PositionTitle));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.JobProfileId)))
                     positionDetailobj.JobProfileId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.JobProfileId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.RecruitingProfileId)))
                     positionDetailobj.RecruitingProfileId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.RecruitingProfileId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.OnBoardingProfileId)))
                     positionDetailobj.OnBoardingProfileId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.OnBoardingProfileId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.CompensationProfileId)))
                     positionDetailobj.CompensationProfileId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.CompensationProfileId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.TrainingTracksId)))
                     positionDetailobj.TrainingTracksId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.TrainingTracksId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.TimeProfileId))))
                     positionDetailobj.TimeProfileId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.TimeProfileId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.WorkProfileId)))
                     positionDetailobj.WorkProfileId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.WorkProfileId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.BudgetId)))
                     positionDetailobj.BudgetId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.BudgetId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.SecurityRoleId))))
                     positionDetailobj.SecurityId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.SecurityRoleId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.LocationId)))
                     positionDetailobj.LocationId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.LocationId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.DepartmentId)))
                     positionDetailobj.DepartmentId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.DepartmentId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.DivisionId))))
                     positionDetailobj.DivisionId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.DivisionId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.CostCenter4Id)))
                     positionDetailobj.CostCenter4Id = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.CostCenter4Id));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.LocationId)))
                     positionDetailobj.CostCenter5Id = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.CostCenter5Id));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.EEOCodeId)))
                     positionDetailobj.EEOCodeId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.EEOCodeId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.FLSACodeId)))
                     positionDetailobj.FLSACodeId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.WorkersCompCodeId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.CostCenter4Id)))
                     positionDetailobj.WorkersCompCodeId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.WorkersCompCodeId));
                 if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(PositionDetailsFields.ReportsToId)))
                     positionDetailobj.ReportsToId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(PositionDetailsFields.ReportsToId));
                 PositionDetailList.Add(positionDetailobj);

             }
             emergencyContactredr.Close();
             return PositionDetailList;

         }
         catch (Exception ex)
         {
             throw;
         }
         finally
         {
             _oDataBaseHelper.Dispose();
         }

     }
     public bool DeletePositionDetail(int PositionID, int CompanyID)
     {
         try
         {
             bool executionState = false;
             _oDataBaseHelper = new DatabaseHelper();
             _oDataBaseHelper.AddParameter("@PositionID", PositionID);
             _oDataBaseHelper.AddParameter("@CompanyID", CompanyID);

             _oDataBaseHelper.ExecuteScalar("HumanResources.usp_PositionDetailDelete", ref executionState);
             _oDataBaseHelper.Dispose();

             return executionState;
         }
         catch (Exception)
         {
             throw;
         }
         finally
         {
             _oDataBaseHelper.Dispose();
         }
     }
}
    
}

