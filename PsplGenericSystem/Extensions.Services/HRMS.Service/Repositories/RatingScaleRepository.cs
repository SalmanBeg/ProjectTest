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
    public class RatingScaleRepository : IRatingScaleRepository
    {
        public int AddReviewScore(ReviewScoreDescription reviewScoreobj)
        {
            int rtnID = -1;
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new ObjectParameter("ReturnID", typeof(int));
                    var result = hrmsEntity.usp_InsertReviewScore(reviewScoreobj.CompanyId, reviewScoreobj.Description, reviewScoreobj.IsChildCompany
                                                                 , reviewScoreobj.CreatedBy, reviewScoreobj.CreatedOn, output);
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

        public bool UpdateReviewScore(ReviewScoreDescription reviewScoreobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_UpdateReviewScore(reviewScoreobj.Description, reviewScoreobj.IsChildCompany, reviewScoreobj.CompanyId, reviewScoreobj.ReviewScoreDescriptionId, reviewScoreobj.ModifiedBy,
                                                                          reviewScoreobj.ModifiedOn);
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ReviewScore> SelectAllReviewScore(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetReviewScore_Result> lstReviewScoretResult = hrmsEntity.usp_GetReviewScore(companyId).ToList();
                    return lstReviewScoretResult.Select(reviewScoreContentObj => new ReviewScore
                    {
                        ReviewScoreId = reviewScoreContentObj.ReviewScoreDescriptionId,
                        Description = reviewScoreContentObj.Description,
                        IsChildCompany = Convert.ToBoolean(reviewScoreContentObj.IsChildCompany),
                        Item = reviewScoreContentObj.Item
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //
        public ReviewScoreDescription SelectReviewScoreById(int reviewScoreId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetReviewScoreById_Result> lstReviewScorDescResult = hrmsEntity.usp_GetReviewScoreById(reviewScoreId).ToList();
                    return lstReviewScorDescResult.Select(reviewDescContentObj => new ReviewScoreDescription
                    {
                        ReviewScoreDescriptionId = reviewDescContentObj.ReviewScoreDescriptionId,
                        Description = reviewDescContentObj.Description,
                        IsChildCompany = reviewDescContentObj.IsChildCompany

                    }).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //
        public List<ReviewScoreContent> SelectReviewScoreContentByID(int reviewScoreId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetReviewScoreContent_Result> lstReviewScoreContentResult = hrmsEntity.usp_GetReviewScoreContent(reviewScoreId).ToList();
                    return lstReviewScoreContentResult.Select(reviewContentObj => new ReviewScoreContent
                    {
                        ReviewScoreContentId = reviewContentObj.ReviewScoreContentId,
                        ItemName = reviewContentObj.ItemName,
                        ItemValue = reviewContentObj.ItemValue

                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertReviewScoreContentBulk(DataTable dtReviewScoreContent)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var parameter = new SqlParameter("@tblReviewScoreContentType", SqlDbType.Structured);
                    parameter.Value = dtReviewScoreContent;
                    parameter.TypeName = "HumanResources.ReviewScoreContent";

                    int i = hrmsEntity.Database.ExecuteSqlCommand("exec HumanResources.usp_InsertReviewScoreContentBulk @tblReviewScoreContentType", parameter);
                    return Convert.ToBoolean(i);


                    // return true; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool UpdateReviewScoreContentBulk(DataTable dtReviewScoreContent)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var parameter = new SqlParameter("@tblReviewScoreContentType", SqlDbType.Structured);
                    parameter.Value = dtReviewScoreContent;
                    parameter.TypeName = "HumanResources.ReviewScoreContent";
                    using (HRMSEntities1 db = new HRMSEntities1())
                    {
                        int i = db.Database.ExecuteSqlCommand("exec HumanResources.usp_UpdateReviewScoreContentBulk @tblReviewScoreContentType", parameter);
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteReviewScoreContent(int reviewScoreId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_DeleteReviewScoreBulk(companyId, reviewScoreId);
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
