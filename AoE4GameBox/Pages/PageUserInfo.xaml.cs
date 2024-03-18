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

namespace AoE4GameBox.Pages
{
    public sealed partial class PageUserInfo : Page
    {
        private PageUserInfoViewModel VMUserInfo = new();

        public PageUserInfo()
        {
            this.InitializeComponent();
            // 开启页面缓存
            this.NavigationCacheMode = Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            // 绑定数据
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

        private async void BtnBind_Click(object sender, RoutedEventArgs e)
        {
            var strPlayerID = this.GetPlayerSearchText();
            // 获取最近一场游戏的信息
            List<OverlayGame> teamList = await this.GetLastGame(strPlayerID);
            // 检查是否获取成功
            if (teamList.Count > 0)
            {
                
            }

            //// 关闭旧的浮窗
            //overlayWindow?.Close();
            //// 创建新的浮窗
            //overlayWindow = new(teamList);
            //// 显示浮窗
            //boolOverlayShow = true;
            //overlayWindow.Show();
        }
    }
}
