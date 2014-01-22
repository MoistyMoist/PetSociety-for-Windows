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
    public partial class CreateLocation : PhoneApplicationPage
    {
        public CreateLocation()
        {
            InitializeComponent();
        }

      

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GeoCoordinate currentLocation;

            string lan;
            string longg;
            NavigationContext.QueryString.TryGetValue("lan", out lan);
            NavigationContext.QueryString.TryGetValue("lon", out longg);

            tb_Lat.Text = lan.ToString();
            tb_Long.Text = longg.ToString();

     
                
        }

      
        private void btn_create_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Uri createLocation = new System.Uri("http://petsociety.cloudapp.net/api/AddLocation?token=" + StaticObjects.Token
                                 + "&INx=" + tb_Lat.Text
                                 + "&INy=" + tb_Long.Text
                                 + "&INdescription=" + tb_Desc.Text.ToString()
                                 + "&INtitle=" + tb_Title.Text.ToString()
                                 + "&INaddress=" + tb_Address.Text.ToString()
                                 + "&INtype=" + "Shop"
                                 + "&INuserID=" + StaticObjects.CurrentUser.UserID);
            MessageBox.Show(createLocation.ToString());

            WebClient Request = new WebClient();
            Request.DownloadStringCompleted += new DownloadStringCompletedEventHandler(AddLocation);
            Request.DownloadStringAsync(createLocation);



        }
        private void AddLocation(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show("Location added");
            NavigationService.Navigate(new Uri("/Pages/CrowdSourcing/Nearby.xaml?", UriKind.Relative)); 

        }

        private void btn_cancel_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/CrowdSourcing/Nearby.xaml?", UriKind.Relative)); 
        }
    

        
    }
}