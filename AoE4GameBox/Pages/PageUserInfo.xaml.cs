using AoE4GameBox.Common;
using AoE4GameBox.Model;
using AoE4GameBox.Tools;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;
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
            // 状态栏
            this.NavigationCacheMode = Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            // 数据绑定
            this.DataContext = VMUserInfo;
        }

        /// <summary>
        /// 搜索玩家
        /// </summary>
        private async void BtnSearchPlayer_Click(object sender, RoutedEventArgs e)
        {
            Player PlayerInfo = await RequestAoE4World.GetPlayerClassBySearch(this.GetPlayerSearchText());
            if (PlayerInfo.Name != "Default")
            {
                // 设置数据绑定信息
                VMUserInfo.Name = $"玩家昵称 : {PlayerInfo.Name}";
                VMUserInfo.ProfileId = $"玩家档案编号 (游戏ID) : {PlayerInfo.ProfileId}";
                VMUserInfo.SteamId = $"Steam3 ID (64bit DEC) : {PlayerInfo.SteamId}";
                VMUserInfo.CountryArea = $"账号国家/地区 (位置可能有误) : {PlayerInfo.CountryArea}";
                VMUserInfo.SiteUrl = PlayerInfo.SiteUrl;
                VMUserInfo.Avatars = PlayerInfo.Avatars.Full;
                VMUserInfo.SteamSite = "https://steamcommunity.com/profiles/" + PlayerInfo.SteamId;
                // 反向绑定输入框
                this.TextBoxPlayerId.Text = PlayerInfo.ProfileId.ToString();
            }
        }

        /// <summary>
        /// 获取玩家id
        /// </summary>
        private string GetPlayerSearchText()
        {
            return this.TextBoxPlayerId.Text;
        }

        public void GetLastGame(string strPlayerID)
        {
            _ = RequestAoE4World.GetPlayerLastGame(strPlayerID);
            //if (reLatestGame.Code == IConstants.CODE_200)
            //{
            //    List<OverlayGame> teamList = new((List<OverlayGame>)reLatestGame.Data);
            //    return teamList;
            //} else
            //{
            //    return [];
            //}
        }

        private void BtnBind_Click(object sender, RoutedEventArgs e)
        {
            GetLastGame(GetPlayerSearchText());
            //ShowOSDInfo();
        }

        //private async void ShowOSDInfo()
        //{
        //    var strPlayerID = this.GetPlayerSearchText();
        //    // 获取玩家最近一场游戏信息
        //    List<OverlayGame> teamList = await this.GetLastGame(strPlayerID);
        //    // 判断是否有数据
        //    if (teamList.Count > 0)
        //    {
        //        Frame.Navigate(typeof(PageOSDSetting), teamList);
        //    }

        //    //// 
        //    //overlayWindow?.Close();
        //    //// 
        //    //overlayWindow = new(teamList);
        //    //// 
        //    //boolOverlayShow = true;
        //    //overlayWindow.Show();
        //}
    }

    public class StringToUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string urlString)
            {
                if (Uri.TryCreate(urlString, UriKind.Absolute, out Uri uriResult))
                {
                    return uriResult;
                }
            }
            return null; // Or you can return a default Uri here if necessary
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException(); // We don't need this for this conversion
        }
    }
}
