using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;


namespace HRMS.Service.Repositories
{
    public class OfferLetterRepository : IOfferLetterRepository
    {
        public int CreateOfferLetter(CandidateOfferLetter candidateOfferLetterObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.CandidateOfferLetter.Add(candidateOfferLetterObj);
                    hrmsEntity.SaveChanges();
                    return result.CandidateOfferLetterId;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int UpdateOfferLetter(CandidateOfferLetter candidateOfferLetterObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result =
                        hrmsEntity.CandidateOfferLetter.Where(j => j.CandidateId == candidateOfferLetterObj.CandidateId);

                    foreach (var resultObj in result)
                    {
                        resultObj.CandidateOfferLetterContent = candidateOfferLetterObj.CandidateOfferLetterContent;
                        //resultObj.Comments = candidateOfferLetterObj.Comments;
                        //resultObj.Status = candidateOfferLetterObj.Status;
                        
                    }
                    return hrmsEntity.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CandidateOfferLetter GetCandidateOfferLetter(int candidateId)
        {
            try
            {
                using (var hrmsentity = new HRMSEntities1())
                {
                    var result =
                        hrmsentity.CandidateOfferLetter.Where(j => j.CandidateId == candidateId).ToList();
                    return result.FirstOrDefault();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //public List<CandidateOfferLetter> GetAllCandidatesOfferLetter(int companyId)
        //{
        //    try
        //    {
        //        using ( var hrmsentity = new HRMSEntities1())
        //        {
        //            var result = hrmsentity.CandidateOfferLetter.Where(j => j.CompanyId == companyId).ToList();
        //            return result;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
        public CandidateOfferLetter GetOfferLetterContent(int candidateOfferLetterId)
        {
            try
            {
                using (var hrmsentity = new HRMSEntities1())
                {
                    var candidateOfferLetterObj = new CandidateOfferLetter();
                    var result =hrmsentity.CandidateOfferLetter.Where(j => j.CandidateOfferLetterId == candidateOfferLetterId).ToList();
                    return result.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int DeleteOfferLetter(int candidateofferLetterId)
        {
            try
            {
                using (var hrmsentity = new HRMSEntities1())
                {
                    var result = hrmsentity.CandidateOfferLetter.Where(j => j.CandidateOfferLetterId == candidateofferLetterId).ToList();
                    hrmsentity.CandidateOfferLetter.Remove(result.FirstOrDefault());
                    return hrmsentity.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateOfferLetterforApproval(CandidateOfferLetter candidateOfferLetterObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result =
                        hrmsEntity.CandidateOfferLetter.Where(j => j.CandidateId == candidateOfferLetterObj.CandidateId);

                    foreach (var resultObj in result)
                    {
                        resultObj.CandidateOfferLetterContent = candidateOfferLetterObj.CandidateOfferLetterContent;
                        resultObj.Comments = candidateOfferLetterObj.Comments;
                        resultObj.Status = candidateOfferLetterObj.Status;

                    }
                    return hrmsEntity.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public CandidateOfferLetter GetOfferLetterPreview(int jobProfileId, int candidateId, int candidateOfferLetterId)
        //{
        //    try
        //    {
        //        using (var hrmsEntity = new HRMSEntities1())
        //        {
        //            var candidateOfferLetterObj = new CandidateOfferLetter();
        //            var result = hrmsEntity.CandidateOfferLetter.Where(j => j.CandidateId == candidateId && j.JobProfileId == jobProfileId && j.CandidateOfferLetterId == candidateOfferLetterId);
        //            return result.FirstOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}
    }
}
