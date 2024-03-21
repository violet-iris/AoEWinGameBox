using AoE4GameBox.Pages;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Runtime.InteropServices;
using Windows.Graphics;

namespace AoE4GameBox
{
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
            this.AppWindow.Resize(new Windows.Graphics.SizeInt32(1280, 780));
            //SetWindowTransparent();
            this.InitializeComponent();
            //this.AppWindow.SetIcon("Assets/Images/A.ico");
            contentFrame.Navigate(typeof(PageUserInfo));
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

            if ((string)selectedItem.Tag == "PageMain")
                contentFrame.Navigate(typeof(PageUserInfo));
            else if ((string)selectedItem.Tag == "PageOSD")
                contentFrame.Navigate(typeof(PageOSDSetting));
            else if ((string)selectedItem.Tag == "PageRandom")
                contentFrame.Navigate(typeof(PageRandom));
            else if ((string)selectedItem.Tag == "PageNetCheck")
                contentFrame.Navigate(typeof(PageNetCheck));
            else if ((string)selectedItem.Tag == "PageAbout")
                contentFrame.Navigate(typeof(PageAbout));

            if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(PageSetting));
            }
        }
    }
}
