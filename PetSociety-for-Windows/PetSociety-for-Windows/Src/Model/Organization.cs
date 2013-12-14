using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Organization
    {
        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int organozationID;
        private string name;
        private string description;
        private string email;
        private string password;
        private string imageURL;


        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Organization()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//


        public int OrganozationID
        {
            get { return organozationID; }
            set { organozationID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string ImageURL
        {
            get { return imageURL; }
            set { imageURL = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
