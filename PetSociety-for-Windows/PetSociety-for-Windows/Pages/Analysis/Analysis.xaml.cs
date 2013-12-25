﻿using Microsoft.Phone.Controls;
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

        MapLayer LocationHeatLayer;
        MapLayer StrayHeatLayer;
        MapLayer EventHeatLayer;
        MapLayer LostHeatLayer;
        Canvas c;

        public Analysis()
        {
            InitializeComponent();
            VisualStateManager.GoToState(this, "Normal", false);
            BuildLocalizedApplicationBar();

            LocationHeatLayer = new MapLayer();
            StrayHeatLayer = new MapLayer();
            EventHeatLayer = new MapLayer();
            LostHeatLayer = new MapLayer();

            MapZoom(null,null);
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

            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Resources/hamster.png", UriKind.Relative));
            appBarButton.Text = "Add Location";
            ApplicationBar.Buttons.Add(appBarButton);
        }

        private void GetAccidentPoints()
        {

        }














        private void buildHeatMaps()
        {
           
            List<Pushpin> pushpins = new List<Pushpin>();
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