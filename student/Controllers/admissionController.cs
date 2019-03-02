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
    public class admissionController : Controller
    {
        private DbModels db = new DbModels();

        // GET: admission
        public async Task<ActionResult> Index()
        {
            var admission_tbl = db.admission_tbl.Include(a => a.courses_tbl);
            return View(await admission_tbl.ToListAsync());
           

        }

        // GET: admission/Details/5
        
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admission_tbl admission_tbl = await db.admission_tbl.FindAsync(id);
            if (admission_tbl == null)
            {
                return HttpNotFound();
            }
            return View(admission_tbl);
        }

        // GET: admission/Create
        public ActionResult Create()
        {
            ViewBag.course = new SelectList(db.courses_tbl, "course", "course");
            return View();
           
        }

        // POST: admission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,rollno,course,name,fname,contactno,admfee,rcvd,doa,gender")] admission_tbl admission_tbl)
        {
            if (ModelState.IsValid)
            {
                db.admission_tbl.Add(admission_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.course = new SelectList(db.courses_tbl, "course", "course", admission_tbl.course);
            return View(admission_tbl);
        }

        // GET: admission/Edit/5
       
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admission_tbl admission_tbl = await db.admission_tbl.FindAsync(id);
            if (admission_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.course = new SelectList(db.courses_tbl, "course", "course", admission_tbl.course);
            return View(admission_tbl);
        }

        // POST: admission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,rollno,course,name,fname,contactno,admfee,rcvd,doa,gender")] admission_tbl admission_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admission_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.course = new SelectList(db.courses_tbl, "course", "course", admission_tbl.course);
            return View(admission_tbl);
        }

        // GET: admission/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admission_tbl admission_tbl = await db.admission_tbl.FindAsync(id);
            if (admission_tbl == null)
            {
                return HttpNotFound();
            }
            return View(admission_tbl);
        }

        // POST: admission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            admission_tbl admission_tbl = await db.admission_tbl.FindAsync(id);
            db.admission_tbl.Remove(admission_tbl);
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
