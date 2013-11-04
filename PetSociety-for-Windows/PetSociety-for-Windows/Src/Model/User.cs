using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Classes
{
    class User
    {
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


        public User()
        {

        }
        public User(string INname, string INbirthdate, string INpassword, string INaddress, int INx, int INy, string INbiography, int INprivicy, string INsex, string INcontact, string INemail, string INcredibility)
        {

        }
        public string getName()
        {
            return this.name;
        }
        public string getBirthdate()
        {
            return this.brithdate;
        }

    }
}
