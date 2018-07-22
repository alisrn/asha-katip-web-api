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
    public class ResourceController : ControllerBase
    {
        // GET api/resource
        [HttpGet]
        public List<ResourceResult> Get()
        {
            List<ResourceResult> resultList = new List<ResourceResult>();

            SqlConnection myDbCon = new SqlConnection(DBConst.conStr);
            myDbCon.Open();
            string CommandText = "SELECT * FROM RESOURCE";
            SqlCommand command = new SqlCommand(CommandText, myDbCon);
                
            SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ResourceResult result = new ResourceResult();
                    result.ID = Convert.ToInt32(reader["ID"]);
                    result.NAME = (string)reader["NAME"];
                    result.PARENT_ID = Convert.ToInt32(reader["PARENT_ID"]);
                    result.CODE = (string)reader["CODE"];
                    result.ok = true;
                    result.message = "Resource information is successfully retrieved.";

                    resultList.Add(result);
                }

            return resultList;
        }
    }
}