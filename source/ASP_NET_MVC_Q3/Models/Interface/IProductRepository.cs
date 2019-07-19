using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3.Models.Interface
{
    interface IProductRepository
    {
        void Create(SimpleProductViewModel param);

        void Update(SimpleProductViewModel param);

        void Delete(int ProductID);

        Product Get(int ProductID);

        IOrderedEnumerable<Product> GetAll();

        int GetUniqueId();

        List<SelectListItem> GetLocaleList(SimpleProductViewModel simpleProduct);
    }
}
