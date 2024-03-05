using System.Text.Json;

namespace AoE4GameBox.Model
{
    internal class PlayerBind
    {
        private static PlayerBind instance;

        public string Name { get; private set; }    // 玩家名
        public string ProfileId { get; private set; }   // Profile ID
        public string SteamId { get; private set; } // Steam ID
        public string Country { get; private set; } // 国家或地区

        // 私有构造方法，防止外部直接实例化
        private PlayerBind()
        {
            Name = "default";
            ProfileId = "default";
            SteamId = "default";
            Country = "default";
        }

        // 获取单例实例的方法
        public static PlayerBind Instance
        {
            get
            {
                // 在此使用默认值或其他逻辑初始化实例
                // 复合分配
                instance ??= new PlayerBind();
                return instance;
            }
        }

        // 修改构造方法，接受 JSON 字符串参数
        public static void InitializeFromResponseString(string response)
        {
            // 使用 System.Text.Json.JsonDocument 解析 JSON 字符串
            using JsonDocument document = JsonDocument.Parse(response);
            JsonElement rootElement = document.RootElement;

            // 使用属性初始化器为属性赋值
            Instance.Name = rootElement.GetProperty("name").GetString() ?? "default";
            Instance.ProfileId = rootElement.GetProperty("profile_id").GetRawText() ?? "default";
            Instance.SteamId = rootElement.GetProperty("steam_id").GetString() ?? "default";
            Instance.Country = rootElement.GetProperty("country").GetString() ?? "default";
        }
    }
}
