using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Interfaces
{
    public interface IOfferLetterRepository
    {
        /// <summary>
        /// To create a new offer letter record for a candidate
        /// </summary>
        /// <param name="candidateOfferLetterObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int CreateOfferLetter(CandidateOfferLetter candidateOfferLetterObj);
        /// <summary>
        /// To update an existing offer letter record for a candidate
        /// </summary>
        /// <param name="candidateOfferLetterObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int UpdateOfferLetter(CandidateOfferLetter candidateOfferLetterObj);
        /// <summary>
        /// To retrieve a offer letter record for a candidate
        /// </summary>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        CandidateOfferLetter GetCandidateOfferLetter(int candidateId);
        /// <summary>
        /// To retrieve a particular offer letter record using candidateofferletterid
        /// </summary>
        /// <param name="candidateofferLetterId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        CandidateOfferLetter GetOfferLetterContent(int candidateOfferLetterId);
        /// <summary>
        /// To Update the Offer Letter Content for Approval/Rejection by Hiring Manager
        /// </summary>
        /// <param name="candidateOfferLetterObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int UpdateOfferLetterforApproval(CandidateOfferLetter candidateOfferLetterObj);
        /// <summary>
        /// Preview of CandiateOfferLetter
        /// </summary>
        /// <param name="jobProfileId"></param>
        /// <param name="candidateId"></param>
        /// <param name="candidateOfferLetterId"></param>
        /// <returns></returns>
        //[Logger]
        //[ExceptionLogger]
        //CandidateOfferLetter GetOfferLetterPreview(int jobProfileId, int candidateId, int candidateOfferLetterId);
    }
}
