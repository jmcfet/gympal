using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPal.Core.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string Location { get; set; }
        [StringLength(1), Required]
        public string Gender { get; set; }
        [StringLength(50), Required]
        public string Email { get; set; }
        public decimal level { get; set; }
        [StringLength(1)]
        public string isPro { get; set; }
        [StringLength(10), Required]
        public string Password { get; set; }
    }
}
