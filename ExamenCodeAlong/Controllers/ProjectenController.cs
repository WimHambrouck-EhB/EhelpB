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
                        View(await _context.Projecten.Include(p => p.PersoneelslidProjecten).ThenInclude(pp => pp.Personeelslid).ToListAsync()) :
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

        public async Task<IActionResult> Koppelpersoneel(KoppelpersoneelViewModel? viewModel)
        {
            viewModel ??= new KoppelpersoneelViewModel();

            if (viewModel?.Project != null)
            {
                var personeelInProject = _context.PersoneelslidProject.Where(pp => pp.ProjectId == viewModel.Project.ProjectNaam).Include(pp => pp.Personeelslid);
                var personeelNietInProject = await _context.Personeelsleden.Where(p => !personeelInProject.Any(pp => pp.PersoneelslidId == p.Id)).ToListAsync();

                foreach (var project in personeelInProject)
                {
                    viewModel.Koppelingen.Add(project.Personeelslid, true);
                }

                foreach (var project in personeelNietInProject)
                {
                    viewModel.Koppelingen.Add(project, false);
                }
            }

            ViewData["Projecten"] = new SelectList(_context.Projecten, "ProjectNaam", "ProjectNaam");

            return View(viewModel);
        }

        [HttpPost, ActionName("Koppelpersoneel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KoppelpersoneelVerzenden(KoppelpersoneelViewModel? viewModel)
        {
            if (viewModel == null || viewModel.Project == null)
            {
                return NotFound();
            }

            var personeelslidProjecten = _context.PersoneelslidProject.Where(pp => pp.ProjectId == viewModel.Project.ProjectNaam);

            foreach (var item in viewModel.Koppelingen)
            {
                PersoneelslidProject? personeelslid = await personeelslidProjecten.SingleOrDefaultAsync(pp => pp.PersoneelslidId == item.Key.Id);

                if (item.Value)
                {
                    if (personeelslid == null)
                    {
                        personeelslid = new PersoneelslidProject
                        {
                            PersoneelslidId = item.Key.Id,
                            ProjectId = viewModel.Project.ProjectNaam
                        };

                        _context.Add(personeelslid);
                    }
                }
                else
                {
                    if (personeelslid != null)
                    {
                        _context.Remove(personeelslid);
                    }
                }
            }

            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(string id)
        {
            return (_context.Projecten?.Any(e => e.ProjectNaam == id)).GetValueOrDefault();
        }
    }
}
