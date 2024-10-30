using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnchapaxiAriel_ExamenP1.Data;
using AnchapaxiAriel_ExamenP1.Models;

namespace AnchapaxiAriel_ExamenP1.Controllers
{
    public class AnchapaxiModelController : Controller
    {
        private readonly AnchapaxiAriel_ExamenP1Context _context;

        public AnchapaxiModelController(AnchapaxiAriel_ExamenP1Context context)
        {
            _context = context;
        }

        // GET: AnchapaxiModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnchapaxiModel.ToListAsync());
        }

        // GET: AnchapaxiModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anchapaxiModel = await _context.AnchapaxiModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anchapaxiModel == null)
            {
                return NotFound();
            }

            return View(anchapaxiModel);
        }

        // GET: AnchapaxiModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnchapaxiModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,MoneyInTheBank,IsStudent,BirthDay,idPhone")] AnchapaxiModel anchapaxiModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anchapaxiModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anchapaxiModel);
        }

        // GET: AnchapaxiModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anchapaxiModel = await _context.AnchapaxiModel.FindAsync(id);
            if (anchapaxiModel == null)
            {
                return NotFound();
            }
            return View(anchapaxiModel);
        }

        // POST: AnchapaxiModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,MoneyInTheBank,IsStudent,BirthDay,idPhone")] AnchapaxiModel anchapaxiModel)
        {
            if (id != anchapaxiModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anchapaxiModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnchapaxiModelExists(anchapaxiModel.Id))
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
            return View(anchapaxiModel);
        }

        // GET: AnchapaxiModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anchapaxiModel = await _context.AnchapaxiModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anchapaxiModel == null)
            {
                return NotFound();
            }

            return View(anchapaxiModel);
        }

        // POST: AnchapaxiModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anchapaxiModel = await _context.AnchapaxiModel.FindAsync(id);
            if (anchapaxiModel != null)
            {
                _context.AnchapaxiModel.Remove(anchapaxiModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnchapaxiModelExists(int id)
        {
            return _context.AnchapaxiModel.Any(e => e.Id == id);
        }
    }
}
