namespace AoE4GameBox.Model
{
    public class Avatar
    {
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Full { get; set; }

        // Default constructor
        public Avatar()
        {
            this.Small = "Default";
            this.Medium = "Default";
            this.Full = "Default";
        }

        // Full parameter constructor
        public Avatar(string small, string medium, string full)
        {
            if (small == null)
            {
                this.Small = "Default";
                this.Medium = "Default";
                this.Full = "Default";
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
