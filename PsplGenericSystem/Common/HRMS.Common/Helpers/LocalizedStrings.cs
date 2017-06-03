﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Common.Helpers
{
    public class LocalizedStrings
    {
        public const string Yes = "Yes";
        public const string RequiredValidation = "Please enter a {0}.";
        public const string InvalidValidation = "Invalid {0}.";
        public const string AddNew = "Add New";
        #region Table Names

        public const string EmployeeTaxDetail = "HumanResources.EmployeeTaxDetail";
        public const string UserRole = "Security.UserRole";
        public const string RoleMaster = "OrganizationLevel.RoleMaster";
        public const string FilesDB = "OrganizationLevel.FilesDB";
        public const string EmployeePayDetail = "HumanResources.EmployeePayDetail";
        public const string EmployeeDirectDepositDetail = "HumanResources.EmployeeDirectDepositDetail";
        public const string CompanyInfo = "OrganizationLevel.CompanyInfo";
        public const string EmployeeEmergencyContactDetail = "HumanResources.EmployeeEmergencyContactDetail";
        public const string EmployeeDependentDetail = "HumanResources.EmployeeDependentDetail";
        public const string EmployeeOSHADetail = "HumanResources.EmployeeOSHADetail";
        public const string Employee = "HumanResources.Employee";
        public const string Suffix = "Utility.Suffix";
        public const string Salutation = "Utility.Salutation";
        public const string Relationship = "Utility.Relationship";
        public const string Gender = "Utility.Gender";
        public const string MaritalStatus = "Utility.MaritalStatus";
        public const string EmploymentStatus = "Utility.EmploymentStatus";
        public const string EmploymentTypes = "Utility.EmploymentTypes";
        public const string ChangeReason = "Utility.ChangeReason";
        public const string InfractionType = "Utility.InfractionType";
        public const string CompensationFrequency = "Utility.CompensationFrequency";
        public const string PayFrequency = "Utility.PayFrequency";
        public const string FLSAStatus = "Utility.FLSAStatus";
        public const string GLCode = "Utility.GLCode";
        public const string WithholdingStatus = "Utility.WithholdingStatus";
        public const string Department = "Utility.Department";
        public const string Division = "Utility.Division";
        public const string Location = "Utility.Location";
        public const string Project = "Utility.Project";
        public const string LaborLevel5 = "Utility.LaborLevel5";
        public const string RegisteredUsers = "Security.RegisteredUsers";
        public const string Position = "Utility.Position";
        public const string I9AcceptableDocuments1 = "Utility.I9AcceptableDocuments1";
        public const string I9AcceptableDocuments2 = "Utility.I9AcceptableDocuments2";
        public const string I9AcceptableDocuments3 = "Utility.I9AcceptableDocuments3";
        public const string Ethnicity = "Utility.Ethnicity";
        public const string FederalBlock = "Utility.FederalBlock";
        public const string CountryRegion = "Utility.CountryRegion";
        public const string StateProvince = "Utility.StateProvince";
        public const string SSMedBlock = "Utility.SSMedBlock";
        public const string SUISDIBlock = "Utility.SUISDIBlock";
        public const string TaxBlock = "Utility.TaxBlock";
        public const string SchoolBlock = "Utility.SchoolBlock";
        public const string SchoolDistrict = "Utility.SchoolDistrict";
        public const string DirectDepositAccountType = "Utility.DirectDepositAccountType";
        public const string JobCostNumber = "Utility.JobCostNumber";
        public const string UnionType = "Utility.UnionType";
        public const string WCJobClassCode = "Utility.WCJobClassCode";
        public const string WCStatus = "Utility.WCStatus";
        public const string WCType = "Utility.WCType";
        public const string BonusType = "Utility.BonusType";
        public const string PayType = "Utility.PayType";
        public const string PayGrade = "Utility.PayGrade";
        public const string ShiftPremium = "Utility.ShiftPremium";
        public const string StockOptionType = "Utility.StockOptionType";
        public const string TerminationReason = "Utility.TerminationReason";
        public const string JobProfile = "HumanResources.JobProfile";
        public const string HireConfigurationSetup = "HumanResources.HireConfigurationSetup";
        public const string UserCompany = "Security.UserCompany";
        public const string ClaimType = "Utility.ClaimType";
        public const string OutCome = "Utility.OutCome";
        public const string RecruitingProfile = "Utility.RecruitingProfile";
        public const string OnBoarding = "HumanResources.OnBoarding";
        public const string TrainingTracks = "Utility.TrainingTracks";
        public const string TimeProfile = "Utility.TimeProfile";
        public const string WorkProfile = "Utility.WorkProfile";
        public const string WorkersCompCode = "Utility.WorkersCompCode";
        public const string ContractStatus = "Utility.ContractStatus";
        public const string DegreeLevel = "Utility.DegreeLevel";
        public const string HonoraryRecognition = "Utility.HonoraryRecognition";
        public const string Graduated = "Utility.Graduated";
        public const string CertificationLicenseType = "Utility.CertificationLicenseType";
        public const string Endorsements = "Utility.Endorsements";
        public const string CertificationLicenseAreas = "Utility.CertificationLicenseAreas";
        public const string CertificationLicenseSchool = "Utility.CertificationLicenseSchool";
        public const string CertificationLicenseJobAssignment = "Utility.CertificationLicenseJobAssignment";
        public const string CertificationLicenseCertification = "Utility.CertificationLicenseCertification";
        public const string JobCategory = "Utility.JobCategory";
        public const string DocumentCategory = "Utility.DocumentCategory";
        public const string PayStatus = "Utility.PayStatus";
        public const string WageUnit = "Utility.WageUnit";
        public const string WageType = "Utility.WageType";
        public const string Priority = "Utility.Priority";
        public const string Frequency = "Utility.Frequency";
        public const string Essential = "Utility.Essential";
        public const string Other = "Utility.Other";
        public const string JobQualificationType = "Utility.JobQualificationType";
        public const string QuestionType = "Utility.QuestionType";
        public const string InterviewType = "Utility.InterviewType";
        public const string InterviewRoom = "Utility.InterviewRoom";
        public const string InterviewStatus = "Utility.InterviewStatus";
        public const string AccountType = "Utility.DirectDepositAccountType";
        public const string JobAssignment = "Utility.EmployeePayJobAssignment";
        #endregion
    }
}