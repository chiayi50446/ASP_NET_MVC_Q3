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
        private ProductViewModel _product;
        private SimpleProductViewModel _simpleProduct;
        public ProductController()
        {
            _product = new ProductViewModel();
            _productRepository = new ProductRepository(_product);
            _simpleProduct = new SimpleProductViewModel();
        }
        public ActionResult List()
        {
            _product.ProductList = _productRepository.GetAll().ToList();
            return View(_product);
        }

        public ActionResult AddProduct()
        {
            ViewBag.IsColorbox = true;
            ViewBag.DefaultLocale = _productRepository.GetLocaleList(_simpleProduct);
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
            ViewBag.DefaultLocale = _productRepository.GetLocaleList(_simpleProduct);
            Product source = _productRepository.Get(productID);
            _simpleProduct.Id = source.Id;
            _simpleProduct.Locale = source.Locale;
            _simpleProduct.Name = source.Name;
            return View(_simpleProduct);
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

    }
}