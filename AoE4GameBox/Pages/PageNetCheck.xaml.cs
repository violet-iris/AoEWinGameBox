using AoE4GameBox.Tools;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AoE4GameBox.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageNetCheck : Page
    {
        public PageNetCheck()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// 检测网站连通性
        /// </summary>
        private void BtnCheckNet_Click(object sender, RoutedEventArgs e)
        {
            BtnCheckNet_Click();
        }

        /// <summary>
        /// 检测网站连通性
        /// </summary>
        private async void BtnCheckNet_Click()
        {
            TextBoxCheckNetworkResult.Text = "{Properties.i18n.Resources.network_diagnostics}\n";

            var host = "aoe4world.com";
            var msg = await NetCheck.CheckHostReachable(host);
            TextBoxCheckNetworkResult.Text += $"{msg}\n";

            host = "aoe4cn.com";
            msg = await NetCheck.CheckHostReachable(host);
            TextBoxCheckNetworkResult.Text += $"{msg}";
        }

        /// <summary>
        /// 检测本地网络接口
        /// </summary>
        private void BtnCheckLocalNic_Click(object sender, RoutedEventArgs e)
        {
            var msg = NetCheck.CheckLocalNic();
            this.textbox_check_localhost_result.Text = msg.ToString();
        }

        /// <summary>
        /// 获取本机的IP地址
        /// </summary>
        private async void GetIPAddress_Click(object sender, RoutedEventArgs e)
        {
            this.TextBoxCheckIPResult.Text = await NetCheck.GetIPAddress();
        }

        /// <summary>
        /// 按钮点击事件：刷新DNS缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshDNSCacheButton_Click(object sender, RoutedEventArgs e)
        {
            this.TextBoxRefreshDNSCacheResult.Text = NetCheck.FlushDNSCache();
        }
    }
}
