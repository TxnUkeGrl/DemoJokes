using DemoJokes.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoJokes.Controllers
{
    public class JokesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                select JokeId, JokeQuestion, JokeAnswer from
                dbo.Jokes
            ";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoJokeDB"].ConnectionString))
                using(var cmd= new SqlCommand(query,con))
                using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Jokes demoJokes)
        {
            try
            {
                string query = @"
                    insert into dbo.Jokes values
                    ('" + demoJokes.JokeQuestion + @"',
                    '"+demoJokes.JokeAnswer +@"')
                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoJokeDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!";
            }

            catch (Exception ex)
            {
                return "Failed to Add!";
            }
        }

        public string Put(Jokes demoJokes)
        {
            try
            {
                string query = @"
                    update dbo.Jokes set JokeQuestion=
                    '" + demoJokes.JokeQuestion + @"',
                                        JokeAnswer=
                    '" + demoJokes.JokeAnswer + @"'
                    where JokeId=" + demoJokes.JokeId+@"
                ;";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoJokeDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                    da.Update(table);
                }

                return "Updated Successfully!";
            }

            catch (Exception)
            {
                return "Failed to Update!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Jokes
                    where JokeId=" + id + @"
                ;";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoJokeDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                    da.Update(table);
                }

                return "Deleted Successfully!";
            }

            catch (Exception)
            {
                return "Failed to Delete!";
            }
        }
    }
}
