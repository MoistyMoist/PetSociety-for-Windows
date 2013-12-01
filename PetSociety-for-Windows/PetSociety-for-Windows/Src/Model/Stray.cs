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
        private String x;
        private String y;
        private String biography;
        private String title;
        private String timeSeen;
        private String dateSeen;
        private String type;
        private String breed;

        private Image image;
        private Pin pin;
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
        public String X
        {
            get { return x; }
            set { x = value; }
        }
        public String Y
        {
            get { return y; }
            set { y = value; }
        }
        public String Biography
        {
            get { return biography; }
            set { biography = value; }
        }
        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        public String TimeSeen
        {
            get { return timeSeen; }
            set { timeSeen = value; }
        }
        public String DateSeen
        {
            get { return dateSeen; }
            set { dateSeen = value; }
        }
        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        public String Breed
        {
            get { return breed; }
            set { breed = value; }
        }
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
        public Pin Pin
        {
            get { return pin; }
            set { pin = value; }
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
