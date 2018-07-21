using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.DataLayer;
using Blog.Biznis.DTO;
using Blog.Biznis;
using Blog.Biznis.Komentar;

namespace Blog.Areas.Admin.Controllers
{
    public class KomentarController : Controller
    {
        OperationManager manager = OperationManager.Singleton;
        // GET: Admin/Komentar
        public ActionResult Index()
        {
            OpKomentari op = new OpKomentari();
            ResultOperation res = manager.ExecuteOperation(op);
            KomentarDto [] komentari = res.items as KomentarDto[];
            return View(komentari);
        }

        // GET: Admin/Komentar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Komentar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Komentar/Create
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

        // GET: Admin/Komentar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Komentar/Edit/5
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

        // GET: Admin/Komentar/Delete/5
        public ActionResult Delete(int id)
        {
            OpKomentarDelete op = new OpKomentarDelete();
            op.id = id;
            ResultOperation result = manager.ExecuteOperation(op);
            var komentari = result.items;
            return Json(komentari, JsonRequestBehavior.AllowGet);
        }

        // POST: Admin/Komentar/Delete/5
      
    }
}
