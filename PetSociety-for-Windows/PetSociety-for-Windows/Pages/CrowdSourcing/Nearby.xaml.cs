using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Controls.Maps;
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
    public partial class Nearby : PhoneApplicationPage
    {
        GeoCoordinateWatcher gps;
        MapLayer NearbyLocationsLayer;
        Pushpin selectedPin;
        String locationId;

        public Nearby()
        {
            InitializeComponent();
            NearbyLocationsLayer = new MapLayer();
            LoadNearbyLocation(null, null);

            if (gps == null)
            {
                gps = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                gps.MovementThreshold = 20;
                //gps.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(GpsPositionChanged);
            }
            gps.Start();
        }

        
          




        private void LoadNearbyLocation(object sender, EventArgs e)
        {
            if (nearbyMap.Children.Contains(NearbyLocationsLayer))
            {
                nearbyMap.Children.Remove(NearbyLocationsLayer);
            }
            else
            {
                progressBar.Opacity = 100;
                WebClient Request = new WebClient();
                Request.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RetrieveAccidentsComplete);
                Request.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/RetrieveLocation?INtoken=" + StaticObjects.Token));
            }
        }
        private void RetrieveAccidentsComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            // MessageBox.Show(e.Result.ToString());
            progressBar.Opacity = 0;
            LocationModel childlist = new LocationModel();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
            childlist = ser.ReadObject(ms) as LocationModel;
            if (childlist.Status != 1)
                StaticObjects.MapLocations = childlist.Data;
            DrawNearbyLocations();
        }
        private void DrawNearbyLocations()
        {
            if (nearbyMap.Children.Contains(NearbyLocationsLayer))
                nearbyMap.Children.Remove(NearbyLocationsLayer);
            if (StaticObjects.MapLocations != null)
            {
                NearbyLocationsLayer = new MapLayer();
                for (int i = 0; i < StaticObjects.MapLocations.Count; i++)
                {
                    Pushpin pushPin = new Pushpin();
                    GeoCoordinate LatLong = new GeoCoordinate(StaticObjects.MapLocations.ElementAt(i).X, StaticObjects.MapLocations.ElementAt(i).Y);
                    pushPin.Tag = StaticObjects.MapLocations.ElementAt(i).LocationID;
                    pushPin.TabIndex = i;
                    pushPin.Location = LatLong;
                    pushPin.Template = this.Resources["NearbyPin"] as ControlTemplate;
                    pushPin.Tap += new EventHandler<GestureEventArgs>(NearbyPinIconClick);
                    NearbyLocationsLayer.Children.Add(pushPin);

                }
                nearbyMap.Children.Add(NearbyLocationsLayer);

            }


        }
        private void NearbyPinIconClick(object sender, GestureEventArgs e)
        {
            Pushpin pin = (Pushpin)sender;
            //  for (int i = 0; i < StaticObjects.MapLocations.Count; i++)
            //   {

            // tb.Text = StaticObjects.MapLocations.ElementAt(i).LocationID.ToString();
            //  locationId = StaticObjects.MapLocations.ElementAt(i).LocationID.ToString();

            //Application.Current.Resources.Add("NavigationParam", <);

            NavigationService.Navigate(new Uri("/NearbyDetails.xaml?msg=", UriKind.Relative));

            // }

        }

        private void nearbyCSBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NearbyCrowdSource.xaml", UriKind.Relative));
        }

    }
}