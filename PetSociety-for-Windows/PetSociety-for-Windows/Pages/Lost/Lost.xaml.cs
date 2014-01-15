using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PetSociety_for_Windows.Src.Utils;
using PetSociety_for_Windows.Src.RootModel;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace PetSociety_for_Windows.Pages.Lost
{
    public partial class Lost : PhoneApplicationPage
    {
        public Lost()
        {
            InitializeComponent();
            LoadLostList();
        }

        private void LoadLostList()
        {

                //progressBar.Opacity = 100;
                WebClient Request = new WebClient();
                Request.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RetrieveLostComplete);
                Request.DownloadStringAsync(new System.Uri("http://petsociety.cloudapp.net/api/RetrieveLost?INtoken=" + StaticObjects.Token));
            
        }
        private void RetrieveLostComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            //MessageBox.Show(e.Result.ToString());
            //progressBar.Opacity = 0;
            LostModel childlist = new LostModel();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result.ToString()));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(childlist.GetType());
            childlist = ser.ReadObject(ms) as LostModel;
            if (childlist.Status != 1)
                StaticObjects.AnalysisLosts = childlist.Data;

            for (int i = 0; i < StaticObjects.AnalysisLosts.Count;i++ )
            {
                lostListBox.Items.Add("" + StaticObjects.AnalysisLosts[i].PetID.ToString() + " | " + StaticObjects.AnalysisLosts[i].Address.ToString());
            }
        }
        
    }
}