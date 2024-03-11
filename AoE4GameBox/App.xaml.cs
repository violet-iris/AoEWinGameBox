using AoE4GameBox.Tools;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AoE4GameBox
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            // 设置默认语言
            ApplicationLanguages.PrimaryLanguageOverride = "zh-CN";
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN"); // 设置默认的区域设置
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            //Logger.Log("1.OnStartup被触发");
            Logger.Info("************************* Log Start *************************");

            m_window = new MainWindow();
            m_window.Activate();

            //OverlappedPresenter windowPresenter = (OverlappedPresenter)m_window.AppWindow.Presenter;
            //windowPresenter.IsAlwaysOnTop = true;
            //windowPresenter.SetBorderAndTitleBar(false, false);
        }

        private Window m_window;
    }
}
