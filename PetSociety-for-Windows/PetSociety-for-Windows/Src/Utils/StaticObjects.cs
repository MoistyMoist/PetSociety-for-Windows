using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetSociety_for_Windows.Src.Model;


namespace PetSociety_for_Windows.Src.Utils
{
    class StaticObjects
    {
        private static string token = "token";
        private static string[] petTypes = { "Dog", "Cat", "Bird","Hamster","Rabbit","Fish","Turtle"};
        private static string[] pins = { "Strays", "Events", "Users", "Lost", "Locations" };//types of pins option on the main map

        

        //definations



        //things for the main page
        private static USER currentUser;
        private static List<LOCATION> mapLocations;
        private static List<STRAY> mapStrays;
        private static List<EVENT> mapEvents;
        private static List<LOST> mapLosts;
        private static List<USER> mapUsers;



        //things for the analysis page
        private static List<LOCATION> analysisLocations;
        private static List<STRAY> analysisStrays;
        private static List<EVENT> analysisEvents;
        private static List<LOST> analysisLosts;





        public static List<LOCATION> MapLocations
        {
            get { return StaticObjects.mapLocations; }
            set { StaticObjects.mapLocations = value; }
        }
        public static List<STRAY> MapStrays
        {
            get { return StaticObjects.mapStrays; }
            set { StaticObjects.mapStrays = value; }
        }
        public static List<EVENT> MapEvents
        {
            get { return StaticObjects.mapEvents; }
            set { StaticObjects.mapEvents = value; }
        }
        public static List<LOST> MapLosts
        {
            get { return StaticObjects.mapLosts; }
            set { StaticObjects.mapLosts = value; }
        }
        public static List<USER> MapUsers
        {
            get { return StaticObjects.mapUsers; }
            set { StaticObjects.mapUsers = value; }
        }
        internal static USER CurrentUser
        {
            get { return StaticObjects.currentUser; }
            set { StaticObjects.currentUser = value; }
        }
        public static string[] PetTypes
        {
            get { return StaticObjects.petTypes; }
            set { StaticObjects.petTypes = value; }
        }
        public static string[] Pins
        {
            get { return StaticObjects.pins; }
            set { StaticObjects.pins = value; }
        }
        public static string Token
        {
            get { return StaticObjects.token; }
            set { StaticObjects.token = value; }
        }


    }
}
