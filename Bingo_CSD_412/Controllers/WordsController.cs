using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bingo_CSD_412.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bingo_CSD_412.Controllers
{
    [Authorize]
    public class WordsController : Controller
    {
        private readonly BingoContext _context;

        public WordsController(BingoContext context)
        {
            _context = context;
        }

        // GET: Words
        public async Task<IActionResult> Index()
        {
            return View(await _context.Words.ToListAsync());
        }

        // GET: Words/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var word = await _context.Words
                .FirstOrDefaultAsync(m => m.WordId == id);
            if (word == null)
            {
                return NotFound();
            }

            return View(word);
        }

        // GET: Words/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Words/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WordId,Label,Description,Category")] Word word)
        {
            if (ModelState.IsValid)
            {
                _context.Add(word);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(word);
        }

        // GET: Words/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var word = await _context.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }
            return View(word);
        }

        // POST: Words/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WordId,Label,Description,Category")] Word word)
        {
            if (id != word.WordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(word);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WordExists(word.WordId))
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
            return View(word);
        }

        // GET: Words/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var word = await _context.Words
                .FirstOrDefaultAsync(m => m.WordId == id);
            if (word == null)
            {
                return NotFound();
            }

            return View(word);
        }

        // POST: Words/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var word = await _context.Words.FindAsync(id);
            _context.Words.Remove(word);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WordExists(int id)
        {
            return _context.Words.Any(e => e.WordId == id);
        }
    }
}
