﻿using System;
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
using System.Xml.Linq;
using System.Runtime.Serialization.Json;
using System.Collections.ObjectModel;
using PetSociety_for_Windows.Src.Model;
using PetSociety_for_Windows.Src.RootModel;
using System.IO;
using System.Text;
using System.IO.IsolatedStorage;

namespace PetSociety_for_Windows.Pages
{
    public partial class LoginPage : PhoneApplicationPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //checks the local database for email n password
            IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication();
            //Grab contents of myFile.txt 
            try
            {
                StreamReader streamReaderFile = new StreamReader(new
                IsolatedStorageFileStream("RootFolder\\Antuation.txt", FileMode.Open, myStore));
                emailTB.Text= streamReaderFile.ReadLine();
                passwordTB.Text = streamReaderFile.ReadLine();
                streamReaderFile.Close();
                if(!emailTB.Text.Equals(""))
                    login(null,null);
            }//end of try 
            catch (Exception) 
            {

            } 

        }

        private void login(object sender, RoutedEventArgs e)
        {
            progressBar.Opacity = 100;
            MessageTX.Opacity=100;
            WebClient loginRequest = new WebClient();
            loginRequest.DownloadStringCompleted += new DownloadStringCompletedEventHandler(loginResponse);
            loginRequest.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/Login?token=" + StaticObjects.Token + "&INemail=" + emailTB.Text + "&INpassword=" + passwordTB.Text));
        }

        private void loginResponse(object sender, DownloadStringCompletedEventArgs e)
        {
            UserModel childlist = new UserModel();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
            childlist = ser.ReadObject(ms) as UserModel;

            USER currentUser = new USER();
            if (childlist.Status == 1)
            {
                MessageTX.Text = "Login Failed";
                progressBar.Opacity = 0;
            }
            else
            {
                foreach (var d in childlist.Data)
                {
                    currentUser = d;
                }
                StaticObjects.CurrentUser = currentUser;

                IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
                file.CreateDirectory("RootFolder");
                StreamWriter streamWriterFile = new StreamWriter(new
                IsolatedStorageFileStream("RootFolder\\Antuation.txt", FileMode.OpenOrCreate, file));
                streamWriterFile.WriteLine(StaticObjects.CurrentUser.Email.ToString());
                streamWriterFile.WriteLine(StaticObjects.CurrentUser.Password.ToString());
                streamWriterFile.Close();


                NavigationService.Navigate(new Uri("/Map.xaml", UriKind.Relative));
            }
           
            ms.Close();

            //save the email and password in local database

           
        }

        private void NavigateToRegister(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Others/RegisterPage.xaml", UriKind.Relative));
        }
    }

}