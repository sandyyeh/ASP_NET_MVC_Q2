using ASP_NET_MVC_Q2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Globalization;

namespace ASP_NET_MVC_Q2.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product(ProductModel productModel, int? page)
        {

            string file = Server.MapPath("~/App_Data/data.json");
            string json = System.IO.File.ReadAllText(file);
            List<ProductModel> _list = JsonConvert.DeserializeObject<List<ProductModel>>(json);

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            
            var result = _list.ToPagedList(pageNumber, pageSize);

            return View(result);
        }

        public ActionResult Detail(ProductModel product)
        {
        
            if (!string.IsNullOrEmpty(product.Price.ToString()))
            { 

                if (decimal.TryParse(product.Price, out decimal number))
                {
                    //呼叫GetLocale()方法 以代入貨幣傳換公式string.Format(new CultureInfo("en-US"), "{0:c}", price);
                    product.Price = Convert.ToString(string.Format(new CultureInfo(GetLocale(product.Locale)), "{0:c}", decimal.Parse(product.Price)));

                }
                else
                {
                    product.Price = "-";                  
                }

            }
            else
            {
                product.Price = "-";
            }

            if (!string.IsNullOrEmpty(product.Promote_Price))
            {
                if (decimal.TryParse(product.Promote_Price, out decimal number))
                {
                    product.Promote_Price = Convert.ToString(string.Format(new CultureInfo(GetLocale(product.Locale)), "{0:c}", decimal.Parse(product.Promote_Price)));
                }
                else
                {
                    product.Promote_Price = "-";
                }
            }       
            else
            {
                product.Promote_Price = "-";
            }

            ProductModel model = new ProductModel();

            model.Id = product.Id;
            model.Product_Name = product.Product_Name;
            model.Promote_Price = product.Promote_Price;
            model.Locale = product.Locale;
            model.Create_Date = product.Create_Date;
            model.Price = product.Price;




            return View(model);

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