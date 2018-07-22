using System;
using System.Runtime.Serialization;
namespace myApp.Controllers
{
    [Serializable]
    public class UserCreds
    {
        [DataMember]
        public String username { get; set; }


        [DataMember]
        public String password { get; set; }
    }
}
