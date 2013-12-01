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
