﻿using System;
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
    public class SalesController : Controller
    {
        private ExcelContext db = new ExcelContext();
        private Sale sale;
        // GET: Sales
        public async Task<ActionResult> Index()
        {
            var sales = db.Sales.Include(s => s.Employee).Include(s => s.ShipToCustomer).Include(s => s.SoldToCustomer);
            return View(await sales.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = await db.Sales.FindAsync(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            if(sale == null)
                sale = new Sale();

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName");
            ViewBag.ShipToId = new SelectList(db.Customers, "CustomerId", "Name");
            ViewBag.SoldToId = new SelectList(db.Customers, "CustomerId", "Name");
            return View(sale);
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SaleId,SoldToId,ShipToId,EmployeeId,SaleDate,ShippingNo,PONumber, SKU, Quantity, Notes")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", sale.EmployeeId);
            ViewBag.ShipToId = new SelectList(db.Customers, "CustomerId", "Name", sale.ShipToId);
            ViewBag.SoldToId = new SelectList(db.Customers, "CustomerId", "Name", sale.SoldToId);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = await db.Sales.FindAsync(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", sale.EmployeeId);
            ViewBag.ShipToId = new SelectList(db.Customers, "CustomerId", "Name", sale.ShipToId);
            ViewBag.SoldToId = new SelectList(db.Customers, "CustomerId", "Name", sale.SoldToId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SaleId,SoldToId,ShipToId,EmployeeId,SaleDate,ShippingNo,PONumber")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", sale.EmployeeId);
            ViewBag.ShipToId = new SelectList(db.Customers, "CustomerId", "Name", sale.ShipToId);
            ViewBag.SoldToId = new SelectList(db.Customers, "CustomerId", "Name", sale.SoldToId);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = await db.Sales.FindAsync(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sale sale = await db.Sales.FindAsync(id);
            db.Sales.Remove(sale);
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

        public ActionResult RenderSaleRowPartial()
        {
            ViewBag.SKU = new SelectList(db.Products, "SKU", "Description");
            Console.WriteLine("RenderSaleRowPartial()");
            return PartialView("_SaleRowPartial");
        }

        /* This does not work right */
        public void AddProduct(Sale _sale)
        {
            System.Diagnostics.Debug.WriteLine("In AddProduct()");

            System.Diagnostics.Debug.WriteLine(_sale.ToString());

            sale = _sale;

            sale.SaleRows.Add(new SaleRow());
        }

    }
}
