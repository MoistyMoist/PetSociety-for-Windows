using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetSociety_for_Windows.Src.Model;


namespace PetSociety_for_Windows.Src.Model
{
    class Review
    {

         //===============================================================//
        //                              Attributes
        //===============================================================//

        private int reviewID;
        private string description;
        private string title;
        private string likes;
        private string diskiles;
        private string dateCreated;
        private string timeCreated;

        private int locationID;

        private User user;
        private Stray stray;

        //===============================================================//
        //                            Constructors
        //===============================================================//

        public Review()
        {

        }

        //===============================================================//
        //                              Accessors
        //===============================================================//
    }
}
