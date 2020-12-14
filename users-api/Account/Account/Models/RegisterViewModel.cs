using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Direction { get; set; }

        public int Phone { get; set; }

        [Required]
        [StringLength(50, MinimumLength =5)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength =5)]
        public string ConfirmPassword { get; set; }
    }
}
