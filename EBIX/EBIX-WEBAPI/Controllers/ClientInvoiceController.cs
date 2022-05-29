
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EBIX_WEBAPI.Controllers
{
    public class ClientInvoiceController : ApiController
    {
        public HttpResponseMessage Get()
        {
           
                string query = @"
                        select InvoiceId,convert(varchar(20),
                            invoiceDate,120) as InvoiceDate, InvoiceNo,ClientId,ClientName
                            from dbo.ClientInvoice
                        ";

                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBIXAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return Request.CreateResponse(HttpStatusCode.OK, table);
            }
             
        
        
    }
}
