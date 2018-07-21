using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Biznis;
using Blog.Biznis.Uloga;
using Blog.DataLayer;
using Blog.Biznis.DTO;
using Blog.Areas.Admin.Models;
using Microsoft.AspNet.Identity;

namespace Blog.Areas.Admin.Controllers
{
    public class UlogaController : Controller
    {
        OperationManager manager = OperationManager.Singleton;
        // GET: Admin/Uloga
        public ActionResult Index()
        {
            OpUloga op = new OpUloga();
            ResultOperation res = manager.ExecuteOperation(op);
            UlogaDto[] uloge = res.items as UlogaDto[];
            ViewBag.uloge = uloge;
            
            return View();
        }

        // GET: Admin/Uloga/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Uloga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Uloga/Create
        [HttpPost]
        public ActionResult Create(UlogaViewModel1 vm)
        {
            try
            {
                UlogaDto dto = new UlogaDto()
                {
                    id_uloga = Guid.NewGuid().ToString(),
                    naziv = vm.naziv

                };
                OpUlogaInsert op = new OpUlogaInsert();
                op.dto = dto;
                ResultOperation res = manager.ExecuteOperation(op);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Uloga/Edit/5
        public ActionResult Edit(string id)
        {
            UlogaDto dto = new UlogaDto()
            {
                id_uloga = id
            };
            OpUlogaGetOne op = new OpUlogaGetOne();
            op.dto = dto;
            ResultOperation res = manager.ExecuteOperation(op);
            UlogaDto uloga = res.items[0] as UlogaDto;
            UlogaViewModel1 vm = new UlogaViewModel1()
            {
                id = uloga.id_uloga,
                naziv = uloga.naziv
            };
            return View(vm);
        }

        // POST: Admin/Uloga/Edit/5
        [HttpPost]
        public ActionResult Edit(UlogaViewModel1 vm)
        {
            
            try
            {
                OpUlogaUpdate op = new OpUlogaUpdate();
                op.dto.id_uloga = vm.id;
                op.dto.naziv = vm.naziv;
                ResultOperation res = manager.ExecuteOperation(op);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        // POST: Admin/Uloga/Delete/5
        public ActionResult Delete(string id,string naziv)
        {
            try
            {
                OpUlogaDelete op = new OpUlogaDelete();
                op.dto.id_uloga = id;
                ResultOperation res = manager.ExecuteOperation(op);
                OpStatistikaInsert ops = new OpStatistikaInsert();
                StatistikaDto dto = new StatistikaDto()
                {
                    datum = DateTime.Now,
                    naziv = naziv,
                    radnja = "Obrisao je ulogu",
                    username = User.Identity.GetUserName()
                };
                ResultOperation resultat_statistika = manager.ExecuteOperation(ops);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
