using System;
using System.Collections.Generic;
using System.Linq;
using PetSociety_for_Windows.Src.Model;

namespace PetSociety_for_Windows.Src.RootModel
{
    public class GalleryModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<GALLERY> Data { get; set; }
        public List<string> ErrorList { get; set; }


        public GalleryModel()
        {
            this.Status = 0;
            this.Message = "";
            this.Data = null;
            this.ErrorList = null;
        }
    }
}