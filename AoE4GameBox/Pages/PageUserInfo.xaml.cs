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
        /// 搜索玩家基础信息
        /// </summary>
        private async void BtnSearchPlayer_Click(object sender, RoutedEventArgs e)
        {
            Player PlayerInfo = await RequestAoE4World.GetPlayerClassBySearch(this.GetPlayerSearchText());
            if (PlayerInfo.Name != "Default")
            {
                // 保存结果
                VMUserInfo.PlayerName = $"玩家昵称 : {PlayerInfo.Name}";
                VMUserInfo.PlayerId = $"玩家档案编号 (游戏ID) : {PlayerInfo.ProfileId}";
                VMUserInfo.PlayerSteamId = $"Steam3 ID (64bit DEC) : {PlayerInfo.SteamId}";
                // 输出到界面
                //text_player_name.Text = VMUserInfo.PlayerName;
                //text_player_id.Text = VMUserInfo.PlayerId;
                //text_player_steam_id.Text = VMUserInfo.PlayerSteamId;
                // 反向绑定文本编辑框
                this.TextBoxPlayerId.Text = PlayerInfo.ProfileId.ToString();
            }
        }

        /// <summary>
        /// 获取输入的玩家ID
        /// </summary>
        /// <returns>返回string</returns>
        private string GetPlayerSearchText()
        {
            return this.TextBoxPlayerId.Text;
        }

    }
}
