using BasketTask.Data;
using BasketTask.Models;
using BasketTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketTask.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.Include(i => i.Images).ToListAsync();
            SliderImage sliderImage = await _context.SliderImages.FirstOrDefaultAsync();


            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                SliderImage = sliderImage,
            };
            return View(homeVM);
        }
    }
}
