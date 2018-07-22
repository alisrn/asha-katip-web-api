using System;
using System.Runtime.Serialization;
namespace myApp.Controllers
{
    [Serializable]
    public class ValidationCreds
    {

        [DataMember]
        public String username { get; set; }

        [DataMember]
        public String email { get; set; }

    }
}
