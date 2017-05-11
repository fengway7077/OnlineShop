using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.EF;

namespace Model.Dao
{
 public   class SlideDao
    {
     private OnlineShopDbContext db = null;
     public SlideDao()
     {
         db = new OnlineShopDbContext();
     }
     public List<Slide> ListAll()
     {
         return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
     }

    }
}
