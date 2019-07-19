using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.Models.Interface;
using ASP_NET_MVC_Q3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3.Models
{
    public class ProductRepository: IProductRepository
    {
        protected ProductViewModel _product;
        public ProductRepository(ProductViewModel product)
        {
            _product = product;
            _product.productList = Product.Data;
        }
        public void Create(SimpleProductViewModel instance)
        {
            Product result = new Product();
            result.Id = this.GetUniqueId();
            result.Name = instance.Name;
            result.Locale = instance.Locale;
            result.CreateDate = DateTime.Now;
            _product.productList.Add(result);
        }

        public void Update(SimpleProductViewModel instance)
        {
            Product oldProduct = this.Get(instance.Id);
            Product newProduct = oldProduct;
            _product.productList.Remove(oldProduct);
            newProduct.Locale = instance.Locale;
            newProduct.Name = instance.Name;
            newProduct.UpdateDate = DateTime.Now;
            _product.productList.Add(newProduct);
        }

        public void Delete(int ProductID)
        {
            Product instance = Get(ProductID);
            _product.productList.Remove(instance);
        }

        public Product Get(int ProductID)
        {
            return _product.productList.FirstOrDefault(x => x.Id == ProductID);
        }

        public IOrderedEnumerable<Product> GetAll()
        {
            return _product.productList.OrderBy(x => x.Id);
        }

        public int GetUniqueId()
        {
            int maxId = _product.productList.Max(t => t.Id);
            maxId++;
            return maxId;
        }
        public List<SelectListItem> GetLocaleList(SimpleProductViewModel simpleProduct)
        {
            List<SelectListItem> localeList = simpleProduct.defaultLocale.Select(s => new SelectListItem()
            {
                Text = s,
                Value = s,
            }).ToList();
            return localeList;
        }
    }
}