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
    public class PhoneModelsController : Controller
    {
        private readonly AnchapaxiAriel_ExamenP1Context _context;

        public PhoneModelsController(AnchapaxiAriel_ExamenP1Context context)
        {
            _context = context;
        }

        // GET: PhoneModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhoneModel.ToListAsync());
        }

        // GET: PhoneModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneModel = await _context.PhoneModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneModel == null)
            {
                return NotFound();
            }

            return View(phoneModel);
        }

        // GET: PhoneModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Year,Price")] PhoneModel phoneModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phoneModel);
        }

        // GET: PhoneModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneModel = await _context.PhoneModel.FindAsync(id);
            if (phoneModel == null)
            {
                return NotFound();
            }
            return View(phoneModel);
        }

        // POST: PhoneModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Year,Price")] PhoneModel phoneModel)
        {
            if (id != phoneModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneModelExists(phoneModel.Id))
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
            return View(phoneModel);
        }

        // GET: PhoneModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneModel = await _context.PhoneModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneModel == null)
            {
                return NotFound();
            }

            return View(phoneModel);
        }

        // POST: PhoneModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneModel = await _context.PhoneModel.FindAsync(id);
            if (phoneModel != null)
            {
                _context.PhoneModel.Remove(phoneModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneModelExists(int id)
        {
            return _context.PhoneModel.Any(e => e.Id == id);
        }
    }
}
