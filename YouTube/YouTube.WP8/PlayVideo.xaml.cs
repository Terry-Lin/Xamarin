using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace YouTube
{
    public partial class PlayVideo : PhoneApplicationPage
    {
        public PlayVideo()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string title, link;
            NavigationContext.QueryString.TryGetValue("Title", out title);
            NavigationContext.QueryString.TryGetValue("Link", out link);
            this.txtTitle.Text = title;

            this.webview.IsScriptEnabled = true;
            this.webview.Navigate(new Uri(link));


        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            this.webview.NavigateToString("");
        }
    }
}