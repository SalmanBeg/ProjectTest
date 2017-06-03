using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Repositories;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.Controllers
{
    public class MailingInfoController : Controller
    {
        #region Class Level Variables and Constructor
        private readonly IMailingInfoRepository _mailingInfoRepository;

        public MailingInfoController(IMailingInfoRepository mailingInfoRepository)
        {
            _mailingInfoRepository = mailingInfoRepository;
        }
        #endregion


        // GET: /MailingInfo/
        public ActionResult CheckMailingInfo()
        {
            List<MailingInfo> mailingInfoListObj = new List<MailingInfo>();
           // _mailingInfoRepository.CreateMailTemplate(mailingInfoObj);
            return View(mailingInfoListObj);
        }
	}
}