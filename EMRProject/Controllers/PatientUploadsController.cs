using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMRProject.Data;
using EMRProject.Models;

namespace EMRProject.Controllers
{
    public class PatientUploadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientUploadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientUploads
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientUpload.ToListAsync());
        }

        // GET: PatientUploads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientUpload = await _context.PatientUpload
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientUpload == null)
            {
                return NotFound();
            }

            return View(patientUpload);
        }

        // GET: PatientUploads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientUploads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Age")] PatientUpload patientUpload)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientUpload);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientUpload);
        }

        // GET: PatientUploads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientUpload = await _context.PatientUpload.FindAsync(id);
            if (patientUpload == null)
            {
                return NotFound();
            }
            return View(patientUpload);
        }

        // POST: PatientUploads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Age")] PatientUpload patientUpload)
        {
            if (id != patientUpload.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientUpload);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientUploadExists(patientUpload.Id))
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
            return View(patientUpload);
        }

        // GET: PatientUploads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientUpload = await _context.PatientUpload
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientUpload == null)
            {
                return NotFound();
            }

            return View(patientUpload);
        }

        // POST: PatientUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientUpload = await _context.PatientUpload.FindAsync(id);
            _context.PatientUpload.Remove(patientUpload);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientUploadExists(int id)
        {
            return _context.PatientUpload.Any(e => e.Id == id);
        }
    }
}
