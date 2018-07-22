﻿using System;
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
                    "GETDATE(), @Insert_User_Id, )";
                SqlCommand command = new SqlCommand(CommandText, myDbCon);
                command.Parameters.Add("@Customer_Id", SqlDbType.Int).Value = issueInfo.Customer_Id;
                command.Parameters.Add("@Project_Id", SqlDbType.Int).Value = issueInfo.Project_Id;
                command.Parameters.Add("@Partnumber_Id", SqlDbType.Int).Value = issueInfo.Partnumber_Id;
                command.Parameters.Add("@Problem_Date", SqlDbType.DateTime).Value = issueInfo.Problem_Date;
                command.Parameters.Add("@Description", SqlDbType.VarChar).Value = issueInfo.Description;
                command.Parameters.Add("@Location_Id", SqlDbType.Int).Value = issueInfo.Location_Id;
                command.Parameters.Add("@Grade_Id", SqlDbType.VarChar).Value = issueInfo.Grade_Id;
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

            return JsonConvert.SerializeObject(result);
        }

        // PUT api/issue/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] QualityIssue issueInfo)
        {
            SignUpResult result = new SignUpResult();
            result.ok = false;
            result.message = "Login failed";


            SqlConnection myDbCon = new SqlConnection(DBConst.conStr);
            myDbCon.Open();

            try
            {
                string CommandText = "UPDATE QualityIssue SET " +
                    "Customer_Id=@Customer_Id, " +
                    "Project_Id=@Project_Id, " +
                    "Partnumber_Id=@Partnumber_Id, " +
                    "Problem_Date=@Problem_Date, " +
                    "Description=@Description, " +
                    "Location_Id=@Location_Id, " +
                    "Grade_Id=@Grade_Id, " +
                    "Resp_Dept_Id=@Resp_Dept_Id, " +
                    "Request_Date=@Request_Date, " +
                    "Target_Date=@Target_Date, " +
                    "Qty_In_1_Month=@Qty_In_1_Month, " +
                    "Qty_In_3_Month=@Qty_In_3_Month, " +
                    "Receive_Date1=@Receive_Date1, " +
                    "Receive_Date2=@Receive_Date2, " +
                    "Receive_Date3=@Receive_Date3, " +
                    "Send_Date=@Send_Date, " +
                    "Awaiting_Date=@Awaiting_Date, " +
                    "Doc_Update=@Doc_Update, " +
                    "Doc_Update_Desc=@Doc_Update_Desc, " +
                    "Update_Date=GETDATE(), " +
                    "Update_User_Id=@Update_User_Id)" +
                    " WHERE Id = @Id";
                SqlCommand command = new SqlCommand(CommandText, myDbCon);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = issueInfo.Id;
                command.Parameters.Add("@Customer_Id", SqlDbType.Int).Value = issueInfo.Customer_Id;
                command.Parameters.Add("@Project_Id", SqlDbType.Int).Value = issueInfo.Project_Id;
                command.Parameters.Add("@Partnumber_Id", SqlDbType.Int).Value = issueInfo.Partnumber_Id;
                command.Parameters.Add("@Problem_Date", SqlDbType.DateTime).Value = issueInfo.Problem_Date;
                command.Parameters.Add("@Description", SqlDbType.VarChar).Value = issueInfo.Description;
                command.Parameters.Add("@Location_Id", SqlDbType.Int).Value = issueInfo.Location_Id;
                command.Parameters.Add("@Grade_Id", SqlDbType.VarChar).Value = issueInfo.Grade_Id;
                command.Parameters.Add("@Resp_Dept_Id", SqlDbType.Int).Value = issueInfo.Resp_Dept_Id;
                command.Parameters.Add("@Request_Date", SqlDbType.DateTime).Value = issueInfo.Request_Date;
                command.Parameters.Add("@Target_Date", SqlDbType.DateTime).Value = issueInfo.Target_Date;
                command.Parameters.Add("@Qty_In_1_Month", SqlDbType.Int).Value = issueInfo.Qty_In_1_Month;
                command.Parameters.Add("@Qty_In_3_Month", SqlDbType.Int).Value = issueInfo.Qty_In_3_Month;
                command.Parameters.Add("@Receive_Date1", SqlDbType.DateTime).Value = issueInfo.Receive_Date1;
                command.Parameters.Add("@Receive_Date2", SqlDbType.DateTime).Value = issueInfo.Receive_Date2;
                command.Parameters.Add("@Receive_Date3", SqlDbType.DateTime).Value = issueInfo.Receive_Date3;
                command.Parameters.Add("@Send_Date", SqlDbType.DateTime).Value = issueInfo.Send_Date;
                command.Parameters.Add("@Awaiting_Date", SqlDbType.DateTime).Value = issueInfo.Awaiting_Date;
                command.Parameters.Add("@Doc_Update", SqlDbType.Int).Value = issueInfo.Doc_Update;
                command.Parameters.Add("@Doc_Update_Desc", SqlDbType.VarChar).Value = issueInfo.Doc_Update_Description;
                command.Parameters.Add("@Update_User_Id", SqlDbType.Int).Value = issueInfo.Update_User_Id;

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
