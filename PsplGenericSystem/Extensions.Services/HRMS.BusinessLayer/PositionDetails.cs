using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;




namespace HRMS.BusinessLayer
{
    public class PositionDetails
    {
        public PositionDetails()
        {
            //PositionIdList = new List<LookUpDataEntity>();
            //CompanyIdList = new List<LookUpDataEntity>();
           // PositionCodeList = new List<LookUpDataEntity>();
           // PositionTitleList = new List<LookUpDataEntity>();
            JobProfileList = new List<LookUpDataEntity>();
            RecruitingProfileList = new List<LookUpDataEntity>();
            OnBoardingProfileList = new List<LookUpDataEntity>();
            CompensationProfileList = new List<LookUpDataEntity>();
            TrainingTracksList = new List<LookUpDataEntity>();
            TimeProfileList = new List<LookUpDataEntity>();
            WorkProfileList = new List<LookUpDataEntity>();
            BudgetList = new List<LookUpDataEntity>();
            SecurityList = new List<LookUpDataEntity>();
            LocationList = new List<LookUpDataEntity>();
            DepartmentList = new List<LookUpDataEntity>();
            DivisionList = new List<LookUpDataEntity>();
            CostCenter4List = new List<LookUpDataEntity>();
            CostCenter5List = new List<LookUpDataEntity>();
            EEOCodeList = new List<LookUpDataEntity>();
            FLSACodeList = new List<LookUpDataEntity>();
            WorkersCompCodeList = new List<LookUpDataEntity>();
            ReportsToList = new List<UserLoginModel>();
            //HeadOfOrganizationList = new List<LookUpDataEntity>();

        }
        [Display(Name = "Position Name")]
        public string PositionName { get; set; }
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Display(Name = "Incumbents")]
        public int Incumbents { get; set; }
        [Display(Name = "Open FTE's")]
        public int OpenFTES { get; set; }
        [Display(Name = "Action")]
        public int Action { get; set; }

        #region Dropdown Properties
        
        [Display(Name = "Position Id")]
        public int PositionID { get; set; }
        [Display(Name = "Company Id")]
        public int CompanyID { get; set; }
        [Display(Name = "Position Code")]
        public string PositionCode { get; set; }
        [Display(Name = "Position Title")]
        public string PositionTitle { get; set; }
        public List<LookUpDataEntity> JobProfileList { get; set; }
        [Display(Name = "JobProfile Id")]
        public int JobProfileId { get; set; }
        public List<LookUpDataEntity> RecruitingProfileList { get; set; }
        [Display(Name = "RecruitingProfile Id")]
        public int RecruitingProfileId { get; set; }
        public List<LookUpDataEntity> OnBoardingProfileList { get; set; }
        [Display(Name = "OnBoardingProfile Id")]
        public int OnBoardingProfileId { get; set; }
        public List<LookUpDataEntity> CompensationProfileList { get; set; }
        [Display(Name = "CompensationProfile Id")]
        public int CompensationProfileId { get; set; }
        public List<LookUpDataEntity> TrainingTracksList { get; set; }
        [Display(Name = "TrainingTracks Id")]
        public int TrainingTracksId { get; set; }
        public List<LookUpDataEntity> TimeProfileList { get; set; }
        [Display(Name = "TimeProfile Id")]
        public int TimeProfileId { get; set; }
        public List<LookUpDataEntity> WorkProfileList { get; set; }
        [Display(Name = "WorkProfile Id")]
        public int WorkProfileId { get; set; }
        public List<LookUpDataEntity> BudgetList { get; set; }
        [Display(Name = "Budget Id")]
        public int BudgetId { get; set; }
        public List<LookUpDataEntity> SecurityList { get; set; }
        [Display(Name = "Security Id")]
        public int SecurityId { get; set; }
        public List<LookUpDataEntity> LocationList { get; set; }
        [Display(Name = "Location Id")]
        public int LocationId { get; set; }
        public List<LookUpDataEntity> DepartmentList { get; set; }
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }
        public List<LookUpDataEntity> DivisionList { get; set; }
        [Display(Name = "Division Id")]
        public int DivisionId { get; set; }
        public List<LookUpDataEntity> CostCenter4List { get; set; }
        [Display(Name = "CostCenter4 Id")]
        public int CostCenter4Id { get; set; }
        public List<LookUpDataEntity> CostCenter5List { get; set; }
        [Display(Name = "CostCenter5 Id")]
        public int CostCenter5Id { get; set; }
        public List<LookUpDataEntity> EEOCodeList { get; set; }
        [Display(Name = "EEOCode Id")]
        public int EEOCodeId { get; set; }
        public List<LookUpDataEntity> FLSACodeList { get; set; }
        [Display(Name = "FLSACode Id")]
        public int FLSACodeId { get; set; }
        public List<LookUpDataEntity> WorkersCompCodeList { get; set; }
        [Display(Name = "WorkesrCompCode Id")]
        public int WorkersCompCodeId { get; set; }
        public List<UserLoginModel> ReportsToList { get; set; }
        [Display(Name = "ReportsTo Id")]
        public int ReportsToId { get; set; }
        [Display(Name = "HeadOfOrganization ")]
        public bool HeadOfOrganization { get; set; }
        #endregion
    }
}

