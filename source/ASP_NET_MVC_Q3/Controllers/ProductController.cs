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
        private IProductRepository productRepository;
        private ProductViewModel product;
        private SimpleProductViewModel simpleProduct;
        public ProductController()
        {
            product = new ProductViewModel();
            productRepository = new ProductRepository(product);
            simpleProduct = new SimpleProductViewModel();
        }
        public ActionResult List()
        {
            product.productList = productRepository.GetAll().ToList();
            return View(product);
        }

        public ActionResult addProduct()
        {
            ViewBag.IsColorbox = true;
            ViewBag.DefaultLocale = productRepository.GetLocaleList(simpleProduct);
            return View();
        }
        [HttpPost]
        public ActionResult addProduct(SimpleProductViewModel data)
        {
            productRepository.Create(data);
            string locationUrl = "<script>parent.location.href='" + Url.Action(nameof(List)) + "'</script>";
            return Content(locationUrl);
        }
        public ActionResult editProduct(int productID)
        {
            ViewBag.IsColorbox = true;
            ViewBag.DefaultLocale = productRepository.GetLocaleList(simpleProduct);
            Product source = productRepository.Get(productID);
            simpleProduct.Id = source.Id;
            simpleProduct.Locale = source.Locale;
            simpleProduct.Name = source.Name;
            return View(simpleProduct);
        }
        [HttpPost]
        public ActionResult editProduct(SimpleProductViewModel data)
        {
            productRepository.Update(data);
            string locationUrl = "<script>parent.location.href='" + Url.Action(nameof(List)) + "'</script>";
            return Content(locationUrl);
        }
        public ActionResult deleteProduct(int productID)
        {
            productRepository.Delete(productID);
            string locationUrl = "<script>parent.location.href='" + Url.Action(nameof(List)) + "'</script>";
            return Content(locationUrl);
        }

    }
}