using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalabaMVC.DBConatext;
using TalabaProMVC.Models;

namespace TalabaProMVC.Controllers
{
    public class TalabaController : Controller
    {
        AppDbContext context;
        public TalabaController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult List(string searchString)
        {
            return View(GetAllTalaba(searchString));
        }

        public IEnumerable<Talaba> GetAllTalaba(string searchString)
        {
            return context.talabas
                .Where(p => p.Name.ToLower().Contains(searchString.ToLower()));
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Add(Talaba talaba)
        {
            context.Add(talaba);
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete( Talaba talaba)
        {
            return View(talaba);
        }

        public IActionResult Removals(int Id)
        {
            var talaba = context.talabas.FirstOrDefault(t => t.Id == Id);
            context.talabas.Remove(talaba);
            context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Details(int Id)
        {
            var talaba = context.talabas.FirstOrDefault(tala => tala.Id == Id);
            return View(talaba);
        }

        public IActionResult Edit(int Id)
        {
            var talaba = context.talabas.FirstOrDefault(p => p.Id == Id);
            return View(talaba);
        }

        public IActionResult Update(Talaba talaba)
        {
            var Oldtalaba = context.talabas.FirstOrDefaultAsync(tala => tala.Id == talaba.Id);
            context.Attach(Oldtalaba).CurrentValues.SetValues(talaba);
            context.SaveChangesAsync();

            return RedirectToAction("List");
        }


    }
}
