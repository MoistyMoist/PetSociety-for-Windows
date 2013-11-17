using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetSociety_for_Windows.Src.Model;

namespace PetSociety_for_Windows.Classes
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

  
        //===============================================================//
        //                            Constructors
        //===============================================================//

        public User()
        {

        }
        public User(string INname, string INbirthdate, string INpassword, string INaddress, int INx, int INy, string INbiography, int INprivicy, string INsex, string INcontact, string INemail, int INcredibility, int INavatarID)
        {
            this.name = INname;
            this.brithdate = INbirthdate;
            this.password = INpassword;
            this.address = INaddress;
            this.x = INx;
            this.y = INy;
            this.biography = INbiography;
            this.privicy = INprivicy;
            this.sex = INsex;
            this.contact = INcontact;
            this.email = INemail;
            this.credibility = INcredibility;
            this.avatarID = INavatarID;
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
        public int AvatarID
        {
            get { return avatarID; }
            set { avatarID = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
