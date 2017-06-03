using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
   public class OnBoardingRepository:IOnBoardingRepository
    {
       private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

       public class OnBoardingModelFields
       {
           public const string ConsentFormId = "ConsentFormId";
           public const string ConsentCode = "ConsentCode";
           public const string UserId = "UserId";
           public const string Title = "Title";
           public const string ConsentType = "ConsentType";
           public const string Description = "Description";
           public const string AttachmentFileId = "AttachmentFileId";
           public const string DisplayDocInConsent = "DisplayDocInConsent";
           public const string EnableUploadLink = "EnableUploadLink";
           public const string OnBoardingProfileId = "OnBoardingProfileId";
           public const string DocumentName = "DocumentName";
           public const string UploadedOn = "UploadedOn";
           public const string CreatedBy = "CreatedBy";
           public const string ModifiedBy = "ModifiedBy";
           public const string CreatedOn = "CreatedOn";
           public const string ModifiedOn = "ModifiedOn";
           public const string OnBoardingId = "OnBoardingId";
           public const string OnBoardingCode = "OnBoardingCode";
           public const string OnBoardingName = "OnBoardingName";
           public const string CompanyId = "CompanyId";
           public const string Active = "Active";
       }

       public bool CreateOnBoarding(OnBoarding onBoardingobj, DataTable consentFormTable)
       {
           bool executionState = false;
           _oDatabaseHelper = new DatabaseHelper();
           _oDatabaseHelper.AddParameter("@CompanyId", onBoardingobj.CompanyId);
           _oDatabaseHelper.AddParameter("@OnBoardingName", onBoardingobj.OnBoardingName);
           _oDatabaseHelper.AddParameter("@ust_ConsentdocId", consentFormTable);
           _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
           _oDatabaseHelper.ExecuteScalar("HumanResources.usp_OnBoardingInsert", ref executionState);
           _oDatabaseHelper.Dispose();
           return executionState;
       }

       public List<OnBoarding> SelectAllOnBoardingByCompanyId(int companyId)
       {
           try
           {
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();

               List<OnBoarding> onBoardingFormList = new List<OnBoarding>();
               _oDatabaseHelper.AddParameter("@CompanyId", companyId);
               IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_OnBoardingSelectAll", ref executionState);
               while (rdr.Read())
               {
                   var onBoardingobj = new OnBoarding();
                   if (!rdr.IsDBNull(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingId)))
                       onBoardingobj.OnBoardingId = rdr.GetInt32(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingId));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingCode)))
                       onBoardingobj.OnBoardingCode = rdr.GetGuid(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingCode)).ToString();
                   if (!rdr.IsDBNull(rdr.GetOrdinal(OnBoardingModelFields.CompanyId)))
                       onBoardingobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(OnBoardingModelFields.CompanyId));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingName)))
                       onBoardingobj.OnBoardingName = rdr.GetString(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingName));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(OnBoardingModelFields.Active)))
                       onBoardingobj.Active = rdr.GetBoolean(rdr.GetOrdinal(OnBoardingModelFields.Active));
                   onBoardingFormList.Add(onBoardingobj);
               }
               rdr.Close();
               return onBoardingFormList;
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

       public List<OnBoarding> SelectOnBoardingByOnBoardingId(int onBoardingId)
       {
           try
           {
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();

               List<OnBoarding> onBoardingFormList = new List<OnBoarding>();
               _oDatabaseHelper.AddParameter("@OnBoardingId", onBoardingId);
               IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_OnBoardingSelect", ref executionState);
               while (rdr.Read())
               {
                   var onBoardingobj = new OnBoarding();
                   if (!rdr.IsDBNull(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingId)))
                       onBoardingobj.OnBoardingId = rdr.GetInt32(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingId));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingCode)))
                       onBoardingobj.OnBoardingCode = rdr.GetGuid(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingCode)).ToString();
                   if (!rdr.IsDBNull(rdr.GetOrdinal(OnBoardingModelFields.CompanyId)))
                       onBoardingobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(OnBoardingModelFields.CompanyId));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingName)))
                       onBoardingobj.OnBoardingName = rdr.GetString(rdr.GetOrdinal(OnBoardingModelFields.OnBoardingName));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(OnBoardingModelFields.Active)))
                       onBoardingobj.Active = rdr.GetBoolean(rdr.GetOrdinal(OnBoardingModelFields.Active));
                   onBoardingFormList.Add(onBoardingobj);
               }
               rdr.Close();
               return onBoardingFormList;
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

       public bool DeleteOnBoarding(int onBoardingId)
       {
           try
           {
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();
               _oDatabaseHelper.AddParameter("@OnBoardingId", onBoardingId);
               _oDatabaseHelper.ExecuteScalar("HumanResources.usp_OnBoardingDelete", ref executionState);
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
    }
}
