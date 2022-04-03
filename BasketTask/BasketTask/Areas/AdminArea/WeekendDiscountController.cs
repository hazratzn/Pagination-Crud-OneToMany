using BasketTask.Data;
using BasketTask.Models;
using BasketTask.Utilities.File;
using BasketTask.Utilities.Helpers;
using BasketTask.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BasketTask.Areas.AdminArea
{
    [Area("AdminArea")]
    public class WeekendDiscountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public WeekendDiscountController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<WeekendDiscount> weekendDiscounts = await _context.WeekendDiscounts.ToListAsync();

            HomeVM homeVM = new HomeVM
            {
                WeekendDiscounts = weekendDiscounts
            };
            return View(homeVM);
        }

        public IActionResult Detail(int id)
        {
            var weekendDiscount = _context.WeekendDiscounts.FirstOrDefault(m => m.Id == id);
            return View(weekendDiscount);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WeekendDiscount weekendDiscount)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();

            if (!weekendDiscount.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Image type is wrong");
                return View();
            }

            if (!weekendDiscount.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Image size is wrong");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + weekendDiscount.Photo.FileName;

            string path = Helper.GetFilePath(_env.WebRootPath,"assets", "img", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await weekendDiscount.Photo.CopyToAsync(stream);
            }

            weekendDiscount.Images = fileName;
            await _context.WeekendDiscounts.AddAsync(weekendDiscount);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            WeekendDiscount weekendDiscount = await GetBannerById(id);

            if (weekendDiscount == null) return NotFound();

            string path = Helper.GetFilePath(_env.WebRootPath, "assets", "img", weekendDiscount.Images);

            Helper.DeleteFile(path);

            _context.WeekendDiscounts.Remove(weekendDiscount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var weekendDiscount = await GetBannerById(id);
            if (weekendDiscount is null) return NotFound();
            return View(weekendDiscount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WeekendDiscount weekendDiscount)
        {
            var dbWeekendDiscount = await GetBannerById(id);
            if (dbWeekendDiscount == null) return NotFound();

            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();

            if (!weekendDiscount.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Image type is wrong");
                return View(dbWeekendDiscount);
            }

            if (!weekendDiscount.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Image size is wrong");
                return View(dbWeekendDiscount);
            }

            string path = Helper.GetFilePath(_env.WebRootPath, "assets", "img", dbWeekendDiscount.Images);

            Helper.DeleteFile(path);


            string fileName = Guid.NewGuid().ToString() + "_" + weekendDiscount.Photo.FileName;

            string newPath = Helper.GetFilePath(_env.WebRootPath, "assets", "img", fileName);

            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await weekendDiscount.Photo.CopyToAsync(stream);
            }

            dbWeekendDiscount.Images = fileName;
            dbWeekendDiscount.Name = weekendDiscount.Name;
            dbWeekendDiscount.Discount = weekendDiscount.Discount;
            dbWeekendDiscount.Decription = weekendDiscount.Decription;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<WeekendDiscount> GetBannerById(int id)
        {
            return await _context.WeekendDiscounts.FindAsync(id);
        }
    }
}
