using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Biznis;
using Blog.Biznis.Post;
using Blog.Biznis.Kategorija;
using Blog.Biznis.Komentar;
using Blog.Biznis.DTO;
using Blog.Models.Aplication;
using Microsoft.AspNet.Identity;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private OperationManager manager = OperationManager.Singleton;
        public ActionResult Index(int? id_kategorija=null,int page=1)
        {
            OpSelectPost opPost = new OpSelectPost();
            opPost.kriterijum.id_kategorija = id_kategorija;
            opPost.kriterijum.offset = (page*2)-2;
            ResultOperation post = manager.ExecuteOperation(opPost);
            OpSelectKategorija opKategorija = new OpSelectKategorija();
            ResultOperation kategorija = manager.ExecuteOperation(opKategorija);
            PostViewModel vm = new PostViewModel
            {
                post = (post.items as PostDto[]).ToList(),
                kategorija = (kategorija.items as KategorijaDto[]).ToList(),
                broj = (int)Math.Ceiling((double)post.broj/2)
            };

            if(id_kategorija != null)
            {
                ViewBag.kategorija = id_kategorija;
            }
            
            return View(vm);
        }



        public ActionResult Single(int id)
        {
            OpSelectOnePost op = new OpSelectOnePost();
            op.id = id;
            ResultOperation postOne = manager.ExecuteOperation(op);
            SingleViewModel vm = new SingleViewModel
            {
                post = (postOne.items as PostDto[]).ToList()
            };
            return View(vm);
        }
        public ActionResult AboutMe()
        {
            return View();
        }
        public JsonResult Komentar(KomentarDto k)
        { 
            k.datum = DateTime.Now;
            k.id_korisnik = User.Identity.GetUserId();
            OpKomentarInsert op = new OpKomentarInsert();
            op.komentar_prenos = k;
            ResultOperation rezultat = manager.ExecuteOperation(op);
            var komentari = rezultat.items;
            return Json(komentari,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel vm)
        {
            ContactDto kontakt = new ContactDto()
            {
                email = vm.email,
                naslov = vm.naslov,
                poruka = vm.poruka
            };
            try
            {
                OpContactInsert op = new OpContactInsert();
                op.dto = kontakt;
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