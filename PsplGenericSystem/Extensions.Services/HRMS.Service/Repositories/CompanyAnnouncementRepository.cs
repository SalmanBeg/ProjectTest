using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class CompanyAnnouncementRepository : ICompanyAnnouncementRepository
    {
        /// <summary>
        /// Returns all Company Announcement by CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<CompanyAnnouncement> SelectAllCompanyAnnouncementByCompanyId(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_CompanyAnnouncementSelectAll_Result> lstCompanyAnnouncementResult = hrmsEntity.usp_CompanyAnnouncementSelectAll(companyId).ToList();
                    var companyAnnouncemetList = lstCompanyAnnouncementResult.Select(companyAnnouncementObj => new CompanyAnnouncement
                    {
                        CompanyAnnouncementId = companyAnnouncementObj.CompanyAnnouncementId,
                        CompanyId = companyAnnouncementObj.CompanyId,
                        Title = companyAnnouncementObj.Title,
                        Message = companyAnnouncementObj.Message,
                        PublishStartDate = companyAnnouncementObj.PublishStartDate,
                        PublishEndDate = companyAnnouncementObj.PublishEndDate,
                        AcknowledgementReq = companyAnnouncementObj.AcknowledgementReq,
                        AttachmentId = companyAnnouncementObj.AttachmentId,
                        IsDraft = companyAnnouncementObj.IsDraft,
                        CreatedBy = companyAnnouncementObj.CreatedBy,
                        CreatedDate = companyAnnouncementObj.CreatedDate,
                        ModifiedBy = companyAnnouncementObj.ModifiedBy,
                        ModifiedDate = companyAnnouncementObj.ModifiedDate,
                        Author = companyAnnouncementObj.Author
                    }).ToList();
                    return companyAnnouncemetList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retuns the selected Company Announcement by CompanyAnnouncementId.
        /// </summary>
        /// <param name="companyAnnouncementId"></param>
        /// <returns></returns>
        public List<CompanyAnnouncement> SelectCompanyAnnouncementById(int companyAnnouncementId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_CompanyAnnouncementSelect_Result> lstCompanyAnnouncementResult = hrmsEntity.usp_CompanyAnnouncementSelect(companyAnnouncementId).ToList();
                    var companyAnnouncemetList = lstCompanyAnnouncementResult.Select(companyAnnouncementObj => new CompanyAnnouncement
                    {
                        CompanyAnnouncementId = companyAnnouncementObj.CompanyAnnouncementId,
                        CompanyId = companyAnnouncementObj.CompanyId,
                        Title = companyAnnouncementObj.Title,
                        Message = companyAnnouncementObj.Message,
                        PublishStartDate = companyAnnouncementObj.PublishStartDate,
                        PublishEndDate = companyAnnouncementObj.PublishEndDate,
                        AcknowledgementReq = companyAnnouncementObj.AcknowledgementReq,
                        AttachmentId = companyAnnouncementObj.AttachmentId,
                        IsDraft = companyAnnouncementObj.IsDraft,
                        CreatedBy = companyAnnouncementObj.CreatedBy,
                        CreatedDate = companyAnnouncementObj.CreatedDate,
                        ModifiedBy = companyAnnouncementObj.ModifiedBy,
                        ModifiedDate = companyAnnouncementObj.ModifiedDate
                    }).ToList();
                    return companyAnnouncemetList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserts new Company Announcement.
        /// </summary>
        /// <param name="companyAnnouncementobj"></param>
        /// <returns></returns>
        public bool CreateCompanyAnnouncement(CompanyAnnouncement companyAnnouncementobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_CompanyAnnouncementInsert(
                        //companyAnnouncementobj.CompanyAnnouncementId,
                        companyAnnouncementobj.CompanyId,
                        companyAnnouncementobj.Title,
                        companyAnnouncementobj.Message,
                        companyAnnouncementobj.PublishStartDate,
                        companyAnnouncementobj.PublishEndDate,
                        companyAnnouncementobj.AcknowledgementReq,
                        companyAnnouncementobj.AttachmentId,
                        companyAnnouncementobj.IsDraft,
                        companyAnnouncementobj.CreatedBy,
                        companyAnnouncementobj.CreatedDate
                        //companyAnnouncementobj.ModifiedBy,
                        //companyAnnouncementobj.ModifiedDate,
                        //outputParam
                        );
                    hrmsEntity.Dispose();
                    //return Convert.ToInt32(outputParam.Value);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the selected company document.
        /// </summary>
        /// <param name="companyAnnouncementobj"></param>
        /// <returns></returns>
        public bool UpdateCompanyAnnouncement(CompanyAnnouncement companyAnnouncementobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_CompanyAnnouncementUpdate(
                        companyAnnouncementobj.CompanyAnnouncementId,
                        companyAnnouncementobj.CompanyId,
                        companyAnnouncementobj.Title,
                        companyAnnouncementobj.Message,
                        companyAnnouncementobj.PublishStartDate,
                        companyAnnouncementobj.PublishEndDate,
                        companyAnnouncementobj.AcknowledgementReq,
                        companyAnnouncementobj.AttachmentId,
                        companyAnnouncementobj.IsDraft,
                        //companyAnnouncementobj.CreatedBy,
                        //companyAnnouncementobj.CreatedDate,
                        companyAnnouncementobj.ModifiedBy,
                        companyAnnouncementobj.ModifiedDate
                        //outputParam
                        );
                    hrmsEntity.Dispose();
                    //return Convert.ToInt32(outputParam.Value);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the Company Announcement by CompanyAnnouncementId.
        /// </summary>
        /// <param name="companyAnnouncementId"></param>
        /// <returns></returns>
        public bool DeleteCompanyAnnouncement(int companyAnnouncementId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var result = hrmsEntity.usp_CompanyAnnouncementDelete(companyAnnouncementId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsTitleExists(CompanyAnnouncement companyAnnouncementObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var companyAnnouncementObjList = hrmsEntity.CompanyAnnouncements.ToList();
                    CompanyAnnouncement companyAnnouncementObj1 = companyAnnouncementObjList.Where(m => m.CompanyId == companyAnnouncementObj.CompanyId && m.Title.ToLower() == companyAnnouncementObj.Title.ToLower() && m.CompanyAnnouncementId != companyAnnouncementObj.CompanyAnnouncementId).FirstOrDefault();
                    if (companyAnnouncementObj1 != null)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
