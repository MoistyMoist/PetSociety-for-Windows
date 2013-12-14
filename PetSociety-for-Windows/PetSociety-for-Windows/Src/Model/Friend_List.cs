using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Friend_List
    {
        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int friend_listID;
        private int userID;
        private int friendID;

        private User user;
        private User friend;
       

        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Friend_List()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        public int Friend_listID
        {
            get { return friend_listID; }
            set { friend_listID = value; }
        }
        public int FriendID
        {
            get { return friendID; }
            set { friendID = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
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

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
