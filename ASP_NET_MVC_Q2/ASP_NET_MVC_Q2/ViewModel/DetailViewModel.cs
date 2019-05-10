using System;

namespace ASP_NET_MVC_Q2.ViewModel
{
    public class DetailViewModel
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string Product_Name { get; set; }
        public DateTime Create_Date { get; set; }
        public string Price { get; set; }
        public string Promote_Price { get; set; }
    }
}