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
        private User user;   
        private User friend;
        private String accepted;
       
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
        public String Accepted
        {
            get { return accepted; }
            set { accepted = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
