using AoE4GameBox.Common;
using AoE4GameBox.Model;
using AoE4GameBox.Tools;
using Microsoft.UI.Text;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Media;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AoE4GameBox.Pages
{
    public sealed partial class PageUserInfo : Page
    {
        private PageUserInfoViewModel VMUserInfo = new();

        public PageUserInfo()
        {
            this.InitializeComponent();
            // ����ҳ�滺��
            this.NavigationCacheMode = Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            // ������
            this.DataContext = VMUserInfo;
        }

        /// <summary>
        /// ������һ�����Ϣ
        /// </summary>
        private async void BtnSearchPlayer_Click(object sender, RoutedEventArgs e)
        {
            Player PlayerInfo = await RequestAoE4World.GetPlayerClassBySearch(this.GetPlayerSearchText());
            if (PlayerInfo.Name != "Default")
            {
                // ������
                VMUserInfo.PlayerName = $"����ǳ� : {PlayerInfo.Name}";
                VMUserInfo.PlayerId = $"��ҵ������ (��ϷID) : {PlayerInfo.ProfileId}";
                VMUserInfo.PlayerSteamId = $"Steam3 ID (64bit DEC) : {PlayerInfo.SteamId}";
                // ������ı��༭��
                this.TextBoxPlayerId.Text = PlayerInfo.ProfileId.ToString();
            }
        }

        /// <summary>
        /// ��ȡ��������ID
        /// </summary>
        /// <returns>����string</returns>
        private string GetPlayerSearchText()
        {
            return this.TextBoxPlayerId.Text;
        }

        public async Task<List<OverlayGame>> GetLastGame(string strPlayerID)
        {
            Result reLatestGame = await RequestAoE4World.GetLatestGame(strPlayerID);
            if (reLatestGame.Code == IConstants.CODE_200)
            {
                List<OverlayGame> teamList = new((List<OverlayGame>)reLatestGame.Data);
                return teamList;
            } else
            {
                return [];
            }
        }

        private void BtnBind_Click(object sender, RoutedEventArgs e)
        {
            ShowOSDInfo();
        }

        private async void ShowOSDInfo()
        {
            var strPlayerID = this.GetPlayerSearchText();
            // ��ȡ���һ����Ϸ����Ϣ
            List<OverlayGame> teamList = await this.GetLastGame(strPlayerID);
            // ����Ƿ��ȡ�ɹ�
            if (teamList.Count > 0)
            {
                Frame.Navigate(typeof(PageOSDSetting), teamList);
            }

            //// �رվɵĸ���
            //overlayWindow?.Close();
            //// �����µĸ���
            //overlayWindow = new(teamList);
            //// ��ʾ����
            //boolOverlayShow = true;
            //overlayWindow.Show();
        }
    }
}
