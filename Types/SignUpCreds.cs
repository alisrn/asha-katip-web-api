using System;
using System.Runtime.Serialization;
namespace myApp.Controllers
{
    [Serializable]
    public class SignUpCreds
    {
        [DataMember]
        public String name { get; set; }

        [DataMember]
        public String surname { get; set; }

        [DataMember]
        public String username { get; set; }

        [DataMember]
        public String email { get; set; }

        [DataMember]
        public String password { get; set; }

        [DataMember]
        public Int32 workgroup { get; set; }
    }
}
