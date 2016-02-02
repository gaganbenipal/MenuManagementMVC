using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MenuManagementMVC.App_Code;
using MenuManagementMVC.Context;
using MenuManagementMVC.Models.UserDefined;

namespace MenuManagementMVC.Controllers.UserDefined
{
    public class UnitController : Controller
    {
        RecipeContext db = new RecipeContext();
        // GET: Unit
        [Authorize]
        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                    return View(db.Units.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Unit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Unit/Create
        [Authorize]
        public ActionResult Create()
        {
            if (ModelState.IsValid)
            {
                    return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Unit/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Unit objUnit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    objUnit.LastUpdatedDate = DateTime.Now;
                    objUnit.RecordStatus = clsStatic.ACTIVE;
                    db.Units.Add(objUnit);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Unit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Unit/Edit/5
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

        // GET: Unit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Unit/Delete/5
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
