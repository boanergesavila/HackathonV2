using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst2.Models;

namespace EFCodeFirst2.Controllers
{
    public class ORCAMENTOesController : Controller
    {
        private Model1 db = new Model1();

        // GET: ORCAMENTOes
        public ActionResult Index()
        {
            var oRCAMENTO = db.ORCAMENTO.Include(o => o.PROJETO);
            return View(oRCAMENTO.ToList());
        }

        // GET: ORCAMENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORCAMENTO oRCAMENTO = db.ORCAMENTO.Find(id);
            if (oRCAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(oRCAMENTO);
        }

        // GET: ORCAMENTOes/Create
        public ActionResult Create()
        {
            ViewBag.PROJETO_ID = new SelectList(db.PROJETO, "ID", "PROJETO_NOME");
            return View();
        }

        // POST: ORCAMENTOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PROJETO_ID,ORCAMENTO_NOME")] ORCAMENTO oRCAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.ORCAMENTO.Add(oRCAMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PROJETO_ID = new SelectList(db.PROJETO, "ID", "PROJETO_NOME", oRCAMENTO.PROJETO_ID);
            return View(oRCAMENTO);
        }

        // GET: ORCAMENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORCAMENTO oRCAMENTO = db.ORCAMENTO.Find(id);
            if (oRCAMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROJETO_ID = new SelectList(db.PROJETO, "ID", "PROJETO_NOME", oRCAMENTO.PROJETO_ID);
            return View(oRCAMENTO);
        }

        // POST: ORCAMENTOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PROJETO_ID,ORCAMENTO_NOME")] ORCAMENTO oRCAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRCAMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROJETO_ID = new SelectList(db.PROJETO, "ID", "PROJETO_NOME", oRCAMENTO.PROJETO_ID);
            return View(oRCAMENTO);
        }

        // GET: ORCAMENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORCAMENTO oRCAMENTO = db.ORCAMENTO.Find(id);
            if (oRCAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(oRCAMENTO);
        }

        // POST: ORCAMENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ORCAMENTO oRCAMENTO = db.ORCAMENTO.Find(id);
            db.ORCAMENTO.Remove(oRCAMENTO);
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
