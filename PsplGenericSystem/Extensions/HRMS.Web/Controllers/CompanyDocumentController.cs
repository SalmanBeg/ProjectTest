using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;
using HRMS.Service.Interfaces;
using HRMS.Common.Enums;
using System.Configuration;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.Controllers
{
    public class CompanyDocumentController : Controller
    {
        #region Class Level Variables and constructor
        private readonly ICompanyDocumentRepository _companyDocumentRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        private readonly IEmployeeDocumentRepository _employeeDocumentRepository;
        private readonly IDocumentBasicCriteriaRepository _documentBasicCriteriaRepository;
        private readonly IDocumentAdvancedCriteriaRepository _documentAdvancedCriteriaRepository;
        public CompanyDocumentController(
            ICompanyDocumentRepository companyDocumentRepository,
            IUtilityRepository utilityRepository,
            IRegisteredUsersRepository registeredUsersRepository,
            IEmployeeRepository employeeRepository,
            IRoleRepository roleRepository,
            ICompanyRepository companyRepository,
            IFilesDBRepository filesDBRepository,
            IEmployeeDocumentRepository employeeDocumentRepository,
            IDocumentBasicCriteriaRepository documentBasicCriteriaRepository,
            IDocumentAdvancedCriteriaRepository documentAdvancedCriteriaRepository
            )
        {
            _companyDocumentRepository = companyDocumentRepository;
            _utilityRepository = utilityRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;
            _companyRepository = companyRepository;
            _filesDBRepository = filesDBRepository;
            _employeeDocumentRepository = employeeDocumentRepository;
            _documentBasicCriteriaRepository = documentBasicCriteriaRepository;
            _documentAdvancedCriteriaRepository = documentAdvancedCriteriaRepository;
        }
        #endregion

        int fileId = 0;
        /// <summary>
        /// Returns all Company Documents by CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ActionName("SelectAllCompanyDocument")]
        public ActionResult SelectAllCompanyDocument()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<CompanyDocument> companyLinkList = _companyDocumentRepository.SelectAllCompanyDocumentByCompanyId(companyId).ToList();
            return View(companyLinkList);
        }


        /// <summary>
        /// Returns employee AddCompanyDocument emptry view. And also returns the record for update.
        /// </summary>
        /// <param name="companyLinkobj"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ActionName("AddCompanyDocument")]
        public ActionResult AddCompanyDocument()
        {
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };

            CompanyDocumentFormModel companyDocumentFormModelobj = new CompanyDocumentFormModel();
            companyDocumentFormModelobj.SendToList = _utilityRepository.GetDocumentSendType(); //Loads from Utility.DocumentSendType
            companyDocumentFormModelobj.SendCriteriaList = _utilityRepository.GetDocumentSendCriteria(); //Loads from Utility.DocumentSendCriteria
            companyDocumentFormModelobj.RoleList = _roleRepository.SelectAllRoles(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));//ToAdd: RoleList
            companyDocumentFormModelobj.CompanyList = _companyRepository.GetAllCompanyInfo();//ToAdd: CompanyList
            companyDocumentFormModelobj.EmployeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));//Employees

            //Lookup Tables List from Employee, Positions, Locations, Departments and EmploymentStatus
            List<LookUpDataEntity> lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            companyDocumentFormModelobj.JobList = lstlookup.Where(j => j.TableName == "Utility.JobCategory").ToList(); //ToAdd: JobTitleList
            companyDocumentFormModelobj.LocationsList = lstlookup.Where(j => j.TableName == "Utility.Location").ToList();
            companyDocumentFormModelobj.DepartmentsList = lstlookup.Where(j => j.TableName == "Utility.Department").ToList();
            companyDocumentFormModelobj.EmploymentStatusList = lstlookup.Where(j => j.TableName == "Utility.EmploymentStatus").ToList();
            companyDocumentFormModelobj.EmploymentTypeList = lstlookup.Where(j => j.TableName == "Utility.EmploymentTypes").ToList(); //EmploymentType
            companyDocumentFormModelobj.DocumentCategoryList = lstlookup.Where(j => j.TableName == "Utility.DocumentCategory").ToList();
            companyDocumentFormModelobj.DocumentCategoryList.Insert(0, lookUpDataEntityobj);
            //For Update View. Lods the Update view with CompanyDocumentId.
            if (Request.QueryString["CompanyDocumentId"] != null)
            {
                var companyDocumentId = Request.QueryString["CompanyDocumentId"];
                companyDocumentFormModelobj.CompanyDocument = _companyDocumentRepository.SelectCompanyDocumentById(Convert.ToInt32(companyDocumentId)).SingleOrDefault();


                //Return Files
                var filesDBList = new List<FilesDB>();
                int filedbId = Convert.ToInt32(companyDocumentFormModelobj.CompanyDocument.AttachmentId);
                filesDBList = _filesDBRepository.SelectFileByFileDBId(filedbId);
                companyDocumentFormModelobj.FilesDBList = filesDBList;


                //**************Return the strored criteria List IDs
                //Returns the Basic Criteria List IDs
                List<DocumentBasicCriteria> documentBasicCriteriaList = _documentBasicCriteriaRepository.SelectAllDocumentBasicCriteria().Where
                    (d => d.CompanyDocumentId == Convert.ToInt32(companyDocumentId)).ToList();
                for (int i = 0; i < documentBasicCriteriaList.Count; i++)
                {
                    if (documentBasicCriteriaList[i].DocumentSendTypeId == 2) //Basic Criteria
                    {
                        companyDocumentFormModelobj.roleIdList += documentBasicCriteriaList[i].SelectedCriteriaListId.ToString() + ",";
                    }
                    if (documentBasicCriteriaList[i].DocumentSendTypeId == 3) //Advanced Criteria
                    {

                    }
                }

                //Returns the Advanced Criteria List IDs
                List<DocumentAdvancedCriteria> documnetAdvancedCriteriaList = _documentAdvancedCriteriaRepository.SelectAllDocumentAdvancedCriteria().Where(
                    da => da.CompanyDocumentId == Convert.ToInt32(companyDocumentId)).ToList();
                //Store the Saved Criteria List according to the Type.
                for (int j = 0; j < documnetAdvancedCriteriaList.Count; j++)
                {
                    //case DocumentSendCriteria
                    switch (documnetAdvancedCriteriaList[j].DocumentSendCriteriaId)
                    {
                        case 1: //Company
                            //Returns DocumentSendCriteria 1 values.
                            companyDocumentFormModelobj.companyIdList += documnetAdvancedCriteriaList[j].SelectedCriteriaListId.ToString() + ",";
                            break;
                        case 2: //Job
                            companyDocumentFormModelobj.jobIdList += documnetAdvancedCriteriaList[j].SelectedCriteriaListId.ToString() + ",";
                            break;
                        case 3: //Location
                            companyDocumentFormModelobj.locationIdList += documnetAdvancedCriteriaList[j].SelectedCriteriaListId.ToString() + ",";
                            break;
                        case 4: //Department
                            companyDocumentFormModelobj.departmentIdList += documnetAdvancedCriteriaList[j].SelectedCriteriaListId.ToString() + ",";
                            break;
                        case 5: //EmployementStatus
                            companyDocumentFormModelobj.employmentstatusIdList += documnetAdvancedCriteriaList[j].SelectedCriteriaListId.ToString() + ",";
                            break;
                        case 6: //EmployementType
                            companyDocumentFormModelobj.employmenttypeIdList += documnetAdvancedCriteriaList[j].SelectedCriteriaListId.ToString() + ",";
                            break;
                    }
                }
                //Removes the last character comma (,) from the string.
                if (companyDocumentFormModelobj.roleIdList != null)
                    companyDocumentFormModelobj.roleIdList = companyDocumentFormModelobj.roleIdList.Remove(companyDocumentFormModelobj.roleIdList.Length - 1, 1);
                if (companyDocumentFormModelobj.companyIdList != null)
                    companyDocumentFormModelobj.companyIdList = companyDocumentFormModelobj.companyIdList.Remove(companyDocumentFormModelobj.companyIdList.Length - 1, 1);
                if (companyDocumentFormModelobj.jobIdList != null)
                    companyDocumentFormModelobj.jobIdList = companyDocumentFormModelobj.jobIdList.Remove(companyDocumentFormModelobj.jobIdList.Length - 1, 1);
                if (companyDocumentFormModelobj.locationIdList != null)
                    companyDocumentFormModelobj.locationIdList = companyDocumentFormModelobj.locationIdList.Remove(companyDocumentFormModelobj.locationIdList.Length - 1, 1);
                if (companyDocumentFormModelobj.departmentIdList != null)
                    companyDocumentFormModelobj.departmentIdList = companyDocumentFormModelobj.departmentIdList.Remove(companyDocumentFormModelobj.departmentIdList.Length - 1, 1);
                if (companyDocumentFormModelobj.employmentstatusIdList != null)
                    companyDocumentFormModelobj.employmentstatusIdList = companyDocumentFormModelobj.employmentstatusIdList.Remove(companyDocumentFormModelobj.employmentstatusIdList.Length - 1, 1);
                if (companyDocumentFormModelobj.employmenttypeIdList != null)
                    companyDocumentFormModelobj.employmenttypeIdList = companyDocumentFormModelobj.employmenttypeIdList.Remove(companyDocumentFormModelobj.employmenttypeIdList.Length - 1, 1);


                ////Return Files
                //var filesDBList = new List<FilesDB>();
                //int filedbId = Convert.ToInt32(companyDocumentFormModelobj.CompanyDocument.AttachmentId);
                //filesDBList = _filesDBRepository.SelectFileByFileDBId(filedbId);
                //companyDocumentFormModelobj.FilesDBList = filesDBList;
                return View(companyDocumentFormModelobj);
            }
            return View(companyDocumentFormModelobj);
        }

        /// <summary>
        /// Inserts the Attached document in FilesBD and Inserts teh Company Document record.
        /// Updates the Company Document records, and also open and update/deletes the files.
        /// </summary>
        /// <param name="companyDocumentFormModelobj"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        [ActionName("AddCompanyDocument")]
        public ActionResult AddCompanyDocument(CompanyDocumentFormModel companyDocumentFormModelobj)
        {
            //Multiple Files
            if ((Request.Files.Count > 0) && (Request.Files[0].ContentLength > 0))
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    string filename = System.IO.Path.GetFileName(Request.Files[i].FileName);
                    FilesDB filesDBobj = new FilesDB();
                    System.IO.Stream filestream = Request.Files[i].InputStream;
                    byte[] bytesInStream = new byte[filestream.Length];
                    filestream.Read(bytesInStream, 0, bytesInStream.Length);
                    string extension = System.IO.Path.GetExtension(filename);
                    filesDBobj.FileName = filename;
                    filesDBobj.FileExtension = extension;
                    filesDBobj.FileBytes = bytesInStream;
                    filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                    filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                    filesDBobj.FileType = GeneralEnum.FileType.CompanyDocument.ToString();
                    fileId = _filesDBRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.SelectedUserId));
                }
            }

            if (companyDocumentFormModelobj.CompanyDocument.CompanyDocumentId == 0)
            {
                companyDocumentFormModelobj.CompanyDocument.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                companyDocumentFormModelobj.CompanyDocument.CreatedOn = System.DateTime.UtcNow;
                //Inserts the fileId into AttachmentId.
                companyDocumentFormModelobj.CompanyDocument.AttachmentId = fileId;
                companyDocumentFormModelobj.CompanyDocument.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                //_companyDocumentRepository.CreateCompanyDocument(companyDocumentFormModelobj.CompanyDocument);
                //Returns the Output Parameter. Updates the EmployeeFolder(FilesDBId) with the inserted FilesDB(FilesDBId).
                int companyDocumentId = _companyDocumentRepository.CreateCompanyDocument(companyDocumentFormModelobj.CompanyDocument);

                //Stores the Selected Criteria values in EmployeeDocument.
                if (!String.IsNullOrEmpty(companyDocumentId.ToString()))
                {
                    //companyDocumentFormModelobj.EmployeeList = _userSignUpRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                    //AddCompanyDocumentToEmployee(companyDocumentFormModelobj.EmployeeList, companyDocumentId);
                    switch (companyDocumentFormModelobj.CompanyDocument.SendTo)
                    {
                        case 1: //AllEmployees
                            {
                                List<UserLoginModel> employeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                                if (employeeList.Count > 0)
                                {
                                    companyDocumentFormModelobj.EmployeeList = employeeList;
                                    AddCompanyDocumentToEmployee(companyDocumentFormModelobj.EmployeeList, companyDocumentId);
                                }
                                break;
                            }
                        case 2: //SelectRoles
                            {
                                //companyDocumentFormModelobj.EmployeeList = _userSignUpRepository.SelectAllManager(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                                //AddCompanyDocumentToEmployee(companyDocumentFormModelobj.EmployeeList, companyDocumentId);
                                foreach (var roleId in companyDocumentFormModelobj.roleIdList.Split(','))
                                {
                                    //Returns the the employees belongs to the selecte roles
                                    List<UserLoginModel> employeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId))
                                        .Where(e => e.RoleId == Convert.ToInt32(roleId)).ToList();
                                    if (employeeList.Count > 0)
                                    {
                                        companyDocumentFormModelobj.EmployeeList = employeeList;
                                        AddCompanyDocumentToEmployee(companyDocumentFormModelobj.EmployeeList, companyDocumentId);

                                        //Stores the Selected Criteria into DocumentBasicCriteria.
                                        DocumentBasicCriteria documentBasicCriteriaobj = new DocumentBasicCriteria();
                                        documentBasicCriteriaobj.CompanyDocumentId = companyDocumentId;
                                        documentBasicCriteriaobj.DocumentSendTypeId = companyDocumentFormModelobj.CompanyDocument.SendTo;
                                        documentBasicCriteriaobj.SelectedCriteriaListId = Convert.ToInt32(roleId);
                                        bool storedCriteria = _documentBasicCriteriaRepository.CreateDocumentBasicCriteria(documentBasicCriteriaobj);
                                    }
                                }
                                break;
                            }
                        case 3: //AdvancedCriteria
                            {
                                AddComapnyDocumentByCriteria(
                                    companyDocumentFormModelobj.companyIdList,
                                    companyDocumentFormModelobj.jobIdList,
                                    companyDocumentFormModelobj.locationIdList,
                                    companyDocumentFormModelobj.departmentIdList,
                                    companyDocumentFormModelobj.employmentstatusIdList,
                                    companyDocumentFormModelobj.employmenttypeIdList,
                                    companyDocumentFormModelobj.CompanyDocument.SendTo,
                                    companyDocumentId);
                            }
                            break;
                    }
                }
            }
            else
            {
                companyDocumentFormModelobj.CompanyDocument.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                companyDocumentFormModelobj.CompanyDocument.ModifiedOn = System.DateTime.UtcNow;
                //Updates the fileId into AttachmentId.
                if (fileId != 0)
                    companyDocumentFormModelobj.CompanyDocument.AttachmentId = fileId;
                bool success = _companyDocumentRepository.UpdateCompanyDocument(companyDocumentFormModelobj.CompanyDocument);
            }
            return RedirectToAction("SelectAllCompanyDocument");
        }

        /// <summary>
        /// Deletes the CompanyDocument.
        /// </summary>
        /// <param name="companyDocumentIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ActionName("DeleteCompanyDocument")]
        public bool DeleteCompanyDocument(string companyDocumentIds)
        {
            if (companyDocumentIds != null)
            {
                foreach (var companyDocumentId in companyDocumentIds.Split(','))
                {
                    var deleteCompanyDocumentDetail =
                        _companyDocumentRepository.DeleteCompanyDocument(Convert.ToInt32(companyDocumentId));
                }
            }
            return true;
        }



        #region Employee Documents according to the selected criteria

        /// <summary>
        /// Inserts the company Document to all employees for AllEmployees and SelectRoles Criteria.
        /// </summary>
        /// <param name="employeeList"></param>
        /// <param name="companyDocumentId"></param>
        [HttpPost]
        [Authorize]
        [ActionName("AddCompanyDocumentToEmployee")]
        public void AddCompanyDocumentToEmployee(List<UserLoginModel> employeeList, int companyDocumentId)
        {
            if (employeeList != null)
            {
                EmployeeDocument employeeDocumentobj = new EmployeeDocument();
                foreach (var empList in employeeList)
                {
                    employeeDocumentobj.CompanyDocumentId = companyDocumentId;
                    employeeDocumentobj.EmployeeId = empList.UserId;
                    employeeDocumentobj.EmployeeName = empList.UserName;
                    employeeDocumentobj.EmployeeEmail = empList.Email;
                    employeeDocumentobj.Status = true;
                    _employeeDocumentRepository.CreateEmployeeDocument(employeeDocumentobj);
                }
            }
        }


        /// <summary>
        //Inserts the Employee in Employee Document by Location, Job, Department, EmploymentStatus, EmploymentType
        /// </summary>
        /// <param name="employeeList"></param>
        /// <param name="companyDocumentId"></param>
        [Authorize]
        public void AddCompanyDocumentToEmployeeByCriteria(List<Employee> employeeList, int companyDocumentId)
        {
            if (employeeList != null)
            {
                EmployeeDocument employeeDocumentobj = new EmployeeDocument();
                foreach (var empList in employeeList)
                {
                    employeeDocumentobj.CompanyDocumentId = companyDocumentId;
                    employeeDocumentobj.EmployeeId = empList.UserId;
                    employeeDocumentobj.EmployeeName = empList.FirstName + " " + empList.MiddleName + "" + empList.LastName;
                    employeeDocumentobj.EmployeeEmail = empList.Email;
                    employeeDocumentobj.Status = true;
                    if (!String.IsNullOrEmpty(empList.Email))
                        _employeeDocumentRepository.CreateEmployeeDocument(employeeDocumentobj);
                }
            }
        }


        /// <summary>
        /// Insertts the employee based on CompanyDocument AdvancedCriteria
        /// </summary>
        /// <param name="companyIdList"></param>
        /// <param name="jobIdList"></param>
        /// <param name="locationIdList"></param>
        /// <param name="departmentIdList"></param>
        /// <param name="employmentstatusIdList"></param>
        /// <param name="employmenttypeIdList"></param>
        /// <param name="SendTo"></param>
        /// <param name="companyDocumentId"></param>
        [Authorize]
        public void AddComapnyDocumentByCriteria(
                                    string companyIdList,
                                    string jobIdList,
                                    string locationIdList,
                                    string departmentIdList,
                                    string employmentstatusIdList,
                                    string employmenttypeIdList,
                                    int? SendTo,
                                    int companyDocumentId)
        {
            List<Employee> employeeList = new List<Employee>();
            CompanyDocumentFormModel companyDocumentFormModelobj = new CompanyDocumentFormModel();
            List<DocumentSendCriteria> criteriaList = _utilityRepository.GetDocumentSendCriteria();
            //Need to replace wiht switch
            if (companyIdList != null)
            {
                foreach (var companyId in companyIdList.Split(','))
                {
                    var documentSendCriteriaId = (from x in criteriaList where x.DocumentSendCriteriaName == "Company" select x.DocumentSendCriteriaId).First();
                    //Returns the employees belogins to the documentSendCriteriaId (companyId)
                    //List<UserLoginModel> employeeList = _userSignUpRepository.SelectAllEmployeesList(Convert.ToInt32(documentSendCriteriaId));
                    employeeList = _employeeRepository.SelectEmployeeByCompanyId(Convert.ToInt32(companyId));
                    if (employeeList.Count > 0)
                    {
                        companyDocumentFormModelobj.EmployeeByCriteriaList = employeeList;
                        //AddCompanyDocumentToEmployeeByCriteria(companyDocumentFormModelobj.EmployeeByList, companyDocumentId);

                        //Stores the Selected Criteria into DocumentAdvancedCriteria.
                        DocumentAdvancedCriteria documentAdvancedCriteriaobj = new DocumentAdvancedCriteria();
                        documentAdvancedCriteriaobj.CompanyDocumentId = companyDocumentId;
                        documentAdvancedCriteriaobj.DocumentSendTypeId = SendTo;
                        documentAdvancedCriteriaobj.DocumentSendCriteriaId = documentSendCriteriaId;
                        documentAdvancedCriteriaobj.SelectedCriteriaListId = Convert.ToInt32(companyId);
                        bool storedCriteria = _documentAdvancedCriteriaRepository.CreateDocumentAdvancedCriteria(documentAdvancedCriteriaobj);
                    }
                }
            }
            if (jobIdList != null)
            {
                foreach (var jobId in jobIdList.Split(','))
                {
                    var documentSendCriteriaId = (from x in criteriaList where x.DocumentSendCriteriaName == "Job" select x.DocumentSendCriteriaId).First();
                    employeeList = _registeredUsersRepository.SelectAllEmployeesByJob(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(jobId));
                    if (employeeList.Count > 0)
                    {
                        companyDocumentFormModelobj.EmployeeByCriteriaList = employeeList;
                        //AddCompanyDocumentToEmployeeByCriteria(companyDocumentFormModelobj.EmployeeByList, companyDocumentId);

                        //Stores the Selected Criteria into DocumentAdvancedCriteria.
                        DocumentAdvancedCriteria documentAdvancedCriteriaobj = new DocumentAdvancedCriteria();
                        documentAdvancedCriteriaobj.CompanyDocumentId = companyDocumentId;
                        documentAdvancedCriteriaobj.DocumentSendTypeId = SendTo;
                        documentAdvancedCriteriaobj.DocumentSendCriteriaId = documentSendCriteriaId;
                        documentAdvancedCriteriaobj.SelectedCriteriaListId = Convert.ToInt32(jobId);
                        bool storedCriteria = _documentAdvancedCriteriaRepository.CreateDocumentAdvancedCriteria(documentAdvancedCriteriaobj);
                    }
                }
            }
            if (locationIdList != null)
            {
                foreach (var locationId in locationIdList.Split(','))
                {
                    var documentSendCriteriaId = (from x in criteriaList where x.DocumentSendCriteriaName == "Location" select x.DocumentSendCriteriaId).First();
                    //Returns the emploees belongs to the selected documentSendCriteriaId (LocationId)
                    employeeList = _registeredUsersRepository.SelectAllEmployeesByLocation(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(locationId));
                    if (employeeList.Count > 0)
                    {
                        companyDocumentFormModelobj.EmployeeByCriteriaList = employeeList;
                        //AddCompanyDocumentToEmployeeByCriteria(companyDocumentFormModelobj.EmployeeByList, companyDocumentId);

                        //Stores the Selected Criteria into DocumentAdvancedCriteria.
                        DocumentAdvancedCriteria documentAdvancedCriteriaobj = new DocumentAdvancedCriteria();
                        documentAdvancedCriteriaobj.CompanyDocumentId = companyDocumentId;
                        documentAdvancedCriteriaobj.DocumentSendTypeId = SendTo;
                        documentAdvancedCriteriaobj.DocumentSendCriteriaId = documentSendCriteriaId;
                        documentAdvancedCriteriaobj.SelectedCriteriaListId = Convert.ToInt32(locationId);
                        bool storedCriteria = _documentAdvancedCriteriaRepository.CreateDocumentAdvancedCriteria(documentAdvancedCriteriaobj);
                    }
                }
            }
            if (departmentIdList != null)
            {
                foreach (var departmentId in departmentIdList.Split(','))
                {
                    var documentSendCriteriaId = (from x in criteriaList where x.DocumentSendCriteriaName == "Department" select x.DocumentSendCriteriaId).First();
                    employeeList = _registeredUsersRepository.SelectAllEmployeesByDepartment(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(departmentId));
                    if (employeeList.Count > 0)
                    {
                        companyDocumentFormModelobj.EmployeeByCriteriaList = employeeList;
                        //AddCompanyDocumentToEmployeeByCriteria(companyDocumentFormModelobj.EmployeeByList, companyDocumentId);

                        //Stores the Selected Criteria into DocumentAdvancedCriteria.
                        DocumentAdvancedCriteria documentAdvancedCriteriaobj = new DocumentAdvancedCriteria();
                        documentAdvancedCriteriaobj.CompanyDocumentId = companyDocumentId;
                        documentAdvancedCriteriaobj.DocumentSendTypeId = SendTo;
                        documentAdvancedCriteriaobj.DocumentSendCriteriaId = documentSendCriteriaId;
                        documentAdvancedCriteriaobj.SelectedCriteriaListId = Convert.ToInt32(departmentId);
                        bool storedCriteria = _documentAdvancedCriteriaRepository.CreateDocumentAdvancedCriteria(documentAdvancedCriteriaobj);
                    }
                }
            }
            if (employmentstatusIdList != null)
            {
                foreach (var employmentstatusId in employmentstatusIdList.Split(','))
                {
                    var documentSendCriteriaId = (from x in criteriaList where x.DocumentSendCriteriaName == "EmploymentStatus" select x.DocumentSendCriteriaId).First();
                    employeeList = _registeredUsersRepository.SelectAllEmployeesByEmploymentStatus(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(employmentstatusId));
                    if (employeeList.Count > 0)
                    {
                        companyDocumentFormModelobj.EmployeeByCriteriaList = employeeList;
                        //AddCompanyDocumentToEmployeeByCriteria(companyDocumentFormModelobj.EmployeeByList, companyDocumentId);

                        //Stores the Selected Criteria into DocumentAdvancedCriteria.
                        DocumentAdvancedCriteria documentAdvancedCriteriaobj = new DocumentAdvancedCriteria();
                        documentAdvancedCriteriaobj.CompanyDocumentId = companyDocumentId;
                        documentAdvancedCriteriaobj.DocumentSendTypeId = SendTo;
                        documentAdvancedCriteriaobj.DocumentSendCriteriaId = documentSendCriteriaId;
                        documentAdvancedCriteriaobj.SelectedCriteriaListId = Convert.ToInt32(employmentstatusId);
                        bool storedCriteria = _documentAdvancedCriteriaRepository.CreateDocumentAdvancedCriteria(documentAdvancedCriteriaobj);
                    }
                }
            }
            if (employmenttypeIdList != null)
            {
                foreach (var employmenttypeId in employmenttypeIdList.Split(','))
                {
                    var documentSendCriteriaId = (from x in criteriaList where x.DocumentSendCriteriaName == "EmploymentType" select x.DocumentSendCriteriaId).First();
                    employeeList = _registeredUsersRepository.SelectAllEmployeesByEmploymentType(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(employmenttypeId));
                    if (employeeList.Count > 0)
                    {
                        companyDocumentFormModelobj.EmployeeByCriteriaList = employeeList;
                        //AddCompanyDocumentToEmployeeByCriteria(companyDocumentFormModelobj.EmployeeByList, companyDocumentId);

                        //Stores the Selected Criteria into DocumentAdvancedCriteria.
                        DocumentAdvancedCriteria documentAdvancedCriteriaobj = new DocumentAdvancedCriteria();
                        documentAdvancedCriteriaobj.CompanyDocumentId = companyDocumentId;
                        documentAdvancedCriteriaobj.DocumentSendTypeId = SendTo;
                        documentAdvancedCriteriaobj.DocumentSendCriteriaId = documentSendCriteriaId;
                        documentAdvancedCriteriaobj.SelectedCriteriaListId = Convert.ToInt32(employmenttypeId);
                        bool storedCriteria = _documentAdvancedCriteriaRepository.CreateDocumentAdvancedCriteria(documentAdvancedCriteriaobj);
                    }
                }
            }

            //Code eliminate duplicate EmployeeIds when all the List values are selected
            var distinctList = employeeList.GroupBy(test => test.UserId).Select(group => group.First());
            companyDocumentFormModelobj.EmployeeByCriteriaList = distinctList.ToList();
            if (companyDocumentFormModelobj.EmployeeByCriteriaList != null)
            {
                AddCompanyDocumentToEmployeeByCriteria(companyDocumentFormModelobj.EmployeeByCriteriaList, companyDocumentId);
            }
        }
        #endregion


        #region File Handling
        /// <summary>
        /// Opens the File
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        //public FileResult OpenFile(int fileDBId)
        public void OpenFile(int fileDBId)
        {
            try
            {
                var filesDBList = new List<FilesDB>();
                filesDBList = _filesDBRepository.SelectFileByFileDBId(fileDBId);
                string fileName = filesDBList[0].FileName;
                byte[] fileBytes = filesDBList[0].FileBytes;
                string contentType = filesDBList[0].ContentType;

                Response.Buffer = true;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.ContentType = contentType;
                //Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(fileBytes);
                Response.End();

                //return File(new FileStream(fileName, FileMode.Open), "application/octetstream", fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the file
        /// </summary>
        /// <param name="fileDBId"></param>
        /// <returns></returns>
        [ActionName("DeleteFile")]
        public ActionResult DeleteFile(int? fileDBId)
        {
            bool deletefileStatus = _filesDBRepository.DeleteFileinFilesDB(Convert.ToInt32(fileDBId));
            //return deletefileStatus;
            return RedirectToAction("UpdateCompanyDocument");
        }
        #endregion
        [HttpGet]
        [ActionName("IsTitleExists")]
        public JsonResult IsTitleExists(CompanyDocumentFormModel companyDocumentFormModelObj)
        {
            companyDocumentFormModelObj.CompanyDocument.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var result = _companyDocumentRepository.IsTitleExists(companyDocumentFormModelObj.CompanyDocument);
            if (companyDocumentFormModelObj.CompanyDocument.CompanyDocumentId.Equals(0))
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}