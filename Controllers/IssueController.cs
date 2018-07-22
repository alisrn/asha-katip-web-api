using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using myApp.Helper;
namespace myApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        // POST api/login
        [HttpPost]
        public string Post([FromBody]QualityIssue issueInfo)
        {
            SignUpResult result = new SignUpResult();
            result.ok = false;
            result.message = "Login failed";


            SqlConnection myDbCon = new SqlConnection(DBConst.conStr);
            myDbCon.Open();

            try
            {
                string CommandText = "INSERT INTO QualityIssue(" +
                    "Customer_Id, Project_Id, Partnumber_Id, Problem_Date, Description, Location_Id, Grade_Id," +
                    "Resp_Dept_Id, Request_Date, Target_Date, Qty_In_1_Month, Qty_In_3_Month, " +
                    "Insert_Date, Insert_User_Id)" +
                    "VALUES (@Customer_Id, @Project_Id, @Partnumber_Id, @Problem_Date, @Description, @Location_Id, @Grade_Id," +
                    "@Resp_Dept_Id, @Request_Date, @Target_Date, @Qty_In_1_Month, @Qty_In_3_Month," +
                    "GETDATE(), @Insert_User_Id)";
                SqlCommand command = new SqlCommand(CommandText, myDbCon);
                command.Parameters.Add("@Customer_Id", SqlDbType.Int).Value = issueInfo.Customer_Id;
                command.Parameters.Add("@Project_Id", SqlDbType.Int).Value = issueInfo.Project_Id;
                command.Parameters.Add("@Partnumber_Id", SqlDbType.Int).Value = issueInfo.Partnumber_Id;
                command.Parameters.Add("@Problem_Date", SqlDbType.DateTime).Value = issueInfo.Problem_Date;
                command.Parameters.Add("@Description", SqlDbType.VarChar).Value = issueInfo.Description;
                command.Parameters.Add("@Location_Id", SqlDbType.Int).Value = issueInfo.Location_Id;
                command.Parameters.Add("@Grade_Id", SqlDbType.Int).Value = issueInfo.Grade_Id;
                command.Parameters.Add("@Resp_Dept_Id", SqlDbType.Int).Value = issueInfo.Resp_Dept_Id;
                command.Parameters.Add("@Request_Date", SqlDbType.DateTime).Value = issueInfo.Request_Date;
                command.Parameters.Add("@Target_Date", SqlDbType.DateTime).Value = issueInfo.Target_Date;
                command.Parameters.Add("@Qty_In_1_Month", SqlDbType.Int).Value = issueInfo.Qty_In_1_Month;
                command.Parameters.Add("@Qty_In_3_Month", SqlDbType.Int).Value = issueInfo.Qty_In_3_Month;
                command.Parameters.Add("@Insert_User_Id", SqlDbType.Int).Value = issueInfo.Insert_User_Id;

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

            return JsonConvert.SerializeObject(result);;
        }

    }
}
