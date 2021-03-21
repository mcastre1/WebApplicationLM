using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationLM.Data;
using WebApplicationLM.Models;

namespace WebApplicationLM.Controllers
{
    public class ColumnsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColumnsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Columns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Column.ToListAsync());
        }

        // GET: Columns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var column = await _context.Column
                .FirstOrDefaultAsync(m => m.ColumnId == id);
            if (column == null)
            {
                return NotFound();
            }

            return View(column);
        }

        // GET: Columns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Columns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColumnId,Title")] Column column)
        {
            if (ModelState.IsValid)
            {
                _context.Add(column);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(column);
        }

        // GET: Columns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var column = await _context.Column.FindAsync(id);
            if (column == null)
            {
                return NotFound();
            }
            return View(column);
        }

        // POST: Columns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColumnId,Title")] Column column)
        {
            if (id != column.ColumnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(column);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColumnExists(column.ColumnId))
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
            return View(column);
        }

        // GET: Columns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var column = await _context.Column
                .FirstOrDefaultAsync(m => m.ColumnId == id);
            if (column == null)
            {
                return NotFound();
            }

            return View(column);
        }

        // POST: Columns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var column = await _context.Column.FindAsync(id);
            _context.Column.Remove(column);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColumnExists(int id)
        {
            return _context.Column.Any(e => e.ColumnId == id);
        }
    }
}
