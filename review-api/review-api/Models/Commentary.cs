using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace review_api.Models
{
    public class Commentary
    {
        [Required]
        public int Id { get; set; }
        public string CommentaryText { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int BookId { get; set; }

    }
}
