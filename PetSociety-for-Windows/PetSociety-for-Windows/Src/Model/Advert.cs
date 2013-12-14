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
        private int organizationID;
        private string title;
        private string description;
        private DateTime dateCreated;
        private string duration;


        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Advert()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        internal int OrganizationID
        {
            get { return organizationID; }
            set { organizationID = value; }
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
