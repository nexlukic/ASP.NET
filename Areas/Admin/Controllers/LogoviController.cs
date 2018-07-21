using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Biznis;
using Blog.Biznis.DTO;

namespace Blog.Areas.Admin.Controllers
{
    public class LogoviController : Controller
    {
        OperationManager manager = OperationManager.Singleton;
        // GET: Admin/Logovi
        public ActionResult Index()
        {
            OpLogovi op = new OpLogovi();
            ResultOperation res = manager.ExecuteOperation(op);
            List<LogoviDto> logovi = (res.items as LogoviDto[]).ToList();
            return View(logovi);
        }

        // GET: Admin/Logovi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Logovi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Logovi/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Logovi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Logovi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Logovi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Logovi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
