using System;

namespace AoE4GameBox.Model
{
    internal class GameLast
    {
        public int ProfileId { get; set; } = 0;
        public int GameId { get; set; } = 0;
        public DateTimeOffset StartedAt { get; set; } = DateTimeOffset.MinValue;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.MinValue;
        public int Duration { get; set; } = 0;
        public string Map { get; set; } = "Default";
        public string Kind { get; set; } = "Default";
        public string Leaderboard { get; set; } = "Default";
        public string MmrLeaderboard { get; set; } = "Default";
        public int Season { get; set; } = 0;
        public string Server { get; set; } = "Default";
        public int Patch { get; set; } = 0;
        public int AvarageRating { get; set; } = 0;
        public int AvarageRatingDeviation { get; set; } = 0;
        public int AvarageMmr { get; set; } = 0;
        public int AvarageMmrDeviation { get; set; } = 0;
        public bool Ongoing { get; set; } = false;
        public bool JustFinished { get; set; } = false;
        public TeamMemberInfo[] TeamMembers { get; set; } = [];

        public GameLast()
        {
            ProfileId = 0;
            GameId = 0;
            StartedAt = DateTimeOffset.MinValue;
            UpdatedAt = DateTimeOffset.MinValue;
            Duration = 0;
            Map = "Default";
            Kind = "Default";
            Leaderboard = "Default";
            MmrLeaderboard = "Default";
            Season = 0;
            Server = "Default";
            Patch = 0;
            AvarageRating = 0;
            AvarageRatingDeviation = 0;
            AvarageMmr = 0;
            AvarageMmrDeviation = 0;
            Ongoing = false;
            JustFinished = false;
            TeamMembers = [];
        }

        public GameLast(int profileId, int gameId, DateTimeOffset startedAt, DateTimeOffset updatedAt, int duration, string map, string kind, string leaderboard, string mmrLeaderboard, int season, string server, int patch, int avarageRating, int avarageRatingDeviation, int avarageMmr, int avarageMmrDeviation, bool ongoing, bool justFinished, TeamMemberInfo[] teamMembers)
        {
            ProfileId = profileId;
            GameId = gameId;
            StartedAt = startedAt;
            UpdatedAt = updatedAt;
            Duration = duration;
            Map = map;
            Kind = kind;
            Leaderboard = leaderboard;
            MmrLeaderboard = mmrLeaderboard;
            Season = season;
            Server = server;
            Patch = patch;
            AvarageRating = avarageRating;
            AvarageRatingDeviation = avarageRatingDeviation;
            AvarageMmr = avarageMmr;
            AvarageMmrDeviation = avarageMmrDeviation;
            Ongoing = ongoing;
            JustFinished = justFinished;
            TeamMembers = teamMembers;
        }
    }
}
