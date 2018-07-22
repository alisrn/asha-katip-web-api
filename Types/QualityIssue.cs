using System;
using System.Runtime.Serialization;

namespace myApp.Controllers
{
    [Serializable]
    public class QualityIssue
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int Customer_Id { get; set; }

        [DataMember]
        public int Project_Id { get; set; }

        [DataMember]
        public int Partnumber_Id { get; set; }

        [DataMember]
        public DateTime Problem_Date { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Location_Id { get; set; }

        [DataMember]
        public string Grade_Id { get; set; }

        [DataMember]
        public int Resp_Dept_Id { get; set; }

        [DataMember]
        public DateTime Request_Date { get; set; }

        [DataMember]
        public DateTime Target_Date { get; set; }

        [DataMember]
        public int Qty_In_1_Month { get; set; }

        [DataMember]
        public int Qty_In_3_Month { get; set; }

        [DataMember]
        public DateTime? Receive_Date1 { get; set; }

        [DataMember]
        public DateTime? Receive_Date2 { get; set; }

        [DataMember]
        public DateTime? Receive_Date3{ get; set; }

        [DataMember]
        public DateTime? Send_Date { get; set; }

        [DataMember]
        public DateTime? Awaiting_Date { get; set; }

        [DataMember]
        public int? Doc_Update { get; set; }

        [DataMember]
        public string Doc_Update_Description { get; set; }

        [DataMember]
        public DateTime Insert_Date { get; set; }

        [DataMember]
        public int Insert_User_Id { get; set; }

        [DataMember]
        public DateTime? Update_Date { get; set; }

        [DataMember]
        public int? Update_User_Id { get; set; }
    }
}
