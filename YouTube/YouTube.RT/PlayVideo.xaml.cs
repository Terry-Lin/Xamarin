﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace YouTube
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class PlayVideo : Page
    {
    

        public PlayVideo()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 在此頁面即將顯示在框架中時叫用。
        /// </summary>
        /// <param name="e">描述如何到達此頁面的事件資料。Parameter
        /// 屬性通常用來設定頁面。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var p = (Entry)e.Parameter;
            this.txtTitle.Text = p.Title;
            this.webview.Navigate(new Uri(p.Link));
        }

        private void OnBackButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                this.webview.NavigateToString("");
                Frame.GoBack();
            }
        }
    }
}
