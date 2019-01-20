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
    public class ITEM_EXECUTADOController : Controller
    {
        private Model1 db = new Model1();

        // GET: ITEM_EXECUTADO
        public ActionResult Index()
        {
            var iTEM_EXECUTADO = db.ITEM_EXECUTADO.Include(i => i.ITEM);
            return View(iTEM_EXECUTADO.ToList());
        }

        // GET: ITEM_EXECUTADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM_EXECUTADO iTEM_EXECUTADO = db.ITEM_EXECUTADO.Find(id);
            if (iTEM_EXECUTADO == null)
            {
                return HttpNotFound();
            }
            return View(iTEM_EXECUTADO);
        }

        // GET: ITEM_EXECUTADO/Create
        public ActionResult Create()
        {
            ViewBag.ITEM_ID = new SelectList(db.ITEM, "ID", "ITEM_NOME");
            return View();
        }

        // POST: ITEM_EXECUTADO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ITEM_ID,ITEM_EXECUTADO_DATA,ITEM_EXECUTADO_QUANTIDADE,ITEM_EXECUTADO_VALOR_UNITARIO,ITEM_EXECUTADO_VALOR_TOTAL")] ITEM_EXECUTADO iTEM_EXECUTADO)
        {
            if (ModelState.IsValid)
            {
                db.ITEM_EXECUTADO.Add(iTEM_EXECUTADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ITEM_ID = new SelectList(db.ITEM, "ID", "ITEM_NOME", iTEM_EXECUTADO.ITEM_ID);
            return View(iTEM_EXECUTADO);
        }

        // GET: ITEM_EXECUTADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM_EXECUTADO iTEM_EXECUTADO = db.ITEM_EXECUTADO.Find(id);
            if (iTEM_EXECUTADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ITEM_ID = new SelectList(db.ITEM, "ID", "ITEM_NOME", iTEM_EXECUTADO.ITEM_ID);
            return View(iTEM_EXECUTADO);
        }

        // POST: ITEM_EXECUTADO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ITEM_ID,ITEM_EXECUTADO_DATA,ITEM_EXECUTADO_QUANTIDADE,ITEM_EXECUTADO_VALOR_UNITARIO,ITEM_EXECUTADO_VALOR_TOTAL")] ITEM_EXECUTADO iTEM_EXECUTADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEM_EXECUTADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ITEM_ID = new SelectList(db.ITEM, "ID", "ITEM_NOME", iTEM_EXECUTADO.ITEM_ID);
            return View(iTEM_EXECUTADO);
        }

        // GET: ITEM_EXECUTADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM_EXECUTADO iTEM_EXECUTADO = db.ITEM_EXECUTADO.Find(id);
            if (iTEM_EXECUTADO == null)
            {
                return HttpNotFound();
            }
            return View(iTEM_EXECUTADO);
        }

        // POST: ITEM_EXECUTADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITEM_EXECUTADO iTEM_EXECUTADO = db.ITEM_EXECUTADO.Find(id);
            db.ITEM_EXECUTADO.Remove(iTEM_EXECUTADO);
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
