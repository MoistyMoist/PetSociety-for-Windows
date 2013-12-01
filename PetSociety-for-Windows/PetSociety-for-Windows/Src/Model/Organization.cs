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
        private String name;
        private String description;
        private String email;
        private String password;

        private Image image;


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
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        internal Image Image
        {
            get { return image; }
            set { image = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
