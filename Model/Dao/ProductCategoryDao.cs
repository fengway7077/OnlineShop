using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Dao
{
  public  class ProductCategoryDao
    {
        private OnlineShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<ProductCategory> ListAll()
        {
            //return db.ProductCategories.Where(p => p.Status == true).OrderBy(p => p.DisplayOrder).ToList();
            return db.ProductCategories.Where(p => p.Status == true).ToList();
        }
      //
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
       
    }
}
