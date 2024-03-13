namespace AoE4GameBox.Model
{
    internal class Player
    {
        public string Name { get; set; } = "Default"; // 玩家名
        public int ProfileId { get; set; } = 0; // Profile ID
        public string SteamId { get; set; } = "Default"; // Steam ID
        public string CountryArea { get; set; } = "Default"; // 国家或地区
        public string SiteUrl { get; set; } = "Default"; // Profile site
        public Avatar Avatars { get; set; } = new Avatar();   // 头像


        // Default constructor
        public Player()
        {
            this.Name = "Default";
            this.ProfileId = 0;
            this.SteamId = "Default";
            this.CountryArea = "Default";
            this.SiteUrl = "Default";
            this.Avatars = new Avatar();
        }

        // Full parameter constructor
        public Player(string name, int profileId, string steamId, string countryArea, string siteUrl, Avatar avatars)
        {
            this.Name = name;
            this.ProfileId = profileId;
            this.SteamId = steamId;
            this.CountryArea = countryArea;
            this.SiteUrl = siteUrl;
            this.Avatars = avatars;
        }

        // Copy constructor
        public Player(Player other)
        {
            this.Name = other.Name;
            this.ProfileId = other.ProfileId;
            this.SteamId = other.SteamId;
            this.CountryArea = other.CountryArea;
            this.SiteUrl = other.SiteUrl;
            this.Avatars = new Avatar(other.Avatars);
        }

        // Override ToString method to customize output
        public override string ToString()
        {
            //Logger.Info("PlayerName", Name);
            //Logger.Info("PlayerProfileId", ProfileId);
            //Logger.Info("PlayerSteamId", SteamId);
            //Logger.Info("PlayerSiteUrl", SiteUrl);
            //Logger.Info("PlayerAvatars", Avatars.ToString());
            //Logger.Info("PlayerCountryArea", CountryArea);
            return $"Name: {Name}, ProfileId: {ProfileId}, SteamId: {SteamId}, CountryArea: {CountryArea}, SiteUrl: {SiteUrl}, Avatars: {Avatars}";
        }
    }
}
