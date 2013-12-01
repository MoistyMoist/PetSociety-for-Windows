using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Event
    {

        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int eventID;
        private String name;   
        private String description;
        private String date;
        private String time;   
        private String duration;
        private String createdDate;
        private String x;       
        private String y;
        private String status;
        private String privicy;

        private Pin pin;
        private User user;
        private List<Attendee> attendees;
        private Gallery gallery;

        

        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Event()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        internal Gallery Gallery
        {
            get { return gallery; }
            set { gallery = value; }
        }
        internal List<Attendee> Attendees
        {
            get { return attendees; }
            set { attendees = value; }
        }
        internal User User
        {
            get { return user; }
            set { user = value; }
        }
        internal Pin Pin
        {
            get { return pin; }
            set { pin = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public int EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        public String Date
        {
            get { return date; }
            set { date = value; }
        }
        public String Y
        {
            get { return y; }
            set { y = value; }
        }
        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        public String Privicy
        {
            get { return privicy; }
            set { privicy = value; }
        }
        public String X
        {
            get { return x; }
            set { x = value; }
        }
        public String Time
        {
            get { return time; }
            set { time = value; }
        }
        public String Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public String CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//

    }
}
