using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Image
    {
        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int imageID;
        private String type;
        private String imageURL;
        private int galleryID;

       
        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Image()
        {
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//

        public int GalleryID
        {
            get { return galleryID; }
            set { galleryID = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int ImageID
        {
            get { return imageID; }
            set { imageID = value; }
        }
        public string ImageURL
        {
            get { return imageURL; }
            set { imageURL = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
