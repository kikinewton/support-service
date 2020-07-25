using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupportService.Entities;
using SupportService.Interfaces;

namespace SupportService.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ILogger logger;
        private readonly AppDbContext _context;
        public ProductController(IProductRepository productRepository, ILoggerFactory logger, AppDbContext context)
        {
            this._context = context;
            this.logger = logger.CreateLogger(nameof(ProductController));
            this.productRepository = productRepository;
        }
        // GET: Product
        public IActionResult Index()
        {
            var product = productRepository.GetProducts();
            return View(product);
        }

        // GET: Product/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            //if (ModelState.IsValid)
            //{
            //    _ = productRepository.Add(product);
            //    //_context.SaveChangesAsync(product);
            //    return RedirectToAction(nameof(Index));
            //}
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ = productRepository.Add(product);
                    //_context.SaveChangesAsync(product);
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}