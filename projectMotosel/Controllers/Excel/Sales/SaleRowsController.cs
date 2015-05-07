using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projectMotosel.Models;
using projectMotosel.Models.Excel;

namespace projectMotosel.Controllers.Excel.Sales
{
    public class SaleRowsController : Controller
    {
        private ExcelContext db = new ExcelContext();

        // GET: SaleRows
        public async Task<ActionResult> Index()
        {
            var saleRows = db.SaleRows.Include(s => s.Product).Include(s => s.Sale);
            return View(await saleRows.ToListAsync());
        }

        // GET: SaleRows/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleRow saleRow = await db.SaleRows.FindAsync(id);
            if (saleRow == null)
            {
                return HttpNotFound();
            }
            return View(saleRow);
        }

        // GET: SaleRows/Create
        public ActionResult Create()
        {
            ViewBag.SKU = new SelectList(db.Products, "SKU", "Description");
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "ShippingNo");
            return View();
        }

        // POST: SaleRows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SaleRowId,SaleId,SKU,Quantity,Notes")] SaleRow saleRow)
        {
            if (ModelState.IsValid)
            {
                db.SaleRows.Add(saleRow);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SKU = new SelectList(db.Products, "SKU", "Description", saleRow.SKU);
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "ShippingNo", saleRow.SaleId);
            return View(saleRow);
        }

        // GET: SaleRows/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleRow saleRow = await db.SaleRows.FindAsync(id);
            if (saleRow == null)
            {
                return HttpNotFound();
            }
            ViewBag.SKU = new SelectList(db.Products, "SKU", "Description", saleRow.SKU);
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "ShippingNo", saleRow.SaleId);
            return View(saleRow);
        }

        // POST: SaleRows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SaleRowId,SaleId,SKU,Quantity,Notes")] SaleRow saleRow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleRow).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SKU = new SelectList(db.Products, "SKU", "Description", saleRow.SKU);
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "ShippingNo", saleRow.SaleId);
            return View(saleRow);
        }

        // GET: SaleRows/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleRow saleRow = await db.SaleRows.FindAsync(id);
            if (saleRow == null)
            {
                return HttpNotFound();
            }
            return View(saleRow);
        }

        // POST: SaleRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SaleRow saleRow = await db.SaleRows.FindAsync(id);
            db.SaleRows.Remove(saleRow);
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
