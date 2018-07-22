using System;
using System.Runtime.Serialization;
namespace myApp.Controllers
{
    [Serializable]
    public class customerCred
    {
        [DataMember]
        public String customerName { get; set; }


        [DataMember]
        public int Id { get; set; }
    }
}
