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
        private String x; 
        private String y;     
        private String description;     
        private String title;       
        private String address;       
        private String type;      
        private String dateCreated;      
        private String timeCreated;
        
        private Pin pin;  
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

        public String X
        {
            get { return x; }
            set { x = value; }
        }
        public int LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }
        public String Y
        {
            get { return y; }
            set { y = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        public String DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }
        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        public String TimeCreated
        {
            get { return timeCreated; }
            set { timeCreated = value; }
        }
        public String Address
        {
            get { return address; }
            set { address = value; }
        }
        internal Pin Pin
        {
            get { return pin; }
            set { pin = value; }
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