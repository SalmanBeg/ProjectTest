using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
   public class LookUpTableRepository:ILookUpTableRepository
    {
       public List<LookUpDataEntity> SelectLookUpData(string tableName, int companyId)
       {
           
           try
           {
               using (var hrmsEntity = new HRMSEntities1())
               {
                   var lstLookUpDataEntityResult = hrmsEntity.usp_LookUpDataSelect(tableName, companyId).ToList();
                   return lstLookUpDataEntityResult.Select(lookupdataentityObj => new LookUpDataEntity
                   {
                       Id = lookupdataentityObj.ID,
                       Name = lookupdataentityObj.Name,
                       Description = lookupdataentityObj.Description,
                       Status = lookupdataentityObj.Status,
                       CompanyId = lookupdataentityObj.CompanyID
                   }).ToList();      
               }         
           }
           catch(Exception)
           {
               throw;
           }
           
       }
       public bool AddLookUpData(LookUpDataEntity lookUpDataEntityObj, string tableName)
       {
           
           try
           {
               using (var hrmsEntity = new HRMSEntities1())
               {
                   var result = hrmsEntity.usp_LookUpDataInsert(tableName, lookUpDataEntityObj.CompanyId, lookUpDataEntityObj.Name, lookUpDataEntityObj.Description
                             , lookUpDataEntityObj.Status);
                   return result > 0; 
               }
           }
           catch(Exception)
           {
               throw;
           }
           
       }
       public LookUpDataEntity SelectLookUpDataById(string tableName, int companyId, int primaryId)
       {
           
           try
           {
               using (var hrmsEntity = new HRMSEntities1())
               {
                   var lstLookUpDataEntityResult = hrmsEntity.usp_LookUpDataSelectById(tableName, companyId, primaryId);
                   //  LookUpDataEntity lookUpDataEntityObj = new LookUpDataEntity();
                   var lstLookUpDataEntityResult1 = new List<usp_UtilityTablesSelect_Result>();
                   return lstLookUpDataEntityResult.Select(lookupdataentityObj => new LookUpDataEntity
                   {
                       Id = lookupdataentityObj.ID,
                       Name = lookupdataentityObj.Name,
                       Description = lookupdataentityObj.Description,
                       Status = lookupdataentityObj.Status,
                       CompanyId = lookupdataentityObj.CompanyID,
                       primaryId = lookupdataentityObj.ID
                   }).FirstOrDefault();      
               }         
           }
           catch (Exception)
           {
               throw;
           }
       }
       public bool UpdateLookUpData(LookUpDataEntity lookUpDataEntityObj, string tableName)
       {
           
           try
           {
               using (var hrmsEntity = new HRMSEntities1())
               {
                   var result = hrmsEntity.usp_LookUpDataUpdate(tableName, lookUpDataEntityObj.CompanyId, lookUpDataEntityObj.Name
                             , lookUpDataEntityObj.Description, lookUpDataEntityObj.Status, lookUpDataEntityObj.primaryId);
                   return result > 0; 
               }
           }
           catch(Exception )
           {
               throw ;
           }
         
       }


       public bool DeleteLookUpDataById(int recordId,string tableName, int companyId)
       {
           
           try
           {
               using (var hrmsEntity = new HRMSEntities1())
               {
                   var result = hrmsEntity.usp_LookUpDataDelete(tableName, recordId, companyId);
                   return result > 0; 
               }
           }
           catch (Exception)
           {
               throw;
           }
       }
    }
}
