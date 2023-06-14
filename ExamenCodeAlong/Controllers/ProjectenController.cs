using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenCodeAlong.Data;
using ExamenCodeAlong.Models;

namespace ExamenCodeAlong.Controllers
{
    public class ProjectenController : Controller
    {
        private readonly EhelpBContext _context;

        public ProjectenController(EhelpBContext context)
        {
            _context = context;
        }

        // GET: Projecten
        public async Task<IActionResult> Index()
        {
              return _context.Projecten != null ? 
                          View(await _context.Projecten.Include(p => p.PersoneelslidProjecten).ThenInclude(pp => pp.Personeelslid).ToListAsync()):
                          Problem("Entity set 'EhelpBContext.Projecten'  is null.");
        }


        // GET: Projecten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projecten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectNaam,Status,HuidigBudget")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        private bool ProjectExists(string id)
        {
          return (_context.Projecten?.Any(e => e.ProjectNaam == id)).GetValueOrDefault();
        }
    }
}
