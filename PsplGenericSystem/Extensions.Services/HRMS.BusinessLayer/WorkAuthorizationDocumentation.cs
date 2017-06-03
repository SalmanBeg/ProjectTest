using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class WorkAuthorizationDocumentation
    {
            public int Id {get;set;}
            public int WorkAuthorizationDocumentationTypeId {get;set;}
	        public int WorkAuthorizationId {get;set;}

	        public int DocumentTitleA {get;set;}
            public int DocumentTitleB { get; set; }
            public int DocumentTitleC { get; set; }

	        public string DocumentIssuingAuthorityA {get;set;}
            public string DocumentIssuingAuthorityB { get; set; }
            public string DocumentIssuingAuthorityC { get; set; }

	        public string DocumentNumberA {get;set;}
            public string DocumentNumberB { get; set; }
            public string DocumentNumberC { get; set; }

	        public DateTime? ExpirationDateA {get;set;}
            public DateTime? ExpirationDateB { get; set; }
            public DateTime? ExpirationDateC { get; set; }

            public string UpdateBy { get; set; }

            public DataTable tWorkAuthorizationDocumentation()
            {
                var dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("WorkAuthorizationDocumentationTypeId", typeof(int));
               // dt.Columns.Add("WorkAuthorizationId", typeof(int));
                dt.Columns.Add("DocumentTitle", typeof(int));
                dt.Columns.Add("DocumentIssuingAuthority", typeof(string));
                dt.Columns.Add("DocumentNumber", typeof(string));
                dt.Columns.Add("ExpirationDate", typeof(DateTime));
               // dt.Columns.Add("UpdateBy", typeof(string));
                return dt;
            }
            public DataRow WorkAuthorizationRow(DataTable dt,int id, int WorkAuthorizationDocumentationTypeId, int DocumentTitle, string DocumentIssuingAuthority, string DocumentNumber, DateTime? ExpirationDate)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = Id;
                dr["WorkAuthorizationDocumentationTypeId"] = WorkAuthorizationDocumentationTypeId;
               // dr["WorkAuthorizationId"] = WorkAuthorizationId;
                dr["DocumentTitle"] = DocumentTitle;
                dr["DocumentIssuingAuthority"] = DocumentIssuingAuthority;
                dr["DocumentNumber"] = DocumentNumber;
                dr["ExpirationDate"] = ExpirationDate != null ? ExpirationDate : DateTime.MinValue;
               // dr["UpdateBy"] = UpdateBy;
                return dr;
            }


    }
}
