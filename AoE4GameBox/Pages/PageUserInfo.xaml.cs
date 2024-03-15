using AoE4GameBox.Model;
using AoE4GameBox.Tools;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace AoE4GameBox.Pages
{
    public sealed partial class PageUserInfo : Page
    {
        private PageUserInfoViewModel VMUserInfo = new PageUserInfoViewModel();

        public PageUserInfo()
        {
            this.InitializeComponent();
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
                // ���������
                //text_player_name.Text = VMUserInfo.PlayerName;
                //text_player_id.Text = VMUserInfo.PlayerId;
                //text_player_steam_id.Text = VMUserInfo.PlayerSteamId;
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

    }
}
