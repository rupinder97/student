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
    public class qut_tblController : Controller
    {
        private DbModels db = new DbModels();

        // GET: qut_tbl
        public async Task<ActionResult> Index()
        {
            var qut_tbl = db.qut_tbl.Include(q => q.admission_tbl);
            return View(await qut_tbl.ToListAsync());
        }

        // GET: qut_tbl/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            qut_tbl qut_tbl = await db.qut_tbl.FindAsync(id);
            if (qut_tbl == null)
            {
                return HttpNotFound();
            }
            return View(qut_tbl);
        }

        // GET: qut_tbl/Create
        public ActionResult Create()
        {
            ViewBag.rollno = new SelectList(db.admission_tbl, "rollno", "course");
            return View();
        }

        // POST: qut_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,rollno,q_fee,rcvd,dor")] qut_tbl qut_tbl)
        {
            if (ModelState.IsValid)
            {
                db.qut_tbl.Add(qut_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.rollno = new SelectList(db.admission_tbl, "rollno", "course", qut_tbl.rollno);
            return View(qut_tbl);
        }

        // GET: qut_tbl/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            qut_tbl qut_tbl = await db.qut_tbl.FindAsync(id);
            if (qut_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.rollno = new SelectList(db.admission_tbl, "rollno", "course", qut_tbl.rollno);
            return View(qut_tbl);
        }

        // POST: qut_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,rollno,q_fee,rcvd,dor")] qut_tbl qut_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qut_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.rollno = new SelectList(db.admission_tbl, "rollno", "course", qut_tbl.rollno);
            return View(qut_tbl);
        }

        // GET: qut_tbl/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            qut_tbl qut_tbl = await db.qut_tbl.FindAsync(id);
            if (qut_tbl == null)
            {
                return HttpNotFound();
            }
            return View(qut_tbl);
        }

        // POST: qut_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            qut_tbl qut_tbl = await db.qut_tbl.FindAsync(id);
            db.qut_tbl.Remove(qut_tbl);
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
