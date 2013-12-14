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
        private DateTime dateTimeSeen;
        private double x;       
        private double y;
        private string address;
        private string desciription;
        private char found;
        private string reward;
        private DateTime dateTimeCreated;
        private int petID;
        private int userID;

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
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public DateTime DateTimeSeen
        {
            get { return dateTimeSeen; }
            set { dateTimeSeen = value; }
        }
        public DateTime DateTimeCreated
        {
            get { return dateTimeCreated; }
            set { dateTimeCreated = value; }
        }
        public char Found
        {
            get { return found; }
            set { found = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Desciription
        {
            get { return desciription; }
            set { desciription = value; }
        }
        public string Reward
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
