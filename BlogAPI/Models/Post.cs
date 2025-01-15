namespace BlogAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
    }
}
