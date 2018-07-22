using System;
using System.Runtime.Serialization;
namespace myApp.Controllers
{
    [Serializable]
    public class LoginResult
    {
        
        [DataMember]
        public bool ok { get; set; }

        [DataMember]
        public String message { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public int workgroup { get; set; }

        [DataMember]
        public int userId { get; set; }
    }
}
