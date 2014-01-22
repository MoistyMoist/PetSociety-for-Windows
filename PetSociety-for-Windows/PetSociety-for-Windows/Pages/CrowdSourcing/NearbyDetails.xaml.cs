using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PetSociety_for_Windows.Src.RootModel;
using PetSociety_for_Windows.Pages.CrowdSourcing;
using PetSociety_for_Windows.Src.Utils;
using PetSociety_for_Windows.Src.Model;
using PetSociety_for_Windows.Src.HttpRequests;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Media;
using System.IO;
using System.IO.IsolatedStorage;
using PetSociety_for_Windows.Src.RootModel;
using System.Runtime.Serialization.Json;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using System.Windows.Shapes;
using PetSociety_for_Windows.Pages.Others;
using System.Windows.Media.Imaging;


namespace PetSociety_for_Windows.Pages.CrowdSourcing
{
    public partial class NearbyDetails : PhoneApplicationPage
    {

        string locationid;
           
        public NearbyDetails()
        {
            InitializeComponent();

            

            
            
        }



        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
           
         
           
            NavigationContext.QueryString.TryGetValue("locationID", out locationid);

            //textBox.Text = locationid.ToString();

            getDetails();
        }



        public void getDetails()
        { 
              for (int i = 0; i < StaticObjects.MapLocations.Count; i++)
                {
                 //   MessageBox.Show(locationid.ToString());
                    
                  if(StaticObjects.MapLocations.ElementAt(i).LocationID.ToString().Equals(locationid.ToString())){
                     tb_Name.Text = StaticObjects.MapLocations.ElementAt(i).Title.ToString();
                     tb_Desc.Text = StaticObjects.MapLocations.ElementAt(i).Description.ToString();
                     tb_Address.Text = StaticObjects.MapLocations.ElementAt(i).Address.ToString();
                        
                  } }
        }

        
    }
}