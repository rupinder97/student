using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using student.Models;

namespace student.Controllers
{
    public class courses_tblController : Controller
    {
        private DbModels db = new DbModels();

        // GET: courses_tbl
        public async Task<ActionResult> Index()
        {
            return View(await db.courses_tbl.ToListAsync());
        }

        // GET: courses_tbl/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courses_tbl courses_tbl = await db.courses_tbl.FindAsync(id);
            if (courses_tbl == null)
            {
                return HttpNotFound();
            }
            return View(courses_tbl);
        }

        // GET: courses_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: courses_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,course,admfee,fq_fee,sq_fee,tq_fee,frthq_fee")] courses_tbl courses_tbl)
        {
            if (ModelState.IsValid)
            {
                db.courses_tbl.Add(courses_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(courses_tbl);
        }

        // GET: courses_tbl/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courses_tbl courses_tbl = await db.courses_tbl.FindAsync(id);
            if (courses_tbl == null)
            {
                return HttpNotFound();
            }
            return View(courses_tbl);
        }

        // POST: courses_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,course,admfee,fq_fee,sq_fee,tq_fee,frthq_fee")] courses_tbl courses_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(courses_tbl);
        }

        // GET: courses_tbl/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courses_tbl courses_tbl = await db.courses_tbl.FindAsync(id);
            if (courses_tbl == null)
            {
                return HttpNotFound();
            }
            return View(courses_tbl);
        }

        // POST: courses_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            courses_tbl courses_tbl = await db.courses_tbl.FindAsync(id);
            db.courses_tbl.Remove(courses_tbl);
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
