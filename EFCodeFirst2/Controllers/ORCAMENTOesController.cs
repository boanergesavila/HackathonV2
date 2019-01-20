using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst2.Models;
using GemBox.Spreadsheet;

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

        [HttpPost]
        public void UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                    load(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";

            }
            catch
            {
                ViewBag.Message = "File upload failed!!";

            }

        }

        
        
        private void load(string path)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile ef = ExcelFile.Load(path);

            StringBuilder sb = new StringBuilder();

            // Iterate through all worksheets in an Excel workbook.
            foreach (ExcelWorksheet sheet in ef.Worksheets)
            {
                sb.AppendLine();
                sb.AppendFormat("{0} {1} {0}", new string('-', 25), sheet.Name);

                // Iterate through all rows in an Excel worksheet.
                foreach (ExcelRow row in sheet.Rows)
                {
                    ITEM item = new ITEM();
                    item.ITEM_NOME = row.AllocatedCells[0].Value.ToString();
                    decimal valor = 0;

                    if (decimal.TryParse(row.AllocatedCells[0].Value.ToString(), out valor))
                    {
                        item.ITEM_QUANTIDADE = valor;
                    }
                    if (decimal.TryParse(row.AllocatedCells[0].Value.ToString(), out valor))
                    {
                        item.ITEM_VALOR_UNITARIO = valor;
                    }
                    if (decimal.TryParse(row.AllocatedCells[0].Value.ToString(), out valor))
                    {
                        item.ITEM_VALOR_UNITARIO = valor;
                    }
                    if (decimal.TryParse(row.AllocatedCells[0].Value.ToString(), out valor))
                    {
                        item.ITEM_VALOR_UNITARIO = valor;
                    }
                    if (decimal.TryParse(row.AllocatedCells[0].Value.ToString(), out valor))
                    {
                        item.ITEM_VALOR_UNITARIO = valor;
                    }
                    if (decimal.TryParse(row.AllocatedCells[0].Value.ToString(), out valor))
                    {
                        item.ITEM_VALOR_UNITARIO = valor;
                    }
                    if (decimal.TryParse(row.AllocatedCells[0].Value.ToString(), out valor))
                    {
                        item.ITEM_VALOR_UNITARIO = valor;
                    }

                    db.ITEM.Add(item);
                    db.SaveChanges();

                }
            }


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
