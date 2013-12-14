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
        private int userID;
        private int petID;
        private int locationID;
        private int eventID;

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
        public int PetID
        {
            get { return petID; }
            set { petID = value; }
        }
        public int LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }
       

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
