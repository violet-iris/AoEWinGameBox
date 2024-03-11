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
            // ��������±�
            int index = new Random().Next(GameParameters.FlagFiles.Count);
            // ѡȡ�ļ�
            Logger.Log("�������", $"ѡȡ���±��ǣ�{index}");
            string randomFlagFiles = GameParameters.FlagFiles[index];
            Logger.Log("�������", $"ѡȡ���ļ��ǣ�{randomFlagFiles}");
            // ����ͼƬ
            BitmapImage img = UITool.GenerateImage($"ms-appx:///Assets/Images/flags/{randomFlagFiles}");
            // Ӧ��ͼƬ
            this.img_random_civ.Source = img;
            // �޸���������
            this.text_civ.Text = randomFlagFiles;
        }

        private void BtnRandomMapClick(object sender, RoutedEventArgs e)
        {
            // ��������±�
            int index = new Random().Next(GameParameters.MapFiles.Count);
            // ѡȡ�ļ�
            Logger.Log("�����ͼ", $"���ѡȡ���±��ǣ�{index}");
            string randomMapFile = GameParameters.MapFiles[index];
            Logger.Log("�����ͼ", $"���ѡȡ���ļ��ǣ�{randomMapFile}");
            // ����ͼƬ
            BitmapImage img = UITool.GenerateImage($"ms-appx:///Assets/Images/maps/{randomMapFile}");
            // Ӧ��ͼƬ
            this.img_random_map.Source = img;
            // �޸ĵ�ͼ����
            this.text_map.Text = randomMapFile;
        }
    }
}
