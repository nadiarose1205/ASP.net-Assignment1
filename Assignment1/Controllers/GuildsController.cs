using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class GuildsController : Controller
    {
        private readonly Assignment1Context _context;

        public GuildsController(Assignment1Context context)
        {
            _context = context;
        }

        // GET: Guilds
        public async Task<IActionResult> Index()
        {
            //return View(//await _context.Guild.ToListAsync());
            return View();
        }

        // GET: Guilds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guild = await _context.Guild
                .FirstOrDefaultAsync(m => m.GuildID == id);
            if (guild == null)
            {
                return NotFound();
            }

            return View(guild);
        }

        // GET: Guilds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guilds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuildID,GuildName,GuildTag,GuildHall,Level")] Guild guild)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guild);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guild);
        }

        // GET: Guilds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guild = await _context.Guild.FindAsync(id);
            if (guild == null)
            {
                return NotFound();
            }
            return View(guild);
        }

        // POST: Guilds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuildID,GuildName,GuildTag,GuildHall,Level")] Guild guild)
        {
            if (id != guild.GuildID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guild);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuildExists(guild.GuildID))
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
            return View(guild);
        }

        // GET: Guilds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guild = await _context.Guild
                .FirstOrDefaultAsync(m => m.GuildID == id);
            if (guild == null)
            {
                return NotFound();
            }

            return View(guild);
        }

        // POST: Guilds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guild = await _context.Guild.FindAsync(id);
            _context.Guild.Remove(guild);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuildExists(int id)
        {
            return _context.Guild.Any(e => e.GuildID == id);
        }
    }
}
