using AoE4GameBox.Model;
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
    public sealed partial class PageUserInfo : Page
    {
        public PageUserInfo()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// ������һ�����Ϣ
        /// </summary>
        private async void BtnSearchPlayer_Click(object sender, RoutedEventArgs e)
        {
            Player PlayerInfo = await RequestAoE4World.GetPlayerClassBySearch(this.GetPlayerSearchText());
            if (PlayerInfo.Name != "Default")
            {
                // ���������
                text_player_name.Text = $"����ǳ� : {PlayerInfo.Name}";
                text_player_id.Text = $"��ҵ������ (��ϷID) : {PlayerInfo.ProfileId}";
                text_player_steam_id.Text = $"Steam3 ID (64bit DEC) : {PlayerInfo.SteamId}";
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
