//==========================================================================================================//
// 
//
//
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetSociety_for_Windows.Src.Model;

namespace PetSociety_for_Windows.Src.Model
{
    class User
    {

        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int userID;
        private string name;
        private string brithdate;
        private string password;
        private string address;
        private double x;
        private double y;
        private string biography;
        private int privicy;
        private string sex;
        private string contact;
        private string email;
        private int credibility;

        private Image profileImage;
        private Gallery gallery;
        private Pin pin;
 
        private List<Attendee> attendees;
        private List<Event> events;
        private List<Lost> lost;
        private List<Pet> pets;
        private List<Location> locations;
        private List<Stray> strays;
        private List<Friend_List> friend_list;
        private List<Friend_Request> friend_request;

      
  
        //===============================================================//
        //                            Constructors
        //===============================================================//

        public User()
        {

        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Brithdate
        {
            get { return brithdate; }
            set { brithdate = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }
        public int Privicy
        {
            get { return privicy; }
            set { privicy = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int Credibility
        {
            get { return credibility; }
            set { credibility = value; }
        }
        public Image ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }
        public Gallery Gallery
        {
            get { return gallery; }
            set { gallery = value; }
        }
        public Pin Pin
        {
            get { return pin; }
            set { pin = value; }
        }
        public List<Attendee> Attendees
        {
            get { return attendees; }
            set { attendees = value; }
        }
        public List<Event> Events
        {
            get { return events; }
            set { events = value; }
        }
        public List<Lost> Lost
        {
            get { return lost; }
            set { lost = value; }
        }
        public List<Pet> Pets
        {
            get { return pets; }
            set { pets = value; }
        }
        public List<Location> Locations
        {
            get { return locations; }
            set { locations = value; }
        }
        public List<Stray> Strays
        {
            get { return strays; }
            set { strays = value; }
        }
        public List<Friend_List> Friend_list
        {
            get { return friend_list; }
            set { friend_list = value; }
        }
        public List<Friend_Request> Friend_request
        {
            get { return friend_request; }
            set { friend_request = value; }
        }
        //===============================================================//
        //                              End
        //===============================================================//
    }
}
