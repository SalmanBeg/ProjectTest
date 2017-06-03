using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using HRMS.Service.Repositories;
using HRMS.Service.Interfaces;
using Microsoft.Practices.Unity.InterceptionExtension;


namespace HRMS.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            container.AddNewExtension<Interception>();
            // TODO: Register your types here
            container.RegisterType<IRegisteredUsersRepository, RegisteredUsersRepository>().Configure<Interception>().SetInterceptorFor<IRegisteredUsersRepository>(new InterfaceInterceptor()); ;
            container.RegisterType<IUtilityRepository, UtilityRepository>().Configure<Interception>().SetInterceptorFor<IUtilityRepository>(new InterfaceInterceptor());
            container.RegisterType<ICompanyRepository, CompanyRepository>().Configure<Interception>().SetInterceptorFor<ICompanyRepository>(new InterfaceInterceptor());
            container.RegisterType<IConsentFormRepository, ConsentFormRepository>().Configure<Interception>().SetInterceptorFor<IConsentFormRepository>(new InterfaceInterceptor());
            container.RegisterType<IDependentRepository, DependentRepository>().Configure<Interception>().SetInterceptorFor<IDependentRepository>(new InterfaceInterceptor());
            container.RegisterType<IDirectDepositRepository, DirectDepositRepository>().Configure<Interception>().SetInterceptorFor<IDirectDepositRepository>(new InterfaceInterceptor());
            container.RegisterType<IEmergencyContanctRepository, EmergencyContactRepository>().Configure<Interception>().SetInterceptorFor<IEmergencyContanctRepository>(new InterfaceInterceptor());
            container.RegisterType<IEmployeeRepository, EmployeeRepository>().Configure<Interception>().SetInterceptorFor<IEmployeeRepository>(new InterfaceInterceptor());
            container.RegisterType<IFilesDBRepository, FilesDBRepository>().Configure<Interception>().SetInterceptorFor<IFilesDBRepository>(new InterfaceInterceptor());
            container.RegisterType<IHireConfigurationSetupRepository, HireConfigurationSetupRepository>().Configure<Interception>().SetInterceptorFor<IHireConfigurationSetupRepository>(new InterfaceInterceptor());
            container.RegisterType<ILookUpTableRepository, LookUpTableRepository>().Configure<Interception>().SetInterceptorFor<ILookUpTableRepository>(new InterfaceInterceptor());
            container.RegisterType<IOnBoardingRepository, OnBoardingRepository>().Configure<Interception>().SetInterceptorFor<IOnBoardingRepository>(new InterfaceInterceptor());
            container.RegisterType<IOSHARepository, OSHARepository>().Configure<Interception>().SetInterceptorFor<IOSHARepository>(new InterfaceInterceptor());
            container.RegisterType<IPayRepository, PayRepository>().Configure<Interception>().SetInterceptorFor<IPayRepository>(new InterfaceInterceptor());
            container.RegisterType<IRoleRepository, RoleRepository>().Configure<Interception>().SetInterceptorFor<IRoleRepository>(new InterfaceInterceptor());
            container.RegisterType<IScreenVerbiageRepository, ScreenVerbiageRepository>().Configure<Interception>().SetInterceptorFor<IScreenVerbiageRepository>(new InterfaceInterceptor());
            container.RegisterType<ITaxRepository, TaxRepository>().Configure<Interception>().SetInterceptorFor<ITaxRepository>(new InterfaceInterceptor());
            container.RegisterType<IW4FormRepository, W4FormRepository>().Configure<Interception>().SetInterceptorFor<IW4FormRepository>(new InterfaceInterceptor());
            container.RegisterType<IAlertTemplateRepository, AlertTemplateRepository>().Configure<Interception>().SetInterceptorFor<IAlertTemplateRepository>(new InterfaceInterceptor());
            container.RegisterType<IMailerRepository, MailerRepository>().Configure<Interception>().SetInterceptorFor<IMailerRepository>(new InterfaceInterceptor());
            container.RegisterType<II9WorkAuthorizationRepository, I9WorkAuthorizationRepository>().Configure<Interception>().SetInterceptorFor<II9WorkAuthorizationRepository>(new InterfaceInterceptor());
            container.RegisterType<IEmployeeSignRepository, EmployeeSignRepository>().Configure<Interception>().SetInterceptorFor<IEmployeeSignRepository>(new InterfaceInterceptor());
            container.RegisterType<IImportEmployeecsvRepository, ImportEmployeecsvRepository>().Configure<Interception>().SetInterceptorFor<IImportEmployeecsvRepository>(new InterfaceInterceptor());
            container.RegisterType<IEmployeePhotoRepository, EmployeePhotoRepository>().Configure<Interception>().SetInterceptorFor<IEmployeePhotoRepository>(new InterfaceInterceptor());
            container.RegisterType<IEmployeeNotesRepository, EmployeeNotesRepository>().Configure<Interception>().SetInterceptorFor<IEmployeeNotesRepository>(new InterfaceInterceptor());
            container.RegisterType<ICompanyLevelSecurityRepository, CompanyLevelSecurityRepository>().Configure<Interception>().SetInterceptorFor<IDependentRepository>(new InterfaceInterceptor());
            container.RegisterType<IJobProfileRepository, JobProfileRepository>().Configure<Interception>().SetInterceptorFor<IJobProfileRepository>(new InterfaceInterceptor());
            container.RegisterType<IEmployeeFolderRepository, EmployeeFolderRepository>().Configure<Interception>().SetInterceptorFor<IEmployeeFolderRepository>(new InterfaceInterceptor());
            container.RegisterType<IEmployeeAssetRepository, EmployeeAssetRepository>().Configure<Interception>().SetInterceptorFor<IEmployeeAssetRepository>(new InterfaceInterceptor());
            container.RegisterType<ITalentManagementRepository, TalentManagementRepository>().Configure<Interception>().SetInterceptorFor<ITalentManagementRepository>(new InterfaceInterceptor());
            container.RegisterType<ICertificationandLicenseRepository, CertificationandLicenseRepository>().Configure<Interception>().SetInterceptorFor<ICertificationandLicenseRepository>(new InterfaceInterceptor());
            container.RegisterType<ITrainingEmployeeRepository, TrainingEmployeeRepository>().Configure<Interception>().SetInterceptorFor<ITrainingEmployeeRepository>(new InterfaceInterceptor());
            container.RegisterType<ICompetencyRepository, CompetencyRepository>().Configure<Interception>().SetInterceptorFor<ICompetencyRepository>(new InterfaceInterceptor());
            container.RegisterType<IReviewCriteriaRepository, ReviewCriteriaRepository>().Configure<Interception>().SetInterceptorFor<IReviewCriteriaRepository>(new InterfaceInterceptor());
            container.RegisterType<IPayTypeRepository, PayTypeRepository>().Configure<Interception>().SetInterceptorFor<IPayTypeRepository>(new InterfaceInterceptor());
            container.RegisterType<ITimeTypeRepository, TimeTypeRepository>().Configure<Interception>().SetInterceptorFor<ITimeTypeRepository>(new InterfaceInterceptor());
            container.RegisterType<IPayPeriodTypeRepository, PayPeriodTypeRepository>().Configure<Interception>().SetInterceptorFor<IPayPeriodTypeRepository>(new InterfaceInterceptor());
            container.RegisterType<IPayPeriodRepository, PayPeriodRepository>().Configure<Interception>().SetInterceptorFor<IPayPeriodRepository>(new InterfaceInterceptor());
            container.RegisterType<IRatingScaleRepository, RatingScaleRepository>().Configure<Interception>().SetInterceptorFor<IRatingScaleRepository>(new InterfaceInterceptor());
            container.RegisterType<IPerformanceReviewsRepository, PerformanceReviewRepository>().Configure<Interception>().SetInterceptorFor<IPerformanceReviewsRepository>(new InterfaceInterceptor());
            container.RegisterType<IReviewCriteriaRepository, ReviewCriteriaRepository>().Configure<Interception>().SetInterceptorFor<IReviewCriteriaRepository>(new InterfaceInterceptor());
            container.RegisterType<ICompensationProfileRepository, CompensationProfileRepository>().Configure<Interception>().SetInterceptorFor<ICompensationProfileRepository>(new InterfaceInterceptor());
            container.RegisterType<IMasterRepository, MasterRepository>().Configure<Interception>().SetInterceptorFor<IMasterRepository>(new InterfaceInterceptor());
            container.RegisterType<IReviewFormRepository, ReviewFormRepository>().Configure<Interception>().SetInterceptorFor<IReviewFormRepository>(new InterfaceInterceptor());
            container.RegisterType<ITrainingClassRepository, TrainingClassRepository>().Configure<Interception>().SetInterceptorFor<ITrainingClassRepository>(new InterfaceInterceptor());
            container.RegisterType<ITrainingTrackRepository, TrainingTrackRepository>().Configure<Interception>().SetInterceptorFor<ITrainingTrackRepository>(new InterfaceInterceptor());
            container.RegisterType<ITrainingClassScheduleRepository, TrainingClassScheduleRepository>().Configure<Interception>().SetInterceptorFor<ITrainingClassScheduleRepository>(new InterfaceInterceptor());
            container.RegisterType<ITrainingClassResourcesRepository, TrainingClassResourcesRepository>().Configure<Interception>().SetInterceptorFor<ITrainingClassResourcesRepository>(new InterfaceInterceptor());
            container.RegisterType<IEmployeeSnapshotRepository, EmployeeSnapshotRepository>().Configure<Interception>().SetDefaultInterceptorFor<IEmployeeSnapshotRepository>(new InterfaceInterceptor());
            //Communication
            container.RegisterType<ICompanyLinkRepository, CompanyLinkRepository>().Configure<Interception>().SetInterceptorFor<ICompanyLinkRepository>(new InterfaceInterceptor());
            container.RegisterType<ICompanyDocumentRepository, CompanyDocumentRepository>().Configure<Interception>().SetInterceptorFor<ICompanyDocumentRepository>(new InterfaceInterceptor());
            container.RegisterType<IEmployeeDocumentRepository, EmployeeDocumentRepository>().Configure<Interception>().SetInterceptorFor<IEmployeeDocumentRepository>(new InterfaceInterceptor());
            container.RegisterType<ICompanyAnnouncementRepository, CompanyAnnouncementRepository>().Configure<Interception>().SetInterceptorFor<ICompanyAnnouncementRepository>(new InterfaceInterceptor());
            container.RegisterType<IDocumentBasicCriteriaRepository, DocumentBasicCriteriaRepository>().Configure<Interception>().SetInterceptorFor<IDocumentBasicCriteriaRepository>(new InterfaceInterceptor());
            container.RegisterType<IDocumentAdvancedCriteriaRepository, DocumentAdvancedCriteriaRepository>().Configure<Interception>().SetInterceptorFor<IDocumentAdvancedCriteriaRepository>(new InterfaceInterceptor());
            container.RegisterType<IEmployeeNoConfigurationRepository, EmployeeNoConfigurationRepository>().Configure<Interception>().SetInterceptorFor<IEmployeeNoConfigurationRepository>(new InterfaceInterceptor());
            container.RegisterType<IJobDutiesRepository, JobDutiesRepository>().Configure<Interception>().SetInterceptorFor<IJobDutiesRepository>(new InterfaceInterceptor());
            container.RegisterType<IJobPMERepository, JobPMERepository>().Configure<Interception>().SetInterceptorFor<IJobPMERepository>(new InterfaceInterceptor());
            container.RegisterType<IJobQualificationRepository, JobQualificationRepository>().Configure<Interception>().SetInterceptorFor<IJobQualificationRepository>(new InterfaceInterceptor());
            container.RegisterType<IRecruitingQuestionsRepository, RecruitingQuestionsRepository>().Configure<Interception>().SetInterceptorFor<IRecruitingQuestionsRepository>(new InterfaceInterceptor());
            container.RegisterType<IJobApplicantRepository, JobApplicantRepository>().Configure<Interception>().SetInterceptorFor<IJobApplicantRepository>(new InterfaceInterceptor());
            container.RegisterType<IInterviewRepository, InterviewRepository>().Configure<Interception>().SetInterceptorFor<IInterviewRepository>(new InterfaceInterceptor());
            container.RegisterType<IRecruitingAnswersRepository, RecruitingAnswersRepository>().Configure<Interception>().SetInterceptorFor<IRecruitingAnswersRepository>(new InterfaceInterceptor());
            container.RegisterType<IOfferLetterRepository, OfferLetterRepository>().Configure<Interception>().SetInterceptorFor<IOfferLetterRepository>(new InterfaceInterceptor());
            container.RegisterType<IMailingInfoRepository, MailingInfoRepository>().Configure<Interception>().SetInterceptorFor<IMailingInfoRepository>(new InterfaceInterceptor()); 
        }
    }
}
