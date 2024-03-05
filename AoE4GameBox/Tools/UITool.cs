using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Linq;

namespace AoE4GameBox.Tools
{
    internal class UITool
    {
        public static void ClearOverlayGrid(Grid grid)
        {
            // 删除第二行及其后的所有行
            for (int i = grid.RowDefinitions.Count - 1; i >= 1; i--)
            {
                // 删除行
                grid.RowDefinitions.RemoveAt(i);
                // 删除行中的子元素
                for (int j = 0; j < grid.ColumnDefinitions.Count; j++)
                {
                    UIElement element = grid.Children.Cast<UIElement>()
                        .FirstOrDefault(e => Grid.GetRow((FrameworkElement)e) == i && Grid.GetColumn((FrameworkElement)e) == j);
                    if (element != null)
                    {
                        grid.Children.Remove(element);
                    }
                }
            }
        }

        public static BitmapImage GenerateImage(string uri)
        {
            // TODO : 不确定写法是否正确
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri(uri);
            return bitmapImage;
        }
    }
}
