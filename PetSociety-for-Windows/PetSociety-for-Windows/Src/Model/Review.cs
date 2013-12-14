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
        private DateTime dateTimeCreated;
        private int locationID;
        private int userID;
        private int strayID;

        

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
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int StrayID
        {
            get { return strayID; }
            set { strayID = value; }
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
        public DateTime DateTimeCreated
        {
            get { return dateTimeCreated; }
            set { dateTimeCreated = value; }
        }
        public int LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }
        

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
