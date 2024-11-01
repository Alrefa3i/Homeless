namespace HomeLess.Models
{
    public class Review
    {
        public int UserId { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }

        public User User { get; set; }
        public product product { get; set; }
    }
}
