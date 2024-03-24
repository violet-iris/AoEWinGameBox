namespace AoE4GameBox.Model
{
    public class TeamMemberInfo
    {
        public string Civilization { get; set; } = "Default";
        public string Result { get; set; } = "Default";
        public int Rating { get; set; } = 0;
        public int RatingDiff { get; set; } = 0;
        public int Mmr { get; set; } = 0;
        public int MmrDiff { get; set; } = 0;
        public string InputType { get; set; } = "Default";
        public Player Player { get; set; } = new Player();
    }

    public class GameModeInfo
    {
        public string ModeName { get; set; } = "Default";
        public int Rating { get; set; } = 0;
        public int MaxRating { get; set; } = 0;
        public int MaxRating7d { get; set; } = 0;
        public int MaxRating1m { get; set; } = 0;
        public int Rank { get; set; } = 0;
        public string RankLevel { get; set; } = "Default";
        public int Streak { get; set; } = 0;
        public int GamesCount { get; set; } = 0;
        public int WinsCount { get; set; } = 0;
        public int LossesCount { get; set; } = 0;
        public int DisputesCount { get; set; } = 0;
        public int DropsCount { get; set; } = 0;
        public string LastGameAt { get; set; } = "Default";
        public int WinRate { get; set; } = 0;

        public int Season { get; set; } = 7;
    }
}
