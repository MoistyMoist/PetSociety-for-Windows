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

namespace PetSociety_for_Windows.Pages.Analysis
{
    public partial class Analysis : PhoneApplicationPage
    {
        double initialPosition;
        bool _viewMoved = false;

        MapLayer AccidentHeatLayer;
        MapLayer StrayHeatLayer;
        MapLayer EventHeatLayer;
        MapLayer LostHeatLayer;
        Canvas c;

        public Analysis()
        {
            InitializeComponent();
            VisualStateManager.GoToState(this, "Normal", false);
            BuildLocalizedApplicationBar();

            AccidentHeatLayer = new MapLayer();
            StrayHeatLayer = new MapLayer();
            EventHeatLayer = new MapLayer();
            LostHeatLayer = new MapLayer();

            //MapZoom(null,null);
            buildHeatMaps();
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
       

        void MoveViewWindow(double left)
        {
            _viewMoved = true;
            if (left == -420)
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
                if (initialPosition < -420)
                    MoveViewWindow(-420);
                else
                    MoveViewWindow(0);
            }

        }
        private void NavigateToHome(object sender, RoutedEventArgs e)
        {
            OpenClose_Left(null, null);
            NavigationService.Navigate(new Uri("/Map.xaml", UriKind.Relative));
        }
        private void NavigateToSearch(object sender, RoutedEventArgs e)
        {
            OpenClose_Left(null, null);
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
            IAsyncResult result = Microsoft.Xna.Framework.GamerServices.Guide.BeginShowMessageBox("Logout", "Confirm logout?", new string[] { "Close", "Logout" }, 0, Microsoft.Xna.Framework.GamerServices.MessageBoxIcon.None, null, null);
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
            
            ApplicationBarIconButton Accidents = new ApplicationBarIconButton(new Uri("/Resources/hamster.png", UriKind.Relative));
            Accidents.Text = "Accidents";
            Accidents.Click += new EventHandler(LoadAccidentHeatMap);
            ApplicationBar.Buttons.Add(Accidents);

            ApplicationBarIconButton LostPets = new ApplicationBarIconButton(new Uri("/Resources/Icons/ic_3-rating-important.png", UriKind.Relative));
            LostPets.Text = "Lost pets";
            LostPets.Click += new EventHandler(LoadLostHeatMap);
            ApplicationBar.Buttons.Add(LostPets);

            ApplicationBarIconButton Strays = new ApplicationBarIconButton(new Uri("/Resources/Icons/ic_2-action-search.png", UriKind.Relative));
            Strays.Text = "Stray Animales";
            Strays.Click += new EventHandler(LoadStrayHeatMap);
            ApplicationBar.Buttons.Add(Strays);

            ApplicationBarIconButton Events = new ApplicationBarIconButton(new Uri("/Resources/Icons/ic_4-collections-go-to-today.png", UriKind.Relative));
            Events.Text = "Events";
            Events.Click += new EventHandler(LoadEventHeatMap);
            ApplicationBar.Buttons.Add(Events);
        }

        private void LoadEventHeatMap(object sender, EventArgs e)
        {
            if (mainMap.Children.Contains(EventHeatLayer))
            {
                mainMap.Children.Remove(EventHeatLayer);
            }
            else
            {
                progressBar.Opacity = 100;
                WebClient Request = new WebClient();
                Request.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RetrieveEventsComplete);
                Request.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/RetrieveEvent?INtoken=" + StaticObjects.Token));
            }    
        }
        private void RetrieveEventsComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            progressBar.Opacity = 0;
            EventModel childlist = new EventModel();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
            childlist = ser.ReadObject(ms) as EventModel;
            if (childlist.Status != 1)
                StaticObjects.AnalysisEvents = childlist.Data;
            DrawEventHeatMap();
        }
        private void DrawEventHeatMap()
        {
            if (mainMap.Children.Contains(EventHeatLayer))
                mainMap.Children.Remove(EventHeatLayer);
            if (StaticObjects.AnalysisEvents != null)
            {
                EventHeatLayer = new MapLayer();
                for (int i = 0; i < StaticObjects.AnalysisEvents.Count; i++)
                {
                    Pushpin pushPin = new Pushpin();
                    GeoCoordinate LatLong = new GeoCoordinate(StaticObjects.AnalysisEvents.ElementAt(i).X, StaticObjects.AnalysisEvents.ElementAt(i).Y);
                    pushPin.Tag = StaticObjects.AnalysisEvents.ElementAt(i).EventID;
                    pushPin.TabIndex = i;
                    pushPin.Location = LatLong;
                    pushPin.Template = this.Resources["HeatMapCluster"] as ControlTemplate;
                    //pushPin.Tap += new EventHandler<GestureEventArgs>(LostPinTap);
                    EventHeatLayer.Children.Add(pushPin);
                }
                mainMap.Children.Add(EventHeatLayer);
            }
        }

        private void LoadAccidentHeatMap(object sender, EventArgs e)
        {
            if(mainMap.Children.Contains(AccidentHeatLayer))
            {
                mainMap.Children.Remove(AccidentHeatLayer);
            }
            else
            {
                progressBar.Opacity = 100;
                WebClient Request = new WebClient();
                Request.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RetrieveAccidentsComplete);
                Request.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/RetrieveLocation?INtoken="+StaticObjects.Token+"&INtype=Accidents"));
            }
        }
        private void RetrieveAccidentsComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            //MessageBox.Show(e.Result.ToString());
            LocationModel childlist = new LocationModel();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
            childlist = ser.ReadObject(ms) as LocationModel;
            if (childlist.Status != 1)
                StaticObjects.AnalysisAccidents = childlist.Data;
            DrawAccidentHeatMap();
        }
        private void DrawAccidentHeatMap()
        {
            if (mainMap.Children.Contains(AccidentHeatLayer))
                mainMap.Children.Remove(AccidentHeatLayer);
            if (StaticObjects.AnalysisAccidents != null)
            {
                AccidentHeatLayer = new MapLayer();
                for (int i = 0; i < StaticObjects.AnalysisAccidents.Count; i++)
                {
                    Pushpin pushPin = new Pushpin();
                    GeoCoordinate LatLong = new GeoCoordinate(StaticObjects.AnalysisAccidents.ElementAt(i).X, StaticObjects.AnalysisAccidents.ElementAt(i).Y);
                    pushPin.Tag = StaticObjects.AnalysisAccidents.ElementAt(i).LocationID;
                    pushPin.TabIndex = i;
                    pushPin.Location = LatLong;
                    pushPin.Template = this.Resources["HeatMapCluster"] as ControlTemplate;
                    //pushPin.Tap += new EventHandler<GestureEventArgs>(LostPinTap);
                    AccidentHeatLayer.Children.Add(pushPin);
                }
                mainMap.Children.Add(AccidentHeatLayer);
            }
        }


        private void LoadLostHeatMap(object sender, EventArgs e)
        {
            ApplicationBar.MenuItems.Clear();

            ApplicationBarMenuItem Dog = new ApplicationBarMenuItem();
            Dog.Text = "Show lost Dogs";
            ApplicationBar.MenuItems.Add(Dog);

            ApplicationBarMenuItem Cat = new ApplicationBarMenuItem();
            Cat.Text = "Show lost Cats";
            ApplicationBar.MenuItems.Add(Cat);

            ApplicationBarMenuItem Fish = new ApplicationBarMenuItem();
            Fish.Text = "Show lost Fishes";
            ApplicationBar.MenuItems.Add(Fish);

            ApplicationBarMenuItem Bird = new ApplicationBarMenuItem();
            Bird.Text = "Show lost Birds";
            ApplicationBar.MenuItems.Add(Bird);

            ApplicationBarMenuItem Hamster = new ApplicationBarMenuItem();
            Hamster.Text = "Show lost Hamsters";
            ApplicationBar.MenuItems.Add(Hamster);

            ApplicationBarMenuItem Rabbit = new ApplicationBarMenuItem();
            Rabbit.Text = "Show Lost Rabbits";
            ApplicationBar.MenuItems.Add(Rabbit);

            ApplicationBarMenuItem Turtle = new ApplicationBarMenuItem();
            Turtle.Text = "Show Lost Turtles";
            ApplicationBar.MenuItems.Add(Turtle);

            if (mainMap.Children.Contains(LostHeatLayer))
            {
                mainMap.Children.Remove(LostHeatLayer);
            }
            else
            {
                progressBar.Opacity = 100;
                WebClient Request = new WebClient();
                Request.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RetrieveAllLostComplete);
                Request.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/RetrieveLost?INtoken=" + StaticObjects.Token));
            }
        }
        private void RetrieveAllLostComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            //MessageBox.Show(e.Result.ToString());
            LostModel childlist = new LostModel();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
            childlist = ser.ReadObject(ms) as LostModel;
            if (childlist.Status != 1)
                StaticObjects.AnalysisLosts = childlist.Data;
            DrawAccidentHeatMap();
        }
        private void DrawLostHeatMap()
        {
            if (mainMap.Children.Contains(LostHeatLayer))
                mainMap.Children.Remove(LostHeatLayer);
            if (StaticObjects.AnalysisLosts != null)
            {
                LostHeatLayer = new MapLayer();
                for (int i = 0; i < StaticObjects.AnalysisLosts.Count; i++)
                {
                    Pushpin pushPin = new Pushpin();
                    GeoCoordinate LatLong = new GeoCoordinate(StaticObjects.AnalysisLosts.ElementAt(i).X, StaticObjects.AnalysisLosts.ElementAt(i).Y);
                    pushPin.Tag = StaticObjects.AnalysisLosts.ElementAt(i).LostID;
                    pushPin.TabIndex = i;
                    pushPin.Location = LatLong;
                    pushPin.Template = this.Resources["HeatMapCluster"] as ControlTemplate;
                    //pushPin.Tap += new EventHandler<GestureEventArgs>(LostPinTap);
                    LostHeatLayer.Children.Add(pushPin);
                }
                mainMap.Children.Add(LostHeatLayer);
            }
        }

        
        private void LoadStrayHeatMap(object sender, EventArgs e)
        {
            ApplicationBar.MenuItems.Clear();

            ApplicationBarMenuItem Dog = new ApplicationBarMenuItem();
            Dog.Text = "Show stray Dogs";
            ApplicationBar.MenuItems.Add(Dog);

            ApplicationBarMenuItem Cat = new ApplicationBarMenuItem();
            Cat.Text = "Show stray Cats";
            ApplicationBar.MenuItems.Add(Cat);

            ApplicationBarMenuItem Fish = new ApplicationBarMenuItem();
            Fish.Text = "Show stray Fishes";
            ApplicationBar.MenuItems.Add(Fish);

            ApplicationBarMenuItem Bird = new ApplicationBarMenuItem();
            Bird.Text = "Show stray Birds";
            ApplicationBar.MenuItems.Add(Bird);

            ApplicationBarMenuItem Hamster = new ApplicationBarMenuItem();
            Hamster.Text = "Show stray Hamsters";
            ApplicationBar.MenuItems.Add(Hamster);

            ApplicationBarMenuItem Rabbit = new ApplicationBarMenuItem();
            Rabbit.Text = "Show stray Rabbits";
            ApplicationBar.MenuItems.Add(Rabbit);

            ApplicationBarMenuItem Turtle = new ApplicationBarMenuItem();
            Turtle.Text = "Show stray Turtles";
            ApplicationBar.MenuItems.Add(Turtle);

            if (mainMap.Children.Contains(StrayHeatLayer))
            {
                mainMap.Children.Remove(StrayHeatLayer);
            }
            else
            {
                progressBar.Opacity = 100;
                WebClient Request = new WebClient();
                Request.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RetrieveAllStrayComplete);
                Request.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/RetrieveStray?INtoken=" + StaticObjects.Token));
            }
        }
        private void RetrieveAllStrayComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            //MessageBox.Show(e.Result.ToString());
            StrayModel childlist = new StrayModel();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
            childlist = ser.ReadObject(ms) as StrayModel;
            if (childlist.Status != 1)
                StaticObjects.AnalysisStrays = childlist.Data;
            DrawAccidentHeatMap();
        }
        private void DrawStrayHeatMap()
        {
            if (mainMap.Children.Contains(StrayHeatLayer))
                mainMap.Children.Remove(StrayHeatLayer);
            if (StaticObjects.AnalysisStrays != null)
            {
                StrayHeatLayer = new MapLayer();
                for (int i = 0; i < StaticObjects.AnalysisStrays.Count; i++)
                {
                    Pushpin pushPin = new Pushpin();
                    GeoCoordinate LatLong = new GeoCoordinate(StaticObjects.AnalysisStrays.ElementAt(i).X, StaticObjects.AnalysisStrays.ElementAt(i).Y);
                    pushPin.Tag = StaticObjects.AnalysisStrays.ElementAt(i).StrayID;
                    pushPin.TabIndex = i;
                    pushPin.Location = LatLong;
                    pushPin.Template = this.Resources["HeatMapCluster"] as ControlTemplate;
                    //pushPin.Tap += new EventHandler<GestureEventArgs>(LostPinTap);
                    StrayHeatLayer.Children.Add(pushPin);
                }
                mainMap.Children.Add(StrayHeatLayer);
            }
        }
        
      













        private void buildHeatMaps()
        {
            for(int i=0;i<StaticObjects.MapLosts.Count;i++)
            {
                Pushpin p = new Pushpin();
                
                GeoCoordinate LatLong = new GeoCoordinate(StaticObjects.MapLosts.ElementAt(i).X, StaticObjects.MapLosts.ElementAt(i).Y);
                p.Location = LatLong;
                p.Template = this.Resources["HeatMapCluster"] as ControlTemplate;
                LostHeatLayer.Children.Add(p);
            }
            mainMap.Children.Add(LostHeatLayer);



            //var clusterer = new ClustersGenerator(mainMap, pushpins, this.Resources["ClusterTemplate"] as DataTemplate);
        }

        

        private void MapZoom(object sender, MapZoomEventArgs e)
        {
            mainMap.ViewChangeEnd += new EventHandler<MapEventArgs>(ReDrawHeatMap);
            
           
        }

        private void ReDrawHeatMap(object sender, MapEventArgs e)
        {
            mainMap.Children.Remove(c);
            Converter conveter = new Converter(mainMap.ZoomLevel);
            c = new Canvas { Width = mainMap.ViewportSize.Width, Height = mainMap.ViewportSize.Height };
            
            for (int i = 0; i < StaticObjects.MapLosts.Count; i++)
            {
                Ellipse pin = new Ellipse();
                GeoCoordinate LatLong = new GeoCoordinate(StaticObjects.MapLosts.ElementAt(i).X, StaticObjects.MapLosts.ElementAt(i).Y);
                Point pixPoint = conveter.FromCoordinatesToPixel(LatLong);

                Point point = new Point();
                Thickness margin = pin.Margin;
                mainMap.TryLocationToViewportPoint(LatLong, out point);

                margin.Left = point.X;
                margin.Top = point.Y;
                pin.Margin = margin;

                pin.Height = 50;
                pin.Width = 50;


                RadialGradientBrush gradient = new RadialGradientBrush();
                gradient.GradientOrigin = new Point(0.5, 0.5);
                gradient.RadiusX = 0.5;
                gradient.RadiusY = 0.5;
                gradient.Opacity = 1;

                GradientStop color1 = new GradientStop();
                color1.Color = Color.FromArgb(255,255,0,0);
                color1.Offset = 0;
                gradient.GradientStops.Add(color1);

                GradientStop color2 = new GradientStop();
                color2.Color = Color.FromArgb(125, 204, 0, 0);
                color2.Offset = 0.25;
                gradient.GradientStops.Add(color2);

                GradientStop color3 = new GradientStop();
                color3.Color = Color.FromArgb(75, 150, 0, 0);
                color3.Offset = 0.50;
                gradient.GradientStops.Add(color3);

                GradientStop color4 = new GradientStop();
                color4.Color = Color.FromArgb(25, 255, 255, 0);
                color4.Offset = 0.75;
                gradient.GradientStops.Add(color4);

                GradientStop color5 = new GradientStop();
                color5.Color = Color.FromArgb(5, 102, 178, 255);
                color5.Offset = 0.9;
                gradient.GradientStops.Add(color5);

                pin.Fill = gradient;

                
                c.Children.Add(pin);



            }
            for (int i = 0; i < canvas.Children.Count; i++)
            {
                var pix = canvas.Children;
                
            }
            
            //mainMap.Children.Add(c);
        }
       
    }
}