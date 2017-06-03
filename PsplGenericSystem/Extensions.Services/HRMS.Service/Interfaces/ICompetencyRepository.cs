using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public  interface ICompetencyRepository
    {
        /// <summary>
        /// View to add a new competency record
        /// </summary>
        /// <param name="competencyobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int AddCompetency(Competency competencyobj);
        /// <summary>
        /// View to show all the competency records in a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Competency> SelectAllCompetency(int companyId);
        /// <summary>
        /// View to show all the competency records based on competencyId and comapanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="competencyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        Competency SelectCompetencyById(int companyId,int competencyId);
        /// <summary>
        /// View to update existing record of a competency
        /// </summary>
        /// <param name="competencyobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateCompetency(Competency competencyobj);
        /// <summary>
        /// view to add competency bulk data 
        /// </summary>
        /// <param name="dtCompetencyContent"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool InsertCompetencyContentBulk(DataTable dtCompetencyContent);
        /// <summary>
        /// to remove competency by competencyId
        /// </summary>
        /// <param name="competencyId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        bool DeleteCompetency(int competencyId, int companyId);
        /// <summary>
        /// to update bulk competency data
        /// </summary>
        /// <param name="dtCompetency"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateCompetencyContentBulk(DataTable dtCompetency);
    }
}
