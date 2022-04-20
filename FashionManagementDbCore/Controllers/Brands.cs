using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FashionManagementDbCore.Models;
using FashionManagementDbCore.Data;

namespace FashionManagementCore.Controllers
{
    public class Brands : Controller
    {
        private readonly ApplicationDbContext _db;

        public Brands(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.Brands.ToList();
            return View(displaydata);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Brand bd)
        {
            if (ModelState.IsValid)
            {
                _db.Add(bd);

                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bd);
        }

        // GET: Brands/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bd2 = await _db.Brands.FindAsync(id);
            if (bd2 == null)
            {
                return NotFound();
            }
            return View(bd2);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Brand bd2)
        {
            if (id != bd2.BrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(bd2);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(bd2);
        }

        // GET: Brands/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var bdetails = await _db.Brands.FindAsync(id);

            return View(bdetails);
        }

        // GET: Brands/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var bdetails = await _db.Brands.FindAsync(id);

            return View(bdetails);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var bdetails = await _db.Brands.FindAsync(id);
            _db.Brands.Remove(bdetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
