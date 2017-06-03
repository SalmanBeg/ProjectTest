using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;


namespace HRMS.Data
{
    public class FilesDBRepository : IFilesDBRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class FilesDBFields
        {
            public const string FilesDBId = "FilesDBId";
            public const string FileId = "FileId";
            public const string FileBytes = "FileBytes";
            public const string FileName = "FileName";
            public const string FileSize = "FileSize";
            public const string ContentType = "ContentType";
            public const string FileExtension = "FileExtension";
            public const string CreatedOn = "CreatedOn";
            public const string ModifiedOn = "ModifiedOn";
            public const string CompanyId = "CompanyId";
            public const string FileType = "FileType";
        }

        public bool CreateFileinFilesDB(FilesDB filesDBobj)
        {
            bool executionState = false;
            _oDatabaseHelper = new DatabaseHelper();
            _oDatabaseHelper.AddParameter("@FileBytes", filesDBobj.FileBytes);
            _oDatabaseHelper.AddParameter("@FileName", filesDBobj.FileName);
            _oDatabaseHelper.AddParameter("@FileSize", filesDBobj.FileSize);
            _oDatabaseHelper.AddParameter("@ContentType", filesDBobj.ContentType);
            _oDatabaseHelper.AddParameter("@FileExtension", filesDBobj.FileExtension);
            _oDatabaseHelper.AddParameter("@CompanyId", filesDBobj.CompanyId);
            _oDatabaseHelper.AddParameter("@CreatedBy", filesDBobj.CreatedBy);
            _oDatabaseHelper.AddParameter("@FileType", filesDBobj.FileType);
            _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
            _oDatabaseHelper.ExecuteScalar("OrganizationLevel.usp_FilesDBInsert", ref executionState);
            _oDatabaseHelper.Dispose();
            return executionState;
        }

        public List<FilesDB> SelectFileByFileDBId(int fileId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                List<FilesDB> filesDBList = new List<FilesDB>();
                _oDatabaseHelper.AddParameter("@FilesDBID", fileId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("OrganizationLevel.usp_FilesDBSelect", ref executionState);
                while (rdr.Read())
                {
                    var filesDBobj = new FilesDB();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FilesDBId)))
                        filesDBobj.FilesDBId = rdr.GetInt32(rdr.GetOrdinal(FilesDBFields.FilesDBId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileId)))
                        filesDBobj.FileId = rdr.GetGuid(rdr.GetOrdinal(FilesDBFields.FileId)).ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.CompanyId)))
                        filesDBobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(FilesDBFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileBytes)))
                        filesDBobj.FileBytes = (Byte[])rdr.GetValue(rdr.GetOrdinal(FilesDBFields.FileBytes));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileName)))
                        filesDBobj.FileName = rdr.GetString(rdr.GetOrdinal(FilesDBFields.FileName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileSize)))
                        filesDBobj.FileSize = rdr.GetString(rdr.GetOrdinal(FilesDBFields.FileSize));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.ContentType)))
                        filesDBobj.ContentType = rdr.GetString(rdr.GetOrdinal(FilesDBFields.ContentType));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileExtension)))
                        filesDBobj.FileExtension = rdr.GetString(rdr.GetOrdinal(FilesDBFields.FileExtension));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.CreatedOn)))
                        filesDBobj.CreatedOn = rdr.GetDateTime(rdr.GetOrdinal(FilesDBFields.CreatedOn));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileType)))
                        filesDBobj.FileType = rdr.GetString(rdr.GetOrdinal(FilesDBFields.FileType));
                    filesDBList.Add(filesDBobj);
                }
                rdr.Close();
                return filesDBList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }

        public List<FilesDB> SelectAllFilesByCompanyId(int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                List<FilesDB> filesDBList = new List<FilesDB>();
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("OrganizationLevel.usp_FilesDBSelectAll", ref executionState);
                while (rdr.Read())
                {
                    var filesDBobj = new FilesDB();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FilesDBId)))
                        filesDBobj.FilesDBId = rdr.GetInt32(rdr.GetOrdinal(FilesDBFields.FilesDBId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileId)))
                        filesDBobj.FileId = rdr.GetGuid(rdr.GetOrdinal(FilesDBFields.FileId)).ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.CompanyId)))
                        filesDBobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(FilesDBFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileBytes)))
                        filesDBobj.FileBytes = (Byte[])rdr.GetValue(rdr.GetOrdinal(FilesDBFields.FileBytes));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileName)))
                        filesDBobj.FileName = rdr.GetString(rdr.GetOrdinal(FilesDBFields.FileName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileSize)))
                        filesDBobj.FileSize = rdr.GetString(rdr.GetOrdinal(FilesDBFields.FileSize));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.ContentType)))
                        filesDBobj.ContentType = rdr.GetString(rdr.GetOrdinal(FilesDBFields.ContentType));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileExtension)))
                        filesDBobj.FileExtension = rdr.GetString(rdr.GetOrdinal(FilesDBFields.FileExtension));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.CreatedOn)))
                        filesDBobj.CreatedOn = rdr.GetDateTime(rdr.GetOrdinal(FilesDBFields.CreatedOn));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(FilesDBFields.FileType)))
                        filesDBobj.FileType = rdr.GetString(rdr.GetOrdinal(FilesDBFields.FileType));
                    filesDBList.Add(filesDBobj);
                }
                rdr.Close();
                return filesDBList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }

        public bool DeleteFileinFilesDB(int FilesDBId)
        {
            bool executionState = false;
            _oDatabaseHelper = new DatabaseHelper();
            _oDatabaseHelper.AddParameter("@FilesDBID", FilesDBId);
            _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
            _oDatabaseHelper.ExecuteScalar("OrganizationLevel.usp_FilesDBDelete", ref executionState);
            _oDatabaseHelper.Dispose();
            return executionState;
        }
    }
}
