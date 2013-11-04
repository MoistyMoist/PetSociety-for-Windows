using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetSociety_for_Windows.Src.Model
{
    class Pet
    {
        //===============================================================//
        //                              Attributes
        //===============================================================//

        private int petID;
        private string name;
        private string sex;
        private string type;
        private int age;
        private string biography;
        private int avatarID;
        //image,icon? x, y?

        //===============================================================//
        //                           Constructors
        //===============================================================//

        public Pet()
        {
        }
        public Pet(string INname, string INsex, string INtype, int INage, string INbiography, int InavatarID)
        {
            this.name = INname;
            this.sex = INsex;
            this.type = INtype;
            this.age = INage;
            this.biography = INbiography;
            this.avatarID = InavatarID;
        }

        //===============================================================//
        //                              Accessors
        //===============================================================//


        public int PetID
        {
            get { return petID; }
            set { petID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }
        public int AvatarID
        {
            get { return avatarID; }
            set { avatarID = value; }
        }

        //===============================================================//
        //                              End
        //===============================================================//
    }
}
