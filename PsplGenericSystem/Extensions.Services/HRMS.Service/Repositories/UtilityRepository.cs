using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;

namespace HRMS.Service.Repositories
{
    public class UtilityRepository : IUtilityRepository
    {
        public List<CountryRegion> GetCountry()
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstCountries = hrmsEntity.usp_CountryRegionSelectAll().ToList();
                    var countryList = lstCountries.Select(countryObj => new CountryRegion
                    {
                        CountryRegionID = countryObj.CountryRegionID,
                        CountryRegionCode = countryObj.CountryRegionCode,
                        Name = countryObj.Name
                    }).ToList();

                    return countryList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public List<StateProvince> GetStateProvince(int? countryRegionId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstStates = hrmsEntity.usp_StateProvinceSelectAll(countryRegionId).ToList();
                    var stateProvinceList = lstStates.Select(stateObj => new StateProvince
                    {
                        StateProvinceID = stateObj.StateProvinceID,
                        StateProvinceCode = stateObj.StateProvinceCode,
                        Name = stateObj.Name,
                        rowguid = stateObj.rowguid
                    }).ToList();

                    return stateProvinceList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public List<StateProvince> GetStateProvinceByStateId(int stateId)
        {
            var hrmsentity = new HRMSEntities1();
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstStates = hrmsentity.usp_StateProvinceSelect(stateId).ToList();
                    var stateProvinceList = lstStates.Select(stateObj => new StateProvince
                    {
                        StateProvinceID = stateObj.StateProvinceID,
                        StateProvinceCode = stateObj.StateProvinceCode,
                        Name = stateObj.Name,
                        rowguid = stateObj.rowguid
                    }).ToList();

                    return stateProvinceList; 
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { hrmsentity.Dispose(); }
        }

        public List<LookUpDataEntity> GetLookUpData(int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstLookUpData = hrmsEntity.usp_UtilityTablesSelect(companyId).ToList();

                    return lstLookUpData.Select(lookUpDataObj => new LookUpDataEntity
                    {
                        CompanyId = lookUpDataObj.CompanyID,
                        Id = lookUpDataObj.ID,
                        Name = lookUpDataObj.Name,
                        Description = lookUpDataObj.Description,
                        Status = lookUpDataObj.Status,
                        TableName = lookUpDataObj.TableName
                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<AlertSendType> GetAlertSendType()
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstLookUpData = hrmsEntity.usp_AlertSendTypeSelect().ToList();
                    return lstLookUpData.Select(alertsendtype => new AlertSendType
                    {
                        AlertSendTypeId = alertsendtype.AlertSendTypeId,
                        AlertSendTypeName = alertsendtype.AlertSendTypeName
                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AlertSendCriteria> GetAlertSendCriteria()
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var lstLookUpData = hrmsEntity.usp_AlertSendCriteriaSelect().ToList();
                    
                    return lstLookUpData.Select(alertsendcriteria => new AlertSendCriteria
                    {
                        AlertSendCriteriaId = alertsendcriteria.AlertSendCriteriaId,
                        AlertSendCriteriaName = alertsendcriteria.AlertSendCriteriaName
                    }).ToList();
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ManageSecurityCriteria> GetManageSecurityCriteria()
        {
            try
            {
                
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstLookUpData = hrmsEntity.usp_ManageSecurityCriteriaSelect().ToList();
                    
                    return lstLookUpData.Select(managesecuritycriteria => new ManageSecurityCriteria
                    {
                        ManageSecurityCriteriaId = managesecuritycriteria.ManageSecurityCriteriaId,
                        ManageSecurityCriteriaName = managesecuritycriteria.ManageSecurityCriteriaName
                    }).ToList(); 
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        //Company Document Send Type. Such as...AllEmployees, SelectManagers, AdvancedCriteria
        public List<DocumentSendType> GetDocumentSendType()
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstLookUpData = hrmsEntity.usp_DocumentSendTypeSelectAll().ToList();
                    return lstLookUpData.Select(documentsendtype => new DocumentSendType
                    {
                        DocumentSendTypeId = documentsendtype.DocumentSendTypeId,
                        DocumentSendTypeName = documentsendtype.DocumentSendTypeName
                    }).ToList(); 
                }
            }
            catch (Exception )
            {
                throw ;
            }
           
        }

        //Company Document Send Criteria. Such as Company, Department, Location etc...
        public List<DocumentSendCriteria> GetDocumentSendCriteria()
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstLookUpData = hrmsEntity.usp_DocumentSendCriteriaSelectAll().ToList();
                    return lstLookUpData.Select(documentsendcriteria => new DocumentSendCriteria
                    {
                        DocumentSendCriteriaId = documentsendcriteria.DocumentSendCriteriaId,
                        DocumentSendCriteriaName = documentsendcriteria.DocumentSendCriteriaName
                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw ;
            }
          
        }

        public List<StateProvince> GetState1()
        {
            return GetState(0);
        }

        public List<StateProvince> GetState(int countryRegionId)
        {
            try
            {
                
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstStateData = hrmsEntity.usp_StateProvinceSelectAll(countryRegionId).ToList();
                    
                    return lstStateData.Select(statedataobj => new StateProvince
                    {
                        StateProvinceID = statedataobj.StateProvinceID,
                        CountryRegionCode = statedataobj.CountryRegionCode,
                        StateProvinceCode = statedataobj.StateProvinceCode
                    }).ToList(); 
                }

            }
            catch (Exception )
            {
                throw ;
            }
        }

        public List<ExceptionLog> ListExceptions()
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    return hrmsEntity.ExceptionLog.ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
