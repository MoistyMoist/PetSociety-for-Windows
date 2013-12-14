﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetSociety_for_Windows.Src.Model;


namespace PetSociety_for_Windows.Src.Utils
{
    class StaticObjects
    {
        private static string token="token";
        private static string[] petTypes = { "Dog", "Cat", "Bird" };
        private static string[] pins = {"Strays","Events","Users","Lost","Locations"};//types of pins option on the main map
        
        //things for the main page
        private static User currentUser;
        private static List<Location> mapLocations;
        private static List<Stray> mapStrays;
        private static List<Event> mapEvents;
        private static List<Lost> mapLosts;


        //things for the analysis page
        private static List<Location> analysisLocations;
        private static List<Stray> analysisStrays;
        private static List<Event> analysisEvents;
        private static List<Lost> analysisLosts;

    }
}
