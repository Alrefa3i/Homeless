namespace HomeLess.Models
{
    public class Comment
    {
       
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }

        public User User { get; set; }
        public product Product { get; set; }
    }
}
