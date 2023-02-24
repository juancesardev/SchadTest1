using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test4.Data;
using test4.Models;

namespace test4.Controllers
{
    public class InvoiceDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InvoiceDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InvoiceDetail.Include(i => i.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InvoiceDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InvoiceDetail == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.InvoiceDetail
                .Include(i => i.Customer)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            var thisCustomer = await _context.Invoice
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == invoiceDetail.CustomerId);
            if (thisCustomer == null)
            {
                return NotFound();
            }

            string CustomerName = "User Id:" +  thisCustomer.Id + " | " + thisCustomer.Customer.CustName;
            ViewBag.CustomerName = CustomerName;

            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Create
        public IActionResult Create()
        {

            //ViewData["CustomerId"] = new SelectList(_context.Invoice, "Id", "Id");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "CustName");
            return View();
        }

        // POST: InvoiceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,Qty,Price,TotalItbis,SubTotal,Total")] InvoiceDetail invoiceDetail)
        {
            //invoiceDetail.CustomerId = 4;
            if (invoiceDetail.CustomerId > 0)
            {
                int qty_        = invoiceDetail.Qty;
                decimal Price_  = invoiceDetail.Price;

                Invoice inv     = new Invoice();
                inv.CustomerId  = invoiceDetail.CustomerId;
                inv.TotalItbis  = (Price_ * (0.18M)) * qty_;
                inv.SubTotal    = Price_ * qty_;
                inv.Total       = inv.SubTotal + inv.TotalItbis;

                //calculate itbis - subtotal and total


                if (inv != null)
                {
                    _context.Add(inv);
                    await _context.SaveChangesAsync();
                    invoiceDetail.CustomerId = inv.Id;
                }

                if(invoiceDetail.CustomerId < 0)
                {

                    return NotFound();
                }


                //invoice details
                invoiceDetail.TotalItbis    = inv.TotalItbis;
                invoiceDetail.SubTotal      = inv.SubTotal;
                invoiceDetail.Total         = inv.Total;
                
                _context.Add(invoiceDetail);
                await _context.SaveChangesAsync();
                return LocalRedirect($"~/Invoices/Index");
            }
            ViewData["CustomerId"] = new SelectList(_context.Invoice, "Id", "Id", invoiceDetail.CustomerId);
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InvoiceDetail == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.InvoiceDetail.FindAsync(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Invoice, "Id", "Id", invoiceDetail.CustomerId);
            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,Qty,Price,TotalItbis,SubTotal,Total")] InvoiceDetail invoiceDetail)
        {
            if (id != invoiceDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceDetailExists(invoiceDetail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Invoice, "Id", "Id", invoiceDetail.CustomerId);
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InvoiceDetail == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.InvoiceDetail
                .Include(i => i.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InvoiceDetail == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InvoiceDetail'  is null.");
            }
            var invoiceDetail = await _context.InvoiceDetail.FindAsync(id);
            if (invoiceDetail != null)
            {
                _context.InvoiceDetail.Remove(invoiceDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceDetailExists(int id)
        {
          return _context.InvoiceDetail.Any(e => e.Id == id);
        }
    }
}
