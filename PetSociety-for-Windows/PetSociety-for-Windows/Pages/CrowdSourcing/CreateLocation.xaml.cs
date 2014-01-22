using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

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

        }

        private void btn_cancel_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/CrowdSourcing/Nearby.xaml?", UriKind.Relative)); 
        }
    

        
    }
}