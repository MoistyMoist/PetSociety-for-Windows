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
                loginRequest.DownloadStringAsync(new System.Uri("http://www.onemap.sg/API/services.svc/basicSearch?token=qo/s2TnSUmfLz+32CvLC4RMVkzEFYjxqyti1KhByvEacEdMWBpCuSSQ+IFRT84QjGPBCuz/cBom8PfSm3GjEsGc8PkdEEOEr&searchVal=" +SearchTB.Text.ToString()+ "&otptFlds=SEARCHVAL,CATEGORY&returnGeom=1&rset=1"));
            }
        }
        protected void RetrieveAddressComplete(object sender, DownloadStringCompletedEventArgs e)
        {

            AddressSearchModel childlist = new AddressSearchModel();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
            childlist = ser.ReadObject(ms) as AddressSearchModel;
            childlist.SEARCHVAL.RemoveAt(0);

            for (int i = 0; i < childlist.SEARCHVAL.Count; i++)
            {
               // AddressResult.Items.Add(childlist.SEARCHVAL.ElementAt(i).SEARCHVAL.ToString());

        
                AddressResult.Items.Add(childlist.SEARCHVAL.ElementAt(i));
            }
        }
      
        protected void PlotOnMainMap()
        {
            
        }

        



    }
}