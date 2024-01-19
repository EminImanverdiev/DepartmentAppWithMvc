using Microsoft.AspNetCore.Mvc;
using WebDepartment.Models;
namespace WebDepartment.Controllers
{
    public class Depart : Controller
    {
        Context _db=new Context();  
        public IActionResult Index()
        {
            var departments=_db.departmens.ToList();    
            return View(departments);
        }
        [HttpGet]
        public IActionResult NewDepart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewDepart(departman d)
        {
            _db.departmens.Add(d);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDepart(int id) {
            var dep=_db.departmens.Find(id);
            _db.departmens.Remove(dep); 
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetDepart(int id)
        {
            var depart = _db.departmens.Find(id);
            return View("GetDepart",depart);
        }
        [HttpPost]
        public IActionResult UpdateDepart(departman d)
        {
            var dep = _db.departmens.Find(d.Id);
            dep.departmanad = d.departmanad;
            _db.SaveChanges();
            return View("Index");
        }
    }
}
