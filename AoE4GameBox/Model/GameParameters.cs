using System.Collections.Generic;
using System.Drawing;

namespace AoE4GameBox.Model
{
    public static class GameParameters
    {
        // 列表，用于存储文件名
        public static readonly List<string> FlagFiles = [
            "Abbasid_Dynasty.png",
            "Ayyubids.png",
            "Byzantines.png",
            "Chinese.png",
            "Delhi_Sultanate.png",
            "English.png",
            "French.png",
            "Holy_Roman_Empire.png",
            "Japanese.png",
            "Jeanne_Darc.png",
            "Malians.png",
            "Mongols.png",
            "Order_Of_The_Dragon.png",
            "Ottomans.png",
            "Rus.png",
            "Zhu_Xis_Legacy.png"
        ];

        public static readonly Dictionary<string, string> FlagFileDict = new()
        {
            { "abbasid_dynasty", "Abbasid_Dynasty.png" },
            { "ayyubids", "Ayyubids.png" },
            { "byzantines", "Byzantines.png" },
            { "chinese", "Chinese.png" },
            { "delhi_sultanate", "Delhi_Sultanate.png" },
            { "english", "English.png" },
            { "french", "French.png" },
            { "holy_roman_empire", "Holy_Roman_Empire.png" },
            { "japanese", "Japanese.png" },
            { "jeanne_darc", "Jeanne_Darc.png" },
            { "malians", "Malians.png" },
            { "mongols", "Mongols.png" },
            { "order_of_the_dragon", "Order_Of_The_Dragon.png" },
            { "ottomans", "Ottomans.png" },
            { "rus", "Rus.png" },
            { "zhu_xis_legacy", "Zhu_Xis_Legacy.png" }
        };

        // 列表，用于存储文件名
        public static readonly List<string> MapFiles = [
            "Altai.png",
            "Ancient_Spires.png",
            "Archipelago.png",
            "Black_Forest.png",
            "Boulder_Bay.png",
            "Confluence.png",
            "Continental.png",
            "Danube_River.png",
            "Dry_Arabia.png",
            "Four_Lakes.png",
            "French_Pass.png",
            "High_View.png",
            "Hill_and_Dale.png",
            "King_of_The_Hill.png",
            "Lipany.png",
            "Marshland.png",
            "Mega_Random.png",
            "Mongolian_Heights.png",
            "Mountain_Pass.png",
            "Nagari.png",
            "Warring_Islands.png"
        ];

        public static readonly List<Color> ColorList = [
            Color.FromArgb(90, 74, 255, 2),
            Color.FromArgb(90, 3, 179, 255),
            Color.FromArgb(90, 255, 0, 0),
            Color.FromArgb(90, 255, 0, 255),
            Color.FromArgb(90, 255, 255, 0),
            Color.FromArgb(90, 112, 161, 255),
            Color.FromArgb(90, 46, 213, 115),
            Color.FromArgb(90, 164, 176, 190),
            Color.FromArgb(90, 87, 96, 111),
            Color.FromArgb(90, 236, 204, 104),
            Color.FromArgb(90, 255, 127, 80),
            Color.FromArgb(90, 255, 107, 129),
            Color.FromArgb(90, 83, 82, 237)
        ];
    }
}
