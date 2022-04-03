using BasketTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketTask.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public SliderImage SliderImage { get; set; }
        public List<WeekendDiscount> WeekendDiscounts { get; set; }
    }
}
