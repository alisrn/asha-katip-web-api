﻿using System;
using System.Runtime.Serialization;
namespace myApp.Controllers
{
    [Serializable]
    public class ValidationResult
    {
        [DataMember]
        public bool ok { get; set; }

        [DataMember]
        public String message { get; set; }
    }
}
