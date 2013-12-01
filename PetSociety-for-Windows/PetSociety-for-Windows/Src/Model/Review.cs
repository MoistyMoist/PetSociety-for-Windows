using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetSociety_for_Windows.Src.Model;


namespace PetSociety_for_Windows.Src.Model
{
    class Review
    {

        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int reviewID;
        private string description;
        private string title;
        private string likes;
        private string diskiles;
        private string dateCreated;
        private string timeCreated;
        private int locationID;

        private User user;
        private Stray stray;

        //===============================================================//
        //                            Constructors
        //===============================================================//

        public Review()
        {

        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        public int ReviewID
        {
            get { return reviewID; }
            set { reviewID = value; }
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
        public string Likes
        {
            get { return likes; }
            set { likes = value; }
        }
        public string Diskiles
        {
            get { return diskiles; }
            set { diskiles = value; }
        }
        public string DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }
        public string TimeCreated
        {
            get { return timeCreated; }
            set { timeCreated = value; }
        }
        public int LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }
        internal User User
        {
            get { return user; }
            set { user = value; }
        }
        internal Stray Stray
        {
            get { return stray; }
            set { stray = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
