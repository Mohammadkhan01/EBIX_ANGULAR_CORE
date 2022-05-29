using EBIX_WEBAPI.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EBIX_WEBAPI.Controllers
{
    public class InvoiceController : ApiController
    {
        //Get Method will return Invoice Details from Invoice Table
        //Query must use from stored procedure in SQL but for demo purpose i am using it from C# code
        public HttpResponseMessage Get()
        {
            try
            {
                string query = @"
                    select InvoiceId,ClientId,convert(varchar(20),
                        invoiceDate,120) as InvoiceDate, InvoiceNo,InvoiceAmount
                        from dbo.Invoice
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
            catch(Exception)
            {
                return Request.CreateResponse("Problem Occors! please check Sql server and local host server");
            }
        }
        //This  method will Insert data into invoice Table
        public string Post(Invoice inv)
        {
            try
            {
                string query = @"insert into dbo.Invoice values
                            (
                                '" + inv.ClientId + @"'
                                ,'" + inv.InvoiceDate + @"'
                                ,'" + inv.InvoiceNo + @"'
                                ,'" + inv.InvoiceAmount + @"'
                            )";
                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBIXAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successful";
            }
            catch(Exception)
            {
                return "Failed to Insert";
            }

        }

        //Put() Method will update data into Invoice Table
        public string Put(Invoice inv)
        {
            try
            {
                string query = @"update dbo.Invoice set 
                     clientId ='" + inv.ClientId + @"'
                     ,invoiceDate = '" + inv.InvoiceDate + @"'
                     ,invoiceNo = '" + inv.InvoiceNo + @"'
                     ,invoiceAmount = '" + inv.InvoiceAmount + @"'
                    where InvoiceId=" + inv.InvoiceId + @"";

                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBIXAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Update Successful";

            }
            catch (Exception)
            {
                return "Failed to Update";
            }
        }

        //Delete Method will delete data from Invoice
        public string Delete(int id)
        {
            try
            {
                string query = @"delete from dbo.Invoice
                    where InvoiceId=" + id + @"";
                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBIXAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Delete Successful";

            }
            catch (Exception)
            {
                return "Failed to Delete";
            }
        }

        //GetAllClient method will return all client stored into CLient table
        [Route("api/Invoice/GetAllClient")]
        [HttpGet]
        public HttpResponseMessage GetAllClient()
        {
            try { 
                string query = @"
                    select ClientId from dbo.Client
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
             catch (Exception)
            {
                return Request.CreateResponse("Problem Occors! please check Sql server and local host server");
            }
        }

    }

}