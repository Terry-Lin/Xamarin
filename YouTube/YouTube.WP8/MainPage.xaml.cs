using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using YouTube.Resources;

namespace YouTube.WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 建構函式
        public MainPage()
        {
            InitializeComponent();

            // 將 ApplicationBar 當地語系化的程式碼範例
            //BuildLocalizedApplicationBar();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searcher = new YouTubeSearcher();
            searcher.list = this.VideoList;
            searcher.SearchForWP8(this.txtKeyword.Text);
        }

        private void VideoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VideoList.SelectedItem != null)
            {
                var title = (VideoList.SelectedItem as Entry).Title;
                var link = (VideoList.SelectedItem as Entry).Link;
                NavigationService.Navigate(new Uri(string.Format("/PlayVideo.xaml?Title={0}&Link={1}", title, link), UriKind.Relative));
            }
        }

        // 建置當地語系化 ApplicationBar 的程式碼範例
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 將頁面的 ApplicationBar 設定為 ApplicationBar 的新執行個體。
        //    ApplicationBar = new ApplicationBar();

        //    // 建立新的按鈕並將文字值設定為 AppResources 的當地語系化字串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 用 AppResources 的當地語系化字串建立新的功能表項目。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}