using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Interfaces
{
    public interface IMailerRepository
    {
        Boolean sendEmailWithCredentials(string _To, string _Subject,
                                      string _Message);
        List<AlertTemplate> GetMailDetailsByStatus(bool p);
        bool UpdateEmployeeAlertStatus(string email, int employeeId, bool status);
    }
}
