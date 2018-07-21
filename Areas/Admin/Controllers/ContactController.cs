﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Biznis;
using Blog.Biznis.DTO;
namespace Blog.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        OperationManager manager = new OperationManager();
        public ActionResult Index()
        {
            OpContact op = new OpContact();
            ResultOperation res = manager.ExecuteOperation(op);
            List<ContactDto> contact = (res.items as ContactDto[]).ToList();
            return View(contact);
        }

        // GET: Admin/Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contact/Create
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

        // GET: Admin/Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Contact/Edit/5
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

        // GET: Admin/Contact/Delete/5
       

        // POST: Admin/Contact/Delete/5
       
        public ActionResult Delete(int id)
        {
            try
            {
                OpContactDelete op = new OpContactDelete();
                op.dto.id = id;
                ResultOperation res = manager.ExecuteOperation(op);
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
