using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using RecipeSharingSite.Models;

namespace RecipeSharingSite.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ApplicationDBContext db;

        public RecipeController(ApplicationDBContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Recipes.ToList());
        }

        public IActionResult CreateRecipe()
        {
            RecipeViewModel viewModel = new RecipeViewModel
            {
                Error = ""
            };
            return View(viewModel);
        }

        public IActionResult RecipeView(int id)
        {
            ViewData["AuthorName"] = db.Authors.Find(db.Recipes.Find(id).AuthorId).Name;
            RecipeViewViewModel m = new RecipeViewViewModel
            {
                Recipe = db.Recipes.Find(id),
                Content = db.RecipeContent.Where(p => p.RecipeId == id).ToList()
            };
            return View(m);
        }

        [HttpPost]
        public IActionResult CreateRecipe([Bind("Name, Description, ImageUrl, Calories")] Recipe i, string IngredientList, List<string> KeyList, List<string> ValueList)
        { 
            if (i == null || IngredientList == null) {
                RecipeViewModel l = new RecipeViewModel
                {
                    Error = "Fill out all fields"
                };
                return(View(l));
            }
            List<string> iList = IngredientList.Split(",").ToList();
            i.IngredientList = iList;
            i.Upvotes = 0;
            i.AuthorName = db.Authors.FirstOrDefault(x => x.Name == HttpContext.Session.GetString("username")).Name;
            i.AuthorId = db.Authors.FirstOrDefault(x => x.Name == HttpContext.Session.GetString("username")).Id;
            if (KeyList != null)
            {
                for(int j = 0; j < KeyList.Count; j++)
                {   
                    RecipeContent k = new RecipeContent
                    {
                        key = KeyList[j],
                        value = ValueList[j]
                    };
                    i.Contents.Add(k);
                }
            }

            //also the flex box goes on forever :sadnesss
            db.Recipes.Add(i);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Upvote(int id)
        {
            Recipe r = db.Recipes.Find(id);
            r.Upvotes++;
            db.Recipes.Update(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Delete(int id)
        { 
            db.Recipes.Remove(db.Recipes.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
