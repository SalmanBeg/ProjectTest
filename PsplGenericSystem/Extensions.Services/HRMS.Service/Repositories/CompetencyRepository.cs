using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using System.Data.Entity.Core.Objects;
using System.Data;
using System.Data.SqlClient;

namespace HRMS.Service.Repositories
{
    public class CompetencyRepository : ICompetencyRepository
    {
        public int AddCompetency(Competency competencyobj)
        {
            int rtnID = -1;
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    ObjectParameter output = new ObjectParameter("ReturnID", typeof(int));
                 
                    var result = hrmsEntity.usp_CompetencyInsert(competencyobj.CompanyId, competencyobj.CompetencySetName, competencyobj.Category
                        , competencyobj.Points, competencyobj.CreatedBy, competencyobj.CreatedOn, output);
                    if (output.Value != null)
                    {
                        if (output.Value.ToString() != "-1")
                        {
                            rtnID = Convert.ToInt32(output.Value);
                        }
                    }
                    else
                    {
                        rtnID = -1;
                    }
                    return rtnID;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateCompetency(Competency competencyobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_CompetencyUpdate(competencyobj.CompanyId, competencyobj.CompetencyId, competencyobj.CompetencySetName
                                , competencyobj.Category, competencyobj.Points, competencyobj.ModifiedBy);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool InsertCompetencyContentBulk(DataTable dtCompetencyContent)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var parameter = new SqlParameter("@tblCompetency", SqlDbType.Structured);
                    parameter.Value = dtCompetencyContent;
                    parameter.TypeName = "HumanResources.Competency";
                    using (HRMSEntities1 db = new HRMSEntities1())
                    {
                        int i = db.Database.ExecuteSqlCommand("exec HumanResources.usp_InsertCompetencyContentBulk  @tblCompetency", parameter);
                        return Convert.ToBoolean(i);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCompetency(int competencyId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_CompetencyDelete(competencyId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Competency SelectCompetencyById(int companyId, int competencyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetCompetencyById_Result> lstCompetencyResult = hrmsEntity.usp_GetCompetencyById(companyId, competencyId).ToList();
                    return lstCompetencyResult.Select(competencyObj => new Competency
                    {
                        CompanyId = competencyObj.CompanyId,
                        CompetencySetName = competencyObj.CompetencySetName,
                        CompetencyId = competencyObj.CompetencyId,
                        Category = competencyObj.Category,
                        Points = competencyObj.Points,
                        CreatedBy = competencyObj.CreatedBy,
                        CreatedOn = competencyObj.CreatedOn
                    }).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateCompetencyContentBulk(DataTable dtCompetency)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var parameter = new SqlParameter("@tblCompetency", SqlDbType.Structured);
                    parameter.Value = dtCompetency;
                    parameter.TypeName = "HumanResources.Competency";
                    using (HRMSEntities1 db = new HRMSEntities1())
                    {
                        db.Database.ExecuteSqlCommand("exec HumanResources.usp_UpdateCompetencyContentBulk @tblCompetency", parameter);
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Competency> SelectAllCompetency(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_CompetencySelectAll_Result> lstCompetencyResult = hrmsEntity.usp_CompetencySelectAll(companyId).ToList();
                    return lstCompetencyResult.Select(competencyObj => new Competency
                    {
                        CompanyId = competencyObj.CompanyId,
                        CompetencyId = competencyObj.CompetencyId,
                        CompetencySetName = competencyObj.CompetencySetName,
                        Category = competencyObj.Category,
                        Points = competencyObj.Points,
                        CreatedOn = competencyObj.CreatedOn,
                        ModifiedOn = competencyObj.ModifiedOn
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
