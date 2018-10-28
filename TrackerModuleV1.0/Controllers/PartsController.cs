using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrackerModuleV1._0.Data;
using TrackerModuleV1._0.Models.PTM;

namespace TrackerModuleV1._0.Controllers
{
    public class PartsController : Controller
    {
        private PTMContex db = new PTMContex();

        //// GET: Parts
        //public ActionResult Index()
        //{
        //    var parts = db.parts.Include(p => p.CreatedBy);
        //    return View(parts.ToList());
        //}

        //public ActionResult Index(string search)
        //{
        //    return View(db.parts.Where(x => x.PartName.Contains(search) || search == null).ToList());
        //}

        //// Parts/Index?partName={PartName}
        //public ActionResult Index(string partName)
        //{
        //    var parts = from p in db.parts
        //                select p;

        //    if (!String.IsNullOrEmpty(partName))
        //    {
        //        parts = parts.Where(s => s.PartName.Contains(partName));
        //    }

        //    return View(parts);
        //}

        // Current Code
        public ActionResult Index(string partName, string status, string clear)
        {
            var StatLst = new List<string>();

            var StatQry = from d in db.parts
                          orderby d.Status
                          select d.Status;

            StatLst.AddRange(StatQry.Distinct());
            ViewBag.status = new SelectList(StatLst);

            var parts = from p in db.parts
                        select p;

            if (!String.IsNullOrEmpty(status))
            {
                parts = parts.Where(s => s.Status.Contains(status) || status == null);
                ModelState.Clear();
            }

            if (!string.IsNullOrEmpty(partName))
            {
                parts = parts.Where(s => s.PartName.Contains(partName) || partName == null);
                ModelState.Clear();
            }
 
            return View(parts);

        }

        //// Parts/Index/{PartName}
        //public ActionResult Index(string id)
        //{
        //    string searchString = id;
        //    var parts = from p in db.parts
        //                 select p;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        parts = parts.Where(s => s.PartName.Contains(searchString));
        //    }

        //    return View(parts);
        //}

        // Filtering Data
        [HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "<h3> From [HttpPost]Index: " + searchString + "</h3>";
        }


        // GET: Parts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        // GET: Parts/Create
        public ActionResult Create()
        {
            ViewBag.CreatedUserId = new SelectList(db.Users, "UserId", "FirstName");
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartId,PartName,PartDescription,NovenaTecPartNumber,SwissRanksPartNumber,OEMPartNumber,VendorPartNumber,StockQuantity,Status,CreatedUserId")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.parts.Add(part);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedUserId = new SelectList(db.Users, "UserId", "FirstName", part.CreatedUserId);
            return View(part);
        }

        // GET: Parts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedUserId = new SelectList(db.Users, "UserId", "FirstName", part.CreatedUserId);
            return View(part);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartId,PartName,PartDescription,NovenaTecPartNumber,SwissRanksPartNumber,OEMPartNumber,VendorPartNumber,StockQuantity,Status,CreatedUserId")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Entry(part).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedUserId = new SelectList(db.Users, "UserId", "FirstName", part.CreatedUserId);
            return View(part);
        }

        // GET: Parts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Part part = db.parts.Find(id);
            db.parts.Remove(part);
            db.SaveChanges();
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
