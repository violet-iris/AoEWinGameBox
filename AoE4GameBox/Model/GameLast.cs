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
        public bool Ongoing { get; set; } = false;
        public bool JustFinished { get; set; } = false;
        public TeamMemberInfo[] TeamMembers { get; set; } = [];
    }
}
