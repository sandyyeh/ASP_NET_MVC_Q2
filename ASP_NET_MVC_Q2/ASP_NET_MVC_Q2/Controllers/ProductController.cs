using ASP_NET_MVC_Q2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Product(Product product, int? page)
        {

            string file = Server.MapPath("~/App_Data/data.json");
            string json = System.IO.File.ReadAllText(file);
            List<Product> list = JsonConvert.DeserializeObject<List<Product>>(json);

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            
            var result = list.ToPagedList(pageNumber, pageSize);

            return View(result);
        }

        public ActionResult Detail(Product product,Detail detail,int? id)
        {
           
            product.Id = detail.Id;
            DetailViewModel detailViewModel = new DetailViewModel();
           // product.Id = detailViewModel.Detail.Id;
            product.Locale = detailViewModel.Product.Locale;
            product.Create_Date = detailViewModel.Product.Create_Date;
            product.Product_Name = detailViewModel.Product.Product_Name;
            detail.Price = detailViewModel.Detail.Price;
            detail.Promote_Price = detailViewModel.Detail.Promote_Price;


            //if (!string.IsNullOrEmpty(detailViewModel.Detail.Price))
            //{
            ////    if (decimal.TryParse(detailViewModel.Price, out decimal number))
            //    {
            //        //呼叫GetLocale()方法 以代入貨幣傳換公式string.Format(new CultureInfo("en-US"), "{0:c}", price);
            //        detailViewModel.Price = Convert.ToString(string.Format(new CultureInfo(GetLocale(detailViewModel.Product.Locale)), "{0:c}", decimal.Parse(detailViewModel.Price)));

            //    }
            //    else
            //    {
            //        detailViewModel.Price = "-";
            //    }
            //}
            //else
            //{
            //    detailViewModel.Detail.Price = "-";
            //}


            //if (!string.IsNullOrEmpty(detailViewModel.Promote_Price))
            //{
            //    if (decimal.TryParse(detailViewModel.Promote_Price, out decimal number))
            //    {
            //        detailViewModel.Promote_Price = Convert.ToString(string.Format(new CultureInfo(GetLocale(detailViewModel.Product.Locale)), "{0:c}", decimal.Parse(detailViewModel.Promote_Price)));
            //    }
            //    else
            //    {
            //        detailViewModel.Promote_Price = "-";
            //    }
            //}
            //else
            //{
            //    detailViewModel.Promote_Price = "-";
            //}

            //DetailViewModel model = new DetailViewModel();


            ////model.Product.Id= product.Id;
            //model.Product.Product_Name = product.Product_Name;
            //model.Promote_Price = detailViewModel.Promote_Price;
            //model.Product.Locale = product.Locale;
            //model.Product.Create_Date = product.Create_Date;
            //model.Price = detailViewModel.Price;

            return View(detailViewModel);


           // return View(model);
            
        }


        public string GetLocale(string locale)
        {
            string type="";
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