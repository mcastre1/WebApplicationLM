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
    public class WorkspacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkspacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Workspaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.Workspace.ToListAsync());
        }

        // GET: Workspaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workspace = await _context.Workspace
                .FirstOrDefaultAsync(m => m.WorkspaceId == id);
            if (workspace == null)
            {
                return NotFound();
            }

            return View(workspace);
        }

        // GET: Workspaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workspaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkspaceId,Title")] Workspace workspace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workspace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workspace);
        }

        // GET: Workspaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workspace = await _context.Workspace.FindAsync(id);
            if (workspace == null)
            {
                return NotFound();
            }
            return View(workspace);
        }

        // POST: Workspaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkspaceId,Title")] Workspace workspace)
        {
            if (id != workspace.WorkspaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workspace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkspaceExists(workspace.WorkspaceId))
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
            return View(workspace);
        }

        // GET: Workspaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workspace = await _context.Workspace
                .FirstOrDefaultAsync(m => m.WorkspaceId == id);
            if (workspace == null)
            {
                return NotFound();
            }

            return View(workspace);
        }

        // POST: Workspaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workspace = await _context.Workspace.FindAsync(id);
            _context.Workspace.Remove(workspace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkspaceExists(int id)
        {
            return _context.Workspace.Any(e => e.WorkspaceId == id);
        }
    }
}
