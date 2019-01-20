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
    public class ITEMsController : Controller
    {
        private Model1 db = new Model1();

        // GET: ITEMs
        public ActionResult Index()
        {
            var iTEM = db.ITEM.Include(i => i.CATEGORIA).Include(i => i.ORCAMENTO).Include(i => i.UNIDADE_MEDIDA);
            return View(iTEM.ToList());
        }

        // GET: ITEMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEM.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            return View(iTEM);
        }

        // GET: ITEMs/Create
        public ActionResult Create()
        {
            ViewBag.CATEGORIA_ID = new SelectList(db.CATEGORIA, "ID", "CATEGORIA_NOME");
            ViewBag.ORCAMENTO_ID = new SelectList(db.ORCAMENTO, "ID", "ORCAMENTO_NOME");
            ViewBag.UNIDADE_MEDIDA_ID = new SelectList(db.UNIDADE_MEDIDA, "ID", "UNIDADE_NOME");
            return View();
        }

        // POST: ITEMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UNIDADE_MEDIDA_ID,ITEM_NOME,ITEM_QUANTIDADE,ITEM_VALOR_UNITARIO,ITEM_VALOR_TOTAL,ITEM_VALOR_SALDO,ORCAMENTO_ID,CATEGORIA_ID")] ITEM iTEM)
        {
            if (ModelState.IsValid)
            {
                db.ITEM.Add(iTEM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CATEGORIA_ID = new SelectList(db.CATEGORIA, "ID", "CATEGORIA_NOME", iTEM.CATEGORIA_ID);
            ViewBag.ORCAMENTO_ID = new SelectList(db.ORCAMENTO, "ID", "ORCAMENTO_NOME", iTEM.ORCAMENTO_ID);
            ViewBag.UNIDADE_MEDIDA_ID = new SelectList(db.UNIDADE_MEDIDA, "ID", "UNIDADE_NOME", iTEM.UNIDADE_MEDIDA_ID);
            return View(iTEM);
        }

        // GET: ITEMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEM.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            ViewBag.CATEGORIA_ID = new SelectList(db.CATEGORIA, "ID", "CATEGORIA_NOME", iTEM.CATEGORIA_ID);
            ViewBag.ORCAMENTO_ID = new SelectList(db.ORCAMENTO, "ID", "ORCAMENTO_NOME", iTEM.ORCAMENTO_ID);
            ViewBag.UNIDADE_MEDIDA_ID = new SelectList(db.UNIDADE_MEDIDA, "ID", "UNIDADE_NOME", iTEM.UNIDADE_MEDIDA_ID);
            return View(iTEM);
        }

        // POST: ITEMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UNIDADE_MEDIDA_ID,ITEM_NOME,ITEM_QUANTIDADE,ITEM_VALOR_UNITARIO,ITEM_VALOR_TOTAL,ITEM_VALOR_SALDO,ORCAMENTO_ID,CATEGORIA_ID")] ITEM iTEM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CATEGORIA_ID = new SelectList(db.CATEGORIA, "ID", "CATEGORIA_NOME", iTEM.CATEGORIA_ID);
            ViewBag.ORCAMENTO_ID = new SelectList(db.ORCAMENTO, "ID", "ORCAMENTO_NOME", iTEM.ORCAMENTO_ID);
            ViewBag.UNIDADE_MEDIDA_ID = new SelectList(db.UNIDADE_MEDIDA, "ID", "UNIDADE_NOME", iTEM.UNIDADE_MEDIDA_ID);
            return View(iTEM);
        }

        // GET: ITEMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEM.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            return View(iTEM);
        }

        // POST: ITEMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITEM iTEM = db.ITEM.Find(id);
            db.ITEM.Remove(iTEM);
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
