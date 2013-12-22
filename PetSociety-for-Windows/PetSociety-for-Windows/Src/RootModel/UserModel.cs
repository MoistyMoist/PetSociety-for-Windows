using System;
using System.Collections.Generic;
using System.Linq;
using PetSociety_for_Windows.Src.Model;
using System.Runtime.Serialization;


namespace PetSociety_for_Windows.Src.RootModel
{
    public class UserModel
    {


        public int Status { get; set; }
        public string Message { get; set; }
        public List<USER> Data { get; set; }
        public List<string> ErrorList { get; set; }


        public UserModel()
        {
            this.Status = 0;
            this.Message = "";
            this.Data = null;
            this.ErrorList = null;
        }
    }
}