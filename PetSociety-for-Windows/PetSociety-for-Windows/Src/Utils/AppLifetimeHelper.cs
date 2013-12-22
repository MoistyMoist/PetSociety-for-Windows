using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Phone.Controls;


namespace PetSociety_for_Windows.Src.Utils
{
    class AppLifetimeHelper
    {
        public void CloseApplication()
        {
            ClearApplicationNavigationBackStack();
            Root.GoBack();
        }

        private PhoneApplicationFrame _root;
        private PhoneApplicationFrame Root
        {
            get
            {
                if (_root == null)
                {
                    _root = Application.Current.RootVisual as PhoneApplicationFrame;
                }

                return _root;
            }
        }

        private void ClearApplicationNavigationBackStack()
        {
            if (Root == null)
            {
                return;
            }

            try
            {
                while (Root.BackStack.Any())
                {
                    Root.RemoveBackEntry();
                }
            }
            catch
            { }
        }

    }
}
