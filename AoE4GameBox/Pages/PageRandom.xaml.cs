using AoE4GameBox.Model;
using AoE4GameBox.Tools;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AoE4GameBox.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageRandom : Page
    {
        public PageRandom()
        {
            this.InitializeComponent();
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
