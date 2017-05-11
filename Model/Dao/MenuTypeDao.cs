using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Dao
{
   
   public class MenuTypeDao
    {
        private OnlineShopDbContext db = null;
        public MenuTypeDao()
        {
            db = new OnlineShopDbContext();
        }
        
   //set give menu dropdownlistfor
        //public List<MenuType> ListAll( )
        //{
        //    return db.MenuTypes.Where(x => x.ID != 0).ToList();
        //}
    }
}
