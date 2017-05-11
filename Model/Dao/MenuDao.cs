using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Dao
{
   public class MenuDao
    {
        private OnlineShopDbContext db = null;
        public MenuDao()
        {
            db = new OnlineShopDbContext();
        }
        //Danh sach Menu chinh Web
        public List<Menu> ListByGroupId(int groupid)
        {
            return db.Menus.Where(x => x.TypeID == groupid && x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        }
        //List menu Admin
        public IEnumerable<Menu> ListAllProductPaging(string searchString, int page, int pageSize)
        {
            
            IQueryable<Menu> model = db.Menus;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Text.Contains(searchString) || x.Link.Contains(searchString) );
            }
            return model.OrderByDescending(x => x.TypeID).ToPagedList(page, pageSize);
        

        }
        //chen menu
        public long Insert(Menu entity)
        {
            db.Menus.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        //delete
        public bool Delete(int id)
        {
            try
            {
                var menu = db.Menus.Find(id);
                db.Menus.Remove(menu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        
            //tim theo khoa chinh
         public Menu ViewDetail(int id)
        {
            return db.Menus.Find(id);
        }
        //update
        public bool Update(Menu entity)
        {
            try
            {
                var menu = db.Menus.Find(entity.ID);//
                menu.Text = entity.Text;
                menu.Link = entity.Link;
                menu.DisplayOrder = entity.DisplayOrder;
                menu.Status = entity.Status;
                menu.Target = entity.Target;
                menu.TypeID = entity.TypeID;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }

        }
    }
}
