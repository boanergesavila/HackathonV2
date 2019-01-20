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
    public class PROJETOesController : Controller
    {
        private Model1 db = new Model1();

        // GET: PROJETOes
        public ActionResult Index()
        {
            var pROJETO = db.PROJETO.Include(p => p.USUARIO);
            return View(pROJETO.ToList());
        }

        // GET: PROJETOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJETO pROJETO = db.PROJETO.Find(id);
            if (pROJETO == null)
            {
                return HttpNotFound();
            }
            return View(pROJETO);
        }

        // GET: PROJETOes/Create
        public ActionResult Create()
        {
            ViewBag.USUARIO_ID = new SelectList(db.USUARIO, "ID", "USUARIO_NOME");
            return View();
        }

        // POST: PROJETOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,USUARIO_ID,PROJETO_NOME")] PROJETO pROJETO)
        {
            if (ModelState.IsValid)
            {
                db.PROJETO.Add(pROJETO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USUARIO_ID = new SelectList(db.USUARIO, "ID", "USUARIO_NOME", pROJETO.USUARIO_ID);
            return View(pROJETO);
        }

        // GET: PROJETOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJETO pROJETO = db.PROJETO.Find(id);
            if (pROJETO == null)
            {
                return HttpNotFound();
            }
            ViewBag.USUARIO_ID = new SelectList(db.USUARIO, "ID", "USUARIO_NOME", pROJETO.USUARIO_ID);
            return View(pROJETO);
        }

        // POST: PROJETOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,USUARIO_ID,PROJETO_NOME")] PROJETO pROJETO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROJETO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USUARIO_ID = new SelectList(db.USUARIO, "ID", "USUARIO_NOME", pROJETO.USUARIO_ID);
            return View(pROJETO);
        }

        // GET: PROJETOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJETO pROJETO = db.PROJETO.Find(id);
            if (pROJETO == null)
            {
                return HttpNotFound();
            }
            return View(pROJETO);
        }

        // POST: PROJETOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROJETO pROJETO = db.PROJETO.Find(id);
            db.PROJETO.Remove(pROJETO);
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
