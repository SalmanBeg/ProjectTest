using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class EmployeeAssetRepository : IEmployeeAssetRepository
    {
        public bool CreateEmployeeAsset(EmployeeAsset employeeAssetobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeAssetInsert(employeeAssetobj.Asset, employeeAssetobj.Description, employeeAssetobj.Manufacturer, employeeAssetobj.Model,
                                                                          employeeAssetobj.SerialNumber, employeeAssetobj.AssetCost, employeeAssetobj.PurchasedDate,
                                                                          employeeAssetobj.AccountNumber, employeeAssetobj.OutOn, employeeAssetobj.DueBack, employeeAssetobj.Returned,
                                                                          employeeAssetobj.Comment, employeeAssetobj.UserId, employeeAssetobj.CompanyId, employeeAssetobj.CreatedBy,
                                                                          employeeAssetobj.CreatedOn);
                    hrmsEntity.Dispose();
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateEmployeeAssetById(EmployeeAsset employeeAssetobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeAssetUpdate(employeeAssetobj.EmployeeAssetId, employeeAssetobj.Asset, employeeAssetobj.Description, employeeAssetobj.Manufacturer,
                                                                           employeeAssetobj.Model, employeeAssetobj.SerialNumber, employeeAssetobj.AssetCost, employeeAssetobj.PurchasedDate,
                                                                           employeeAssetobj.AccountNumber, employeeAssetobj.OutOn, employeeAssetobj.DueBack, employeeAssetobj.Returned,
                                                                           employeeAssetobj.Comment, employeeAssetobj.UserId, employeeAssetobj.ModifiedBy, employeeAssetobj.ModifiedOn
                                                                           );
                    hrmsEntity.Dispose();
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public EmployeeAsset GetEmployeeAssetByAssetId(int employeeAssetId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeAsetResult = hrmsEntity.usp_EmployeeAssetSelectById(employeeAssetId).ToList();
                    return lstEmployeeAsetResult.Select(employeeasset => new EmployeeAsset
                    {
                        EmployeeAssetId = employeeasset.EmployeeAssetId,
                        EmployeeAssetCode = employeeasset.EmployeeAssetCode,
                        CompanyId = employeeasset.CompanyId,
                        Asset = employeeasset.Asset,
                        UserId = employeeasset.UserId,
                        Description = employeeasset.Description,
                        Manufacturer = employeeasset.Manufacturer,
                        Model = employeeasset.Model,
                        SerialNumber = employeeasset.SerialNumber,
                        AssetCost = employeeasset.AssetCost,
                        PurchasedDate = employeeasset.PurchasedDate,
                        AccountNumber = employeeasset.AccountNumber,
                        OutOn = employeeasset.OutOn,
                        DueBack = employeeasset.DueBack,
                        Returned = employeeasset.Returned,
                        Comment = employeeasset.Comment,
                        CreatedBy = employeeasset.CreatedBy,
                        CreatedOn = employeeasset.CreatedOn,
                        ModifiedBy = employeeasset.ModifiedBy,
                        ModifiedOn = employeeasset.Modifiedon
                    }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<EmployeeAsset> GetAllEmployeeAssetByUserId(int userId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeAsetResult = hrmsEntity.usp_EmployeeAssetSelectAll(userId).ToList();
                    return lstEmployeeAsetResult.Select(employeeasset => new EmployeeAsset
                    {
                        EmployeeAssetId = employeeasset.EmployeeAssetId,
                        EmployeeAssetCode = employeeasset.EmployeeAssetCode,
                        CompanyId = employeeasset.CompanyId,
                        Asset = employeeasset.Asset,
                        UserId = employeeasset.UserId,
                        Description = employeeasset.Description,
                        Manufacturer = employeeasset.Manufacturer,
                        Model = employeeasset.Model,
                        SerialNumber = employeeasset.SerialNumber,
                        AssetCost = employeeasset.AssetCost,
                        PurchasedDate = employeeasset.PurchasedDate,
                        AccountNumber = employeeasset.AccountNumber,
                        OutOn = employeeasset.OutOn,
                        DueBack = employeeasset.DueBack,
                        Returned = employeeasset.Returned,
                        Comment = employeeasset.Comment,
                        CreatedBy = employeeasset.CreatedBy,
                        CreatedOn = employeeasset.CreatedOn,
                        ModifiedBy = employeeasset.ModifiedBy,
                        ModifiedOn = employeeasset.Modifiedon
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteEmployeeAssetById(int employeeAssetId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeAssetDelete(employeeAssetId);
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
