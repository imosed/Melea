using System;
using System.Collections.Generic;
using System.Linq;
using Melea.Data;
using Melea.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Melea.Controllers
{
    [Route("/api/[controller]/")]
    public class BlendsController : Controller
    {
        private readonly MeleaContext _context;
        public BlendsController(MeleaContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<bool> AddBlend([FromBody] RecipePost recipe)
        {
            var blend = new Blend {Name = recipe.Name};
            _context.Blends.Add(blend);
            var additions = _context.SaveChanges() > 0;
            recipe.Volumes.ToList().ForEach(v => v.BlendId = blend.Id);
            _context.Volumes.AddRange(recipe.Volumes);
            return _context.SaveChanges() > 0 || additions;
        }

        [Route("all")]
        public ActionResult<IEnumerable<Blend>> AllBlends()
        {
            return _context.Blends
                .Include(e => e.Volumes)
                .ThenInclude(v => v.Oil).ToList();
        }

        [Route("random")]
        public ActionResult<Blend> RandomBlend()
        {
            var blends = _context.Blends.ToList();
            if (!blends.Any()) return null;

            var rnd = new Random();
            var blendIds = blends.Select(b => b.Id).Distinct().ToList();
            var blendId = blendIds[blendIds.Count > 1 ? rnd.Next() % blendIds.Count : 0];

            return _context.Blends
                .Include(e => e.Volumes)
                .ThenInclude(v => v.Oil)
                .Single(b => b.Id == blendId);
        }
    }
}