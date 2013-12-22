//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetSociety_for_Windows.Src.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public partial class STRAY
    {
        public STRAY()
        {
            this.REVIEWs = new List<REVIEW>();
        }

        [DataMember(Order = 1)]
        public int StrayID { get; set; }
        [DataMember(Order = 2)]
        public double X { get; set; }
        [DataMember(Order = 3)]
        public double Y { get; set; }
        [DataMember(Order = 4)]
        public string Biography { get; set; }
        [DataMember(Order = 5)]
        public string Title { get; set; }
        [DataMember(Order = 6)]
        public Nullable<System.DateTime> DateTimeSeen { get; set; }
        [DataMember(Order = 7)]
        public string Type { get; set; }
        [DataMember(Order = 8)]
        public string Breed { get; set; }
        [DataMember(Order = 9)]
        public string ImageURL { get; set; }
        [DataMember(Order = 10)]
        public int UserID { get; set; }
        [DataMember(Order = 11)]
        public Nullable<int> Status { get; set; }


        [DataMember(Order = 12)]
        public virtual List<REVIEW> REVIEWs { get; set; }
        [DataMember(Order = 13)]
        public virtual USER USER { get; set; }
    }

}
