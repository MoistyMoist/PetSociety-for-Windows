using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Advert
    {
        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int advertID;
        private Organization organization;
        private String title;
        private String description;
        private String sateCreated;
        private String duration;


        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Advert()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        public String Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public String SateCreated
        {
            get { return sateCreated; }
            set { sateCreated = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        internal Organization Organization
        {
            get { return organization; }
            set { organization = value; }
        }
        public int AdvertID
        {
            get { return advertID; }
            set { advertID = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//

    }
}
