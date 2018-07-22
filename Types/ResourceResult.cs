using System;
using System.Runtime.Serialization;
namespace myApp.Controllers
{
    [Serializable]
    public class ResourceResult
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int PARENT_ID { get; set; }

        [DataMember]
        public string NAME { get; set; }

        [DataMember]
        public string CODE { get; set; }

        [DataMember]
        public DateTime INITIAL_DATE { get; set; }

        [DataMember]
        public bool ok { get; set; }

        [DataMember]
        public string message { get; set; }
    }
}
