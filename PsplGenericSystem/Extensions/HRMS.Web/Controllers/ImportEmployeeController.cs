using HRMS.Service.Models.ExtendedModels;
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



namespace HRMS.Web.Controllers
{
    public class ImportEmployeeController : Controller
    {
        //
        // GET: /ImportEmployeedata/

        [ValidateFile]
        public ActionResult ImportEmployeeData()
        {
            return View();
        }

        public ActionResult ViewEmployeeData1(UploadFile xls)
        { 
            if ((Request.Files.Count > 0) && (Request.Files[0].ContentLength > 0))
            {
                //if (ModelState.IsValid)
                //{
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();                   
                    // List<  Country> Countries = this.CountryRepository.GetCountriesDetails(100, 0).ToList();

                    string[] strFieldStructure = new[] {"First Name", "Middle Name", "Last Name" ,"Birth Date",
                                                         "Gender", "Street1","Street2", "City","CountryId","StateId","Zip","HomeEmail","HomePhone","CellPhone", "SSN"                                                        
                                                       };   
                    string fileExtension = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        string fileLocation = string.Format("{0}/{1}", Server.MapPath("~/Content/Templates/"),
                                                                                            Request.Files[0].FileName);
                        if (System.IO.File.Exists(fileLocation))
                            System.IO.File.Delete(fileLocation);
                        Request.Files[0].SaveAs(fileLocation);
                        string excelConnectionString = string.Empty;

                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        //connection String for xls file format.
                        if (fileExtension == ".xls")
                        {
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        }
                        //connection String for xlsx file format.
                        else if (fileExtension == ".xlsx")
                        {
                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        }
                        //Create Connection to Excel work book and add oledb namespace
                        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                        excelConnection.Open();
                        dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        if (dt == null)
                        {
                            return null;
                        }
                        String[] excelSheets = new String[dt.Rows.Count];
                        int t = 0;
                        //excel data saves in temp file here.
                        foreach (DataRow row in dt.Rows)
                        {
                            excelSheets[t] = row["TABLE_NAME"].ToString();
                            t++;
                        }
                        OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);
                        string query = string.Format("Select * from [{0}]", excelSheets[0]);
                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                        {
                            dataAdapter.Fill(ds);
                        }
                        excelConnection.Close();
                    }
                    DataTable dtImport = new DataTable();
                    dtImport = ds.Tables[0].Clone();
                    string ErroMessage = string.Empty;
                    //if (dtImport.Columns.Count != 16 ) //54)
                    //{
                    //    ModelState.AddModelError("Columns", "Please upload valid file,uploaded file columns are not mapped with template.");
                    //}
                    //for (int col = 0; col < dtImport.Columns.Count; col++)
                    //{
                    //    if (!dtImport.Columns[col].ToString().Equals(strFieldStructure[col].ToString()))
                    //        ErroMessage += "  " + strFieldStructure[col];
                    //}

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (row.ItemArray.Where(g => g == DBNull.Value).Count() != dtImport.Columns.Count)
                            dtImport.Rows.Add(row.ItemArray);
                    }

                    if (!string.IsNullOrEmpty(ErroMessage))
                        ModelState.AddModelError("File", "Imported file does not contain fields like" + ErroMessage);
                    else if (dtImport.Rows.Count == 0)
                        ModelState.AddModelError("File", "Imported file does not contain record's to import");
                    //if (ModelState.IsValid)
                    //{                      
                        List<ImportEmployeeFormModel> lstUsers = new List<ImportEmployeeFormModel>();
                        if (fileExtension == ".xls" || fileExtension == ".xlsx")
                        {
                            // Create a folder in App_Data named ExcelFiles because you need to save the file temporarily location and getting data from there. 
                            string fileLocation = string.Format("{0}/{1}", Server.MapPath("~/Content/Files"),
                                                                                               Request.Files[0].FileName);
                            for (int i = 0; i < dtImport.Rows.Count; i++)
                            {
                                DateTime birthDate;
                                DateTime hireDate;
                               
                                ImportEmployeeFormModel objUserModel = new ImportEmployeeFormModel();                              
                                objUserModel.Employee.FirstName  = ds.Tables[0].Rows[i]["First Name"] != DBNull.Value ? ds.Tables[0].Rows[i]["First Name"].ToString().Length > 30 ? ds.Tables[0].Rows[i]["First Name"].ToString().Substring(0, 30) : ds.Tables[0].Rows[i]["First Name"].ToString() : "";
                                objUserModel.Employee.MiddleName = ds.Tables[0].Rows[i]["Middle Name"] != DBNull.Value ? ds.Tables[0].Rows[i]["Middle Name"].ToString().Length > 30 ? ds.Tables[0].Rows[i]["Middle Name"].ToString().Substring(0, 30) : ds.Tables[0].Rows[i]["Middle Name"].ToString() : "";
                                objUserModel.Employee.LastName = ds.Tables[0].Rows[i]["Last Name"] != DBNull.Value ? ds.Tables[0].Rows[i]["Last Name"].ToString().Length > 30 ? ds.Tables[0].Rows[i]["Last Name"].ToString().Substring(0, 30) : ds.Tables[0].Rows[i]["Last Name"].ToString() : "";

                                if (ds.Tables[0].Rows[i]["Date of Birth"] != DBNull.Value && DateTime.TryParse(ds.Tables[0].Rows[i]["Date of Birth"].ToString(), out birthDate))
                                    objUserModel.Employee.BirthDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Birth"]);
                                //if (ds.Tables[0].Rows[i]["Hire Date"] != DBNull.Value && DateTime.TryParse(ds.Tables[0].Rows[i]["Hire Date"].ToString(), out hireDate))
                                //    objUserModel.EmployeeDependentDetail.NewHireDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Hire Date"]);


                                objUserModel.Employee.Address1 = ds.Tables[0].Rows[i]["Street1"] != DBNull.Value ? ds.Tables[0].Rows[i]["Street1"].ToString().Length > 100 ? ds.Tables[0].Rows[i]["Street1"].ToString().Substring(0, 100) : ds.Tables[0].Rows[i]["Street1"].ToString() : "";
                                objUserModel.Employee.Address2 = ds.Tables[0].Rows[i]["Street2"] != DBNull.Value ? ds.Tables[0].Rows[i]["Street2"].ToString().Length > 100 ? ds.Tables[0].Rows[i]["Street2"].ToString().Substring(0, 100) : ds.Tables[0].Rows[i]["Street2"].ToString() : "";
                                objUserModel.Employee.City = ds.Tables[0].Rows[i]["City"] != DBNull.Value ? ds.Tables[0].Rows[i]["City"].ToString().Length > 30 ? ds.Tables[0].Rows[i]["City"].ToString().Substring(0, 30) : ds.Tables[0].Rows[i]["City"].ToString() : "";

                                objUserModel.Employee.ZIP = ds.Tables[0].Rows[i]["Zip Code"] != DBNull.Value ? ds.Tables[0].Rows[i]["Zip Code"].ToString() : "";
                               // objUserModel.EmployeeDependentDetail.Department = ds.Tables[0].Rows[i]["Department"] != DBNull.Value ? ds.Tables[0].Rows[i]["Department"].ToString() : "";
                                objUserModel.Employee.HomeEmail = ds.Tables[0].Rows[i]["Home Email"] != DBNull.Value ? ds.Tables[0].Rows[i]["Home Email"].ToString() : "";
                                if (ds.Tables[0].Rows[i]["Gender"] != DBNull.Value)
                                    objUserModel.Employee.Gender = ds.Tables[0].Rows[i]["Gender"].ToString() == "Female" ? 2 : 1;
                                // objUserModel.HomeEmail = ds.Tables[0].Rows[i]["Home Email"] != DBNull.Value ? ds.Tables[0].Rows[i]["Home Email"].ToString() : "";
                                objUserModel.Employee.HomePhone = ds.Tables[0].Rows[i]["Home Phone"] != DBNull.Value ? ds.Tables[0].Rows[i]["Home Phone"].ToString() : "";
                                objUserModel.Employee.SSN = ds.Tables[0].Rows[i]["SSN"] != DBNull.Value ? ds.Tables[0].Rows[i]["SSN"].ToString() : "";
                               // objUserModel.EmployeeDependentDetail.Salutation = ds.Tables[0].Rows[i]["Salutation"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["Salutation"]) : 0;
                                objUserModel.Employee.WorkPhone = ds.Tables[0].Rows[i]["Cell"] != DBNull.Value ? ds.Tables[0].Rows[i]["Cell"].ToString() : "";
                                objUserModel.Employee.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                                objUserModel.Employee.UserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);                                
                                lstUsers.Add(objUserModel);    
                                                     
                            }
                            return View(lstUsers);
                            //this.ImportUserRepository.SaveTempImportEmployees(lstUsers);
                           // return RedirectToAction("Details");
                        }                    
            }
            return View();
        }

        public ActionResult UpdateEmployeeData()
        {
            List<ImportEmployeeFormModel> lstUsers = new List<ImportEmployeeFormModel>();
            return View();
        }
        // this is working to display table values in view : not using this method
        public ActionResult ViewEmployeeData(UploadFile xls)
        {
          
           // private  List <ImportEmployeeModel> ImportEmployeeModel = new List<ImportEmployeeModel>();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            if ((Request.Files.Count > 0) && (Request.Files[0].ContentLength > 0))
            {                
                    string fileExtension = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv")
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
                    }

                #region looping the data into object variables
                   // List<ImportEmployeeFormModel> lstUsers = new List<ImportEmployeeFormModel>();

                    //ImportEmployeeFormModel objUserModel = new ImportEmployeeFormModel();

                    ImportEmployee importEmployeeObj = new ImportEmployee();

                   // ImportEmployeeFormModel I9WorkAuthorizationobj = new ImportEmployeeFormModel();

                    if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv")
                    {
                        // Create a folder in App_Data named ExcelFiles because you need to save the file temporarily location and getting data from there. 
                        string fileLocation = string.Format("{0}/{1}", Server.MapPath("~/Content/Files"),
                                                                                           Request.Files[0].FileName);                        
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DateTime birthDate;
                            DateTime hireDate;

                           // ImportEmployeeFormModel objUserModel = new ImportEmployeeFormModel();
                            //objUserModel.Csvslno = i;
                            importEmployeeObj.FirstName = dt.Rows[i]["First Name"] != DBNull.Value ? dt.Rows[i]["First Name"].ToString().Length > 30 ? dt.Rows[i]["First Name"].ToString().Substring(0, 30) : dt.Rows[i]["First Name"].ToString() : "";
                            importEmployeeObj.MiddleName = dt.Rows[i]["Middle Name"] != DBNull.Value ? dt.Rows[i]["Middle Name"].ToString().Length > 30 ? dt.Rows[i]["Middle Name"].ToString().Substring(0, 30) : dt.Rows[i]["Middle Name"].ToString() : "";
                            importEmployeeObj.LastName = dt.Rows[i]["Last Name"] != DBNull.Value ? dt.Rows[i]["Last Name"].ToString().Length > 30 ? dt.Rows[i]["Last Name"].ToString().Substring(0, 30) : dt.Rows[i]["Last Name"].ToString() : "";

                            if (dt.Rows[i]["Date of Birth"] != DBNull.Value && DateTime.TryParse(dt.Rows[i]["Date of Birth"].ToString(), out birthDate))
                                importEmployeeObj.BirthDate = Convert.ToDateTime(dt.Rows[i]["Date of Birth"]);
                            //if (ds.Tables[0].Rows[i]["Hire Date"] != DBNull.Value && DateTime.TryParse(ds.Tables[0].Rows[i]["Hire Date"].ToString(), out hireDate))
                            //    objUserModel.EmployeeDependentDetail.NewHireDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Hire Date"]);


                            importEmployeeObj.Address1 = dt.Rows[i]["Street1"] != DBNull.Value ? dt.Rows[i]["Street1"].ToString().Length > 100 ? dt.Rows[i]["Street1"].ToString().Substring(0, 100) : dt.Rows[i]["Street1"].ToString() : "";
                            importEmployeeObj.Address2 = dt.Rows[i]["Street2"] != DBNull.Value ? dt.Rows[i]["Street2"].ToString().Length > 100 ? dt.Rows[i]["Street2"].ToString().Substring(0, 100) : dt.Rows[i]["Street2"].ToString() : "";
                            importEmployeeObj.City = dt.Rows[i]["City"] != DBNull.Value ? dt.Rows[i]["City"].ToString().Length > 30 ? dt.Rows[i]["City"].ToString().Substring(0, 30) : dt.Rows[i]["City"].ToString() : "";

                            importEmployeeObj.Zip = dt.Rows[i]["Zip Code"] != DBNull.Value ? dt.Rows[i]["Zip Code"].ToString() : "";
                            // objUserModel.EmployeeDependentDetail.Department =dt.Rows[i]["Department"] != DBNull.Value ?dt.Rows[i]["Department"].ToString() : "";
                            importEmployeeObj.HomeEmail = dt.Rows[i]["Home Email"] != DBNull.Value ? dt.Rows[i]["Home Email"].ToString() : "";
                            if (dt.Rows[i]["Gender"] != DBNull.Value)
                                importEmployeeObj.Gender = dt.Rows[i]["Gender"].ToString() == "Female" ? 2 : 1;
                            // objUserModel.HomeEmail =dt.Rows[i]["Home Email"] != DBNull.Value ?dt.Rows[i]["Home Email"].ToString() : "";
                            importEmployeeObj.HomePhone = dt.Rows[i]["Home Phone"] != DBNull.Value ? dt.Rows[i]["Home Phone"].ToString() : "";
                            importEmployeeObj.SSN = dt.Rows[i]["SSN"] != DBNull.Value ? dt.Rows[i]["SSN"].ToString() : "";
                            // objUserModel.EmployeeDependentDetail.Salutation =dt.Rows[i]["Salutation"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["Salutation"]) : 0;
                            importEmployeeObj.WorkPhone = dt.Rows[i]["Cell"] != DBNull.Value ? dt.Rows[i]["Cell"].ToString() : "";
                            importEmployeeObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                            importEmployeeObj.UserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                            //lstUsers.Add(objUserModel);

                        }
                        return View(importEmployeeObj);
                        //this.ImportUserRepository.SaveTempImportEmployees(lstUsers);
                        // return RedirectToAction("Details");
                    }  
                #endregion

                //
            }

            return View(dt);
        }    


    }
}
