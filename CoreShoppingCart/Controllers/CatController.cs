using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreShoppingCart.Areas.Identity.Data;
using CoreShoppingCart.Models;

namespace CoreShoppingCart.Controllers
{
    public class CatController : Controller
    {
        private readonly SCartDbContext db;

        public CatController(SCartDbContext context)
        {
            db = context;
        }

        // GET: Cat
        public async Task<IActionResult> Index()
        {
            return View(await db.Categories.ToListAsync());                         
        }

        // GET: Cat/Details/5
        public async Task<IActionResult> Details(int? id)
        {          

            var c = await db.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
          
            return View(c);
        }

        // GET: Cat/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Cat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            

            var category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Cat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(category);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Cat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Categories == null)
            {
                return NotFound();
            }

            var category = await db.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Cat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Categories == null)
            {
                return Problem("Entity set 'SCartDbContext.Categories'  is null.");
            }
            var category = await db.Categories.FindAsync(id);
            if (category != null)
            {
                db.Categories.Remove(category);
            }
            
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return (db.Categories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
