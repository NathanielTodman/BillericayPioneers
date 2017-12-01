using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BP.Data;

namespace BP.Controllers
{
    public class PerformancesController : Controller
    {
        private readonly BPContext _context;

        public PerformancesController(BPContext context)
        {
            _context = context;
        }

        // GET: Performances
        public async Task<IActionResult> Index(int matchID)
        {
            var bPContext = _context.Performances.Where(m => m.MatchID == matchID)
                .Include(p => p.Match).Include(p => p.Player)
                .OrderByDescending(g=>g.TotalPoints);
            ViewData["MatchID"] = matchID;
            return View(await bPContext.ToListAsync());
        }

        // GET: Performances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performance = await _context.Performances
                .Include(p => p.Match)
                .Include(p => p.Player)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (performance == null)
            {
                return NotFound();
            }

            return View(performance);
        }

        // GET: Performances/Create
        public IActionResult Create(int matchID)
        {
            ViewData["PlayerID"] = new SelectList(_context.Players, "ID", "FullName");
            var model = new Performance();
            model.MatchID = matchID;
            model.Match = _context.Matches.Where(i => i.ID == matchID)
                .Include("Oposition").FirstOrDefault();
            return View(model);
        }

        // POST: Performances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PlayerID,MatchID,Position,Appearance,Goals,CleanSheet,Assists,GoalsConceeded,PenaltiesSaved,PenaltiesMissed,MOTM,YellowCard,RedCard")] Performance performance)
        {
            if (ModelState.IsValid)
            {
                ScoreCalculator.CalculateTotal(performance, _context);
                _context.Add(performance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { matchID = performance.MatchID });
            }
            ViewData["MatchID"] = new SelectList(_context.Matches, "ID", "ID", performance.MatchID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "ID", "ID", performance.PlayerID);
            return View(performance);
        }

        // GET: Performances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performance = await _context.Performances.SingleOrDefaultAsync(m => m.ID == id);
            if (performance == null)
            {
                return NotFound();
            }
            ViewData["MatchID"] = new SelectList(_context.Matches, "ID", "ID", performance.MatchID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "ID", "FullName", performance.PlayerID);
            return View(performance);
        }

        // POST: Performances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PlayerID,MatchID,Position,Appearance,Goals,CleanSheet,Assists,GoalsConceeded,PenaltiesSaved,PenaltiesMissed,MOTM,YellowCard,RedCard")] Performance performance)
        {
            if (id != performance.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ScoreCalculator.CalculateTotal(performance, _context);
                    _context.Update(performance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformanceExists(performance.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { matchID = performance.MatchID });
            }
            ViewData["MatchID"] = new SelectList(_context.Matches, "ID", "ID", performance.MatchID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "ID", "ID", performance.PlayerID);
            return View(performance);
        }

        // GET: Performances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performance = await _context.Performances
                .Include(p => p.Match)
                .Include(p => p.Player)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (performance == null)
            {
                return NotFound();
            }

            return View(performance);
        }

        // POST: Performances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var performance = await _context.Performances.SingleOrDefaultAsync(m => m.ID == id);
            _context.Performances.Remove(performance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerformanceExists(int id)
        {
            return _context.Performances.Any(e => e.ID == id);
        }
    }
}
