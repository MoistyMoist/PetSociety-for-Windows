using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Pet
    {
        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int petID;
        private String name;
        private String breed; 
        private String sex;
        private String type;
        private String age;
        private String biography;

        private Gallery gallery;
        private User user;
        private Pin pin;
        private Image profileImage;

        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Pet()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//


        public int PetID
        {
            get { return petID; }
            set { petID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public String Age
        {
            get { return age; }
            set { age = value; }
        }
        public String Biography
        {
            get { return biography; }
            set { biography = value; }
        }
        internal Gallery Gallery
        {
            get { return gallery; }
            set { gallery = value; }
        }
        internal User User
        {
            get { return user; }
            set { user = value; }
        }
        internal Pin Pin
        {
            get { return pin; }
            set { pin = value; }
        }
        internal Image ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
