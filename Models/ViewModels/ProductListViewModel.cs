using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public IQueryable<string> AllCategories { get; set; }
        public string CurrentCategory { get; set; }

    }
}
