using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public class BookEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int NumberPages { get; set; }
        public string Gender { get; set; }
        public string Author { get; set; }
        public long Price { get; set; }
    }
}
