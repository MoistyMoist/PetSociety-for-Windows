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
    public partial class IMAGE
    {

        [DataMember(Order = 1)]
        public int ImageID { get; set; }
        [DataMember(Order = 2)]
        public string Type { get; set; }
        [DataMember(Order = 3)]
        public string ImageURL { get; set; }
        [DataMember(Order = 4)]
        public Nullable<int> GalleryID { get; set; }

        [DataMember(Order = 5)]
        public virtual GALLERY GALLERY { get; set; }
    }
}
