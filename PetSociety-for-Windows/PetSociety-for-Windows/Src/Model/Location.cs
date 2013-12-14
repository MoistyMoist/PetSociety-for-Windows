using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Location
    {

        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int locationID;
        private double x;
        private double y;     
        private string description;
        private string title;
        private string address;
        private string type;      
        private DateTime dateTimeCreated;
        private int userID;
        private int galleryID;
        
        private User user;
        private List<Review> reviews;
        private Gallery gallery;
        

        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Location()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        public double X
        {
            get { return x; }
            set { x = value; }
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
        public int LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public DateTime DateTimeCreated
        {
            get { return dateTimeCreated; }
            set { dateTimeCreated = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        internal User User
        {
            get { return user; }
            set { user = value; }
        }
        internal Gallery Gallery
        {
            get { return gallery; }
            set { gallery = value; }
        }
        internal List<Review> Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//

    }
}