using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Commentary
    {
        public int  Id { get; set; }
        public string  CommentaryText { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
