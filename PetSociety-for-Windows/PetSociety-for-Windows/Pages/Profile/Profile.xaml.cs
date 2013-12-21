﻿using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Media;

namespace PetSociety_for_Windows.Pages.Profile
{
    public partial class Profile : PhoneApplicationPage
    {
        public Profile()
        {
            InitializeComponent();
            VisualStateManager.GoToState(this, "Normal", false);
            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
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
           // if (e.DeltaManipulation.Translation.X != 0)
           //     Canvas.SetLeft(LayoutRoot, Math.Min(Math.Max(-840, Canvas.GetLeft(LayoutRoot) + e.DeltaManipulation.Translation.X), 0));
        }

        double initialPosition;
        bool _viewMoved = false;
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
                MoveViewWindow(initialPosition);
                return;
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

      


        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            //           appBarButton.Text = AppResources.AppBarButtonText;
            //           ApplicationBar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
            //          ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            //         ApplicationBar.MenuItems.Add(appBarMenuItem);
        }



        double preFlickX;
        double preFlickY;
        bool firstTime = false;
        int id = -1;
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            TouchPointCollection tpc = e.GetTouchPoints(canvas);
            if (id == -1)
            {
                if ((tpc.Count == 1) && (tpc[0].Action == TouchAction.Down))
                {
                    id = tpc[0].TouchDevice.Id;
                    X = tpc[0].Position.X;
                    preFlickX = Canvas.GetLeft(LayoutRoot);
                    firstTime = true;
                    ((Storyboard)canvas.Resources["moveAnimation"]).Stop();
                }
            }
            else
            {
                foreach (var tpoint in tpc)
                    if (tpoint.TouchDevice.Id == id)
                    {
                        var delta = tpoint.Position.X - X;
                        System.Diagnostics.Debug.WriteLine(delta + " " + X + " " + tpoint.Position.X);
                        if ((Math.Abs(delta) > 10) && ((((Storyboard)canvas.Resources["moveAnimation"]).GetCurrentState() == ClockState.Filling) || (((Storyboard)canvas.Resources["moveAnimation"]).GetCurrentState() == ClockState.Stopped)))
                        {
                            if ((Math.Abs(delta) > 50) && (firstTime))
                                id = -1;
                            else
                            {
                                firstTime = false;
                                X = tpoint.Position.X;
                                ((DoubleAnimation)((Storyboard)canvas.Resources["moveAnimation"]).Children[0]).To = Math.Min(Math.Max(-840, Canvas.GetLeft(LayoutRoot) + delta), 0);
                                ((Storyboard)canvas.Resources["moveAnimation"]).Begin();
                            }

                        }

                        if ((tpoint.Action == TouchAction.Up) || (id == -1))
                        {

                            var left = Canvas.GetLeft(LayoutRoot);
                            id = -1;
                            ((Storyboard)canvas.Resources["moveAnimation"]).SkipToFill();
                            if ((left - preFlickX > 100) || (delta > 50))
                            {
                                //right flick
                                if (((VisualStateGroup)VisualStateManager.GetVisualStateGroups(canvas as FrameworkElement)[0]).CurrentState.Name == "RightMenuOpened")
                                {
                                    ApplicationBar.IsVisible = true;
                                    VisualStateManager.GoToState(this, "Normal", true);
                                }
                                else
                                {
                                    ApplicationBar.IsVisible = false;
                                    VisualStateManager.GoToState(this, "LeftMenuOpened", true);
                                }
                                return;
                            }
                            if ((left - preFlickX < -100) || (delta < -50))
                            {
                                //right flick
                                if (((VisualStateGroup)VisualStateManager.GetVisualStateGroups(canvas as FrameworkElement)[0]).CurrentState.Name == "LeftMenuOpened")
                                {
                                    ApplicationBar.IsVisible = true;
                                    VisualStateManager.GoToState(this, "Normal", true);
                                }
                                else
                                {
                                    ApplicationBar.IsVisible = false;
                                    VisualStateManager.GoToState(this, "RightMenuOpened", true);
                                }
                                return;
                            }
                            Canvas.SetLeft(LayoutRoot, preFlickX);
                        }
                    }
            }

        }
        double X;











        private void NavigateToSearch(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Others/SearchAddress.xaml", UriKind.Relative));
        }
        private void NavigateToHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../Map.xaml", UriKind.Relative));
        }
        private void NavigateToEvent(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Event/Event.xaml", UriKind.Relative));
        }
        private void NavigateToLost(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Lost/Lost.xaml", UriKind.Relative));
        }
        private void NavigateToStray(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/CrowdSourcing/Stray.xaml", UriKind.Relative));
        }
        private void NavigateToAnalysis(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Analysis/Analysis.xaml", UriKind.Relative));
        }
        private void NavigateToNearby(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/CrowdSourcing/Nearby.xaml", UriKind.Relative));
        }
        private void NavigateToSetting(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Others/Setting.xaml", UriKind.Relative));
        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            // NavigationService.Navigate(new Uri("/Pages/CrowdSourcing/Nearby.xaml", UriKind.Relative));
        }
    }
}