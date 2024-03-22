using AoE4GameBox.Common;
using AoE4GameBox.Model;
using AoE4GameBox.Tools;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;
using System;

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
                VMUserInfo.Name = $"����ǳ� : {PlayerInfo.Name}";
                VMUserInfo.ProfileId = $"��ҵ������ (��ϷID) : {PlayerInfo.ProfileId}";
                VMUserInfo.SteamId = $"Steam3 ID (64bit DEC) : {PlayerInfo.SteamId}";
                VMUserInfo.CountryArea = $"���һ���� (λ�ÿ�������) : {PlayerInfo.CountryArea}";
                VMUserInfo.SiteUrl = PlayerInfo.SiteUrl;
                VMUserInfo.Avatars = PlayerInfo.Avatars.Full;
                VMUserInfo.SteamSite = "https://steamcommunity.com/profiles/" + PlayerInfo.SteamId;
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
                Logger.Info("����ҳɹ�");
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
