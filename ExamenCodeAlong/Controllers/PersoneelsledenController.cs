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
    public class PersoneelsledenController : Controller
    {
        private readonly EhelpBContext _context;

        public PersoneelsledenController(EhelpBContext context)
        {
            _context = context;
        }

        // GET: Personeelsleden
        public async Task<IActionResult> Index()
        {
            var ehelpBContext = _context.Personeelsleden.Include(p => p.Vestiging);
            return View(await ehelpBContext.ToListAsync());
        }

       

    }
}
