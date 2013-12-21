using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PetSociety_for_Windows;
using PetSociety_for_Windows.Src.Utils;

namespace PetSociety_for_Windows.Pages
{
    public partial class LoginPage : PhoneApplicationPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
           
        }

        private void login(object sender, RoutedEventArgs e)
        {
            WebClient loginRequest = new WebClient();
            loginRequest.DownloadStringCompleted += new DownloadStringCompletedEventHandler(loginResponse);
            loginRequest.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/Login?token="+StaticObjects.Token+"&INemail="+"kaiquan88@gmail.com"+"&INpassword="+"password"));
        }

        private void loginResponse(object sender, DownloadStringCompletedEventArgs e)
        {
            emailTB.Text = e.Result.ToString();
        }
    }
}