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
            // ����ҳ�滺��
            this.NavigationCacheMode = Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
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
