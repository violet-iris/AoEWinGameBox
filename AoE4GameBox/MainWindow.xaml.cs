using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AoE4GameBox
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        //private IntPtr hWndMain = IntPtr.Zero;
        //private Microsoft.UI.Windowing.AppWindow _apw;
        //private Microsoft.UI.Windowing.OverlappedPresenter _presenter;

        private const int WS_EX_TRANSPARENT = 0x00000020;
        private const int GWL_EXSTYLE = -20;
        private const int GWL_STYLE = -16;

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        public MainWindow()
        {
            //this.AppWindow.Resize(new Windows.Graphics.SizeInt32(800, 600));
            this.InitializeComponent();
            //SetWindowTransparent();
        }

        public void SetWindowTransparent()
        {
            IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            int extendedStyle = GetWindowLong(hwnd, GWL_STYLE);
            //int extendedStyle = 825566;
            _ = SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
            //_ = SetWindowLong(hwnd, GWL_EXSTYLE, 0x80020);
        }

        public void SetWindowNormal()
        {
            IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            int extendedStyle = GetWindowLong(hwnd, GWL_STYLE);
            _ = SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | ~WS_EX_TRANSPARENT);
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var selectedItem = (NavigationViewItem)args.SelectedItem;
            if ((string)selectedItem.Tag == "BlankPage1") contentFrame.Navigate(typeof(BlankPage1));
            else if ((string)selectedItem.Tag == "BlankPage2") contentFrame.Navigate(typeof(BlankPage2));
            else if ((string)selectedItem.Tag == "BlankPage3") contentFrame.Navigate(typeof(BlankPage3));
            else if ((string)selectedItem.Tag == "TestPage") contentFrame.Navigate(typeof(TestPage));
        }




        ///// <summary>
        ///// 检测网站连通性
        ///// </summary>
        //private void BtnCheckNet_Click(object sender, RoutedEventArgs e)
        //{
        //    BtnCheckNet_Click();
        //}

        ///// <summary>
        ///// 检测网站连通性
        ///// </summary>
        //private async void BtnCheckNet_Click()
        //{
        //    TextBoxCheckNetworkResult.Text = "{Properties.i18n.Resources.network_diagnostics}\n";

        //    var host = "aoe4world.com";
        //    var msg = await NetCheck.CheckHostReachable(host);
        //    TextBoxCheckNetworkResult.Text += $"{msg}\n";

        //    host = "aoe4cn.com";
        //    msg = await NetCheck.CheckHostReachable(host);
        //    TextBoxCheckNetworkResult.Text += $"{msg}";
        //}

        ///// <summary>
        ///// 检测本地网络接口
        ///// </summary>
        //private void BtnCheckLocalNic_Click(object sender, RoutedEventArgs e)
        //{
        //    var msg = NetCheck.CheckLocalNic();
        //    this.textbox_check_localhost_result.Text = msg.ToString();
        //}

        ///// <summary>
        ///// 获取本机的IP地址
        ///// </summary>
        //private async void GetIPAddress_Click(object sender, RoutedEventArgs e)
        //{
        //    this.TextBoxCheckIPResult.Text = await NetCheck.GetIPAddress();
        //}

        ///// <summary>
        ///// 按钮点击事件：刷新DNS缓存
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void RefreshDNSCacheButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.TextBoxRefreshDNSCacheResult.Text = NetCheck.FlushDNSCache();
        //}
    }
}
