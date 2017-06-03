using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class FilesDBRepository : IFilesDBRepository
    {
        public int CreateFileinFilesDB(FilesDB filesDBobj, int userId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_FilesDBInsert(
                        filesDBobj.CompanyId,
                        filesDBobj.FileBytes,
                        filesDBobj.FileName,
                        filesDBobj.FileSize,
                        filesDBobj.ContentType,
                        filesDBobj.FileExtension,
                        filesDBobj.CreatedBy,
                        filesDBobj.FileType,
                        userId,
                        output);

                    return Convert.ToInt32(output.Value);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<FilesDB> SelectFileByFileDBId(int fileId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstFileByList = hrmsEntity.usp_FilesDBSelect(fileId).ToList();
                    var filedbList = lstFileByList.Select(filedb => new FilesDB
                    {
                        FilesDBId = filedb.FilesDBID,
                        FileId = filedb.FileId,
                        CompanyId = filedb.CompanyId,
                        FileBytes = filedb.FileBytes,
                        FileName = filedb.FileName,
                        FileSize = filedb.FileSize,
                        ContentType = filedb.ContentType,
                        FileExtension = filedb.FileExtension,
                        CreatedOn = filedb.CreatedOn,
                        FileType = filedb.FileType
                    }).ToList();

                    return filedbList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FilesDB> SelectAllFilesByCompanyId(int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstFileByList = hrmsEntity.usp_FilesDBSelectAll(companyId).ToList();
                    var filedbList = lstFileByList.Select(filedb => new FilesDB
                    {
                        FilesDBId = filedb.FilesDBID,
                        FileId = filedb.FileId,
                        CompanyId = filedb.CompanyId,
                        FileBytes = filedb.FileBytes,
                        FileName = filedb.FileName,
                        FileSize = filedb.FileSize,
                        ContentType = filedb.ContentType,
                        FileExtension = filedb.FileExtension,
                        CreatedOn = filedb.CreatedOn,
                        FileType = filedb.FileType
                    }).ToList();
                    return filedbList;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool DeleteFileinFilesDB(int fileId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_FilesDBDelete(fileId);
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
