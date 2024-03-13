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
        /// �����վ��ͨ��
        /// </summary>
        private void BtnCheckNet_Click(object sender, RoutedEventArgs e)
        {
            BtnCheckNet_Click();
        }

        /// <summary>
        /// �����վ��ͨ��
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
        /// ��Ȿ������ӿ�
        /// </summary>
        private void BtnCheckLocalNic_Click(object sender, RoutedEventArgs e)
        {
            var msg = NetCheck.CheckLocalNic();
            this.textbox_check_localhost_result.Text = msg.ToString();
        }

        /// <summary>
        /// ��ȡ������IP��ַ
        /// </summary>
        private async void GetIPAddress_Click(object sender, RoutedEventArgs e)
        {
            this.TextBoxCheckIPResult.Text = await NetCheck.GetIPAddress();
        }

        /// <summary>
        /// ��ť����¼���ˢ��DNS����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshDNSCacheButton_Click(object sender, RoutedEventArgs e)
        {
            this.TextBoxRefreshDNSCacheResult.Text = NetCheck.FlushDNSCache();
        }
    }
}
