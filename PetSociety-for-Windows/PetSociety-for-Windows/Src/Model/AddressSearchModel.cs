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
    class AddressSearchModel
    {
        [DataMember(Name = "SearchResults")]
        public List<ADDRESS> SEARCHVAL { get; set; }
    }
}
