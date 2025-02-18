
using System.ComponentModel.DataAnnotations;


namespace DataAccess.Entity
{
    public class BlogEntity
    {

        [Key]
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(5000)]
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
