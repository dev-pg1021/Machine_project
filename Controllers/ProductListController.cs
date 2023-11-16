using Machine_proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Machine_proj.Controllers
{
    public class ProductListController : Controller
    {
        public static List<ProductList> productLists = new List<ProductList>
        {
           new ProductList { ProductId = 1, ProductName = "Product1", CategoryId = 1, CategoryName = "CategoryA" },
        new ProductList { ProductId = 2, ProductName = "Product2", CategoryId = 2, CategoryName = "CategoryB" },
        // Add more sample data as needed
        };
        public IActionResult Index()
        {
            List<string> categoryNames = productLists
                                             .Select(p => p.CategoryName)
                                             .Distinct()
                                             .ToList();

            // Create a SelectList from the category names
            SelectList categoryList = new SelectList(categoryNames);

            // Pass the SelectList to the view
            ViewBag.Categories = categoryList;

            return View();
        }

        [HttpPost]
        public IActionResult YourAction(ProductList model)
        {
            // Handle form submission, use model.CategoryName to get the selected category name

            return View(model);
        }
    }
}
