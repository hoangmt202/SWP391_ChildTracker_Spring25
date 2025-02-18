
using System.ComponentModel.DataAnnotations;


namespace DataAccess.Entity
{
    public class BlogEntity
    {
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserEntity Author { get; set; }
    }
}
