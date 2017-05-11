using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using PagedList;

namespace Model.Dao
{
  public  class CategoryDao
    {
     OnlineShopDbContext db = null;
        public CategoryDao() {
            db=new OnlineShopDbContext();
        }
        //insert Category
        public long Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category.ID;

        }
        //danh sach category
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public IEnumerable<Category> ListAllPaging(int page = 1, int pageSize = 10)
        {
           
            return db.Categories.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
            //   IQueryable < Category >= db.Categories;
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}
