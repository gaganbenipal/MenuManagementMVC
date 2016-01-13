using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MenuManagementMVC.Context;
using MenuManagementMVC.Models.UserDefined;
using MenuManagementMVC.App_Code;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace MenuManagementMVC.Controllers.UserDefined
{
    public class RecipeController : Controller
    {
        RecipeContext db = new RecipeContext();
       
        // GET: Recipe
        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                if (Request.IsAuthenticated)
                {
                    // login logic here

                    //the below query will also work
                    //IEnumerable<Recipe> objRecipe = from recipes in db.Recipes where recipes.UserId.Equals(User.Identity.GetUserId()) select recipes;
                    string userId = User.Identity.GetUserId();
                    IEnumerable<Recipe> objRecipe = db.Recipes.Where(s => s.UserId.Equals(userId));

                    return View(objRecipe);
                }
                else
                {
                    
                    return Redirect("~/Home/Index");
                }
            }
            return Redirect("~/Home/Index");
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            if (ModelState.IsValid)
            {
                if (Request.IsAuthenticated)
                {
                    // login logic here
                    return View();
                }
                else
                {
                    return Redirect("~/Home/Index");
                }
            }
            return Redirect("~/Home/Index");
           
        }

        // POST: Recipe/Create
        [HttpPost]
        public ActionResult Create(Recipe objRecipe)
        {

            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (Request.IsAuthenticated)
                    {
                        objRecipe.LastUpdatedDate = DateTime.Now;
                        objRecipe.RecordStatus = clsStatic.ACTIVE;
                        objRecipe.UserId = User.Identity.GetUserId();
                        db.Recipes.Add(objRecipe);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return Redirect("~/Home/Index");
                    }
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recipe/Edit/5
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

        // GET: Recipe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recipe/Delete/5
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
