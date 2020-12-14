using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Data.Entites
{
    public class UserEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
