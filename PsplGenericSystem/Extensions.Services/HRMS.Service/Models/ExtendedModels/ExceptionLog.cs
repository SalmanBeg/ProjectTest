using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HRMS.Service.Models.ExtendedModels
{
    [MetadataType(typeof(ExceptionLogMetaData))]
    public partial class ExceptionLog
    {

    }
    public partial class ExceptionLogMetaData
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public int StackTrace { get; set; }
        public DateTime ExceptionSource { get; set; }
        public string MachineName { get; set; }
        public string CallStack { get; set; }
        public int AppDomainName { get; set; }
        public DateTime AssemblyName { get; set; }
        public string AssemblyVersion { get; set; }
        public string ThreadID { get; set; }
        public string ThreadUser { get; set; }
    }
}
