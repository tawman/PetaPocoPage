using System.Web.Mvc;
using PetaPocoPage.Helpers;
using PetaPocoPage.Models;
using PetaPocoPage.Services;

namespace PetaPocoPage.Controllers
{
	public class HomeController : Controller
	{
		private readonly Repository _repository = new Repository();

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CustomerPage(DataTablesPageRequest pageRequest)
		{
			var petaPocoPage = _repository.GetCustomers(pageRequest);
			var pageResponse = DataTablesFormat.PageResponse(pageRequest, petaPocoPage);

			return Json(pageResponse);
		}
	}
}