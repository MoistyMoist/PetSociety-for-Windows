using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetSociety_for_Windows.Src.Model;

namespace PetSociety_for_Windows.Src.Model
{
    class Stray
    {

        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int strayID;
        private double x;
        private double y;
        private string biography;
        private string title;
        private DateTime dateTimeSeen;
        private string type;
        private string breed;
        private int status;
        private int userID;
        private string imageURL;

        private List<Review> reviews;
        private User user;


        //===============================================================//
        //                            Constructors
        //===============================================================//

        public Stray()
        {

        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        public int StrayID
        {
            get { return strayID; }
            set { strayID = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public DateTime DateTimeSeen
        {
            get { return dateTimeSeen; }
            set { dateTimeSeen = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }
        public string ImageURL
        {
            get { return imageURL; }
            set { imageURL = value; }
        }
        public List<Review> Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        //===============================================================//
        //                              End
        //===============================================================//
    }
}
