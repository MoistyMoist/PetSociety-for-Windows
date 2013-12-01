using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Gallery
    {

        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int galleryID;   
        private Pet pet;
        private User user;

        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Gallery()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        public int GalleryID
        {
            get { return galleryID; }
            set { galleryID = value; }
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
