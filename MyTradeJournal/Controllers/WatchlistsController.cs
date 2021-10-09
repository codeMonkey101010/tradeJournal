using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FrameworkDAL;

namespace MyTradeJournal.Controllers
{
    public class WatchlistsController : Controller
    {
        private Model2 db = new Model2();

        // GET: Watchlists
        public async Task<ActionResult> Index()
        {
            return View(await db.Watchlists.ToListAsync());
        }

        // GET: Watchlists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Watchlist watchlist = await db.Watchlists.FindAsync(id);
            List<Watchlist> watchlists = db.Watchlists.Where(x => x.Tickr == watchlist.Tickr).ToList();
            if (watchlist == null)
            {
                return HttpNotFound();
            }
            return View(watchlists);
        }

        // GET: Watchlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Watchlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "WatchlistId,EntryDate,Tickr,ImageLink,RsiWeekly")] Watchlist watchlist)
        {
            if (ModelState.IsValid)
            {
                db.Watchlists.Add(watchlist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(watchlist);
        }

        // GET: Watchlists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watchlist watchlist = await db.Watchlists.FindAsync(id);
            if (watchlist == null)
            {
                return HttpNotFound();
            }
            return View(watchlist);
        }

        // POST: Watchlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "WatchlistId,EntryDate,Tickr,ImageLink,RsiWeekly")] Watchlist watchlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(watchlist).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(watchlist);
        }

        // GET: Watchlists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watchlist watchlist = await db.Watchlists.FindAsync(id);
            if (watchlist == null)
            {
                return HttpNotFound();
            }
            return View(watchlist);
        }

        // POST: Watchlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Watchlist watchlist = await db.Watchlists.FindAsync(id);
            db.Watchlists.Remove(watchlist);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
