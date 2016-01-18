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
using System.Net;
using System.Data.Entity;

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
                        HttpPostedFileBase file = Request.Files["RecipeImageURL"];
                        string imageName = System.IO.Path.GetFileNameWithoutExtension(file.FileName) + System.Guid.NewGuid() +
                                            System.IO.Path.GetExtension(file.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath(clsStatic.RECIPE_IMAGES_PATH), imageName);  //full path of file

                        objRecipe.LastUpdatedDate = DateTime.Now;
                        objRecipe.RecordStatus = clsStatic.ACTIVE;
                        objRecipe.RecipeImageURL = imageName;
                        objRecipe.UserId = User.Identity.GetUserId();
                        db.Recipes.Add(objRecipe);
                        db.SaveChanges();

                        //we save the file after the db changes.. might be a chance that image is large or any other error occurred.
                        file.SaveAs(path);

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
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.IsAuthenticated)
                    {
                        Recipe recipe = db.Recipes.Find(id);
                        //only edit the recipe which belongs to the current user
                        if (recipe.UserId == User.Identity.GetUserId())
                            return View(recipe);
                    }
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // POST: Recipe/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int id, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.IsAuthenticated)
                    {
                        // TODO: Add update logic here
                        if (id == null)
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }
                       // db.Entry(objRecipe).State = EntityState.Modified;
                        Recipe objRecipe = db.Recipes.Find(id);

                        HttpPostedFileBase file = Request.Files["RecipeImageURL"];
                        string imageName = System.IO.Path.GetFileNameWithoutExtension(file.FileName) + System.Guid.NewGuid() +
                                            System.IO.Path.GetExtension(file.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath(clsStatic.RECIPE_IMAGES_PATH), imageName);  //full path of file


                        objRecipe.RecipeName = collection["RecipeName"].ToString();
                        objRecipe.RecipeDescription = collection["RecipeDescription"].ToString();
                        objRecipe.RecipeServes = Convert.ToInt32(collection["RecipeServes"]);
                        objRecipe.RecipeMethod = collection["RecipeMethod"].ToString();
                        

                        if (file.ContentLength>0)
                            objRecipe.RecipeImageURL = imageName;
                        objRecipe.LastUpdatedDate = DateTime.Now;


                      db.Entry(objRecipe).State = EntityState.Modified;
                        db.SaveChanges();

                        //we save the file after the db changes.. might be a chance that image is large or any other error occurred.
                        file.SaveAs(path);

                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.IsAuthenticated)
                    {
                        //if(id==null)
                        //{
                        //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        //}
                        //Recipe recipe = db.Recipes.Find(id);
                        //if (recipe == null)
                        //{
                        //    return HttpNotFound();
                        //}
                        //return View(recipe);



                        //they say dont delete in get.. will have to further investigate how to do it in post.. seems like an extra page or via javascript
                        //but for now, lets do it here
                        Recipe recipe = db.Recipes.Find(id);
                        db.Recipes.Remove(recipe);
                        db.SaveChanges();

                    }
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.IsAuthenticated)
                    {
                        // TODO: Add delete logic here
                        Recipe recipe = db.Recipes.Find(id);
                        db.Recipes.Remove(recipe);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
