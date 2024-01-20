using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDepartment.Models;

namespace WebDepartment.Controllers
{
    public class PersonelController : Controller
    {
        Context _db = new Context();
        public IActionResult Index()
        {
            var values = _db.personels.Include(x=>x.departman).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult NewPerson()
        {
            List<SelectListItem> values=(from item in _db.departmens.ToList()
                                         select new SelectListItem { 
                                          Text=item.departmanad,
                                          Value=item.Id.ToString()
                                         }).ToList();
            ViewBag.values=values;
            return View();
        }
        [HttpPost]
        public IActionResult NewPerson(personel p)
        {
            var per=_db.departmens.Where(x=>x.Id==p.departman.Id).FirstOrDefault();
            p.departman = per;
            _db.personels.Add(p);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeletePerson(int id)
        {
            var per = _db.personels.Find(id);
            _db.personels.Remove(per);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetPerson(int id)
        {
            var person = _db.personels.Find(id);
            return View("GetPerson",person);
        }
        [HttpPost]
        public IActionResult UpdatePerson(personel p)
        {
            if (p == null)
            {
                return RedirectToAction("Index");
            }
            var per = _db.personels.Find(p.perid);

            if (per == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                per.ad = p.ad;
                per.soyad = p.soyad;
                per.sehir = p.sehir;
                per.departmanid = p.departmanid;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    } 
}
