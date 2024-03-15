using AoE4GameBox.Model;
using AoE4GameBox.Tools;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;

namespace AoE4GameBox.Pages
{
    public sealed partial class PageRandom : Page
    {
        public PageRandom()
        {
            this.InitializeComponent();
            // 开启页面缓存
            this.NavigationCacheMode = Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }
        private void BtnRandomCivClick(object sender, RoutedEventArgs e)
        {
            // 随机生成下标
            int index = new Random().Next(GameParameters.FlagFiles.Count);
            // 选取文件
            Logger.Log("随机文明", $"选取的下标是：{index}");
            string randomFlagFiles = GameParameters.FlagFiles[index];
            Logger.Log("随机文明", $"选取的文件是：{randomFlagFiles}");
            // 更换图片
            BitmapImage img = UITool.GenerateImage($"ms-appx:///Assets/Images/flags/{randomFlagFiles}");
            // 应用图片
            this.img_random_civ.Source = img;
            // 修改文明名称
            this.text_civ.Text = randomFlagFiles;
        }

        private void BtnRandomMapClick(object sender, RoutedEventArgs e)
        {
            // 随机生成下标
            int index = new Random().Next(GameParameters.MapFiles.Count);
            // 选取文件
            Logger.Log("随机地图", $"随机选取的下标是：{index}");
            string randomMapFile = GameParameters.MapFiles[index];
            Logger.Log("随机地图", $"随机选取的文件是：{randomMapFile}");
            // 更换图片
            BitmapImage img = UITool.GenerateImage($"ms-appx:///Assets/Images/maps/{randomMapFile}");
            // 应用图片
            this.img_random_map.Source = img;
            // 修改地图名称
            this.text_map.Text = randomMapFile;
        }
    }
}
