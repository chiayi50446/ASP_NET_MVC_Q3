using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC_Q3.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> ProductList { get; set; }
    }

    public class SimpleProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Locale { get; set; }
        public List<String> DefaultLocale = new List<string>() { "US", "DE", "CA", "ES", "FR", "JP" };
    }
}