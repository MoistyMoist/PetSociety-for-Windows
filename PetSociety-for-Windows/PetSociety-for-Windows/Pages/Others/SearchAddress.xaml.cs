using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PetSociety_for_Windows.Pages.Others
{
    public partial class SearchAddress : PhoneApplicationPage
    {
        public SearchAddress()
        {
            InitializeComponent();

        }


        private void SearchTB_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                WebClient loginRequest = new WebClient();
                loginRequest.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RetrieveAddressComplete);
                loginRequest.DownloadStringAsync(new System.Uri("http://www.onemap.sg/API/services.svc/basicSearch?token=qo/s2TnSUmfLz+32CvLC4RMVkzEFYjxqyti1KhByvEacEdMWBpCuSSQ+IFRT84QjGPBCuz/cBom8PfSm3GjEsGc8PkdEEOEr&searchVal=" +SearchTB.Text.ToString()+ "&otptFlds=SEARCHVAL,CATEGORY&returnGeom=0&rset=1"));
            }
        }
        protected void RetrieveAddressComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }
        protected void displayResult()
        {
            
        }

        protected void PlotOnMainMap()
        {
            
        }

        



    }
}