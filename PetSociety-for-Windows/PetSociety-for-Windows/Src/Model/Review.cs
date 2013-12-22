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
    public partial class REVIEW
    {
        [DataMember(Order = 1)]
        public int ReviewID { get; set; }
        [DataMember(Order = 2)]
        public string Description { get; set; }
        [DataMember(Order = 3)]
        public string Title { get; set; }
        [DataMember(Order = 4)]
        public string Likes { get; set; }
        [DataMember(Order = 5)]
        public string Dislikes { get; set; }
        [DataMember(Order = 6)]
        public Nullable<System.DateTime> DateTimeCreated { get; set; }
        [DataMember(Order = 7)]
        public Nullable<int> LocationID { get; set; }
        [DataMember(Order = 8)]
        public Nullable<int> UserID { get; set; }
        [DataMember(Order = 9)]
        public Nullable<int> StrayID { get; set; }


        [DataMember(Order = 10)]
        public virtual LOCATION LOCATION { get; set; }
        [DataMember(Order = 11)]
        public virtual USER USER { get; set; }
        [DataMember(Order = 12)]
        public virtual STRAY STRAY { get; set; }
    }

}
