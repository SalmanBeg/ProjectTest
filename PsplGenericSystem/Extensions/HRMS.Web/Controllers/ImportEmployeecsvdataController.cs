using HRMS.Web.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Web.Models;
using HRMS.Web.ViewModels;
using System.Data.OleDb;
using HRMS.Web.Helper;
using System.ComponentModel;
using HRMS.Common.Helpers;
using System.Collections;
using HRMS.Service.Interfaces;
using HRMS.Service.Repositories;
using HRMS.Service.Models.EDM;
using System.Web.UI;


namespace HRMS.Web.Controllers
{
    public class ImportEmployeecsvdataController : Controller
    {
        #region Class Level Variables and constructor


        private IImportEmployeecsvRepository _ImportEmployeecsvrepo = null;
        private IUtilityRepository _utilityRepo = null;
        private IUserRepository _UserRepositoryRepo = null;
        #endregion


        public ImportEmployeecsvdataController()
        {
            this._ImportEmployeecsvrepo = new ImportEmployeecsvRepository();
            this._utilityRepo = new UtilityRepository();
            this._UserRepositoryRepo = new UserRepository();
        }

        [ValidateFile]
        public ActionResult ImportEmployeeData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportEmployeeData(UploadFile uploadFileObj)
        {
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                if ((Request.Files.Count > 0) && (Request.Files[0].ContentLength > 0))
                {
                    string fileExtension = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    if (fileExtension == ".csv")
                    {
                        string fileLocation = string.Format("{0}/{1}", Server.MapPath("~/Content/Templates"),
                                                                                            Request.Files[0].FileName);
                        if (System.IO.File.Exists(fileLocation))
                            System.IO.File.Delete(fileLocation);
                        Request.Files[0].SaveAs(fileLocation);
                        // }
                        //string strFilePath = "";
                        StreamReader sr = new StreamReader(fileLocation);
                        string[] headers = sr.ReadLine().Split(',');

                        foreach (string header in headers)
                        {
                            dt.Columns.Add(header);
                        }
                        while (!sr.EndOfStream)
                        {
                            string[] rows = sr.ReadLine().Split(',');
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < headers.Length; i++)
                            {
                                dr[i] = rows[i];
                            }
                            dt.Rows.Add(dr);
                        }
                        sr.Dispose();
                        TempData["ImportData"] = dt;
                    }
                    else
                    {
                        //ModelState.AddModelError("File", "Invalid Imported file");
                       // ViewBag.validationmsg = "Invalid file to Imported";


                        ViewBag.message = @"<script type='text/javascript' language='javascript'>alert(""Invalid file to Imported"")</script>";
                     
                        // return View("ImportEmployeeData", "_MasterLayout");
                        return RedirectToAction("ImportEmployeeData", "ImportEmployeecsvdata");
                    }
                }
                return RedirectToAction("ViewEmployeeData");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //_oDatabaseHelper.Dispose();
            }
        }

        public ActionResult ViewEmployeeData()
        {

            try
            {
                List<ImportEmployeedata> lstUsers = new List<ImportEmployeedata>();
                ImportEmployeedata objUserModel = new ImportEmployeedata();

                string[] strFieldStructure = new[] {"UserName","First Name","Middle Name","Last Name","Suffix",	"Salutation","Street1","Street2","City","Country",
	            "State","Zip Code","Citizen Of","Home Email","Home Phone",	"Cell",	"SSN","Date of Birth","Gender","Status","Change Reason",
	            "Position","Job Title",	"Cost Center1","Cost Center2","Cost Center3","Cost Center4","Cost Center5",	"Job Code",	"Job Class",
	            "Compensation","Per","Rate Effective Date","Payroll Group","FLSA Status","Marital Status","Employee ID",
	            "Work Phone","Work Email","Hire Date","PayrollEEID","Federal Tax Status","Federal Tax Exemptions","State Tax Exemptions",
	            "State Tax Additional Withholding","Live in Country","Live in State","Work in Country","Work in State",	
	            "Pay Period","Type","WC Job Class Code","WC status","WC Type"};
                string ErroMessage = string.Empty;
                var lstlookup = new List<LookUpDataEntity>();
                var UserLoginlookup = new List<UserLoginModel>();
                lstlookup = _utilityRepo.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                if (TempData["ImportData"] != null)
                {
                    var records = TempData["ImportData"];
                    DataTable dt = new DataTable();
                    dt = ((System.Data.DataTable)(records));
                    //var duplicateValues = dt.AsEnumerable()
                    //   .GroupBy(row => row["UserName"])
                    //   .Where(group => group.Count() > 1)
                    //   .Select(g => g.Key);
                    if (dt.Columns.Count != 54)
                    {
                        //ModelState.AddModelError("Columns", "Please upload valid file,uploaded file columns are not mapped with template.");
                        ViewBag.validationmsg = "Please upload valid file,uploaded file columns are not mapped with template";
                        return View(lstUsers);
                    }
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        if (dt.Columns[col].ToString().Trim() != strFieldStructure[col].ToString().Trim())
                        {
                            ErroMessage += "  " + strFieldStructure[col];
                        }
                    }

                    if (!string.IsNullOrEmpty(ErroMessage))
                    {
                        //  ModelState.AddModelError("File", "Imported file does not contain fields like" + ErroMessage);
                        ViewBag.validationmsg = "Imported file does not contain fields like" + ErroMessage;
                        return View(lstUsers);
                    }

                    #region looping the data into object variables

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                ImportEmployeedata objUserModelobj = new ImportEmployeedata();
                                string username = dt.Rows[i]["UserName"] != DBNull.Value ? dt.Rows[i]["UserName"].ToString().Length > 30 ? dt.Rows[i]["UserName"].ToString().Substring(0, 30) : dt.Rows[i]["UserName"].ToString() : "";
                                UserLoginlookup = _UserRepositoryRepo.SelectAllUserList(username);

                                if (UserLoginlookup.Count == 0)
                                {
                                    objUserModelobj.ImportTag = "New Record";
                                }
                                else
                                {
                                    objUserModelobj.ImportTag = "Existing User";
                                }
                                DateTime birthDate;
                                DateTime tHireDate;
                                DateTime RateEffectiveDate;
                                objUserModelobj.CompanyId = GlobalsVariables.CurrentCompanyId;
                                objUserModelobj.UserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                                //objUserModelobj.EmploymentDetailId = i;   // This is Refrence for row id ,  temporarly assigned to  "EmploymentDetailId" field not for saving.
                                objUserModelobj.UserName = dt.Rows[i]["UserName"] != DBNull.Value ? dt.Rows[i]["UserName"].ToString().Length > 30 ? dt.Rows[i]["UserName"].ToString().Substring(0, 30) : dt.Rows[i]["UserName"].ToString() : "";
                                objUserModelobj.FirstName = dt.Rows[i]["First Name"] != DBNull.Value ? dt.Rows[i]["First Name"].ToString().Length > 30 ? dt.Rows[i]["First Name"].ToString().Substring(0, 30) : dt.Rows[i]["First Name"].ToString() : "";
                                objUserModelobj.MiddleName = dt.Rows[i]["Middle Name"] != DBNull.Value ? dt.Rows[i]["Middle Name"].ToString().Length > 30 ? dt.Rows[i]["Middle Name"].ToString().Substring(0, 30) : dt.Rows[i]["Middle Name"].ToString() : "";
                                objUserModelobj.LastName = dt.Rows[i]["Last Name"] != DBNull.Value ? dt.Rows[i]["Last Name"].ToString().Length > 30 ? dt.Rows[i]["Last Name"].ToString().Substring(0, 30) : dt.Rows[i]["Last Name"].ToString() : "";
                                // objUserModelobj.Suffix = dt.Rows[i]["Suffix"] != DBNull.Value ? dt.Rows[i]["Suffix"].ToString() : "";  
                                objUserModelobj.Salutation = dt.Rows[i]["Salutation"] != DBNull.Value ? dt.Rows[i]["Salutation"].ToString() : "";
                                objUserModelobj.Address1 = dt.Rows[i]["Street1"] != DBNull.Value ? dt.Rows[i]["Street1"].ToString() : "";
                                objUserModelobj.Address2 = dt.Rows[i]["Street2"] != DBNull.Value ? dt.Rows[i]["Street2"].ToString() : "";
                                objUserModelobj.City = dt.Rows[i]["City"] != DBNull.Value ? dt.Rows[i]["City"].ToString() : "";
                                objUserModelobj.ZIP = dt.Rows[i]["Zip Code"] != DBNull.Value ? dt.Rows[i]["Zip Code"].ToString() : "";
                                objUserModelobj.HomeEmail = dt.Rows[i]["Home Email"] != DBNull.Value ? dt.Rows[i]["Home Email"].ToString() : "";
                                objUserModelobj.HomePhone = dt.Rows[i]["Home Phone"] != DBNull.Value ? dt.Rows[i]["Home Phone"].ToString() : "";
                                objUserModelobj.WorkPhone = dt.Rows[i]["Work Phone"] != DBNull.Value ? dt.Rows[i]["Work Phone"].ToString() : "";
                                objUserModelobj.SSN = dt.Rows[i]["SSN"] != DBNull.Value ? dt.Rows[i]["SSN"].ToString() : "";
                                if (dt.Rows[i]["Date of Birth"] != DBNull.Value && DateTime.TryParse(dt.Rows[i]["Date of Birth"].ToString(), out birthDate))
                                    objUserModelobj.BirthDate = Convert.ToDateTime(dt.Rows[i]["Date of Birth"]);
                                objUserModelobj.Status = dt.Rows[i]["Status"] != DBNull.Value ? dt.Rows[i]["Status"].ToString() : "";
                                objUserModelobj.WorkPhone = dt.Rows[i]["Work Phone"] != DBNull.Value ? dt.Rows[i]["Work Phone"].ToString() : "";
                                objUserModelobj.WorkEmail = dt.Rows[i]["Work Email"] != DBNull.Value ? dt.Rows[i]["Work Email"].ToString() : "";
                                if (dt.Rows[i]["Hire Date"] != DBNull.Value && DateTime.TryParse(dt.Rows[i]["Hire Date"].ToString(), out tHireDate))
                                    objUserModelobj.HireDate = Convert.ToDateTime(dt.Rows[i]["Hire Date"]);
                                objUserModelobj.WCJobClassCode = !string.IsNullOrEmpty(dt.Rows[i]["WC Job Class Code"].ToString()) ? Convert.ToInt32(dt.Rows[i]["WC Job Class Code"]) : 0;
                                objUserModelobj.WCStatus = !string.IsNullOrEmpty(dt.Rows[i]["WC status"].ToString()) ? Convert.ToInt32(dt.Rows[i]["WC status"]) : 0;
                                objUserModelobj.WCType = !string.IsNullOrEmpty(dt.Rows[i]["WC Type"].ToString()) ? Convert.ToInt32(dt.Rows[i]["WC Type"]) : 0;

                                #region objUserModelobj lists
                                objUserModelobj.ChangeReasonList = lstlookup.Where(j => j.TableName == "Utility.ChangeReason").ToList();
                                objUserModelobj.EmploymentStatusList = lstlookup.Where(j => j.TableName == "Utility.EmploymentStatus").ToList();
                                objUserModelobj.EmploymentTypeList = lstlookup.Where(j => j.TableName == "Utility.EmploymentTypes").ToList();
                                objUserModelobj.LocationList = lstlookup.Where(j => j.TableName == "Utility.Location").ToList();
                                objUserModelobj.PositionList = lstlookup.Where(j => j.TableName == "Utility.Position").ToList();
                                objUserModelobj.JobProfileList = lstlookup.Where(j => j.TableName == "Utility.JobProfile").ToList();
                                objUserModelobj.TerminationReasonList = lstlookup.Where(j => j.TableName == "Utility.TerminationReason").ToList();
                                objUserModelobj.DivisionList = lstlookup.Where(j => j.TableName == "Utility.Division").ToList();
                                objUserModelobj.DepartmentList = lstlookup.Where(j => j.TableName == "Utility.Department").ToList();
                                objUserModelobj.FLSAStatusList = lstlookup.Where(j => j.TableName == "Utility.FLSAStatus").ToList();
                                objUserModelobj.UnionList = lstlookup.Where(j => j.TableName == "Utility.UnionType").ToList();
                                objUserModelobj.GenderList = lstlookup.Where(j => j.TableName == "Utility.Gender").ToList();
                                objUserModelobj.MaritalStatusList = lstlookup.Where(j => j.TableName == "Utility.MaritalStatus").ToList();
                                objUserModelobj.SalutationList = lstlookup.Where(j => j.TableName == "Utility.Salutation").ToList();
                                objUserModelobj.SuffixList = lstlookup.Where(j => j.TableName == "Utility.Suffix").ToList();
                                objUserModelobj.JobProfileList = lstlookup.Where(j => j.TableName == "Utility.JobProfile").ToList();
                                objUserModelobj.CountryList = _utilityRepo.GetCountry();

                                if (!string.IsNullOrEmpty(dt.Rows[i]["Country"].ToString()) && objUserModelobj.CountryList.Find(g => g.Name == dt.Rows[i]["Country"].ToString()) != null)
                                {
                                    objUserModelobj.Country = dt.Rows[i]["Country"].ToString();
                                    objUserModelobj.CountryId = objUserModelobj.CountryList.Find(g => g.Name == dt.Rows[i]["Country"].ToString()).CountryRegionID;

                                    if (objUserModelobj.CountryId != 0)
                                        objUserModelobj.StateList = _utilityRepo.GetState(Convert.ToInt32(objUserModelobj.CountryId));
                                    else
                                        objUserModelobj.StateList = _utilityRepo.GetState1();
                                }
                                else
                                {
                                    objUserModelobj.Country = dt.Rows[i]["Country"] != DBNull.Value ? dt.Rows[i]["Country"].ToString() : "";
                                    objUserModelobj.StateList = _utilityRepo.GetState1();
                                }

                                if (!string.IsNullOrEmpty(dt.Rows[i]["Suffix"].ToString()) && objUserModelobj.SuffixList.Find(g => g.Name == dt.Rows[i]["Suffix"].ToString()) != null)
                                {
                                    objUserModelobj.Suffix = dt.Rows[i]["Suffix"].ToString();
                                    objUserModelobj.Suffixid = Convert.ToInt32(objUserModelobj.SuffixList.Find(g => g.Name == dt.Rows[i]["Suffix"].ToString()).Id);
                                }
                                else
                                {
                                    objUserModelobj.Suffix = dt.Rows[i]["Suffix"] != DBNull.Value ? dt.Rows[i]["Suffix"].ToString() : "";
                                }

                                if (!string.IsNullOrEmpty(dt.Rows[i]["State"].ToString()) && objUserModelobj.StateList.Find(g => g.Name == dt.Rows[i]["State"].ToString()) != null)
                                {
                                    objUserModelobj.State = dt.Rows[i]["State"].ToString();
                                    objUserModelobj.StateId = objUserModelobj.StateList.Find(g => g.Name == dt.Rows[i]["State"].ToString()).StateProvinceID;
                                }
                                else
                                {
                                    objUserModelobj.Country = dt.Rows[i]["State"] != DBNull.Value ? dt.Rows[i]["State"].ToString() : "";
                                }

                                if (!string.IsNullOrEmpty(dt.Rows[i]["Gender"].ToString()) && objUserModelobj.GenderList.Find(g => g.Name == dt.Rows[i]["Gender"].ToString()) != null)
                                {
                                    objUserModelobj.TGender = dt.Rows[i]["Gender"].ToString();
                                    objUserModelobj.Gender = Convert.ToInt32(objUserModelobj.GenderList.Find(g => g.Name == dt.Rows[i]["Gender"].ToString()).Id);
                                }
                                else
                                {
                                    objUserModelobj.TGender = dt.Rows[i]["Gender"] != DBNull.Value ? dt.Rows[i]["Gender"].ToString() : "";
                                }

                                if (!string.IsNullOrEmpty(dt.Rows[i]["Change Reason"].ToString()) && objUserModelobj.ChangeReasonList.Find(g => g.Name == dt.Rows[i]["Change Reason"].ToString()) != null)
                                {
                                    objUserModelobj.TChangeReason = dt.Rows[i]["Change Reason"].ToString();
                                    objUserModelobj.ChangeReason = objUserModelobj.ChangeReasonList.Find(g => g.Name == dt.Rows[i]["Change Reason"].ToString()).Id;
                                }
                                else
                                {
                                    objUserModelobj.TChangeReason = dt.Rows[i]["Change Reason"] != DBNull.Value ? dt.Rows[i]["Change Reason"].ToString() : "";
                                }

                                //if (!string.IsNullOrEmpty(dt.Rows[i]["Position"].ToString()))
                                if (!string.IsNullOrEmpty(dt.Rows[i]["Position"].ToString()) && objUserModelobj.PositionList.Find(g => g.Name == dt.Rows[i]["Position"].ToString()) != null)
                                {
                                    objUserModelobj.TPosition = dt.Rows[i]["Position"].ToString();
                                    objUserModelobj.Position = objUserModelobj.PositionList.Find(g => g.Name == dt.Rows[i]["Position"].ToString()).Id;
                                }
                                else
                                {
                                    objUserModelobj.TChangeReason = dt.Rows[i]["Position"] != DBNull.Value ? dt.Rows[i]["Position"].ToString() : "";
                                }
                                if (!string.IsNullOrEmpty(dt.Rows[i]["Job Title"].ToString()) && objUserModelobj.JobProfileList.Find(g => g.Name == dt.Rows[i]["Job Title"].ToString()) != null)
                                {
                                    objUserModelobj.TJobProfile = dt.Rows[i]["Job Title"].ToString();
                                    objUserModelobj.JobProfile = Convert.ToInt32(objUserModelobj.JobProfileList.Find(g => g.Name == dt.Rows[i]["Job Title"].ToString()).Id);
                                }
                                else
                                {
                                    objUserModelobj.TJobProfile = dt.Rows[i]["Job Title"] != DBNull.Value ? dt.Rows[i]["Job Title"].ToString() : "";
                                }

                                if (!string.IsNullOrEmpty(dt.Rows[i]["FLSA Status"].ToString()) && objUserModelobj.FLSAStatusList.Find(g => g.Name == dt.Rows[i]["FLSA Status"].ToString()) != null)
                                {
                                    objUserModelobj.TFLSAStatus = dt.Rows[i]["FLSA Status"].ToString();
                                    objUserModelobj.FLSAStatus = objUserModelobj.FLSAStatusList.Find(g => g.Name == dt.Rows[i]["FLSA Status"].ToString()).Id;
                                }
                                else
                                {
                                    objUserModelobj.TFLSAStatus = dt.Rows[i]["FLSA Status"] != DBNull.Value ? dt.Rows[i]["FLSA Status"].ToString() : " ";
                                }
                                if (!string.IsNullOrEmpty(dt.Rows[i]["Marital Status"].ToString()) && objUserModelobj.MaritalStatusList.Find(g => g.Name == dt.Rows[i]["Marital Status"].ToString()) != null)
                                {
                                    objUserModelobj.TMaritalStatus = dt.Rows[i]["Marital Status"].ToString();
                                    objUserModelobj.MaritalStatus = objUserModelobj.MaritalStatusList.Find(g => g.Name == dt.Rows[i]["Marital Status"].ToString()).Id;
                                }
                                else
                                {
                                    objUserModelobj.TMaritalStatus = dt.Rows[i]["Marital Status"] != DBNull.Value ? dt.Rows[i]["Marital Status"].ToString() : "";
                                }
                                #endregion
                                lstUsers.Add(objUserModelobj);
                                // }


                            }
                        }
                    }
                    else
                    {
                        //ModelState.AddModelError("File", "No data found");
                        ViewBag.validationmsg = "No data found";
                    }
                    return View(lstUsers);
                }
                return View(lstUsers);
            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                //_oDatabaseHelper.Dispose();
            }
                    #endregion



        }

        [HttpPost]
        public ActionResult ViewEmployeeData(List<ImportEmployeedata> importdataobj)
        {
            try
            {

                var lstlookup = new List<LookUpDataEntity>();
                var UserLoginlookup = new List<UserLoginModel>();
                lstlookup = _utilityRepo.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

                bool success = false;
                if (importdataobj != null)
                {
                    DataTable dt = new DataTable();
                    dt = Createtable();
                    DataTable dtDuplicate = new DataTable();
                    dtDuplicate = dt.Clone();

                    for (int i = 0; i < importdataobj.Count; i++)
                    {

                        //if (importdataobj[i].DeleteCheckstatus == true)
                        //{
                        //    importdataobj.RemoveAt(0);
                        //    return View(importdataobj);
                        //}
                        Guid ImportTag = Guid.NewGuid();
                        var passwordgenerator = new RandomStringGenerator();
                        string password = passwordgenerator.Generate("LlnlnLlL");
                        var row = dt.NewRow();

                        if (importdataobj[i].ImportTag.Trim() != "Existing User")
                        {
                            #region storing new recod values into data table
                            row["RowID"] = i + 1;
                            row["UserName"] = importdataobj[i].UserName;
                            row["Userid"] = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                            row["CompanyID"] = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                            row["EmployeeNo"] = importdataobj[i].EmployeeNo;
                            row["Salutation"] = importdataobj[i].Salutation;
                            row["FirstName"] = importdataobj[i].FirstName;
                            row["MiddleName"] = importdataobj[i].MiddleName;
                            row["LastName"] = importdataobj[i].LastName;
                            row["Suffix"] = importdataobj[i].Suffix;
                            row["WorkEmail"] = importdataobj[i].HomeEmail;
                            row["Address1"] = importdataobj[i].Address1;
                            row["Address2"] = importdataobj[i].Address2;
                            row["City"] = importdataobj[i].City != string.Empty ? importdataobj[i].City : "";
                            row["ZIP"] = importdataobj[i].ZIP;
                            row["Countryid"] = importdataobj[i].CountryId;
                            row["State"] = importdataobj[i].StateId;
                            row["SSN"] = importdataobj[i].SSN;
                            row["WorkPhone1"] = importdataobj[i].WorkPhone;
                            row["HomePhone"] = importdataobj[i].HomePhone;
                            row["BirthDate"] = Convert.ToDateTime(importdataobj[i].BirthDate);
                            row["Gender"] = importdataobj[i].Gender;
                            row["MaritalStatus"] = importdataobj[i].MaritalStatus;
                            row["ChangeReason"] = importdataobj[i].ChangeReason;
                            row["HireDate"] = importdataobj[i].HireDate == null ? null : importdataobj[i].HireDate;
                            row["OriginalHireDate"] = importdataobj[i].OriginalHireDate == null ? null : importdataobj[i].OriginalHireDate;
                            row["TerminationDate"] = importdataobj[i].TerminationDate == null ? null : importdataobj[i].TerminationDate;
                            row["TerminationReason"] = importdataobj[i].TerminationReason;
                            row["WorkPhone"] = importdataobj[i].WorkPhone;
                            row["HomeEmail"] = importdataobj[i].HomeEmail;
                            row["StartDate"] = importdataobj[i].StartDate == null ? null : importdataobj[i].StartDate;
                            row["SeniorityDate"] = importdataobj[i].SeniorityDate == null ? null : importdataobj[i].SeniorityDate;
                            row["LastPaidDate"] = importdataobj[i].LastPaidDate == null ? null : importdataobj[i].LastPaidDate;
                            row["LastPayRise"] = importdataobj[i].LastPayRise == null ? null : importdataobj[i].LastPayRise;
                            row["LastPromotionDate"] = importdataobj[i].LastPromotionDate == null ? null : importdataobj[i].LastPromotionDate;
                            row["LastReviewDate"] = importdataobj[i].LastReviewDate == null ? null : importdataobj[i].LastReviewDate;
                            row["NextReviewDate"] = importdataobj[i].NextReviewDate == null ? null : importdataobj[i].NextReviewDate;
                            row["NewHireReportDate"] = importdataobj[i].NewHireReportDate == null ? null : importdataobj[i].NewHireReportDate;
                            row["EmploymentStatus"] = importdataobj[i].EmploymentStatus;
                            row["JobProfileid"] = importdataobj[i].JobProfile;
                            row["Positionid"] = importdataobj[i].Position;
                            row["PayGroup"] = importdataobj[i].PayGroup;
                            row["Locationid"] = importdataobj[i].Location;
                            row["Divisionid"] = importdataobj[i].Division;
                            row["Departmentid"] = importdataobj[i].Department;
                            row["Managerid"] = importdataobj[i].Manager;
                            row["EmploymentType"] = importdataobj[i].EmploymentType;
                            row["ComplianceCode"] = importdataobj[i].ComplianceCode;
                            row["BenefitClass"] = importdataobj[i].BenefitClass;
                            row["FLSAStatus"] = importdataobj[i].FLSAStatus;
                            row["Union"] = importdataobj[i].Union;
                            row["DistrictCode"] = importdataobj[i].DistrictCode;
                            row["CheckDistribution"] = importdataobj[i].CheckDistribution;
                            row["DirectDepositEmail"] = importdataobj[i].DirectDepositEmail;
                            row["OkToRehire"] = importdataobj[i].OkToRehire;
                            row["WCJobClassCode"] = importdataobj[i].WCJobClassCode;
                            row["WCStatus"] = importdataobj[i].WCStatus;
                            row["WCType"] = importdataobj[i].WCType;
                            row["ImportTag"] = ImportTag.ToString();
                            row["Password"] = Encryption.Encrypt(password);
                            //row["CompanyId"] = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);

                            #endregion
                            dt.Rows.Add(row);
                            //success = _ImportEmployeecsvrepo.InsertImportdata(dt);    // Commented on 22nd Sep 14
                        }
                        else
                        {
                            #region Storing duplicate values in datatable
                            var row1 = dtDuplicate.NewRow();
                            row1["UserName"] = importdataobj[i].UserName;
                            row1["Userid"] = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                            row1["CompanyID"] = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                            row1["EmployeeNo"] = importdataobj[i].EmployeeNo;
                            row1["Salutation"] = importdataobj[i].Salutation;
                            row1["FirstName"] = importdataobj[i].FirstName;
                            row1["MiddleName"] = importdataobj[i].MiddleName;
                            row1["LastName"] = importdataobj[i].LastName;
                            row1["Suffix"] = importdataobj[i].Suffix;
                            row1["WorkEmail"] = importdataobj[i].HomeEmail;
                            row1["Address1"] = importdataobj[i].Address1;
                            row1["Address2"] = importdataobj[i].Address2;
                            row1["City"] = importdataobj[i].City != string.Empty ? importdataobj[i].City : "";
                            row1["ZIP"] = importdataobj[i].ZIP;
                            row1["Countryid"] = importdataobj[i].CountryId;
                            row1["State"] = importdataobj[i].StateId;
                            row1["SSN"] = importdataobj[i].SSN;
                            row1["WorkPhone1"] = importdataobj[i].WorkPhone;
                            row1["HomePhone"] = importdataobj[i].HomePhone;
                            row1["BirthDate"] = Convert.ToDateTime(importdataobj[i].BirthDate);
                            row1["Gender"] = importdataobj[i].Gender;
                            row1["MaritalStatus"] = importdataobj[i].MaritalStatus;
                            //row["HomeEmail"] = importdataobj[i].HomeEmail;
                            row1["ChangeReason"] = importdataobj[i].ChangeReason;
                            row1["HireDate"] = importdataobj[i].HireDate == null ? null : importdataobj[i].HireDate;
                            row1["OriginalHireDate"] = importdataobj[i].OriginalHireDate == null ? null : importdataobj[i].OriginalHireDate;
                            row1["TerminationDate"] = importdataobj[i].TerminationDate == null ? null : importdataobj[i].TerminationDate;
                            row1["TerminationReason"] = importdataobj[i].TerminationReason;
                            row1["WorkPhone"] = importdataobj[i].WorkPhone;
                            row1["HomeEmail"] = importdataobj[i].HomeEmail;
                            //row["StartDate"] = Convert.ToDateTime(importdataobj[i].StartDate);

                            row1["StartDate"] = importdataobj[i].StartDate == null ? null : importdataobj[i].StartDate;
                            row1["SeniorityDate"] = importdataobj[i].SeniorityDate == null ? null : importdataobj[i].SeniorityDate;
                            row1["LastPaidDate"] = importdataobj[i].LastPaidDate == null ? null : importdataobj[i].LastPaidDate;
                            row1["LastPayRise"] = importdataobj[i].LastPayRise == null ? null : importdataobj[i].LastPayRise;
                            row1["LastPromotionDate"] = importdataobj[i].LastPromotionDate == null ? null : importdataobj[i].LastPromotionDate;
                            row1["LastReviewDate"] = importdataobj[i].LastReviewDate == null ? null : importdataobj[i].LastReviewDate;
                            row1["NextReviewDate"] = importdataobj[i].NextReviewDate == null ? null : importdataobj[i].NextReviewDate;
                            row1["NewHireReportDate"] = importdataobj[i].NewHireReportDate == null ? null : importdataobj[i].NewHireReportDate;

                            row1["EmploymentStatus"] = importdataobj[i].EmploymentStatus;
                            row1["JobProfileid"] = importdataobj[i].JobProfile;
                            row1["Positionid"] = importdataobj[i].Position;
                            row1["PayGroup"] = importdataobj[i].PayGroup;

                            row1["Locationid"] = importdataobj[i].Location;
                            row1["Divisionid"] = importdataobj[i].Division;
                            row1["Departmentid"] = importdataobj[i].Department;
                            row1["Managerid"] = importdataobj[i].Manager;

                            row1["EmploymentType"] = importdataobj[i].EmploymentType;
                            row1["ComplianceCode"] = importdataobj[i].ComplianceCode;
                            row1["BenefitClass"] = importdataobj[i].BenefitClass;
                            row1["FLSAStatus"] = importdataobj[i].FLSAStatus;
                            row1["Union"] = importdataobj[i].Union;
                            row1["DistrictCode"] = importdataobj[i].DistrictCode;
                            row1["CheckDistribution"] = importdataobj[i].CheckDistribution;
                            row1["DirectDepositEmail"] = importdataobj[i].DirectDepositEmail;
                            row1["OkToRehire"] = importdataobj[i].OkToRehire;
                            row1["WCJobClassCode"] = importdataobj[i].WCJobClassCode;
                            row1["WCStatus"] = importdataobj[i].WCStatus;
                            row1["WCType"] = importdataobj[i].WCType;
                            //row["CreatedOn"] = DateTime.Now;
                            row1["ImportTag"] = ImportTag.ToString();
                            row1["Password"] = Encryption.Encrypt(password);
                            row1["CompanyId"] = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);


                            dtDuplicate.Rows.Add(row1);
                            #endregion
                        }

                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        success = _ImportEmployeecsvrepo.InsertCSVFileData(dt);
                    }
                    //return View("ResultEmployeeData");
                    //success = _ImportEmployeecsvrepo.Insertcsvfiledata(dt);    // Commented on 22nd Sep 14
                    if (dtDuplicate.Rows.Count > 0)
                    {
                        // return RedirectToAction("ImportEmployeeData", "ImportEmployeeData");
                        ViewBag.Message = "Existing Records are not inserted";
                        //ViewBag.validationmsg = "Existing Users are not inserted";                
                        return View(importdataobj);
                    }
                    else
                    {
                        return View("ImportemployeeData");
                    }
                }
                else
                {
                    ViewBag.validationmsg = "There is no data to Import";
                    return View(importdataobj);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //_oDatabaseHelper.Dispose();
            }
        }

        private DataTable Createtable()
        {
            #region Creating Table Headers
            DataTable dt = new DataTable();
            dt.Columns.Add("RowID");
            dt.Columns.Add("UserName");
            dt.Columns.Add("Userid");
            dt.Columns.Add("CompanyID");
            dt.Columns.Add("EmployeeNo");
            dt.Columns.Add("Salutation");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("MiddleName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Suffix");
            dt.Columns.Add("HomeEmail");
            dt.Columns.Add("Address1");
            dt.Columns.Add("Address2");
            dt.Columns.Add("City");
            dt.Columns.Add("ZIP");
            dt.Columns.Add("Countryid");
            dt.Columns.Add("State");
            dt.Columns.Add("SSN");
            dt.Columns.Add("WorkPhone1");
            dt.Columns.Add("HomePhone");
            dt.Columns.Add("BirthDate");
            dt.Columns.Add("Gender");
            dt.Columns.Add("MaritalStatus");
            // dt.Columns.Add("HomeEmail");
            dt.Columns.Add("ChangeReason");
            dt.Columns.Add("HireDate");
            dt.Columns.Add("OriginalHireDate");
            dt.Columns.Add("TerminationDate");
            dt.Columns.Add("TerminationReason");
            dt.Columns.Add("WorkPhone");
            dt.Columns.Add("WorkEmail");
            dt.Columns.Add("StartDate");
            dt.Columns.Add("SeniorityDate");
            dt.Columns.Add("LastPaidDate");
            dt.Columns.Add("LastPayRise");
            dt.Columns.Add("LastPromotionDate");
            dt.Columns.Add("LastReviewDate");
            dt.Columns.Add("NextReviewDate");
            dt.Columns.Add("NewHireReportDate");
            dt.Columns.Add("EmploymentStatus");
            dt.Columns.Add("JobProfileid");
            dt.Columns.Add("Positionid");
            dt.Columns.Add("PayGroup");
            dt.Columns.Add("Locationid");
            dt.Columns.Add("Divisionid");
            dt.Columns.Add("Departmentid");
            dt.Columns.Add("Managerid");
            dt.Columns.Add("EmploymentType");
            dt.Columns.Add("ComplianceCode");
            dt.Columns.Add("BenefitClass");
            dt.Columns.Add("FLSAStatus");
            dt.Columns.Add("Union");
            dt.Columns.Add("DistrictCode");
            dt.Columns.Add("CheckDistribution");
            dt.Columns.Add("DirectDepositEmail");
            dt.Columns.Add("OkToRehire");
            dt.Columns.Add("WCJobClassCode");
            dt.Columns.Add("WCStatus");
            dt.Columns.Add("WCType");
            //dt.Columns.Add("CreatedOn");
            dt.Columns.Add("ImportTag");
            dt.Columns.Add("Password");
            //dt.Columns.Add("CompanyId");

            //
            dt.Columns.Add("Batchkey");

            //
            return dt;
            #endregion
        }
    }
}
