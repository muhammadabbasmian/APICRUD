using APICRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace APICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string sqlDataSource;

        public Students(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select Id,StudentName,Email,Dob,Notes From TestDb.Student";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("StudentsApp");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDatasource))
            {
                mycon.Open();
                using(MySqlCommand mycmd = new MySqlCommand(query, mycon))
                {
                    myreader = mycmd.ExecuteReader();   
                    table.Load(myreader);

                    myreader.Close();
                    mycon.Close();
                }

            }
            return new JsonResult(table);
        }
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"select Id,StudentName,Email,Dob,Notes From TestDb.Student where Id=@id";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("StudentsApp");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDatasource))
            {
                mycon.Open();
                using (MySqlCommand mycmd = new MySqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@id", id);
                    myreader = mycmd.ExecuteReader();
                    table.Load(myreader);

                    myreader.Close();
                    mycon.Close();
                }

            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Student std)
        {
            string query = @"insert into TestDb.Student (StudentName,Email,Dob,Notes)
            Values(@StdName,@email,@Dob,@notes)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("StudentsApp");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDatasource))
            {
                mycon.Open();
                using (MySqlCommand mycmd = new MySqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@StdName",std.StudentName);
                    mycmd.Parameters.AddWithValue("@email", std.Email);
                    mycmd.Parameters.AddWithValue("@Dob", std.Dob);
                    mycmd.Parameters.AddWithValue("@notes", std.Notes);
                    myreader = mycmd.ExecuteReader();
                    table.Load(myreader);

                    myreader.Close();
                    mycon.Close();
                }

            }
            return new JsonResult("Added Succesfully");
        }

        [HttpPut]
        public JsonResult Put(Student std)
        {
            string query = @"Update TestDb.Student set
              StudentName=@StdName,
              Email=@email,
              Dob=@Dob,
              Notes=@notes
              where Id=@id;";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("StudentsApp");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDatasource))
            {
                mycon.Open();
                using (MySqlCommand mycmd = new MySqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@id", std.Id);
                    mycmd.Parameters.AddWithValue("@StdName", std.StudentName);
                    mycmd.Parameters.AddWithValue("@email", std.Email);
                    mycmd.Parameters.AddWithValue("@Dob", std.Dob);
                    mycmd.Parameters.AddWithValue("@notes", std.Notes);
                   
                    myreader = mycmd.ExecuteReader();
                    table.Load(myreader);

                    myreader.Close();
                    mycon.Close();
                }

            }
            return new JsonResult("Updated Succesfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete From TestDb.Student 
              where Id=@id;";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("StudentsApp");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDatasource))
            {
                mycon.Open();
                using (MySqlCommand mycmd = new MySqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@id", id);
                    

                    myreader = mycmd.ExecuteReader();
                    table.Load(myreader);

                    myreader.Close();
                    mycon.Close();
                }

            }
            return new JsonResult("Deleted Succesfully");
        }

    } 
}
