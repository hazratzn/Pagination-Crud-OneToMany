using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasketTask.Models
{
    public class WeekendDiscount
    {
        public int Id { get; set; }
        public string Discount { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        [Required]
        public string Images { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
