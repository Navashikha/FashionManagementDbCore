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
    public class Suppliers : Controller
    {
        private readonly ApplicationDbContext _db;

        public Suppliers(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.Suppliers.ToList();
            return View(displaydata);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Supplier sp)
        {
            if (ModelState.IsValid)
            {
                _db.Add(sp);

                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sp);
        }

        // GET: Suppliers/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sp2 = await _db.Suppliers.FindAsync(id);
            if (sp2 == null)
            {
                return NotFound();
            }
            return View(sp2);
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Supplier sp2)
        {
            if (id != sp2.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(sp2);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(sp2);
        }

        // GET: Suppliers/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var sdetails = await _db.Suppliers.FindAsync(id);

            return View(sdetails);
        }

        // GET: Suppliers/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var sdetails = await _db.Suppliers.FindAsync(id);

            return View(sdetails);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var sdetails = await _db.Suppliers.FindAsync(id);
            _db.Suppliers.Remove(sdetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
