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
        private string name;
        private string breed; 
        private char sex;
        private string type;
        private string age;
        private string biography;
        private int userID;
        private int galleryID;
        private string profileImageURL;
        private DateTime dateTimeCreated;

        private Gallery gallery;
        private User user;

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
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int GalleryID
        {
            get { return galleryID; }
            set { galleryID = value; }
        }
        public string ProfileImageURL
        {
            get { return profileImageURL; }
            set { profileImageURL = value; }
        }
        public DateTime DateTimeCreated
        {
            get { return dateTimeCreated; }
            set { dateTimeCreated = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public char Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Biography
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

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
