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
    public class Customers : Controller
    {
        private readonly ApplicationDbContext _db;

        public Customers(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.Customers.ToList();
            return View(displaydata);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Customer cs)
        {
            if (ModelState.IsValid)
            {
                _db.Add(cs);

                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cs);
        }
        // GET: Customers/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cs2 = await _db.Customers.FindAsync(id);
            if (cs2 == null)
            {
                return NotFound();
            }
            return View(cs2);
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer cs2)
        {
            if (id != cs2.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(cs2);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(cs2);
        }

        // GET: Customers/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var cdetails = await _db.Customers.FindAsync(id);

            return View(cdetails);
        }

        // GET: Customers/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var cdetails = await _db.Customers.FindAsync(id);

            return View(cdetails);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var cdetails = await _db.Customers.FindAsync(id);
            _db.Customers.Remove(cdetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
