using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Achivement
    {
        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int achievementID;
        private String title;
        private String type;
        private String rank;
        private String condition;

        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Achivement()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//


        public String Condition
        {
            get { return condition; }
            set { condition = value; }
        }
        public String Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        public int AchievementID
        {
            get { return achievementID; }
            set { achievementID = value; }
        }


        //===============================================================//
        //                              End
        //===============================================================//
    }
}
