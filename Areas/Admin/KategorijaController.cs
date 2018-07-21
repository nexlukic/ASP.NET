using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Biznis.Kategorija;
using Blog.Biznis.Komentar;
using Blog.Biznis.DTO;
using Blog.Models.Aplication;
using Microsoft.AspNet.Identity;
using Blog.Biznis;
using Blog.Areas.Admin.Models;

namespace Blog.Areas.Admin
{
    public class KategorijaController : Controller
    {
        private OperationManager manager = OperationManager.Singleton;
        // GET: Admin/Kategorija
        public ActionResult Index()
        {
            OpSelectKategorija opKategorija = new OpSelectKategorija();
            ResultOperation kategorija = manager.ExecuteOperation(opKategorija);
            List<KategorijaDto> kategorije = (kategorija.items as KategorijaDto[]).ToList();
            ViewBag.Kategorije = kategorije;
            return View();
        }

        // GET: Admin/Kategorija/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Kategorija/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Kategorija/Create
        [HttpPost]
        public ActionResult Create(KategorijaViewModel vm)
        {
            try
            {
                OpKategorijaInsert op = new OpKategorijaInsert();
                op.dto.naziv = vm.naziv;
                ResultOperation res = manager.ExecuteOperation(op);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Kategorija/Edit/5
        public ActionResult Edit(int id)
        {
            OpKategorijaOne op = new OpKategorijaOne();
            op.dto.id = id;
            ResultOperation result = manager.ExecuteOperation(op);
            KategorijaDto kategorija = result.items[0] as KategorijaDto;
            KategorijaViewModel vm = new KategorijaViewModel()
            {
                id = kategorija.id,
                naziv = kategorija.naziv
            };
            return View(vm);
        }

        // POST: Admin/Kategorija/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KategorijaViewModel vm)
        {
            try
            {
                KategorijaDto dto = new KategorijaDto()
                {
                    id = vm.id,
                    naziv = vm.naziv
                };
                OpKategorijaUpdate op = new OpKategorijaUpdate();
                op.dto = dto;
                ResultOperation res = manager.ExecuteOperation(op);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Delete(int id)
        {
            try
            {
                OpKategorijaDelete op = new OpKategorijaDelete();
                op.dto.id = id;
                ResultOperation res = manager.ExecuteOperation(op);

               
              

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
