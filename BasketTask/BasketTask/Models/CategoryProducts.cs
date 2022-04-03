using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketTask.Models
{
    public class CategoryProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Categories Categories { get; set; }
        public int CategoriesId { get; set; }
    }
}
