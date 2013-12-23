using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PetSociety_for_Windows.Pages
{
    public partial class Map : PhoneApplicationPage
    {
        MapLayer lostLayer;
        MapLayer strayLayer;
        MapLayer eventLayer;
        MapLayer userLayer;
        MapLayer locationLayer;

        double initialPosition;
        bool _viewMoved = false;

        public Map()
        {
            InitializeComponent();
            VisualStateManager.GoToState(this, "Normal", false);
            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
            
            lostLayer = new MapLayer();
            strayLayer = new MapLayer();
            eventLayer = new MapLayer();
            userLayer = new MapLayer();
            locationLayer = new MapLayer();
        }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            LoadLostPins();
            LoadStrayPins();
            LoadUserPins();
            LoadEventPins();
            LoadLocationPins();
        }
        private void OpenClose_Left(object sender, RoutedEventArgs e)
        {
            var left = Canvas.GetLeft(LayoutRoot);
            if (left > -100)
            {
                ApplicationBar.IsVisible = true;
                MoveViewWindow(-420);
            }
            else
            {
                ApplicationBar.IsVisible = false;
                MoveViewWindow(0);
            }
        }
        private void OpenClose_Right(object sender, RoutedEventArgs e)
        {
            var left = Canvas.GetLeft(LayoutRoot);
            if (left > -520)
            {
                ApplicationBar.IsVisible = false;
                MoveViewWindow(-840);
            }
            else
            {
                ApplicationBar.IsVisible = true;
                MoveViewWindow(-420);
               
            }
        }

        void MoveViewWindow(double left)
        {
            _viewMoved = true;
            if (left==-420)
                ApplicationBar.IsVisible = true;
            else
                ApplicationBar.IsVisible = false;
            ((Storyboard)canvas.Resources["moveAnimation"]).SkipToFill();
            ((DoubleAnimation)((Storyboard)canvas.Resources["moveAnimation"]).Children[0]).To = left;
            ((Storyboard)canvas.Resources["moveAnimation"]).Begin();
        }

        private void canvas_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
         //   if (e.DeltaManipulation.Translation.X != 0)
         //       Canvas.SetLeft(LayoutRoot, Math.Min(Math.Max(-840, Canvas.GetLeft(LayoutRoot) + e.DeltaManipulation.Translation.X), 0));
        }
        private void canvas_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            _viewMoved = false;
            initialPosition = Canvas.GetLeft(LayoutRoot);
        }
        private void canvas_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            var left = Canvas.GetLeft(LayoutRoot);
            if (_viewMoved)
                return;
            if (Math.Abs(initialPosition - left) < 100)
            {
                //bouncing back
               // MoveViewWindow(initialPosition);
                //return;
            }
            //change of state
            if (initialPosition - left > 0)
            {
                //slide to the left
                if (initialPosition > -420)
                     MoveViewWindow(-420);
                else
                    MoveViewWindow(-840);
            }
            else
            {
                //slide to the right
                if (initialPosition< -420)
                      MoveViewWindow(-420);
                else
                    MoveViewWindow(0);
            }

        }
       
        private void NavigateToSearch(object sender, RoutedEventArgs e)
        {
            OpenClose_Left(null,null);
            NavigationService.Navigate(new Uri("/Pages/Others/SearchAddress.xaml", UriKind.Relative));
        }
        private void NavigateToProfile(object sender, RoutedEventArgs e)
        {
            OpenClose_Left(null, null);
            NavigationService.Navigate(new Uri("/Pages/Profile/Profile.xaml", UriKind.Relative));
        }
        private void NavigateToEvent(object sender, RoutedEventArgs e)
        {
            OpenClose_Left(null, null);
            NavigationService.Navigate(new Uri("/Pages/Event/Event.xaml", UriKind.Relative));
        }
        private void NavigateToLost(object sender, RoutedEventArgs e)
        {
            OpenClose_Left(null, null);
            NavigationService.Navigate(new Uri("/Pages/Lost/Lost.xaml", UriKind.Relative));
        }
        private void NavigateToStray(object sender, RoutedEventArgs e)
        {
            OpenClose_Left(null, null);
            NavigationService.Navigate(new Uri("/Pages/CrowdSourcing/Stray.xaml", UriKind.Relative));
        }
        private void NavigateToAnalysis(object sender, RoutedEventArgs e)
        {
            OpenClose_Left(null, null);
            NavigationService.Navigate(new Uri("/Pages/Analysis/Analysis.xaml", UriKind.Relative));
        }
        private void NavigateToNearby(object sender, RoutedEventArgs e)
        {
            OpenClose_Left(null, null);
            NavigationService.Navigate(new Uri("/Pages/CrowdSourcing/Nearby.xaml", UriKind.Relative));
        }
        private void NavigateToSetting(object sender, RoutedEventArgs e)
        {
            OpenClose_Left(null, null);
            NavigationService.Navigate(new Uri("/Pages/Others/Setting.xaml", UriKind.Relative));
        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            IAsyncResult result = Microsoft.Xna.Framework.GamerServices.Guide.BeginShowMessageBox("Logout","Confirm logout?",new string[] { "Close", "Logout" },0,Microsoft.Xna.Framework.GamerServices.MessageBoxIcon.None,null,null);
            result.AsyncWaitHandle.WaitOne();
            int? choice = Microsoft.Xna.Framework.GamerServices.Guide.EndShowMessageBox(result);
            if (choice.HasValue)
            {
                if (choice.Value == 1)
                {
                    IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
                    file.CreateDirectory("RootFolder");
                    StreamWriter streamWriterFile = new StreamWriter(new
                    IsolatedStorageFileStream("RootFolder\\Antuation.txt", FileMode.OpenOrCreate, file));
                    streamWriterFile.WriteLine("");
                    streamWriterFile.WriteLine("");
                    streamWriterFile.Close();


                    OpenClose_Left(null, null);
                    StaticObjects.CurrentUser = null;
                    AppLifetimeHelper close = new AppLifetimeHelper();
                    //close.CloseApplication();
                    NavigationService.Navigate(new Uri("/Pages/Others/LoginPage.xaml", UriKind.Relative));
                }
            }
        }
        
        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Resources/AppbarIcon/Dark/feature.camera.png", UriKind.Relative));
            appBarButton.Text = "Add Location";
            ApplicationBar.Buttons.Add(appBarButton);
        }
        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StaticObjects.CurrentUser = null;
            AppLifetimeHelper close = new AppLifetimeHelper();
            close.CloseApplication();
        }
    
        private void LoadLostPins()
        {
            if (StaticObjects.MapLosts == null || StaticObjects.MapLosts.Count == 0)
            {
                progressBar.Opacity = 100;
                WebClient loginRequest = new WebClient();
                loginRequest.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RetrieveLostComplete);
                loginRequest.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/RetrieveLost?INtoken=" + StaticObjects.Token + "&INfound=" + 0));
            }
            else
            {
                PlotLostPins();
            }
        }
        private void RetrieveLostComplete(object sender, DownloadStringCompletedEventArgs e)
        {
           MessageBox.Show(e.Result.ToString());
           LostModel childlist = new LostModel();
           MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
           DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
           childlist = ser.ReadObject(ms) as LostModel;
           StaticObjects.MapLosts = childlist.Data;
           PlotLostPins();
        }
        private void PlotLostPins()
        {
            Pushpin pushPin = new Pushpin();
            GeoCoordinate supermartLatLong = new GeoCoordinate(1.36, 103.8);

            pushPin.Location = supermartLatLong;
            pushPin.Template = this.Resources["lostPin"] as ControlTemplate;
            //pushPin.Content = "wtf";
            //pushPin.ContentTemplate = this.Resources["PushpinControlTemplate2"] as DataTemplate;
            pushPin.Tap += new EventHandler<GestureEventArgs>(pushPin_Tap);

            lostLayer.Children.Add(pushPin);
            mainMap.Children.Add(lostLayer);
            mainMap.SetView(supermartLatLong,18.0);
        }
        private void LoadStrayPins()
        {
        
        }
        private void RetrieveStrayComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }
        private void LoadUserPins()
        {
            
        }
        private void RetrieveUserComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }
        private void LoadEventPins()
        {
            
        }
        private void RetrieveEventComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }
        private void LoadLocationPins()
        {
            
        }
        private void RetrieveLocationComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }


        private void pushPin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Pushpin pin = new Pushpin();

            pin = (Pushpin)lostLayer.Children.ElementAt(0);
           // pin.Template = pin.Template;
           // pin.ContentTemplate = this.Resources["PushpinControlTemplate2"] as DataTemplate;
          //  pin.DataContext = StaticObjects.MapLosts.ElementAt(0);
            e.Handled = true;
        }

        public DataTemplate content { get; set; }
    }

}