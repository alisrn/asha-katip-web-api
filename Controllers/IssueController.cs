using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using myApp.Helper;
namespace myApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // POST api/login
        [HttpPost]
        public LoginResult Post([FromBody]UserCreds creds)
        {
            LoginResult result = new LoginResult();
            result.ok = false;
            result.message = "Login failed";


            SqlConnection myDbCon = new SqlConnection(DBConst.conStr);
            myDbCon.Open();
            string CommandText = "SELECT * FROM UserInfo WHERE Username=@name";

            SqlCommand command = new SqlCommand(CommandText, myDbCon);
            command.Parameters.AddWithValue("@name", creds.username);
            SqlDataReader reader = command.ExecuteReader();

            string password=null;

            if (reader.Read())
            {
                result.userId = Convert.ToInt32(reader["Id"]);
                result.username = (string)reader["Username"];
                password = (string)reader["Password"];
                result.workgroup = (int)reader["Workgroup"];
            }

            if (creds.username == result.username && creds.password == password)
            {
                result.ok = true;
                result.message = "Login Başarılı";
            }
            return result;
        }

    }
}
