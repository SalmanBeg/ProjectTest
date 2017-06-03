using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class MailingInfoRepository : IMailingInfoRepository
    {
        /// <summary>
        /// Method to create a Mail template 
        /// </summary>
        /// <param name="mailingInfoObj"></param>
        /// <returns></returns>
        public int CreateMailTemplate(MailingInfo mailingInfoObj)
        {
            //try
            //{
            //    using (var hrmsEntity = new HRMSEntities1())
            //    {
            //        var result = hrmsEntity.MailingInfo.Add(mailingInfoObj);
            //        hrmsEntity.SaveChanges();
            //        return result.MailId;
            //    }
            //}
            //catch (Exception)
            //{
                
            //    throw;
            //}
            return 1;
        }
    }
}
