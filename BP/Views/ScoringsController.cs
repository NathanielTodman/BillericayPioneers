using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BP.Data;

namespace BP.Views
{
    public class ScoringsController : Controller
    {
        private readonly BPContext _context;

        public ScoringsController(BPContext context)
        {
            _context = context;
        }

        // GET: Scorings
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScoringSystem.ToListAsync());
        }

        // GET: Scorings/Details/5
        public async Task<IActionResult> Details(Position id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scoring = await _context.ScoringSystem
                .SingleOrDefaultAsync(m => m.Position == id);
            if (scoring == null)
            {
                return NotFound();
            }

            return View(scoring);
        }

        // GET: Scorings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Scorings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Position,Appearance,GoalScored,CleanSheet,Assist,ConceedOnePlus,ConceedThreePlus,ConceedFivePlus,PenSave,PenMiss,MOTM,YellowCard,RedCard")] Scoring scoring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scoring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scoring);
        }

        // GET: Scorings/Edit/5
        public async Task<IActionResult> Edit(Position id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scoring = await _context.ScoringSystem.SingleOrDefaultAsync(m => m.Position == id);
            if (scoring == null)
            {
                return NotFound();
            }
            return View(scoring);
        }

        // POST: Scorings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Position id, [Bind("Position,Appearance,GoalScored,CleanSheet,Assist,ConceedOnePlus,ConceedThreePlus,ConceedFivePlus,PenSave,PenMiss,MOTM,YellowCard,RedCard")] Scoring scoring)
        {
            if (id != scoring.Position)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scoring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScoringExists(scoring.Position))
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
            return View(scoring);
        }

        // GET: Scorings/Delete/5
        public async Task<IActionResult> Delete(Position id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scoring = await _context.ScoringSystem
                .SingleOrDefaultAsync(m => m.Position == id);
            if (scoring == null)
            {
                return NotFound();
            }

            return View(scoring);
        }

        // POST: Scorings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Position id)
        {
            var scoring = await _context.ScoringSystem.SingleOrDefaultAsync(m => m.Position == id);
            _context.ScoringSystem.Remove(scoring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScoringExists(Position id)
        {
            return _context.ScoringSystem.Any(e => e.Position == id);
        }
    }
}
