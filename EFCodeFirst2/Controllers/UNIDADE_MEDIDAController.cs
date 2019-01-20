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
    public class UNIDADE_MEDIDAController : Controller
    {
        private Model1 db = new Model1();

        // GET: UNIDADE_MEDIDA
        public ActionResult Index()
        {
            return View(db.UNIDADE_MEDIDA.ToList());
        }

        // GET: UNIDADE_MEDIDA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNIDADE_MEDIDA uNIDADE_MEDIDA = db.UNIDADE_MEDIDA.Find(id);
            if (uNIDADE_MEDIDA == null)
            {
                return HttpNotFound();
            }
            return View(uNIDADE_MEDIDA);
        }

        // GET: UNIDADE_MEDIDA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UNIDADE_MEDIDA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UNIDADE_NOME,UNIDADE_SIGLA")] UNIDADE_MEDIDA uNIDADE_MEDIDA)
        {
            if (ModelState.IsValid)
            {
                db.UNIDADE_MEDIDA.Add(uNIDADE_MEDIDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uNIDADE_MEDIDA);
        }

        // GET: UNIDADE_MEDIDA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNIDADE_MEDIDA uNIDADE_MEDIDA = db.UNIDADE_MEDIDA.Find(id);
            if (uNIDADE_MEDIDA == null)
            {
                return HttpNotFound();
            }
            return View(uNIDADE_MEDIDA);
        }

        // POST: UNIDADE_MEDIDA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UNIDADE_NOME,UNIDADE_SIGLA")] UNIDADE_MEDIDA uNIDADE_MEDIDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uNIDADE_MEDIDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uNIDADE_MEDIDA);
        }

        // GET: UNIDADE_MEDIDA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNIDADE_MEDIDA uNIDADE_MEDIDA = db.UNIDADE_MEDIDA.Find(id);
            if (uNIDADE_MEDIDA == null)
            {
                return HttpNotFound();
            }
            return View(uNIDADE_MEDIDA);
        }

        // POST: UNIDADE_MEDIDA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UNIDADE_MEDIDA uNIDADE_MEDIDA = db.UNIDADE_MEDIDA.Find(id);
            db.UNIDADE_MEDIDA.Remove(uNIDADE_MEDIDA);
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
