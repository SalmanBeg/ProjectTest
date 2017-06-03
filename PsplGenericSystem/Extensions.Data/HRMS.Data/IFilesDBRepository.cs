using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
   public  interface IFilesDBRepository
    {
       bool CreateFileinFilesDB(FilesDB filesDBobj);

       List<FilesDB> SelectFileByFileDBId(int fileId);

       bool DeleteFileinFilesDB(int FilesDBId);

       List<FilesDB> SelectAllFilesByCompanyId(int companyId);
    }
}
