using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_App.Models
{
    [DataContract]
    public class Student
    {
        [DataMember(IsRequired = true)]
        public string StudentId { get; set; }
        [DataMember(IsRequired = true)]
        public string StudentName { get; set; }
        [DataMember(IsRequired = true)]
        public string StudentAddress { get; set; }

    }
}