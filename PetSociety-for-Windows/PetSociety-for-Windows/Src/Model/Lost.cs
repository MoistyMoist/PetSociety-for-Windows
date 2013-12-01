using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Lost
    {
        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int lostID;
        private String time;
        private String date;
        private String x;       
        private String y;      
        private String address;
        private String desciription;
        private String found;
        private String reward;
        private String dateCreated;

        private Pet pet;
        private User user;

        
        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Lost()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//


        public int LostID
        {
            get { return lostID; }
            set { lostID = value; }
        }
        public String Y
        {
            get { return y; }
            set { y = value; }
        }
        public String X
        {
            get { return x; }
            set { x = value; }
        }
        public String Date
        {
            get { return date; }
            set { date = value; }
        }
        public String Time
        {
            get { return time; }
            set { time = value; }
        }
        public String DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }
        public String Found
        {
            get { return found; }
            set { found = value; }
        }
        public String Address
        {
            get { return address; }
            set { address = value; }
        }
        public String Desciription
        {
            get { return desciription; }
            set { desciription = value; }
        }
        public String Reward
        {
            get { return reward; }
            set { reward = value; }
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
