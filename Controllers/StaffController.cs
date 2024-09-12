using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Models;

namespace ProjectCore.Controllers
{
	public class StaffController : Controller
	{
		Context c = new Context();
		[Authorize]
		public IActionResult Index()
		{
			var values = c.Staffs.Include(x=>x.Unit).ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult NewStaff()
		{
			List<SelectListItem> values = (from x in c.Units.ToList()
										   select new SelectListItem
										   {
											   Text = x.UnitName,
											   Value = x.UnitID.ToString()
										   }).ToList();
			ViewBag.value = values;
			return View(); 
		}
		public IActionResult NewStaff(Staff s)
		{
			var st = c.Units.Where(x=>x.UnitID == s.Unit.UnitID).FirstOrDefault();
			s.Unit = st;
			c.Staffs.Add(s);
			c.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}