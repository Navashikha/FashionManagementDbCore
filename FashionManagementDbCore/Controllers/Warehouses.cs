using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FashionManagementDbCore.Models;
using Microsoft.AspNetCore.Authorization;
using FashionManagementDbCore.Data;

namespace FashionManagementCore.Controllers
{
    [Authorize]
    public class Warehouses : Controller
    {
        private readonly ApplicationDbContext _db;

        public Warehouses(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.Warehouses.ToList();
            return View(displaydata);
        }

        // GET: Warehouses/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Warehouse wh1)
        {
            if (ModelState.IsValid)
            {
                _db.Add(wh1);

                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wh1);
        }

        // GET: Warehouses/Edit

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wh2 = await _db.Warehouses.FindAsync(id);
            if (wh2 == null)
            {
                return NotFound();
            }
            return View(wh2);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Warehouse wh2)
        {
            if (id != wh2.WarehouseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(wh2);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(wh2);
        }

        // GET: Warehouses/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var wdetails = await _db.Warehouses.FindAsync(id);

            return View(wdetails);
        }

        // GET: Warehouses/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var wdetails = await _db.Warehouses.FindAsync(id);

            return View(wdetails);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var wdetails = await _db.Warehouses.FindAsync(id);
            _db.Warehouses.Remove(wdetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
