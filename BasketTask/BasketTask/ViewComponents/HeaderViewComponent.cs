using BasketTask.Data;
using BasketTask.Models;
using BasketTask.Services;
using BasketTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketTask.ViewComponents
{
    public class HeaderViewComponent: ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        public HeaderViewComponent(LayoutService layoutService, AppDbContext context)
        {
            _layoutService = layoutService;
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            

            Dictionary<string, string> settings = _layoutService.GetSetting();
            List<Categories> categories = await _context.Categories.Include(i => i.CategoryProducts).ToListAsync();
            List<CategoryProducts> categoryProducts = await _context.CategoryProducts.ToListAsync();

            LayoutVM layoutVM = new LayoutVM
            {
                Categories = categories,
                CategoryProducts = categoryProducts,
                Settings = settings
            };

            return (await Task.FromResult(View(layoutVM))); 
        }
    }
}
