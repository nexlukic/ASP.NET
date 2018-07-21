using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Biznis;
using Blog.DataLayer;
using Blog.Biznis.DTO;
using Blog.Biznis.Post;
using Blog.Biznis.Kategorija;
using Blog.Models.Admin;
using System.IO;
using Microsoft.AspNet.Identity;

namespace Blog.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private OperationManager manager = OperationManager.Singleton;
        // GET: Admin/Post
        public ActionResult Index(int? id_kategorija = null, int page = 1)
        {
            
            OpSelectPost op = new OpSelectPost();
            op.kriterijum.id_kategorija = id_kategorija;
            op.kriterijum.offset = (page * 2) - 2;
            ResultOperation result = manager.ExecuteOperation(op);
            ViewBag.Broj = (int)Math.Ceiling((double)result.broj / 2);
            PostDto [] postovi = result.items as PostDto[];
            return View(postovi);
        }

        // GET: Admin/Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            OperationManager manager = OperationManager.Singleton;
            OpSelectKategorija op = new OpSelectKategorija();
            ResultOperation result = manager.ExecuteOperation(op);
            ViewBag.kategorije = result.items as KategorijaDto[];
            return View();
        }

        // POST: Admin/Post/Create
        [HttpPost]
        public ActionResult Create(PostViewModel vm)
        {
            try
            {
                string id_korisnik= User.Identity.GetUserId();
                string FileName = Guid.NewGuid().ToString() + "_" + vm.slika.FileName;
                string putanja = Path.Combine(Server.MapPath("~/Content/images"), FileName);
                vm.slika.SaveAs(putanja);
                PostDto post = new PostDto
                {
                    naslov = vm.naslov,
                    tekst = vm.tekst,
                    putanja =FileName,
                    datum = DateTime.Now,
                    id_korisnik=id_korisnik,
                    id_kategorija = vm.id_kategorija,
                };
                OpPostInsert op = new OpPostInsert();
                op.dto = post;
                ResultOperation res= manager.ExecuteOperation(op);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Post/Edit/5
        public ActionResult Edit(int id)
        {
            OpSelectOnePost op = new OpSelectOnePost();
            op.id = id;
            ResultOperation res = manager.ExecuteOperation(op);
            PostDto post = res.items[0] as PostDto;
            OpSelectKategorija opKategorija = new OpSelectKategorija();
            ResultOperation kategorija = manager.ExecuteOperation(opKategorija);
            List<KategorijaDto> kategorije = (kategorija.items as KategorijaDto[]).ToList();
            ViewBag.Kategorije = kategorije;
            PostViewModel vm = new PostViewModel()
            {
                naslov = post.naslov,
                tekst = post.tekst,
                id_kategorija = post.id_kategorija,
                putanja = post.putanja,
                id = post.id_posta
            };
            return View(vm);
        }

        // POST: Admin/Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PostViewModel vm)
        {
            try
            {
                string FileName = null;
                if (vm.slika != null){
                    FileName = Guid.NewGuid().ToString() + "_" + vm.slika.FileName;
                    string putanja = Path.Combine(Server.MapPath("~/Content/images"), FileName);
                    vm.slika.SaveAs(putanja);
                }
                PostDto post = new PostDto
                {
                    naslov = vm.naslov,
                    tekst = vm.tekst,
                    putanja = FileName,
                    id_kategorija = vm.id_kategorija,
                    id_posta = vm.id
                };
                OpPostUpdate op = new OpPostUpdate();
                op.dto = post;
                ResultOperation res = manager.ExecuteOperation(op);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Post/Delete/5
     

        // POST: Admin/Post/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                OperationManager manager = OperationManager.Singleton;
                OpPostDelete op = new OpPostDelete();
                op.Dto.id_posta = id;
                ResultOperation result = manager.ExecuteOperation(op);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
