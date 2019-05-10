using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC_Q2.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string Product_Name { get; set; }
        public DateTime Create_Date { get; set; }
    }

}