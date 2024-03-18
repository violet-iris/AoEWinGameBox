using AoE4GameBox.Model;
using AoE4GameBox.Tools;
using Microsoft.UI.Text;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Media;
using System.Collections.Generic;

namespace AoE4GameBox.Pages
{
    public sealed partial class PageOSDSetting : Page
    {
        public PageOSDSetting()
        {
            this.InitializeComponent();
            // 开启页面缓存
            this.NavigationCacheMode = Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        public void SetOverlayInfo(List<OverlayGame> teamList)
        {
            UITool.ClearOverlayGrid(this.GridGame);

            foreach (var item in teamList)
            {
                Logger.Log("对象数据打印", "teamList");
                Logger.Log(item.ToString());

                // 输出到界面
                TextBlockMapName.Text = $"地图 : {item.Map}";

                RowDefinition rowDef = new();
                GridGame.RowDefinitions.Add(rowDef);   // 添加行定义

                Border border_player_civ = new();
                border_player_civ.SetValue(Grid.ColumnProperty, 0);
                border_player_civ.SetValue(Grid.RowProperty, GridGame.RowDefinitions.Count - 1); // 设置行属性
                border_player_civ.HorizontalAlignment = HorizontalAlignment.Center;
                border_player_civ.VerticalAlignment = VerticalAlignment.Center;
                string? str_player_civ = GameParameters.FlagFileDict.GetValueOrDefault(item.PlayerCiv);
                Logger.Log("Civ图片", str_player_civ);
                string mapUri = $"pack://application:,,,/images/flags/{str_player_civ}";
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
                border_player_name.SetValue(Grid.RowProperty, GridGame.RowDefinitions.Count - 1); // 设置行属性
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
                border_rating.SetValue(Grid.RowProperty, GridGame.RowDefinitions.Count - 1); // 设置行属性
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
                border_rank.SetValue(Grid.RowProperty, GridGame.RowDefinitions.Count - 1); // 设置行属性
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
                border_winrate.SetValue(Grid.RowProperty, GridGame.RowDefinitions.Count - 1); // 设置行属性
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
                border_wins.SetValue(Grid.RowProperty, GridGame.RowDefinitions.Count - 1); // 设置行属性
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
                border_losses.SetValue(Grid.RowProperty, GridGame.RowDefinitions.Count - 1); // 设置行属性
                border_losses.HorizontalAlignment = HorizontalAlignment.Center;
                border_losses.VerticalAlignment = VerticalAlignment.Center;
                TextBlock label_losses = new()
                {
                    Text = item.Losses,
                    Foreground = new SolidColorBrush(Colors.Red)
                };
                border_losses.Child = label_losses;   // 将 Label 添加到 Border 的子元素集合中

                // 将 Border 添加到 Grid 的子元素集合中，放置在最新的行中
                GridGame.Children.Add(border_player_civ);
                GridGame.Children.Add(border_player_name);
                GridGame.Children.Add(border_rating);
                GridGame.Children.Add(border_rank);
                GridGame.Children.Add(border_winrate);
                GridGame.Children.Add(border_wins);
                GridGame.Children.Add(border_losses);
            }
        }
    }
}
