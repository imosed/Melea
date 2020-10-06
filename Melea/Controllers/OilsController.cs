using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Melea.Data;
using Melea.Models;
using Microsoft.AspNetCore.Mvc;

namespace Melea.Controllers
{
    [Route("/api/[controller]/")]
    public class OilsController : Controller
    {
        private readonly MeleaContext _context;

        public OilsController(MeleaContext context)
        {
            _context = context;
        }
        
        [Route("list")]
        public ActionResult<IEnumerable<EssentialOil>> Index()
        {
            return _context.Oils.ToList();
        }
    }
}