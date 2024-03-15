using AoE4GameBox.Tools;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace AoE4GameBox.Pages
{
    public sealed partial class PageNetCheck : Page
    {
        public PageNetCheck()
        {
            this.InitializeComponent();
            // ����ҳ�滺��
            this.NavigationCacheMode = Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
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
