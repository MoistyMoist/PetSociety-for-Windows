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
        private string name;
        private string description;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private DateTime dateTimeCreated;
        private double x;       
        private double y;
        private int status;
        private int privicy;
        private int userID;
        private int galleryID;
        

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
        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }
        public DateTime DateTimeCreated
        {
            get { return dateTimeCreated; }
            set { dateTimeCreated = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int GalleryID
        {
            get { return galleryID; }
            set { galleryID = value; }
        }
        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
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
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public int Privicy
        {
            get { return privicy; }
            set { privicy = value; }
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }
 

        //===============================================================//
        //                              End
        //===============================================================//

    }
}
