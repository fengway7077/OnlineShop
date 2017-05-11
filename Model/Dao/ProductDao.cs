using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.EF;
using Model.ViewModel;
using PagedList;

namespace Model.Dao
{
    public class ProductDao
    {
        private OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        /// <summary>
        /// list all products menu chinh
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Product> ListAllProducts(ref int totalRecord,int page =1, int pageSize = 2)
        {
            //  return db.Products.Where(x => x.Status == true).OrderBy(x => x.CreateDate).ToList();
            totalRecord = db.Products.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Count();
            var model = db.Products.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Skip((pageSize - 1 ) *page).Take(pageSize).ToList();
            return model;
        }
        /// <summary>
        ///phan trang Areas/admin
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Product> ListAllProductPaging(string searchString,int page,int pageSize)
        {
            // return db.Products.OrderByDescending(x=>x.CreateDate).ToPagedList(page, pageSize);
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Code.Contains(searchString));//Contains tim chuoi gan dung
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        /// <summary>
        /// lay id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetByID(long id)
        {
            return db.Products.Find(id);
        }
        /// <summary>
        /// danh sach san pham moi
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product>ListNewProduct(int top)//lay top may ra
        {
            //lay danh sach san pham giam dan theo ngay thuoc top
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();//
        }
        /// <summary>
        /// danh sach san pham hot
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product> ListFeatureProduct( int top)
        {
            //tophot khac null va ngay tophot lon hon ngay hien tai
            return db.Products.Where(x=>x.TopHot !=null && x.TopHot > DateTime.Now).OrderByDescending(x=>x.CreateDate).Take(top).ToList();
        }


        /// <summary>
        /// danh sach san pham cung loai
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<Product> ListRelateProduct(long productId)
        {
            var product =db.Products.Find(productId);

            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();
        }
        public Product ViewDetail(long id)
        {
            return   db.Products.Find(id);

            //var model = db.Products.Find(id);
            //model.ViewCount++;//tang so view
            //db.SaveChanges();//
            ////lay cookies cu
            //var views = Request.Cookies["Views"];
            ////chua cookies -> tao moi
            //if (views == null)
            //{
            //    views = new HttpCookies["Views"];
            //}
            ////bo sung mat hang da xem
            //views.Values[id.ToString()] = id.ToString();
            ////dat thoi hang
            //views.Exprires = DateTime.Now.AddMonths(1);//1 thang
            ////goi cookies ve client 
            //Response.Cookies.Add(views);
            //var keys = views.Values.AllKeys.Select(k => int.Parse(k)).ToList();
            //db.Products.Where(p => keys.Contains(p.ID));
            //ViewBag.Views = views.Values.ToString();
            //return model;
  }
        /// <summary>
        ///Get list product by category
        /// </summary>
        /// <param name="categoryTD"></param>
        /// <returns></returns>
        //public List<Product> ListByCategoryId(long catagoryID, ref int totalRecord, int page = 1, int pageSize = 2)
        //{
        //    ///  return db.Products.Where(x => x.CatagoryID == catagoryID).ToList();
        //    totalRecord = db.Products.Where(x => x.CatagoryID == catagoryID).Count();

        //    var model = db.Products.Where(x => x.CatagoryID == catagoryID).OrderByDescending(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        //    return model;
        //}
        //phan trang
        public List<ProductViewModel> ListByCategoryId(long categoryID, ref int totalRecord, int page = 1, int pageSize = 2)
        {
          //noi 2 bang
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryID equals b.ID
                        where a.CategoryID == categoryID
                        select new ProductViewModel()
                        {
                            CateMetaTitle = b.MetaTitle,
                              CateName = b.Name,
                            CreateDate = a.CreateDate,
                            ID = a.ID,
                            Images = a.Image,
                            Name = a.Name,
                            MetaTitle = a.MetaTitle,
                            Price = a.Price,
                            PromotionPrice=a.PromotionPrice  //dong bo sung
                            

                        };

             model.OrderByDescending(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        /// <summary>
        /// search goi y
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();

        }
        /// <summary>
        /// search phan trang begin web
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="totalRecord"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int page = 1, int pageSize = 2)
        {
            //noi 2 bang
            totalRecord = db.Products.Where(x => x.Name.Contains(keyword)).Count();
            var model = (from a in db.Products
                         join b in db.ProductCategories
                         on a.CategoryID equals b.ID
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreateDate = a.CreateDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price,
                             PromotionPrice = a.PromotionPrice  //dong bo sung

                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {

                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreateDate = x.CreateDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price,
                             PromotionPrice = x.PromotionPrice  //dong bo sung
                         });

            model.OrderByDescending(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        //search phan tran end
        /// <summary>
        /// insert product
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        //
        /// <summary>
        /// Delete Areas/admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                var user = db.Products.Find(id);
                db.Products.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        //

    }
}
