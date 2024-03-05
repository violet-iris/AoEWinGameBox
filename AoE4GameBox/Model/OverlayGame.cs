namespace AoE4GameBox.Model
{
    public class OverlayGame
    {
        public string Leaderboard { get; set; }
        public string Map { get; set; }
        public int TeamNumber { get; set; }
        public string PlayerName { get; set; }
        public string PlayerCiv { get; set; }
        public string Rating { get; set; }
        public string Rank { get; set; }
        public string Winrate { get; set; }
        public string Wins { get; set; }
        public string Losses { get; set; }

        // 无参构造方法
        public OverlayGame()
        {
            // 设置默认值
            Leaderboard = "Default";
            Map = "Default";
            TeamNumber = 0;
            PlayerName = "Default";
            PlayerCiv = "Default";
            Rating = "0";
            Rank = "Unranked";
            Winrate = "0%";
            Wins = "0";
            Losses = "0";
        }

        // 复制构造方法
        public OverlayGame(OverlayGame other)
        {
            // 使用传入的对象的属性值来初始化新对象
            Leaderboard = other.Leaderboard;
            Map = other.Map;
            TeamNumber = other.TeamNumber;
            PlayerName = other.PlayerName;
            PlayerCiv = other.PlayerCiv;
            Rating = other.Rating;
            Rank = other.Rank;
            Winrate = other.Winrate;
            Wins = other.Wins;
            Losses = other.Losses;
        }

        public override string ToString()
        {
            return $"Leaderboard: {Leaderboard}, Map: {Map}, Team Number: {TeamNumber}, " +
                   $"Player Name: {PlayerName}, Player Civ: {PlayerCiv}, Rating: {Rating}, " +
                   $"Rank: {Rank}, Winrate: {Winrate}, Wins: {Wins}, Losses: {Losses}";
        }
    }
}
