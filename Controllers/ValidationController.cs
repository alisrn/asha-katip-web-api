using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using myApp.Helper;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace myApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        // GET api/validation
        [HttpGet]
        public string Get([FromQuery]string username, string email)
        {
            ValidationCreds creds = new ValidationCreds();
            creds.email = email;
            creds.username = username;

            ValidationResult result = new ValidationResult();
            result.ok = false;
            result.message = "An unexpected error occured. Sign up couln't be completed.";

            SqlConnection myDbCon = new SqlConnection(DBConst.conStr);
            myDbCon.Open();

            string CommandText = "SELECT username, email FROM USERInfo WHERE USERNAME = @username OR EMAIL = @email";

            SqlCommand command = new SqlCommand(CommandText, myDbCon);
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = creds.username;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = creds.email;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (creds.username == (string)reader["USERNAME"])
                {
                    result.ok = false;
                    result.message = "Username is already taken by another user.";
                    return JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.ok = false;
                    result.message = "Email is already taken by another user.";
                    return JsonConvert.SerializeObject(result);
                }
            }

            result.ok = true;
            result.message = "Username and email is available.";
            myDbCon.Close();   

            return JsonConvert.SerializeObject(result);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
