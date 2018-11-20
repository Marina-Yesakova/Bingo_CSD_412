using System;
using Microsoft.AspNetCore.Mvc;
using Bingo_CSD_412.Models;

namespace Bingo_CSD_412.Controllers
{
    public class CategoriesController : Controller
    {
        //TODO implement connect to Database here and proper dependency injection for CategoryManager into CategoriesController 
        public static CategoryManager categoryManager = new CategoryManager();

        // GET: Categories
        public ActionResult Index()
        {
            Category[] categories = categoryManager.ListAllCategories();
            return View(categories);
        }

        // GET: Categories/Details/CSD_412
        public ActionResult Details(String categoryName)
        {
            return View(Category.CSD_412_Category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(String categoryName)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction(nameof(Details), new { categoryName = categoryName });
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/AddWordToCategory?categoryName=CSD_412
        public ActionResult AddWordToCategory(String categoryName)
        {
            return View("AddWordToCategory", categoryName);
        }

        // POST: Categories/AddWordToCategory
        [HttpPost]
        public ActionResult AddWordToCategory(String categoryName, String word)
        {
            categoryManager.AddWordToCategory(categoryName, word);
            return RedirectToAction(nameof(Details), new { categoryName = categoryName });
        }

        // POST: Categories/RemoveWordFromCategory
        [HttpPost]
        public ActionResult RemoveWordFromCategory(String categoryName, String word)
        {
            return RedirectToAction(nameof(Details), new { categoryName = categoryName });
        }
    }
}