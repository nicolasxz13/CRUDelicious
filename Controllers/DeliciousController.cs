using CRUDelicious.Data;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDelicious.Controllers
{
    public class Delicious : Controller
    {
        private DeliciousContext _context;

        public Delicious(DeliciousContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dishe> result = _context.Dishes
                .Select(
                    a =>
                        new Dishe
                        {
                            DishId = a.DishId,
                            Name = a.Name,
                            Chef = a.Chef
                        }
                )
                .OrderByDescending(a => a.DishId)
                .ToList();
            return View(result);
        }

        [HttpGet("dishes/new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("dishes/create")]
        public IActionResult Create(Dishe dishe)
        {
            if (ModelState.IsValid)
            {
                dishe.CreatedAt = DateTime.Now;
                dishe.UpdatedAt = DateTime.Now;
                _context.Add(dishe);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }

        [HttpGet("dishes/{DishId}")]
        public IActionResult Show(int DishId)
        {
            Dishe? result = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("dishes/{DishId}/destroy")]
        public IActionResult Destroy(int DishId)
        {
            Dishe? result = _context.Dishes.SingleOrDefault(a => a.DishId == DishId);
            if (result != null)
            {
                _context.Dishes.Remove(result);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("dishes/{DishId}/edit")]
        public IActionResult Edit(int DishId)
        {
            Dishe? result = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("dishes/{DishId}/update")]
        public IActionResult Update(Dishe dishe, int DishId)
        {
            Dishe? result = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
            if (ModelState.IsValid)
            {
                result.Name = dishe.Name;
                result.Chef = dishe.Chef;
                result.Tastiness = dishe.Tastiness;
                result.Calories = dishe.Calories;
                result.Description = dishe.Description;
                result.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", dishe);
            }
        }
    }
}
