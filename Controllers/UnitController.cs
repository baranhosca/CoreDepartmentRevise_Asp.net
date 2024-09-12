using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.Models;

namespace ProjectCore.Controllers
{
	public class UnitController : Controller
	{
		Context c = new Context();
		[Authorize]
		public IActionResult Index()
		{
			var values = c.Units.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult NewUnit()
		{
			return View();
		}
		[HttpPost]
		public IActionResult NewUnit(Unit u)
		{
			c.Units.Add(u);
			c.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult DeleteUnit(int id)
		{
			var dep = c.Units.Find(id);
			c.Units.Remove(dep);
			c.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult ReturnUnit(int id)
		{
			var depart = c.Units.Find(id);
			return View("ReturnUnit", depart);
		}
		public IActionResult UpdateUnit(Unit d)
		{
			var dep = c.Units.Find(d.UnitID);
			dep.UnitName = d.UnitName;
			c.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult UnitDetail(int id)
		{
			var values = c.Staffs.Where(x=>x.UnitID == id).ToList();
			var untName = c.Units.Where(x=> x.UnitID ==id).Select(y=> y.UnitName).FirstOrDefault();
			ViewBag.unt = untName;
			return View(values); 
		}
	}
}