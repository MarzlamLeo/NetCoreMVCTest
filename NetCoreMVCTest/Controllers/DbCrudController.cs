using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCTest.Controllers
{
    public class DbCrudController : Controller
    {
        // GET: DbCrudController
       
        private TestDbContext _context;

        public DbCrudController(TestDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: DbCrudController/Details/5
        public ActionResult Details(int id)
        {
           var data= _context.Users.FindAsync(id);
            return View();
        }

        // GET: DbCrudController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DbCrudController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DbCrudController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DbCrudController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DbCrudController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DbCrudController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
