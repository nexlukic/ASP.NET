using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Areas.Admin.Models;
using Blog.Biznis;
using Blog.Biznis.DTO;
using Blog.Biznis.Korisnici;
namespace Blog.Areas.Admin.Controllers
{
    public class KorisniciController : Controller
    {
        OperationManager manager = OperationManager.Singleton;
       
        // GET: Admin/Korisnici
        public ActionResult Index()
        {
            OpKorisnici op = new OpKorisnici();
            ResultOperation res = manager.ExecuteOperation(op);
            IEnumerable<KorisniciDto> korisnici = (res.items as KorisniciDto[]).ToList();
            return View(korisnici);
        }

        // GET: Admin/Korisnici/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Korisnici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Korisnici/Create
        [HttpPost]
        public ActionResult Create(KorisnikViewModel vm)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Korisnici/Edit/5
        public ActionResult Edit(string id)
        {
            OpKorisniciGetOne op = new OpKorisniciGetOne();
            op.dto.id = id;
            ResultOperation res = manager.ExecuteOperation(op);
            KorisnikViewModel vm = new KorisnikViewModel();
            KorisniciDto korisnik = res.items[0] as KorisniciDto;
            vm.id = korisnik.id;
            vm.username = korisnik.username;
            vm.email = korisnik.email;
            return View(vm);
        }

        // POST: Admin/Korisnici/Edit/5
        [HttpPost]
        public ActionResult Edit(KorisnikViewModel vm)
        {
            try
            {
                KorisniciDto dto = new KorisniciDto()
                {
                    email = vm.email,
                    id = vm.id,
                    username = vm.username
                };
                OpKorisnikUpdate op = new OpKorisnikUpdate();
                op.dto = dto;
                ResultOperation res = manager.ExecuteOperation(op);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Korisnici/Delete/5
      

        
        public ActionResult Delete(string id)
        {
            try
            {
                KorisniciDto dto = new KorisniciDto()
                {
                    id = id
                };
                OpKorisnikDelete op = new OpKorisnikDelete();
                op.dto = dto;
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
