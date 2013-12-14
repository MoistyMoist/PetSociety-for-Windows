using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Friend_Request
    {

        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int friend_requestID;
        private int accepted;
        private int userID;
        private int friendID;

        private User user;   
        private User friend;
        
       
        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Friend_Request()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        public int Friend_requestID
        {
            get { return friend_requestID; }
            set { friend_requestID = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int FriendID
        {
            get { return friendID; }
            set { friendID = value; }
        }
        internal User User
        {
            get { return user; }
            set { user = value; }
        }
        internal User Friend
        {
            get { return friend; }
            set { friend = value; }
        }
        public int Accepted
        {
            get { return accepted; }
            set { accepted = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
