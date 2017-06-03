using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Common.Enums
{
    public class GeneralEnum
    {
        public enum Status
        {
            Active = 1,
            Inactive = 0
        }

        public enum Gender
        {
            Female = 1,
            Male = 2
        }

        public enum FileType
        {
            consentdocuments = 1,
            userimage = 2,
            companydocuments = 3,
            ConSentFormSign = 4,
            EmployeeSign = 5,
            AlertAttachment = 6,
            Document = 7,
            NotesAttachment = 8,
            CompanyDocument = 9,
            ResumeAttachment = 10,
            CertificationAttachment = 11,
            SignedConsentDocument = 12,
            TrainingClassImage = 13
        }

        public enum HireWizardSteps
        {
            SendOfferLetter,
            SendAgreements,
            CollectForPayRoll,
            Tax_W4,
            Eligibility_I9,
            EligibilityDocument,
            EnrollBenefits,
            Personal,
            ConsentForms,
            DirectDeposit,
            Employment
        }

        public enum HireType
        {
            SelfHire,
            AddNewHire,
            Recruiting
        }

        public enum SendTo
        {
            AllEmployees = 0,
            AllManagers = 1,
            SelectIndividuals = 2,
            ExternalRecipients = 3

        }

        public enum RoleName
        {
            Superadministrator,
            Administrator,
            Manager,
            Employee
        }

        public enum JobProperties
        {
            JobDuty,
            JobQualification,
            JobPME
        }

        public enum JobApplicationStatus
        {
            IsApplied = 1,
            Rejected = 2,
            Withdrawn = 3,
            IsSubmitted = 4
        }

        public enum EmployeeSendCriteriaId
        {
            Positions = 1,
            Divisions = 2,
            Locations = 3,
            Departments = 4,
            EmploymentStatus = 5,
        }
    }
}
