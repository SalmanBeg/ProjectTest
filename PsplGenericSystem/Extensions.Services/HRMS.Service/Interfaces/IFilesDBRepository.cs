using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IFilesDBRepository
    {
        /// <summary>
        /// MEthod for new file creation
        /// </summary>
        /// <param name="filesDBobj"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int CreateFileinFilesDB(FilesDB filesDBobj, int userId);
        /// <summary>
        /// To select an individual record of file from database based on id
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<FilesDB> SelectFileByFileDBId(int fileId);
        /// <summary>
        /// to select all the files based on company 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger] 
        List<FilesDB> SelectAllFilesByCompanyId(int companyId);
        /// <summary>
        /// To remove an file from database based on record id
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteFileinFilesDB(int fileId);
    }
}
