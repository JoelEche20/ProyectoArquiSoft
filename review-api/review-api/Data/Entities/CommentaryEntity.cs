using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace review_api.Data.Entities
{
    public class CommentaryEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string CommentaryText { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}
