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
    public class Products : Controller
    {
        private readonly ApplicationDbContext _db;

        public Products(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.Products.ToList();
            return View(displaydata);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Product pd)
        {
            if (ModelState.IsValid)
            {
                _db.Add(pd);

                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pd);
        }

        // GET: Products/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pd2 = await _db.Products.FindAsync(id);
            if (pd2 == null)
            {
                return NotFound();
            }
            return View(pd2);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product pd2)
        {
            if (id != pd2.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(pd2);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(pd2);
        }

        // GET: Products/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var pdetails = await _db.Products.FindAsync(id);

            return View(pdetails);
        }

        // GET: Products/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var pdetails = await _db.Products.FindAsync(id);

            return View(pdetails);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var pdetails = await _db.Products.FindAsync(id);
            _db.Products.Remove(pdetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
