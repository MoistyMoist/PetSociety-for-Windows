using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Pin
    {

        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int pinID;
        private Image image;
        private String type;

       
        //===============================================================//
        //                            Constructors
        //===============================================================//

        public Pin()
        {

        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        public int PinID
        {
            get { return pinID; }
            set { pinID = value; }
        }
        internal Image Image
        {
            get { return image; }
            set { image = value; }
        }
        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
