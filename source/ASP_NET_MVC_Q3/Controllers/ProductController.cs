using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.Models;
using ASP_NET_MVC_Q3.Models.Interface;
using ASP_NET_MVC_Q3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private static ProductViewModel _product;
        public List<string> DefaultLocale = new List<string>() { "US", "DE", "CA", "ES", "FR", "JP" };
        public ProductController()
        {
            _product = GetProduct();
            _productRepository = new ProductRepository(_product);
        }
        public ActionResult List()
        {
            _product.ProductList = _productRepository.GetAll().ToList();
            return View(_product);
        }

        public ActionResult AddProduct()
        {
            ViewBag.IsColorbox = true;
            ViewBag.DefaultLocale = _productRepository.GetLocaleList(DefaultLocale);
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(SimpleProductViewModel data)
        {
            _productRepository.Create(data);
            string locationUrl = "<script>parent.location.href='" + Url.Action(nameof(List)) + "'</script>";
            return Content(locationUrl);
        }
        public ActionResult EditProduct(int productID)
        {
            ViewBag.IsColorbox = true;
            ViewBag.DefaultLocale = _productRepository.GetLocaleList(DefaultLocale);
            Product source = _productRepository.Get(productID);
            SimpleProductViewModel simpleProduct = new SimpleProductViewModel();
            simpleProduct.Id = source.Id;
            simpleProduct.Locale = source.Locale;
            simpleProduct.Name = source.Name;
            return View(simpleProduct);
        }
        [HttpPost]
        public ActionResult EditProduct(SimpleProductViewModel data)
        {
            _productRepository.Update(data);
            string locationUrl = "<script>parent.location.href='" + Url.Action(nameof(List)) + "'</script>";
            return Content(locationUrl);
        }
        public ActionResult DeleteProduct(int productID)
        {
            _productRepository.Delete(productID);
            string locationUrl = "<script>parent.location.href='" + Url.Action(nameof(List)) + "'</script>";
            return Content(locationUrl);
        }
        public static ProductViewModel GetProduct()
        {
            if (_product == null)
            {
                _product = new ProductViewModel();
                _product.ProductList = Product.Data;
                _product.UniqueId = 5;
            }
            return _product;
        }

    }
}