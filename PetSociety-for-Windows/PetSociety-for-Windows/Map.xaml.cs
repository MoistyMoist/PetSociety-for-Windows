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
using System.Windows.Shapes;
using PetSociety_for_Windows.Pages.Others;
using System.Windows.Media.Imaging;

namespace PetSociety_for_Windows.Pages
{
    public partial class Map : PhoneApplicationPage
    {
        MapLayer lostLayer;
        MapLayer strayLayer;
        MapLayer eventLayer;
        MapLayer userLayer;
        MapLayer locationLayer;
        Pushpin selectedPin;
        int selectedPinType;
        int selectedStrayType;
        int selectedUserType;
        int selectedLocationType;

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
            LoadLostPins(null,null);
            LoadStrayPins(null, null);
            LoadUserPins(null, null);
           // LoadEventPins(null, null);
           // LoadLocationPins(null, null);
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

        private void LoadLostPins(object sender, RoutedEventArgs e)
        {
            if ((StaticObjects.MapLosts == null || StaticObjects.MapLosts.Count == 0)||(e!=null))
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
          // MessageBox.Show(e.Result.ToString());
           LostModel childlist = new LostModel();
           MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
           DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
           childlist = ser.ReadObject(ms) as LostModel;
           StaticObjects.MapLosts = childlist.Data;
           PlotLostPins();
        }
        private void PlotLostPins()
        {
            if (lostLayer.Children.Count != 0)
                mainMap.Children.Remove(lostLayer);
            if (StaticObjects.MapLosts != null)
            {
                lostLayer = new MapLayer();
                for (int i = 0; i < StaticObjects.MapLosts.Count; i++)
                {
                    Pushpin pushPin = new Pushpin();
                    GeoCoordinate LatLong = new GeoCoordinate(StaticObjects.MapLosts.ElementAt(i).X, StaticObjects.MapLosts.ElementAt(i).Y);
                    pushPin.Tag = StaticObjects.MapLosts.ElementAt(i).LostID;
                    pushPin.TabIndex = i;
                    pushPin.Location = LatLong;
                    pushPin.Template = this.Resources["LostPinIcon"] as ControlTemplate;
                    pushPin.Tap += new EventHandler<GestureEventArgs>(LostPinTap);
                    lostLayer.Children.Add(pushPin);
                }
                mainMap.Children.Add(lostLayer);
            }
        }
        private void LostPinTap(object sender, GestureEventArgs e)
        {
            Pushpin pin = (Pushpin)sender;
            if (selectedPin != null)
            {
                if (selectedPinType == 0)
                    selectedPin.Template = this.Resources["LostPinIcon"] as ControlTemplate;
                if (selectedPinType == 1)
                {
                    if (selectedStrayType == 0)
                        selectedPin.Template = this.Resources["StrayDogPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 1)
                        selectedPin.Template = this.Resources["StrayCatPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 2)
                        selectedPin.Template = this.Resources["StrayBirdPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 3)
                        selectedPin.Template = this.Resources["StrayhamsterPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 4)
                        selectedPin.Template = this.Resources["StrayRabbitPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 5)
                        selectedPin.Template = this.Resources["StrayFishPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 6)
                        selectedPin.Template = this.Resources["StrayTurtlePinIcon"] as ControlTemplate;

                }
                if (selectedPinType == 2)
                {
                    if (selectedUserType == 0)
                        selectedPin.Template = this.Resources["UserMalePinIcon"] as ControlTemplate;
                    if (selectedUserType == 1)
                        selectedPin.Template = this.Resources["UserFemalePinIcon"] as ControlTemplate;
                }
                if (selectedPinType == 3)
                    selectedPin.Template = this.Resources["EventPinIcon"] as ControlTemplate;
                if (selectedPinType == 4)
                    selectedPin.Template = this.Resources["LocationPinIcon"] as ControlTemplate;
            }

            selectedPin = pin;
            selectedPinType = 0;

            int lostID = Convert.ToInt16(pin.TabIndex);
            pin = (Pushpin)lostLayer.Children.ElementAt(lostID);
            
            LostContentTempletControl content = new LostContentTempletControl();
            for (int i = 0; i < StaticObjects.MapLosts.Count; i++)
            {
                if (StaticObjects.MapLosts.ElementAt(i).LostID == Convert.ToInt16(pin.Tag))
                {
                    content.title.Text = StaticObjects.MapLosts.ElementAt(i).Address;
                    break;
                }
            }
            pin.Content = content;
            pin.Template = this.Resources["LostPinIconClick"] as ControlTemplate;
      
            mainMap.SetView(pin.Location, mainMap.ZoomLevel);
        }

        private void LoadStrayPins(object sender, RoutedEventArgs e)
        {
            if ((StaticObjects.MapStrays == null || StaticObjects.MapStrays.Count == 0)||(e!=null))
            {
                progressBar.Opacity = 100;
                WebClient loginRequest = new WebClient();
                loginRequest.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RetrieveStrayComplete);
                loginRequest.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/RetrieveStray?INtoken=" + StaticObjects.Token));
            }
            else
            {
                PlotStrayPins();
            }
        }
        private void RetrieveStrayComplete(object sender, DownloadStringCompletedEventArgs e)
        {
           // MessageBox.Show(e.Result.ToString());
            StrayModel childlist = new StrayModel();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
            childlist = ser.ReadObject(ms) as StrayModel;
            StaticObjects.MapStrays = childlist.Data;
            PlotStrayPins();
        }
        private void PlotStrayPins()
        {
            if (strayLayer.Children.Count != 0)
                mainMap.Children.Remove(strayLayer);
            if (StaticObjects.MapStrays != null)
            {
                strayLayer = new MapLayer();
                for (int i = 0; i < StaticObjects.MapStrays.Count; i++)
                {
                    Pushpin pushPin = new Pushpin();
                    GeoCoordinate LatLong = new GeoCoordinate(StaticObjects.MapStrays.ElementAt(i).X, StaticObjects.MapStrays.ElementAt(i).Y);
                    pushPin.Tag = StaticObjects.MapStrays.ElementAt(i).StrayID;
                    pushPin.TabIndex = i;
                    pushPin.Location = LatLong;
                    string petType=StaticObjects.MapStrays.ElementAt(i).Type.ToUpper();
                    if (petType.Equals("DOG"))
                    {
                        pushPin.Template = this.Resources["StrayDogPinIcon"] as ControlTemplate;
                        selectedStrayType = 0;
                    }
                    if (petType.Equals("CAT"))
                    {
                        pushPin.Template = this.Resources["StrayCatPinIcon"] as ControlTemplate;
                        selectedStrayType = 1;
                    }
                    if (petType.Equals("BIRD"))
                    {
                        pushPin.Template = this.Resources["StrayBirdPinIcon"] as ControlTemplate;
                        selectedStrayType = 2;
                    }
                    if (petType.Equals("HAMSTER"))
                    {
                        pushPin.Template = this.Resources["StrayhamsterPinIcon"] as ControlTemplate;
                        selectedStrayType = 3;
                    }
                    if (petType.Equals("RABBIT"))
                    {
                        pushPin.Template = this.Resources["StrayRabbitPinIcon"] as ControlTemplate;
                        selectedStrayType = 4;
                    }
                    if (petType.Equals("FISH"))
                    {
                        pushPin.Template = this.Resources["StrayFishPinIcon"] as ControlTemplate;
                        selectedStrayType = 5;
                    }
                    if (petType.Equals("TURTLE"))
                    {
                        pushPin.Template = this.Resources["StrayTurtlePinIcon"] as ControlTemplate;
                        selectedStrayType = 6;
                    }

                    pushPin.Tap += new EventHandler<GestureEventArgs>(StrayPinTap);
                    strayLayer.Children.Add(pushPin);
                }
                mainMap.Children.Add(strayLayer);
            }
        }
        private void StrayPinTap(object sender, GestureEventArgs e)
        {
            Pushpin pin = (Pushpin)sender;
            if (selectedPin != null)
            {
                if (selectedPinType == 0)
                    selectedPin.Template = this.Resources["LostPinIcon"] as ControlTemplate;
                if (selectedPinType == 1)
                {
                    if(selectedStrayType == 0)
                        selectedPin.Template = this.Resources["StrayDogPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 1)
                        selectedPin.Template = this.Resources["StrayCatPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 2)
                        selectedPin.Template = this.Resources["StrayBirdPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 3)
                        selectedPin.Template = this.Resources["StrayhamsterPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 4)
                        selectedPin.Template = this.Resources["StrayRabbitPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 5)
                        selectedPin.Template = this.Resources["StrayFishPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 6)
                        selectedPin.Template = this.Resources["StrayTurtlePinIcon"] as ControlTemplate;

                }
                if (selectedPinType == 2)
                {
                    if(selectedUserType == 0)
                        selectedPin.Template = this.Resources["UserMalePinIcon"] as ControlTemplate;
                    if (selectedUserType == 1)
                        selectedPin.Template = this.Resources["UserFemalePinIcon"] as ControlTemplate;
                }
                if (selectedPinType == 3)
                    selectedPin.Template = this.Resources["EventPinIcon"] as ControlTemplate;
                if (selectedPinType == 4)
                    selectedPin.Template = this.Resources["LocationPinIcon"] as ControlTemplate;
            }

            selectedPin = pin;
            selectedPinType = 1;
            string petType="";

            int strayID = Convert.ToInt16(pin.TabIndex);
            pin = (Pushpin)strayLayer.Children.ElementAt(strayID);

            StrayContentTempletControl content = new StrayContentTempletControl();
            for (int i = 0; i < StaticObjects.MapStrays.Count; i++)
            {
                if (StaticObjects.MapStrays.ElementAt(i).StrayID == Convert.ToInt16(pin.Tag))
                {
                    petType = StaticObjects.MapStrays.ElementAt(i).Type.ToUpper();
                    content.title.Text = StaticObjects.MapStrays.ElementAt(i).Biography;
                    break;
                }
            }
            pin.Content = content;

            if (petType.Equals("DOG"))
            {
                pin.Template = this.Resources["StrayDogPinIconClick"] as ControlTemplate;
                selectedStrayType = 0;
            }
            if (petType.Equals("CAT"))
            {
                pin.Template = this.Resources["StrayCatPinIconClick"] as ControlTemplate;
                selectedStrayType = 1;
            }
            if (petType.Equals("BIRD"))
            {
                pin.Template = this.Resources["StrayBirdPinIconClick"] as ControlTemplate;
                selectedStrayType = 2;
            }
            if (petType.Equals("HAMSTER"))
            {
                pin.Template = this.Resources["StrayhamsterPinIconClick"] as ControlTemplate;
                selectedStrayType = 3;
            }
            if (petType.Equals("RABBIT"))
            {
                pin.Template = this.Resources["StrayRabbitPinIconClick"] as ControlTemplate;
                selectedStrayType = 4;
            }
            if (petType.Equals("FISH"))
            {
                pin.Template = this.Resources["StrayFishPinIconClick"] as ControlTemplate;
                selectedStrayType = 5;
            }
            if (petType.Equals("TURTLE"))
            {
                pin.Template = this.Resources["StrayTurtlePinIconClick"] as ControlTemplate;
                selectedStrayType = 6;
            }

            mainMap.SetView(pin.Location, mainMap.ZoomLevel);
        }

        private void LoadUserPins(object sender, RoutedEventArgs e)
        {
            if ((StaticObjects.MapUsers == null || StaticObjects.MapUsers.Count == 0) || (e != null))
            {
                progressBar.Opacity = 100;
                WebClient loginRequest = new WebClient();
                loginRequest.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RetrieveUserComplete);
                loginRequest.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/RetrieveUser?token=" + StaticObjects.Token));
            }
            else
            {
                PlotUserPins();
            }
        }
        private void RetrieveUserComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            //MessageBox.Show(e.Result.ToString());
            UserModel childlist = new UserModel();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
            childlist = ser.ReadObject(ms) as UserModel;
            StaticObjects.MapUsers = childlist.Data;
            PlotUserPins();
        }
        private void PlotUserPins()
        {
            if (userLayer.Children.Count != 0)
                mainMap.Children.Remove(userLayer);
            if (StaticObjects.MapUsers != null)
            {
                userLayer = new MapLayer();
                for (int i = 0; i < StaticObjects.MapUsers.Count; i++)
                {
                    Pushpin pushPin = new Pushpin();
                    GeoCoordinate LatLong = new GeoCoordinate(Convert.ToDouble(StaticObjects.MapUsers.ElementAt(i).X), (Convert.ToDouble(StaticObjects.MapUsers.ElementAt(i).Y)));
                    pushPin.Tag = StaticObjects.MapUsers.ElementAt(i).UserID;
                    pushPin.TabIndex = i;
                    pushPin.Location = LatLong;
                    if (StaticObjects.MapUsers.ElementAt(i).Sex.Equals("M") || StaticObjects.MapUsers.ElementAt(i).Sex.Equals("m"))
                        pushPin.Template = this.Resources["UserMalePinIcon"] as ControlTemplate;
                    if (StaticObjects.MapUsers.ElementAt(i).Sex.Equals("F") || StaticObjects.MapUsers.ElementAt(i).Sex.Equals("f"))
                        pushPin.Template = this.Resources["UserFemalePinIcon"] as ControlTemplate;
                    pushPin.Tap += new EventHandler<GestureEventArgs>(UserPinTap);
                    userLayer.Children.Add(pushPin);
                }
                mainMap.Children.Add(userLayer);
            }
        }
        private void UserPinTap(object sender, GestureEventArgs e)
        {
            Pushpin pin = (Pushpin)sender;
            if (selectedPin != null)
            {
                if (selectedPinType == 0)
                    selectedPin.Template = this.Resources["LostPinIcon"] as ControlTemplate;
                if (selectedPinType == 1)
                {
                    if (selectedStrayType == 0)
                        selectedPin.Template = this.Resources["StrayDogPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 1)
                        selectedPin.Template = this.Resources["StrayCatPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 2)
                        selectedPin.Template = this.Resources["StrayBirdPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 3)
                        selectedPin.Template = this.Resources["StrayhamsterPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 4)
                        selectedPin.Template = this.Resources["StrayRabbitPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 5)
                        selectedPin.Template = this.Resources["StrayFishPinIcon"] as ControlTemplate;
                    if (selectedStrayType == 6)
                        selectedPin.Template = this.Resources["StrayTurtlePinIcon"] as ControlTemplate;
                }
                if (selectedPinType == 2)
                {
                    if (selectedUserType == 0)
                        selectedPin.Template = this.Resources["UserMalePinIcon"] as ControlTemplate;
                    if (selectedUserType == 1)
                        selectedPin.Template = this.Resources["UserFemalePinIcon"] as ControlTemplate;
                }
                if (selectedPinType == 3)
                    selectedPin.Template = this.Resources["EventPinIcon"] as ControlTemplate;
                if (selectedPinType == 4)
                    selectedPin.Template = this.Resources["LocationPinIcon"] as ControlTemplate;
            }
            selectedPin = pin;
            selectedPinType = 2;

            int userID = Convert.ToInt16(pin.TabIndex);
            pin = (Pushpin)userLayer.Children.ElementAt(userID);
            string sex = "";
            LostContentTempletControl content = new LostContentTempletControl();
            for (int i = 0; i < StaticObjects.MapUsers.Count; i++)
            {
                if (StaticObjects.MapUsers.ElementAt(i).UserID == Convert.ToInt16(pin.Tag))
                {
                    sex = StaticObjects.MapUsers.ElementAt(i).Sex.ToUpper();
                    content.title.Text = StaticObjects.MapUsers.ElementAt(i).Name;
                    break;
                }
            }
            pin.Content = content;
            if (sex.Equals("M"))
            {
                selectedUserType = 0;
                pin.Template = this.Resources["UserMalePinIconClick"] as ControlTemplate;
            }
            if (sex.Equals("F"))
            {
                selectedUserType=1;
                pin.Template = this.Resources["UserFemalePinIconClick"] as ControlTemplate;
            }
            mainMap.SetView(pin.Location, mainMap.ZoomLevel);
        }


        private void LoadEventPins(object sender, RoutedEventArgs e)
        {
            if ((StaticObjects.MapEvents == null || StaticObjects.MapEvents.Count == 0) || (e != null))
            {
                progressBar.Opacity = 100;
                WebClient loginRequest = new WebClient();
                loginRequest.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RetrieveEventComplete);
                loginRequest.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/RetrieveUser?token=" + StaticObjects.Token));
            }
            else
            {
                PlotEventPins();
            }
        }
        private void RetrieveEventComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }
        private void PlotEventPins()
        {
        }
        private void EventPinTap(object sender, GestureEventArgs e)
        {
        }



        private void LoadLocationPins(object sender, RoutedEventArgs e)
        {
            
        }
        private void RetrieveLocationComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }


       

        public DataTemplate content { get; set; }
    }

}