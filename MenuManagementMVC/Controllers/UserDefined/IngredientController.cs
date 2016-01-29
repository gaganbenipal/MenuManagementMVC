using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MenuManagementMVC.Context;
using MenuManagementMVC.Models.UserDefined;
using Microsoft.AspNet.Identity;

namespace MenuManagementMVC.Controllers.UserDefined
{
    public class IngredientController : Controller
    {
        RecipeContext db = new RecipeContext();
        // GET: Ingredient
        public ActionResult Index()
        {
            return View(db.Ingredients.ToList());
        }

        // GET: Ingredient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ingredient/Create
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            ViewBag.Recipes = new SelectList(db.Recipes.Where(s => s.UserId.Equals(userId)), "RecipeId", "RecipeName");

            return View();
        }

        // POST: Ingredient/Create
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

        // GET: Ingredient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ingredient/Edit/5
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

        // GET: Ingredient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ingredient/Delete/5
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
