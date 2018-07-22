using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using myApp.Helper;
namespace myApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        // POST api/signup
        [HttpPost]
        public string Post([FromBody]SignUpCreds creds)
        {
            SignUpResult result = new SignUpResult();
            result.ok = false;
            result.message = "An unexpected error occured. Sign up couln't be completed.";

            SqlConnection myDbCon = new SqlConnection(DBConst.conStr);
            myDbCon.Open();

            try
            {
                string CommandText = "INSERT INTO USERInfo(USERNAME, NAME, SURNAME, WORKGROUP, EMAIL, Insert_Date, PASSWORD) VALUES (@username, @name, @surname, @workgroup, @email, GETDATE(), @Password)";
                SqlCommand command = new SqlCommand(CommandText, myDbCon);
                command.Parameters.Add("@username", SqlDbType.VarChar).Value = creds.username;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = creds.name;
                command.Parameters.Add("@surname", SqlDbType.VarChar).Value = creds.surname;
                command.Parameters.Add("@workgroup", SqlDbType.Int).Value = creds.workgroup;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = creds.email;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = creds.password;
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                result.ok = false;
                result.message = ex.Message;
                return JsonConvert.SerializeObject(result);
            }

            result.ok = true;
            result.message = "Signup completed successfully!";
            myDbCon.Close();
            return JsonConvert.SerializeObject(result);
        }


    }
}
