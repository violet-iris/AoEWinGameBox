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
        public ClassGameModeInfo Modes { get; set; } = new ClassGameModeInfo();

        public TeamMemberInfo()
        {
            Civilization = "Default";
            Result = "Default";
            Rating = 0;
            RatingDiff = 0;
            Mmr = 0;
            MmrDiff = 0;
            InputType = "Default";
            Player = new Player();
            Modes = new ClassGameModeInfo();
        }

        public TeamMemberInfo(string civilization, string result, int rating, int ratingDiff, int mmr, int mmrDiff, string inputType, Player player, ClassGameModeInfo modes)
        {
            Civilization = civilization;
            Result = result;
            Rating = rating;
            RatingDiff = ratingDiff;
            Mmr = mmr;
            MmrDiff = mmrDiff;
            InputType = inputType;
            Player = player;
            Modes = modes;
        }
    }

    public class ClassGameModeInfo
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
        public ClassRatingHistory RatingHistory { get; set; } = new ClassRatingHistory();
        public int Season { get; set; } = 7;
        public ClassPreviousSeasons PreviousSeasons { get; set; } = new ClassPreviousSeasons();

        public ClassGameModeInfo()
        {
            ModeName = "Default";
            Rating = 0;
            MaxRating = 0;
            MaxRating7d = 0;
            MaxRating1m = 0;
            Rank = 0;
            RankLevel = "Default";
            Streak = 0;
            GamesCount = 0;
            WinsCount = 0;
            LossesCount = 0;
            DisputesCount = 0;
            DropsCount = 0;
            LastGameAt = "Default";
            WinRate = 0;
            RatingHistory = new ClassRatingHistory();
            Season = 7;
            PreviousSeasons = new ClassPreviousSeasons();
        }

        public ClassGameModeInfo(string modeName, int rating, int maxRating, int maxRating7d, int maxRating1m, int rank, string rankLevel, int streak, int gamesCount, int winsCount, int lossesCount, int disputesCount, int dropsCount, string lastGameAt, int winRate, ClassRatingHistory ratingHistory, int season, ClassPreviousSeasons previousSeasons)
        {
            ModeName = modeName;
            Rating = rating;
            MaxRating = maxRating;
            MaxRating7d = maxRating7d;
            MaxRating1m = maxRating1m;
            Rank = rank;
            RankLevel = rankLevel;
            Streak = streak;
            GamesCount = gamesCount;
            WinsCount = winsCount;
            LossesCount = lossesCount;
            DisputesCount = disputesCount;
            DropsCount = dropsCount;
            LastGameAt = lastGameAt;
            WinRate = winRate;
            RatingHistory = ratingHistory;
            Season = season;
            PreviousSeasons = previousSeasons;
        }
    }

    public class ClassRatingHistory
    {
        public int GameId { get; set; } = 0;
        public int Rating { get; set; } = 0;
        public int Streak { get; set; } = 0;
        public int WinsCount { get; set; } = 0;
        public int DropsCount { get; set; } = 0;
        public int DisputesCount { get; set; } = 0;
        public int GamesCount { get; set; } = 0;

        public ClassRatingHistory()
        {
            GameId = 0;
            Rating = 0;
            Streak = 0;
            WinsCount = 0;
            DropsCount = 0;
            DisputesCount = 0;
            GamesCount = 0;
        }

        public ClassRatingHistory(int gameId, int rating, int streak, int winsCount, int dropsCount, int disputesCount, int gamesCount)
        {
            GameId = gameId;
            Rating = rating;
            Streak = streak;
            WinsCount = winsCount;
            DropsCount = dropsCount;
            DisputesCount = disputesCount;
            GamesCount = gamesCount;
        }
    }

    public class ClassPreviousSeasons
    {
        public int Rating { get; set; } = 0;
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
        public int Season { get; set; } = 0;

        public ClassPreviousSeasons()
        {
            Rating = 0;
            Rank = 0;
            RankLevel = "Default";
            Streak = 0;
            GamesCount = 0;
            WinsCount = 0;
            LossesCount = 0;
            DisputesCount = 0;
            DropsCount = 0;
            LastGameAt = "Default";
            WinRate = 0;
            Season = 0;
        }

        public ClassPreviousSeasons(int rating, int rank, string rankLevel, int streak, int gamesCount, int winsCount, int lossesCount, int disputesCount, int dropsCount, string lastGameAt, int winRate, int season)
        {
            Rating = rating;
            Rank = rank;
            RankLevel = rankLevel;
            Streak = streak;
            GamesCount = gamesCount;
            WinsCount = winsCount;
            LossesCount = lossesCount;
            DisputesCount = disputesCount;
            DropsCount = dropsCount;
            LastGameAt = lastGameAt;
            WinRate = winRate;
            Season = season;
        }
    }
}
