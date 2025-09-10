using Microsoft.AspNetCore.Mvc;
using RecipeSharingSite.Models;

namespace RecipeSharingSite.Controllers
{
    public class AuthorController : Controller
    {

        private readonly ApplicationDBContext db;

        public AuthorController(ApplicationDBContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            int authorID = db.Authors.FirstOrDefault(p => p.Name == HttpContext.Session.GetString("username")).Id;
            AuthorPageViewModel aPVM = new AuthorPageViewModel
            {
                Author = db.Authors.FirstOrDefault(p => p.Name == HttpContext.Session.GetString("username")),
                RecipeList = db.Recipes.Where(x => x.AuthorId == authorID).ToList()
            };
            return View(aPVM);
        }

        public IActionResult CreateAccount() 
        {
            var viewModel = new AuthorCreationViewModel
            {
                Error = ""
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateAccount([Bind("Name, Password")] Author i, string checkPassword)
        {
            string[] nums = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
            bool num = false;
            for (int j = 0; j < nums.Length; j++)
            {
                if (i.Password.IndexOf(nums[j]) != -1)
                {
                    num = true;
                }
            }

            

            if (i.Password == null || i.Name == null || checkPassword == null) 
                {
                    var viewModel = new AuthorCreationViewModel
                    {
                        Error = "A field is not filled out"
                    };
                    return View(viewModel);
                }
            else if (i.Name.Length < 6)
            {
                var viewModel = new AuthorCreationViewModel
                {
                    Error = "Name must be stleast 6 characters long"
                };
                return View(viewModel);
            }
            else if (db.Authors.FirstOrDefault(m => m.Name.Contains(i.Name)) != null)
            {
                var viewModel = new AuthorCreationViewModel
                {
                    Error = "This username is already taken"
                };
                return View(viewModel);
            }
            else if (i.Password.Length < 8 || !num)
            {
                var viewModel = new AuthorCreationViewModel
                {
                    Error = "Password must be atleast 8 characters long and contain a number"
                };
                return View(viewModel);
            }
            else if (!i.Password.Equals(checkPassword))
            {
                var viewModel = new AuthorCreationViewModel
                {
                    Error = "Passwords don't match"
                };
                return View(viewModel);
            }
            db.Add(i);
            db.SaveChanges();
            HttpContext.Session.SetString("username", i.Name);
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            var viewModel = new AuthorCreationViewModel
            {
                Error = ""
            };
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Login([Bind("Name, Password")] Author i)
        {
            Author j = db.Authors.FirstOrDefault(m => m.Name.Contains(i.Name));
            if (j == null)
            {
                var viewModel = new AuthorCreationViewModel
                {
                    Error = "This username is already taken"
                };
                return View(viewModel);
            }
            else
            {
                if (j.Password.Equals(i.Password))
                {
                    HttpContext.Session.SetString("username", i.Name);
                    return RedirectToAction("Index");
                }
                else
                {
                    var viewModel = new AuthorCreationViewModel
                    {
                        Error = "Passwords don't match"
                    };
                    return View(viewModel);
                }
            }
            
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Recipe");
        }
    }
}
