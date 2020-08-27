using Officework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using System.Web.UI;

namespace Officework.Controllers
{
	public class HomeController : Controller
	{
		
		public ActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public ActionResult Formdetails()
		{
				return View();
		}
		[HttpPost]
		public ActionResult Formdetails(Userdetail1 user)
		{
			if (ModelState.IsValid)
			{
				FormData1Entities form = new FormData1Entities();
				form.Userdetail1.Add(user);
				form.SaveChanges();
				return RedirectToAction("DisplayUserdetails");
			}
			return View();
		}

		[HttpGet]
		public ActionResult UpdateDetails(int id)
		{
			FormData1Entities form = new FormData1Entities();
			Userdetail1 user = form.Userdetail1.Find(id);
			return View(user);
		}

		[HttpPost]

		public ActionResult UpdateDetails(Userdetail1 user)
		{
			if (ModelState.IsValid)
			{
				FormData1Entities form = new FormData1Entities();
				form.Entry(user).State = EntityState.Modified;

				form.SaveChanges();
				return RedirectToAction("Displayuserdetails");
			}
			return View();

		}

		public ActionResult DisplayUserdetails()
		{
			FormData1Entities form = new FormData1Entities();
			return View(form.Userdetail1.ToList());
		}

		public ActionResult DeleteDetails(int id)
		{
			FormData1Entities form = new FormData1Entities();
			Userdetail1 user = form.Userdetail1.Find(id);
			form.Userdetail1.Remove(user);
			form.SaveChanges();
			return RedirectToAction("Displayuserdetails");
		}

	}
}