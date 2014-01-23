using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Pages.Lost
{
    class ListBoxLost
    {
        public int petID { get; set; }
        public String name { get; set; }
        public String address { get; set; }
        public String description { get; set; }

        public ListBoxLost(int petID1, String name1, String address1, String desc1)
        {
            petID = petID1;
            name = name1;
            address = address1;
            description = desc1;
        }
        
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Address
        {
            get { return address; }
            set { address = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        } 

    }
}
