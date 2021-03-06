﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public Book()
        {
            ReviewList = new List<Commentary>();
        }
        public int Id { get; set; }
        public List<Commentary> ReviewList { get; set; }
        public string Title { get; set; }
        public int  NumberPages{ get; set; }
        public string Gender { get; set; }
        public string Author { get; set; }
        public long  Price { get; set; }

    }
}
