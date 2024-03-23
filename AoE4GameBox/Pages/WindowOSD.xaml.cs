using AoE4GameBox.Model;
using AoE4GameBox.Tools;
using Microsoft.UI;
using Microsoft.UI.Text;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Windows.Graphics;
using Windows.UI.WindowManagement;

namespace AoE4GameBox.Pages
{
    public sealed partial class WindowOSD : Window
    {
        private const int WS_EX_TRANSPARENT = 0x00000020;
        private const int GWL_EXSTYLE = -20;
        private const int GWL_STYLE = -16;

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        public WindowOSD(List<OverlayGame> teamList)
        {
            // 初始化窗口
            this.InitializeComponent();
            // 设置窗口透明
            SetWindowTransparent();
            OverlappedPresenter windowPresenter = (OverlappedPresenter)AppWindow.Presenter;
            windowPresenter.IsAlwaysOnTop = true;
            windowPresenter.SetBorderAndTitleBar(false, false);

            var ScreenHeight = DisplayArea.Primary.WorkArea.Height;
            var ScreenWidth = DisplayArea.Primary.WorkArea.Width;
            this.AppWindow.MoveAndResize(new RectInt32((int)(ScreenWidth - 992), (int)-8, 1000, 600));

            //// 在窗口构造函数中设置不显示任务栏图标
            //this.ShowInTaskbar = false;
            // 在窗口加载时设置初始位置为右上角
            //Loaded += MainWindow_Loaded;
            // 设置浮窗信息
            this.SetOverlayInfo(teamList, this.GridGameOverlay);
            //// 绑定鼠标左键预览与点按事件
            //this.PreviewMouseDown += MainWindow_PreviewMouseDown;
            //this.MouseLeftButtonDown += new MouseButtonEventHandler(Window_MouseLeftButtonDown);
        }

        public void SetWindowTransparent()
        {
            IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            int extendedStyle = GetWindowLong(hwnd, GWL_STYLE);
            //int extendedStyle = 825566;
            _ = SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
            //_ = SetWindowLong(hwnd, GWL_EXSTYLE, 0x80020);
        }

        public void SetWindowNormal()
        {
            IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            int extendedStyle = GetWindowLong(hwnd, GWL_STYLE);
            _ = SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | ~WS_EX_TRANSPARENT);
        }

        public void SetOverlayInfo(List<OverlayGame> teamList, Grid grid)
        {
            UITool.ClearOverlayGrid(grid);

            foreach (var item in teamList)
            {
                Logger.Log("对象数据打印", "teamList");
                Logger.Log(item.ToString());

                // 输出到界面
                TextBlockMapName.Text = $"地图 : {item.Map}";

                RowDefinition rowDef = new();
                grid.RowDefinitions.Add(rowDef);   // 添加行定义

                Border border_player_civ = new();
                border_player_civ.SetValue(Grid.ColumnProperty, 0);
                border_player_civ.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1); // 设置行属性
                border_player_civ.HorizontalAlignment = HorizontalAlignment.Center;
                border_player_civ.VerticalAlignment = VerticalAlignment.Center;
                string str_player_civ = GameParameters.FlagFileDict.GetValueOrDefault(item.PlayerCiv);
                Logger.Log("Civ图片", str_player_civ);
                string mapUri = $"ms-appx:///Assets/Images/flags/{str_player_civ}";
                // 更换图片
                BitmapImage image = UITool.GenerateImage(mapUri);
                Image image_player_civ = new()
                {
                    Height = 32,
                    Stretch = Stretch.Uniform,
                    Source = image
                };
                border_player_civ.Child = image_player_civ;   // 将 Label 添加到 Border 的子元素集合中

                Border border_player_name = new();
                border_player_name.SetValue(Grid.ColumnProperty, 1);
                border_player_name.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1); // 设置行属性
                border_player_name.HorizontalAlignment = HorizontalAlignment.Stretch;
                border_player_name.VerticalAlignment = VerticalAlignment.Stretch;
                border_player_name.Background = new SolidColorBrush(GameParameters.ColorList[item.TeamNumber]);   // 设置背景颜色
                TextBlock label_player_name = new()
                {
                    Text = item.PlayerName,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                border_player_name.Child = label_player_name;   // 将 Label 添加到 Border 的子元素集合中

                Border border_rating = new();
                border_rating.SetValue(Grid.ColumnProperty, 2);
                border_rating.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1); // 设置行属性
                border_rating.HorizontalAlignment = HorizontalAlignment.Center;
                border_rating.VerticalAlignment = VerticalAlignment.Center;
                TextBlock label_rating = new()
                {
                    Text = item.Rating,
                    Foreground = new SolidColorBrush(Colors.Blue),
                    FontWeight = FontWeights.Bold
                };
                border_rating.Child = label_rating;   // 将 Label 添加到 Border 的子元素集合中

                Border border_rank = new();
                border_rank.SetValue(Grid.ColumnProperty, 3);
                border_rank.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1); // 设置行属性
                border_rank.HorizontalAlignment = HorizontalAlignment.Center;
                border_rank.VerticalAlignment = VerticalAlignment.Center;
                TextBlock label_rank = new()
                {
                    Text = $"# {item.Rank}",
                    Foreground = new SolidColorBrush(Colors.Black)
                };
                border_rank.Child = label_rank;   // 将 Label 添加到 Border 的子元素集合中

                Border border_winrate = new();
                border_winrate.SetValue(Grid.ColumnProperty, 4);
                border_winrate.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1); // 设置行属性
                border_winrate.HorizontalAlignment = HorizontalAlignment.Center;
                border_winrate.VerticalAlignment = VerticalAlignment.Center;
                TextBlock label_winrate = new()
                {
                    Text = item.Winrate,
                    Foreground = new SolidColorBrush(Colors.Green)
                };
                border_winrate.Child = label_winrate;   // 将 Label 添加到 Border 的子元素集合中

                Border border_wins = new();
                border_wins.SetValue(Grid.ColumnProperty, 5);
                border_wins.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1); // 设置行属性
                border_wins.HorizontalAlignment = HorizontalAlignment.Center;
                border_wins.VerticalAlignment = VerticalAlignment.Center;
                TextBlock label_wins = new()
                {
                    Text = item.Wins,
                    Foreground = new SolidColorBrush(Colors.YellowGreen)
                };
                border_wins.Child = label_wins;   // 将 Label 添加到 Border 的子元素集合中

                Border border_losses = new();
                border_losses.SetValue(Grid.ColumnProperty, 6);
                border_losses.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1); // 设置行属性
                border_losses.HorizontalAlignment = HorizontalAlignment.Center;
                border_losses.VerticalAlignment = VerticalAlignment.Center;
                TextBlock label_losses = new()
                {
                    Text = item.Losses,
                    Foreground = new SolidColorBrush(Colors.Red)
                };
                border_losses.Child = label_losses;   // 将 Label 添加到 Border 的子元素集合中

                // 将 Border 添加到 Grid 的子元素集合中，放置在最新的行中
                grid.Children.Add(border_player_civ);
                grid.Children.Add(border_player_name);
                grid.Children.Add(border_rating);
                grid.Children.Add(border_rank);
                grid.Children.Add(border_winrate);
                grid.Children.Add(border_wins);
                grid.Children.Add(border_losses);
            }
        }
    }
}
