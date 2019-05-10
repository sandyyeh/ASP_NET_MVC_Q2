using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using System.Globalization;
using ASP_NET_MVC_Q2.ViewModel;

namespace ASP_NET_MVC_Q2.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product(int? page)
        {
            string file = Server.MapPath("~/App_Data/data.json");
            string json = System.IO.File.ReadAllText(file);
            List<ProductViewModel> list = JsonConvert.DeserializeObject<List<ProductViewModel>>(json);

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var result = list.ToPagedList(pageNumber, pageSize);

            return View(result);
        }

        public ActionResult Detail(int id)
        {
            string file = Server.MapPath("~/App_Data/data.json");
            string json = System.IO.File.ReadAllText(file);
            List<DetailViewModel> list = JsonConvert.DeserializeObject<List<DetailViewModel>>(json);

            var result = list.Where(n => n.Id == id).FirstOrDefault();

            DetailViewModel viewModel = new DetailViewModel();
            viewModel.Product_Name = result.Product_Name;
            viewModel.Locale = result.Locale;
            viewModel.Create_Date = result.Create_Date;
            if (decimal.TryParse(result.Price, out decimal num))
            {
                viewModel.Price = string.Format(new CultureInfo(GetLocale(result.Locale)), "{0:c}", float.Parse(result.Price));
            }
            else
            {
                viewModel.Price = "-";
            }
            if (decimal.TryParse(result.Promote_Price, out decimal num2))
            {
                viewModel.Promote_Price = string.Format(new CultureInfo(GetLocale(result.Locale)), "{0:c}", float.Parse(result.Promote_Price));
            }
            else
            {
                viewModel.Promote_Price = "-";
            }


            return View(viewModel);
        }


        public string GetLocale(string locale)
        {
            string type = "";
            switch (locale)
            {
                case "US":
                    type = "en-US";
                    break;
                case "CA":
                    type = "en-CA";
                    break;
                case "JP":
                    type = "ja-JP";
                    break;
                case "ES":
                    type = "es-ES";
                    break;
                case "DE":
                    type = "de-DE";
                    break;
                case "FR":
                    type = "fr-FR";
                    break;
            }
            return type;
        }

    }
}