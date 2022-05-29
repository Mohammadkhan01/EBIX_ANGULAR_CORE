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
    public class ClientController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select ClientId,FirstName,SurName,convert(varchar(20),
                        DateOfBirth,120) as DateOfBirth, Address,Suburb,State,PostCode,Telephone
                        from dbo.Client
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
        public string Post(Client cln)
        {

            string query = @"insert into dbo.Client values
                            (
                                '" + cln.FirstName + @"'
                                ,'" + cln.SurName + @"'
                                ,'" + cln.DateOfBirth + @"'
                                ,'" + cln.Address + @"'
                                ,'" + cln.Suburb + @"'
                                ,'" + cln.State + @"'
                                ,'" + cln.PostCode + @"'
                                ,'" + cln.Telephone + @"'
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

        public string Put(Client cln)
        {
            try
            {
                string query = @"update dbo.Client set 
                     FirstName ='" + cln.FirstName + @"'
                     ,SurName = '" + cln.SurName + @"'
                     ,DateOfBirth = '" + cln.DateOfBirth + @"'
                     ,Address = '" + cln.Address + @"'
                     ,Suburb = '" + cln.Suburb + @"'
                     ,State = '" + cln.State + @"'
                     ,PostCode = '" + cln.PostCode + @"'
                      ,Telephone = '" + cln.Telephone + @"'

                    where ClientId=" + cln.ClientId + @"";

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
        public string Delete(int id)
        {
            try
            {
                string query = @"delete from dbo.Client 
                    where ClientId=" + id + @"";
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
    }

}
