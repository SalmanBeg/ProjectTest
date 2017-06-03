using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkExtras.EF6;

namespace HRMS.Service.Models.ExtensionProc
{
    public class ExtendedStoredProcedures
    {
        [StoredProcedure("Security.usp_CreateEmployeeConfigurationSetup")]
        public class UspCreateEmployeeConfigurationSetup
        {
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "companyId")]
            public Nullable<int> companyId { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "firstName")]
            public string firstName { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "lastName")]
            public string lastName { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "email")]
            public string email { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "password")]
            public string password { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "userName")]
            public string userName { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "isApproved")]
            public Nullable<bool> isApproved { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "isLockedOut")]
            public Nullable<bool> isLockedOut { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "passwordQuestion")]
            public string passwordQuestion { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "passwordAnswer")]
            public string passwordAnswer { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "jobProfileId")]
            public Nullable<int> jobProfileId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "createdBy")]
            public Nullable<int> createdBy { get; set; }
            [StoredProcedureParameter(SqlDbType.DateTime, ParameterName = "hireDate")]
            public Nullable<System.DateTime> hireDate { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "onBoardingId")]
            public Nullable<int> onBoardingId { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "RoleName")]
            public string RoleName { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "EmploymentStatusId")]
            public int EmploymentStatusId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "ManagerId")]
            public int ManagerId { get; set; }
            [StoredProcedureParameter(SqlDbType.Money, ParameterName = "Compensation")]
            public double Compensation { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CompensationFrequency")]
            public int CompensationFrequency { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "EmployeeNo")]
            public string EmployeeNo { get; set; }

            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "errorCode")]
            public ObjectParameter errorCode { get; set; }

            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "ust_StepName")]
            public List<UdtStepName> UdtStepName { get; set; }
        }
        [UserDefinedTableType("ust_StepName")]
        public class UdtStepName
        {
            [UserDefinedTableTypeColumn(1)]
            public int StepId { get; set; }
            [UserDefinedTableTypeColumn(2)]
            public string StepName { get; set; }
            [UserDefinedTableTypeColumn(3)]
            public bool Active { get; set; }
        }
        //
        [StoredProcedure("HumanResources.usp_InserAndUpdateTrainingClassResource")]
        public class UspTrainingClassResourceInsert
        {
            //[StoredProcedureParameter(SqlDbType.Int, ParameterName = "TrainingClassId")]
            //public int TrainingClassId { get; set; }
            //[StoredProcedureParameter(SqlDbType.Int, ParameterName = "Attachment")]
            //public int? Attachment { get; set; }
            //[StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "FileName")]
            //public string FileName { get; set; }
            //[StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "ContentType")]
            //public string ContentType { get; set; }
            //[StoredProcedureParameter(SqlDbType.Int, ParameterName = "CompanyId")]
            //public Nullable<int> CompanyId { get; set; }
            //[StoredProcedureParameter(SqlDbType.Int, ParameterName = "CreatedBy")]
            //public Nullable<int> CreatedBy { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CreateOrModifyUserId")]
            public Nullable<int> CreateOrModifyUserId { get; set; }


            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "udt_TrainingClassResources")]
            public List<UdtResourceIdTable> ResourceIdTable { get; set; }
        }
        [UserDefinedTableType("HumanResources.udt_TrainingClassResources")]
        public class UdtResourceIdTable
        {
            [UserDefinedTableTypeColumn(1)]
            public int TrainingClassResourceId { get; set; }
            [UserDefinedTableTypeColumn(2)]
            public int TrainingClassId { get; set; }
            [UserDefinedTableTypeColumn(5)]
            public string ContentType { get; set; }
            [UserDefinedTableTypeColumn(3)]
            public string Filename { get; set; }
            [UserDefinedTableTypeColumn(4)]
            public int Attachment { get; set; }



        }
        //

        [StoredProcedure("HumanResources.usp_TrainingTrackInsert")]
        public class UspTrainingTrackInsert
        {
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "TrainingTrackName")]
            public string TrainingTrackName { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "TrainingTrackDescription")]
            public string TrainingTrackDescription { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CompanyId")]
            public Nullable<int> CompanyId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CreatedBy")]
            public Nullable<int> CreatedBy { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "TrainingTrackId")]
            public Nullable<int> TrainingTrackId { get; set; }

            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "ClassIdTable")]
            public List<UdtTrainingClassIds> ClassIdTable { get; set; }
        }


        [StoredProcedure("HumanResources.usp_TrainingTrackUpdate")]
        public class UspTrainingTrackUpdate
        {
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "TrainingTrackName")]
            public string TrainingTrackName { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "TrainingTrackDescription")]
            public string TrainingTrackDescription { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CompanyId")]
            public Nullable<int> CompanyId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "ModifiedBy")]
            public Nullable<int> ModifiedBy { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "TrainingTrackId")]
            public Nullable<int> TrainingTrackId { get; set; }

            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "ClassIdTable")]
            public List<UdtTrainingClassIds> ClassIdTable { get; set; }
        }


        [UserDefinedTableType("HumanResources.udt_TrainingClassId")]
        public class UdtTrainingClassIds
        {
            [UserDefinedTableTypeColumn(1)]
            public int TrainingClassId { get; set; }
            [UserDefinedTableTypeColumn(2)]
            public int TrainingTrackId { get; set; }
            [UserDefinedTableTypeColumn(3)]
            public int TrainingTrackClassId { get; set; }
        }




        [StoredProcedure("HumanResources.usp_OnBoardingInsert")]
        public class UspInsertOnBoardingConsentDocument
        {
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "companyId")]
            public Nullable<int> companyId { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "OnBoardingName")]
            public string OnBoardingName { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "errorCode")]
            public ObjectParameter errorCode { get; set; }

            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "ust_ConsentdocId")]
            public List<UdtConsentDoc> UdtConsentDoc { get; set; }
        }
        [UserDefinedTableType("ust_ConsentdocId")]
        public class UdtConsentDoc
        {
            [UserDefinedTableTypeColumn(1)]
            public int ConsentdocId { get; set; }
        }

        [StoredProcedure("HumanResources.usp_ImportBulkEmployee")]
        public class UspImportEmployee
        {
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "ErrorCode")]
            public ObjectParameter ErrorCode { get; set; }

            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "tblImportEmployeedata")]
            public List<UdtImport> UdtImport { get; set; }
        }
        [UserDefinedTableType("tblImportEmployeedata")]
        public class UdtImport
        {
            [UserDefinedTableTypeColumn(1)]
            public int RowID { get; set; }
            [UserDefinedTableTypeColumn(2)]
            public string UserName { get; set; }
            [UserDefinedTableTypeColumn(3)]
            public int UserID { get; set; }
            [UserDefinedTableTypeColumn(4)]
            public int CompanyID { get; set; }
            [UserDefinedTableTypeColumn(5)]
            public string EmployeeNo { get; set; }
            [UserDefinedTableTypeColumn(6)]
            public string Salutation { get; set; }
            [UserDefinedTableTypeColumn(7)]
            public string FirstName { get; set; }
            [UserDefinedTableTypeColumn(8)]
            public string MiddleName { get; set; }
            [UserDefinedTableTypeColumn(9)]
            public string LastName { get; set; }
            [UserDefinedTableTypeColumn(10)]
            public string Suffix { get; set; }
            [UserDefinedTableTypeColumn(11)]
            public string HomeEmail { get; set; }
            [UserDefinedTableTypeColumn(12)]
            public string Address1 { get; set; }
            [UserDefinedTableTypeColumn(13)]
            public string Address2 { get; set; }
            [UserDefinedTableTypeColumn(14)]
            public string City { get; set; }
            [UserDefinedTableTypeColumn(15)]
            public string ZIP { get; set; }
            [UserDefinedTableTypeColumn(16)]
            public int CountryID { get; set; }
            [UserDefinedTableTypeColumn(17)]
            public int State { get; set; }
            [UserDefinedTableTypeColumn(18)]
            public string SSN { get; set; }
            [UserDefinedTableTypeColumn(19)]
            public string WorkPhone1 { get; set; }
            [UserDefinedTableTypeColumn(20)]
            public string HomePhone { get; set; }
            [UserDefinedTableTypeColumn(21)]
            public DateTime BirthDate { get; set; }
            [UserDefinedTableTypeColumn(22)]
            public int Gender { get; set; }
            [UserDefinedTableTypeColumn(23)]
            public int MaritalStatus { get; set; }
            [UserDefinedTableTypeColumn(24)]
            public int ChangeReason { get; set; }
            [UserDefinedTableTypeColumn(25)]
            public DateTime HireDate { get; set; }
            [UserDefinedTableTypeColumn(26)]
            public DateTime OriginalHireDate { get; set; }
            [UserDefinedTableTypeColumn(27)]
            public DateTime TerminationDate { get; set; }
            [UserDefinedTableTypeColumn(28)]
            public int TerminationReason { get; set; }
            [UserDefinedTableTypeColumn(29)]
            public string WorkPhone { get; set; }
            [UserDefinedTableTypeColumn(30)]
            public string WorkEmail { get; set; }
            [UserDefinedTableTypeColumn(31)]
            public DateTime StartDate { get; set; }
            [UserDefinedTableTypeColumn(32)]
            public DateTime SeniorityDate { get; set; }
            [UserDefinedTableTypeColumn(33)]
            public DateTime LastPaidDate { get; set; }
            [UserDefinedTableTypeColumn(34)]
            public DateTime LastPayRise { get; set; }
            [UserDefinedTableTypeColumn(35)]
            public DateTime LastPromotionDate { get; set; }
            [UserDefinedTableTypeColumn(36)]
            public DateTime LastReviewDate { get; set; }
            [UserDefinedTableTypeColumn(37)]
            public DateTime NextReviewDate { get; set; }
            [UserDefinedTableTypeColumn(38)]
            public DateTime NewHireReportDate { get; set; }
            [UserDefinedTableTypeColumn(39)]
            public int EmploymentStatus { get; set; }
            [UserDefinedTableTypeColumn(40)]
            public int JobProfileid { get; set; }
            [UserDefinedTableTypeColumn(41)]
            public int Positionid { get; set; }
            [UserDefinedTableTypeColumn(42)]
            public int PayGroup { get; set; }
            [UserDefinedTableTypeColumn(43)]
            public int Locationid { get; set; }
            [UserDefinedTableTypeColumn(44)]
            public int Divisionid { get; set; }
            [UserDefinedTableTypeColumn(45)]
            public int Departmentid { get; set; }
            [UserDefinedTableTypeColumn(46)]
            public int Managerid { get; set; }
            [UserDefinedTableTypeColumn(47)]
            public int EmploymentType { get; set; }
            [UserDefinedTableTypeColumn(48)]
            public int ComplianceCode { get; set; }
            [UserDefinedTableTypeColumn(49)]
            public int BenefitClass { get; set; }
            [UserDefinedTableTypeColumn(50)]
            public int FLSAStatus { get; set; }
            [UserDefinedTableTypeColumn(51)]
            public int Union { get; set; }
            [UserDefinedTableTypeColumn(52)]
            public string DistrictCode { get; set; }
            [UserDefinedTableTypeColumn(53)]
            public string CheckDistribution { get; set; }
            [UserDefinedTableTypeColumn(54)]
            public bool DirectDepositEmail { get; set; }
            [UserDefinedTableTypeColumn(54)]
            public bool OkToRehire { get; set; }
            [UserDefinedTableTypeColumn(56)]
            public int WCJobClassCode { get; set; }
            [UserDefinedTableTypeColumn(57)]
            public int WCStatus { get; set; }
            [UserDefinedTableTypeColumn(58)]
            public int WCType { get; set; }
            [UserDefinedTableTypeColumn(59)]
            public string ImportTag { get; set; }
            [UserDefinedTableTypeColumn(60)]
            public string Password { get; set; }
            [UserDefinedTableTypeColumn(61)]
            public string Batchkey { get; set; }

        }

        [StoredProcedure("HumanResources.usp_FormI9ComplianceDetails")]
        public class InsertUpdateFormI9ComplianceDetails
        {
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "WorkAuthorizationId")]
            public int WorkAuthorizationId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CompanyId")]
            public Nullable<int> CompanyId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "UserId")]
            public int UserId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CitizenOfUS")]
            public Nullable<int> CitizenOfUS { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "AlienNumber")]
            public string AlienNumber { get; set; }
            [StoredProcedureParameter(SqlDbType.DateTime, ParameterName = "PermanentResidentExpire")]
            public Nullable<DateTime> PermanentResidentExpire { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "AlienCitizenof")]
            public Nullable<int> AlienCitizenof { get; set; }
            [StoredProcedureParameter(SqlDbType.DateTime, ParameterName = "AlienAuthorisedDate")]
            public Nullable<DateTime> AlienAuthorisedDate { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "AlienAutharisedCitizenof")]
            public Nullable<int> AlienAutharisedCitizenof { get; set; }
            [StoredProcedureParameter(SqlDbType.DateTime, ParameterName = "CertificationDate")]
            public Nullable<DateTime> CertificationDate { get; set; }
            [StoredProcedureParameter(SqlDbType.Binary, ParameterName = "Attachment")]
            public byte[] Attachment { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "AttachmentName")]
            public string AttachmentName { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "AttachmentType")]
            public string AttachmentType { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "AlienRegistrationNumber")]
            public string AlienRegistrationNumber { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "AdmissionNumber")]
            public string AdmissionNumber { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "PassportNumber")]
            public string PassportNumber { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "Countryof")]
            public Nullable<int> Countryof { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "ModifiedBy")]
            public Nullable<int> ModifiedBy { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "FederalLaw")]
            public Nullable<bool> FederalLaw { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "IsSSN")]
            public Nullable<bool> IsSSN { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "EmployeeSignId")]
            public Nullable<int> EmployeeSignId { get; set; }
            [StoredProcedureParameter(SqlDbType.DateTime, ParameterName = "EmployeeSignDate")]
            public Nullable<DateTime> EmployeeSignDate { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "EmployerSignId")]
            public Nullable<int> EmployerSignId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output, ParameterName = "WorkauthId")]
            public int WorkauthId { get; set; }
            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "WorkAuthorizationDocumentation")]
            public List<UdtWorkAuthorizationDocumentation> UdtWorkAuthorizationDocumentation { get; set; }


        }
        [UserDefinedTableType("WorkAuthorizationDocumentation")]
        public class UdtWorkAuthorizationDocumentation
        {
            [UserDefinedTableTypeColumn(1)]
            public Nullable<int> WorkAuthorizationId { get; set; }
            [UserDefinedTableTypeColumn(2)]
            public int WorkAuthorizationDocumentationTypeId { get; set; }
            [UserDefinedTableTypeColumn(3)]
            public Nullable<int> DocumentTitle { get; set; }
            [UserDefinedTableTypeColumn(4)]
            public string DocumentIssuingAuthority { get; set; }
            [UserDefinedTableTypeColumn(5)]
            public string DocumentNumber { get; set; }
            [UserDefinedTableTypeColumn(6)]
            public Nullable<DateTime> ExpirationDate { get; set; }
            // [UserDefinedTableTypeColumn(7)]
            //public Nullable<int> UpdateBy { get; set; }

        }
        #region Manage securty mena to supply parametera with user defined table types to the procedure for managing security at form and module level
        [StoredProcedure("Security.usp_ManageFormAuthorizationByRole")]
        public class UspManageFormAuthorizationByRole
        {

            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "companyId")]
            public Nullable<int> companyId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "RoleId")]
            public Nullable<int> RoleId { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "CanHire")]
            public Nullable<bool> CanHire { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "CanViewHires")]
            public Nullable<bool> CanViewHires { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "CanAccessDashBoard")]
            public Nullable<bool> CanAccessDashBoard { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "EmployeeFilterCriteriaId")]
            public Nullable<int> EmployeeFilterCriteriaId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "ModifiedBy")]
            public Nullable<int> ModifiedBy { get; set; }
            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "udt_FormLevelSecurity")]
            public List<UdtFormLevelSecurity> UdtFormLevelSecurity { get; set; }
            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "udt_ModuleLevelSecurity")]
            public List<UdtModuleLevelSecurity> UdtModuleLevelSecurity { get; set; }

        }

        [UserDefinedTableType("udt_FormLevelSecurity")]
        public class UdtFormLevelSecurity
        {
            [UserDefinedTableTypeColumn(1)]
            public int FormId { get; set; }
            [UserDefinedTableTypeColumn(2)]
            public bool IsVisible { get; set; }
            [UserDefinedTableTypeColumn(3)]
            public bool IsEditable { get; set; }
        }


        [UserDefinedTableType("udt_ModuleLevelSecurity")]
        public class UdtModuleLevelSecurity
        {
            [UserDefinedTableTypeColumn(1)]
            public int ModuleId { get; set; }
            [UserDefinedTableTypeColumn(2)]
            public bool IsVisible { get; set; }
            [UserDefinedTableTypeColumn(3)]
            public bool IsEditable { get; set; }
        }
        #endregion


        [StoredProcedure("HumanResources.usp_JobProfileInsertORUpdate")]
        public class JobProfileInsertORUpdate
        {
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "JobProfileID")]
            public int JobProfileId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CompanyId")]
            public Nullable<int> CompanyId { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "JobCode")]
            public string JobCode { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "Title")]
            public string Title { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "CityStateOrZipCode")]
            public string CityStateOrZipCode { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "JobCategory")]
            public Nullable<int> JobCategory { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "JobDescription")]
            public string JobDescription { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "CompanyDescription")]
            public string CompanyDescription { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "Status")]
            public Nullable<bool> Status { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "IsPosted")]
            public Nullable<bool> IsPosted { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "BasicInfo")]
            public Nullable<bool> BasicInfo { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "Education")]
            public Nullable<bool> Education { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "Employment")]
            public Nullable<bool> Employment { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "Certification")]
            public Nullable<bool> Certification { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "Skill")]
            public Nullable<bool> Skill { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CreatedBy")]
            public Nullable<int> CreatedBy { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "ModifiedBy")]
            public Nullable<int> ModifiedBy { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "HiringManager")]
            public Nullable<int> HiringManager { get; set; }
            [StoredProcedureParameter(SqlDbType.Date, ParameterName = "PostDate")]
            public Nullable<DateTime> PostDate { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "IsRequisition")]
            public Nullable<bool> IsRequisition { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output, ParameterName = "JobId")]
            public int JobId { get; set; }
            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "udt_JobDuties")]
            public List<UdtJobDuties> UdtJobDuties { get; set; }
            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "udt_JobQualifications")]
            public List<UdtJobQualifications> UdtJobQualifications { get; set; }
            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "udt_JobPMEs")]
            public List<UdtJobPMEs> UdtJobPMEs { get; set; }
            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "udt_RecruitingQuestions")]
            public List<UdtRecruitingQuestions> UdtRecruitingQuestions { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Comments { get; set; }
        }


        [UserDefinedTableType("HumanResources.udt_JobDuties")]
        public class UdtJobDuties
        {

            [UserDefinedTableTypeColumn(1)]
            public Nullable<int> JobDutyId { get; set; }

        }
        [UserDefinedTableType("HumanResources.udt_JobQualifications")]
        public class UdtJobQualifications
        {
            [UserDefinedTableTypeColumn(1)]
            public Nullable<int> JobQualificationId { get; set; }

        }
        [UserDefinedTableType("HumanResources.udt_JobPMEs")]
        public class UdtJobPMEs
        {
            [UserDefinedTableTypeColumn(1)]
            public Nullable<int> JobPMEId { get; set; }

        }
        [UserDefinedTableType("HumanResources.udt_RecruitingQuestions")]
        public class UdtRecruitingQuestions
        {
            [UserDefinedTableTypeColumn(1)]
            public Nullable<int> RecruitingQuestionId { get; set; }

        }
        [StoredProcedure("HumanResources.usp_InterviewInsert")]
        public class InterviewInsert
        {
      
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "JobProfileId")]
            public int JobProfileId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CompanyId")]
            public int CompanyId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "UserId")]
            public int UserId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "Type")]
            public Nullable<int> Type { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "InterviewRoom")]
            public Nullable<int> InterviewRoom { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CandidateId")]
            public Nullable<int> CandidateId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "Status")]
            public Nullable<int> Status { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "InterviewerId")]
            public Nullable<int> InterviewerId { get; set; }
            [StoredProcedureParameter(SqlDbType.Date, ParameterName = "InterviewDate")]
            public Nullable<DateTime> InterviewDate { get; set; }
            [StoredProcedureParameter(SqlDbType.DateTime, ParameterName = "InterviewTime")]
            public Nullable<DateTime> InterviewTime { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "CandidateInstructions")]
            public string CandidateInstructions { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "InterviewerInstructions")]
            public string InterviewerInstructions { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "SendInterviewerEmail")]
            public Nullable<bool> SendInterviewerEmail { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "SendCandidateEmail")]
            public Nullable<bool> SendCandidateEmail { get; set; }
            [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "Feedback")]
            public string Feedback { get; set; }
            //[StoredProcedureParameter(SqlDbType.DateTime, ParameterName = "CreatedOn")]
            //public Nullable<DateTime> CreatedOn { get; set; }
            //[StoredProcedureParameter(SqlDbType.DateTime, ParameterName = "ModifiedOn")]
            //public Nullable<DateTime> ModifiedOn { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, ParameterName = "CreatedBy")]
            public Nullable<int> CreatedBy { get; set; }
            //[StoredProcedureParameter(SqlDbType.Int, ParameterName = "ModifiedBy")]
            //public Nullable<int> ModifiedBy { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output, ParameterName = "InterviewId")]
            public int InterviewId { get; set; }
            [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "udt_JobInterviewers")]
            public List<UdtJobInterviewers> UdtJobInterviewers { get; set; }

        }

        [UserDefinedTableType("HumanResources.udt_JobInterviewers")]
        public class UdtJobInterviewers
        {
             [UserDefinedTableTypeColumn(1)]
            public Nullable<int> InterviewerId { get; set; }
        }

    }
}
