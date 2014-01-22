using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    class ADDRESS
    {

        [DataMember(Name = "SEARCHVAL")]
        public string SEARCHVAL{ get; set;}
        [DataMember(Name="CATEGORY")]
        public string CATEGORY { get; set; }
        [DataMember(Name="X")]
        public double X { get; set; }
        [DataMember(Name="Y")]
        public double Y { get; set; }
    }
}
