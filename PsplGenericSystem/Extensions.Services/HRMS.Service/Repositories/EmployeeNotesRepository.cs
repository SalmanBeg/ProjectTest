using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;    

namespace HRMS.Service.Repositories
{
    public class EmployeeNotesRepository : IEmployeeNotesRepository
    {
        public int CreateEmployeeNotes(EmployeeNote employeeNoteobj)
        {
            
            try
            {
                using ( var hrmsEntity = new HRMSEntities1())
                {
                    var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_EmployeeNotesInsert(employeeNoteobj.UserId, employeeNoteobj.CompanyId, employeeNoteobj.Description
                        , employeeNoteobj.NotesContent, employeeNoteobj.DocumentName, employeeNoteobj.DocumentId, employeeNoteobj.AttachmentFileId, employeeNoteobj.CreatedBy
                        , employeeNoteobj.CreatedDate, outputParam);
                    hrmsEntity.Dispose();
                    return Convert.ToInt32(outputParam.Value); 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public bool UpdateEmployeeNotesById(EmployeeNote employeeNoteobj)
        {
            
            try
            {
                using ( var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeNotesUpdate(employeeNoteobj.EmployeeNotesId, employeeNoteobj.Description
                                , employeeNoteobj.NotesContent, employeeNoteobj.DocumentName, employeeNoteobj.DocumentId, employeeNoteobj.AttachmentFileId
                                , employeeNoteobj.ModifiedBy, employeeNoteobj.ModifiedDate).ToList();
                    hrmsEntity.Dispose();
                    return result.Count > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public EmployeeNote GetEmployeeNotesById(int employeeNotesId)
        {
            
            try
            {
                using ( var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeNotesResult = hrmsEntity.usp_EmployeeNotesSelectById(employeeNotesId).ToList();
                    return lstEmployeeNotesResult.Select(employeenote => new EmployeeNote
                    {
                        EmployeeNotesId = employeenote.EmployeeNotesId,
                        EmployeeNotesCode = employeenote.EmployeeNotesCode,
                        CompanyId = employeenote.CompanyId,
                        DocumentName = employeenote.DocumentName,
                        UserId = employeenote.UserId,
                        Description = employeenote.Description,
                        NotesContent = employeenote.NotesContent,
                        AttachmentFileId = employeenote.AttachmentFileId,
                        File = employeenote.FileName,
                        CreatedBy = employeenote.CreatedBy,
                        CreatedDate = employeenote.CreatedDate,
                        DocumentId = employeenote.DocumentId
                    }).FirstOrDefault(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<EmployeeNote> GetAllEmployeeNotesByUserId(int userId)
        {
            
            try
            {
                using ( var hrmsEntity = new HRMSEntities1())
                {
                    var lstAllEmployeeNotesResult = hrmsEntity.usp_EmployeeNotesSelectAll(userId).ToList();
                    return lstAllEmployeeNotesResult.Select(employeenote => new EmployeeNote
                    {
                        EmployeeNotesId = employeenote.EmployeeNotesId,
                        EmployeeNotesCode = employeenote.EmployeeNotesCode,
                        CompanyId = employeenote.CompanyId,
                        DocumentName = employeenote.DocumentName,
                        UserId = employeenote.UserId,
                        Description = employeenote.Description,
                        NotesContent = employeenote.NotesContent,
                        AttachmentFileId = employeenote.AttachmentFileId,
                        File = employeenote.FileName,
                        CreatedBy = employeenote.CreatedBy,
                        CreatedDate = employeenote.CreatedDate,
                        DocumentId = employeenote.DocumentId
                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        /// <summary>
        /// Method to Check if the EmployeeNote Title is already existing
        /// </summary>
        /// <param name="jobProfileObj"></param>
        /// <returns></returns>
        public bool IsTitleExists(EmployeeNote employeeNoteObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var enlist = hrmsEntity.EmployeeNotes.ToList();
                    var employeeNoteObj1 = enlist.SingleOrDefault(m => m.CompanyId == employeeNoteObj.CompanyId && m.Description.ToLower() == employeeNoteObj.Description.ToLower() && m.EmployeeNotesId != employeeNoteObj.EmployeeNotesId);
                    if (employeeNoteObj1 != null)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteEmployeeNotesById(int employeeNotesById)
        {
            
            try
            {
                using ( var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeNotesDelete(employeeNotesById);
                    return result > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
