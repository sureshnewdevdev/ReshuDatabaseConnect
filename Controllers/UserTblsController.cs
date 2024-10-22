using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database_Connect.Models;

namespace Database_Connect.Controllers
{
    public class UserTblsController : Controller
    {
        private readonly BookingDbContext _context;

        public UserTblsController(BookingDbContext context)
        {
            //BookingDbContext wo = new BookingDbContext();
            _context = context;
        }

        // GET: UserTbls
        public async Task<IActionResult> Index()
        {
            var bookingDbContext = _context.UserTbls.Include(u => u.Role);
            return View(await bookingDbContext.ToListAsync());
        }

        // GET: UserTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTbl = await _context.UserTbls
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTbl == null)
            {
                return NotFound();
            }

            return View(userTbl);
        }

        // GET: UserTbls/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.RoleTbls, "RoleId", "RoleId");
            return View();
        }

        // POST: UserTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ContactDetails,RoleId")] UserTbl userTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.RoleTbls, "RoleId", "RoleId", userTbl.RoleId);
            return View(userTbl);
        }

        // GET: UserTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTbl = await _context.UserTbls.FindAsync(id);
            if (userTbl == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.RoleTbls, "RoleId", "RoleId", userTbl.RoleId);
            return View(userTbl);
        }

        // POST: UserTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ContactDetails,RoleId")] UserTbl userTbl)
        {
            if (id != userTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTblExists(userTbl.Id))
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
            ViewData["RoleId"] = new SelectList(_context.RoleTbls, "RoleId", "RoleId", userTbl.RoleId);
            return View(userTbl);
        }

        // GET: UserTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTbl = await _context.UserTbls
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTbl == null)
            {
                return NotFound();
            }

            return View(userTbl);
        }

        // POST: UserTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTbl = await _context.UserTbls.FindAsync(id);
            if (userTbl != null)
            {
                _context.UserTbls.Remove(userTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTblExists(int id)
        {
            return _context.UserTbls.Any(e => e.Id == id);
        }
    }
}
