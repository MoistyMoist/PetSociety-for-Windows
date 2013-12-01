using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Attendee
    {

        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int attendeeID;
        private String status;
        private Event events;
        private User user;


        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Attendee()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        internal User User
        {
            get { return user; }
            set { user = value; }
        }
        internal Event Events
        {
            get { return events; }
            set { events = value; }
        }
        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        public int AttendeeID
        {
            get { return attendeeID; }
            set { attendeeID = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//


    }
}
