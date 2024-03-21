namespace AoE4GameBox.Model
{
    public class Avatar
    {
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Full { get; set; }

        private readonly string defaultAvatar = "https://static.aoe4world.com/assets/steam/missing_avatar-e242b35d00203aa906f62c1c86d27eefce0320fc9d02de64338abfa732303652.jpg";

        // Default constructor
        public Avatar()
        {
            this.Small = defaultAvatar;
            this.Medium = defaultAvatar;
            this.Full = defaultAvatar;
        }

        // Full parameter constructor
        public Avatar(string small, string medium, string full)
        {
            if (small == null)
            {
                this.Small = defaultAvatar;
                this.Medium = defaultAvatar;
                this.Full = defaultAvatar;
            } else
            {
                this.Small = small;
                this.Medium = medium;
                this.Full = full;
            }
        }

        // Copy constructor
        public Avatar(Avatar other)
        {
            this.Small = other.Small;
            this.Medium = other.Medium;
            this.Full = other.Full;
        }

        // Override ToString method to customize output
        public override string ToString()
        {
            return $"Small: {Small}, Medium: {Medium}, Full: {Full}";
        }
    }

}
