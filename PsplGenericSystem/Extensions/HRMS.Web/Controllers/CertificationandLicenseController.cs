using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using System.Configuration;
using HRMS.Web.ViewModels;
using HRMS.Web.Areas.HireWizard.Models;
using HRMS.Service.Interfaces;
using System.Web.UI;
using HRMS.Common.Enums;
using HRMS.Common.Helpers;

namespace HRMS.Web.Controllers
{
    public class CertificationandLicenseController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly ICertificationandLicenseRepository _certificationandLicenseRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        public CertificationandLicenseController(IUtilityRepository utilityRepository, ICertificationandLicenseRepository certificationandLicenseRepository, IFilesDBRepository filesDBRepository)
        {
            _utilityRepository = utilityRepository;
            _certificationandLicenseRepository = certificationandLicenseRepository;
            _filesDBRepository = filesDBRepository;
        }
        #endregion

        /// <summary>
        /// A view to save and an individual new CL record
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CertificationandLicense()
        {
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            var certificationandLicenseFormModelobj = new CertificationandLicenseFormModel();
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            var lookUpDataEntityobj = new LookUpDataEntity { Name = "Add New Item", Id = 0 };
            certificationandLicenseFormModelobj.TypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseType).ToList();
            certificationandLicenseFormModelobj.TypeList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.CertificationList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseCertification).ToList();
            certificationandLicenseFormModelobj.CertificationList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.SchoolList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseSchool).ToList();
            certificationandLicenseFormModelobj.SchoolList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.EndorsementsList = lstlookup.Where(j => j.TableName == LocalizedStrings.Endorsements).ToList();
            certificationandLicenseFormModelobj.EndorsementsList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.AreasList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseAreas).ToList(); certificationandLicenseFormModelobj.AreasList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.LicenseCountryList = _utilityRepository.GetCountry();
            if (certificationandLicenseFormModelobj.CertificationandLicense.LicenseCountry != 0)
                certificationandLicenseFormModelobj.LicenseStateList = _utilityRepository.GetStateProvince(certificationandLicenseFormModelobj.CertificationandLicense.LicenseCountry);
            else
                certificationandLicenseFormModelobj.LicenseStateList = _utilityRepository.GetStateProvince(certificationandLicenseFormModelobj.CertificationandLicense.LicenseCountry);

            return View(certificationandLicenseFormModelobj);
        }
        /// <summary>
        /// Post method to save individual new record for CL
        /// </summary>
        /// <param name="certificationandLicenseFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult CertificationandLicense(CertificationandLicenseFormModel certificationandLicenseFormModelobj, FormCollection fc)
        {
            int fileId = 0;
            bool success = false;
            String Filepath = ConfigurationManager.AppSettings["ScannedDocuments"];
            if ((Request.Files.Count > 0) && (Request.Files[0].ContentLength > 0))
            {
                string filename = System.IO.Path.GetFileName(Request.Files[0].FileName);
                FilesDB filesDBobj = new FilesDB();
                System.IO.Stream filestream = Request.Files[0].InputStream;
                byte[] bytesInStream = new byte[filestream.Length];
                filestream.Read(bytesInStream, 0, bytesInStream.Length);
                string extension = System.IO.Path.GetExtension(filename);
                filesDBobj.FileName = filename;
                filesDBobj.FileExtension = extension;
                filesDBobj.FileBytes = bytesInStream;
                filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                filesDBobj.FileType = GeneralEnum.FileType.CertificationAttachment.ToString();
                fileId = _filesDBRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.CurrentUserId));
                certificationandLicenseFormModelobj.CertificationandLicense.FileName = filename.ToString();
                certificationandLicenseFormModelobj.CertificationandLicense.Document = fileId;
            }


            certificationandLicenseFormModelobj.CertificationandLicense.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }

            var lookUpDataEntityobj = new LookUpDataEntity { Name = "Add New Item", Id = 0 };
            certificationandLicenseFormModelobj.TypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseType).ToList();
            certificationandLicenseFormModelobj.TypeList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.CertificationList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseCertification).ToList();
            certificationandLicenseFormModelobj.CertificationList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.SchoolList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseSchool).ToList();
            certificationandLicenseFormModelobj.SchoolList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.EndorsementsList = lstlookup.Where(j => j.TableName == LocalizedStrings.Endorsements).ToList();
            certificationandLicenseFormModelobj.EndorsementsList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.AreasList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseAreas).ToList(); certificationandLicenseFormModelobj.AreasList.Insert(0, lookUpDataEntityobj);

            if (certificationandLicenseFormModelobj.CertificationandLicense.CertificationLicensesId == 0)
            {
                certificationandLicenseFormModelobj.CertificationandLicense.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                certificationandLicenseFormModelobj.CertificationandLicense.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                certificationandLicenseFormModelobj.CertificationandLicense.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                certificationandLicenseFormModelobj.CertificationandLicense.CreatedOn = System.DateTime.UtcNow;
                certificationandLicenseFormModelobj.CertificationandLicense.Document = fileId;
                success = _certificationandLicenseRepository.InsertCertificationandLicense(certificationandLicenseFormModelobj.CertificationandLicense);
            }
            else
            {
                certificationandLicenseFormModelobj.CertificationandLicense.Document = fileId;
                certificationandLicenseFormModelobj.CertificationandLicense.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                certificationandLicenseFormModelobj.CertificationandLicense.ModifiedOn = System.DateTime.UtcNow;
                success = _certificationandLicenseRepository.UpdateCertificationandLicense(certificationandLicenseFormModelobj.CertificationandLicense);
            }
            certificationandLicenseFormModelobj.LicenseCountryList = _utilityRepository.GetCountry();
            if (certificationandLicenseFormModelobj.CertificationandLicense.LicenseCountry != 0)
                certificationandLicenseFormModelobj.LicenseStateList = _utilityRepository.GetStateProvince(certificationandLicenseFormModelobj.CertificationandLicense.LicenseCountry);
            if (success)
                return RedirectToAction("SelectAllCertificationLicense");
            else
                return RedirectToAction("SelectAllCertificationLicense");
        }
        /// <summary>
        ///A View to update individual selected record for CL
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult UpdateCertificationandLicense()
        {
            var certificationandLicenseFormModelobj = new CertificationandLicenseFormModel();
            var id = Request.QueryString["CertificationLicensesId"];
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            certificationandLicenseFormModelobj.CertificationandLicense = _certificationandLicenseRepository.SelectCertificationandLicense(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(id)).FirstOrDefault();
            certificationandLicenseFormModelobj.LicenseCountryList = _utilityRepository.GetCountry();
            if (certificationandLicenseFormModelobj.CertificationandLicense.LicenseCountry != 0)
                certificationandLicenseFormModelobj.LicenseStateList = _utilityRepository.GetStateProvince(certificationandLicenseFormModelobj.CertificationandLicense.LicenseCountry);
            var lookUpDataEntityobj = new LookUpDataEntity { Name = "Add New Item", Id = 0 };
            certificationandLicenseFormModelobj.TypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseType).ToList();
            certificationandLicenseFormModelobj.TypeList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.CertificationList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseCertification).ToList();
            certificationandLicenseFormModelobj.CertificationList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.SchoolList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseSchool).ToList();
            certificationandLicenseFormModelobj.SchoolList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.EndorsementsList = lstlookup.Where(j => j.TableName == LocalizedStrings.Endorsements).ToList();
            certificationandLicenseFormModelobj.EndorsementsList.Insert(0, lookUpDataEntityobj);
            certificationandLicenseFormModelobj.AreasList = lstlookup.Where(j => j.TableName == LocalizedStrings.CertificationLicenseAreas).ToList(); certificationandLicenseFormModelobj.AreasList.Insert(0, lookUpDataEntityobj);
            return View(certificationandLicenseFormModelobj);
        }
        /// <summary>
        ///Post method to update individual selected record for CL
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult UpdateCertificationandLicense(CertificationandLicenseFormModel certificationandLicenseFormModelobj)
        {
            bool success = _certificationandLicenseRepository.UpdateCertificationandLicense(certificationandLicenseFormModelobj.CertificationandLicense);
            if (success)
            {
                ModelState.AddModelError("", "Certification and license(s) Updated Successfully.");
            }
            else
            {
                ModelState.AddModelError("", "Certification and license(s) cannot be updated, Please try again.");
            }
            return RedirectToAction("SelectAllCertificationLicense");
        }
        /// <summary>
        /// To list all the certifications and licenses for a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllCertificationLicense()
        {
            int userId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            List<CertificationandLicense> certificationandLicenseList = _certificationandLicenseRepository.SelectAllCertificationandLicense(userId);
            return View(certificationandLicenseList);
        }
        /// <summary>
        /// To remove an selected record from database
        /// </summary>
        /// <param name="certificationandLicenseIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteCertificationandLicense(string certificationandLicenseIds)
        {
            if (certificationandLicenseIds != null)
            {
                foreach (var certificationandLicenseId in certificationandLicenseIds.Split(','))
                {
                    var deleteDependentDetail =
                        _certificationandLicenseRepository.DeleteCertificationandLicense(Int32.Parse(certificationandLicenseId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;

        }
    }
}