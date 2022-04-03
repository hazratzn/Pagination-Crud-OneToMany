using BasketTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketTask.ViewModels
{
    public class LayoutVM
    {
        public List<Categories> Categories { get; set; }
        public List<CategoryProducts> CategoryProducts { get; set; }
        public Dictionary<string, string> Settings { get; set; }
    }
}
