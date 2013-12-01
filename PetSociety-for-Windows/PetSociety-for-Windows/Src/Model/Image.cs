using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Image
    {
        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int imageID;
        private String type;
        private String imageURL;
       
        private User user;
        private Pet pet;
        private Gallery gallery;

       
        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Image()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        internal Gallery Gallery
        {
            get { return gallery; }
            set { gallery = value; }
        }
        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        public int ImageID
        {
            get { return imageID; }
            set { imageID = value; }
        }
        public String ImageURL
        {
            get { return imageURL; }
            set { imageURL = value; }
        }
        internal User User
        {
            get { return user; }
            set { user = value; }
        }
        internal Pet Pet
        {
            get { return pet; }
            set { pet = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
