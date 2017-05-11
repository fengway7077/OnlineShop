using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Dao
{
 public   class ContactDao
    {
        private OnlineShopDbContext db = null;
        public ContactDao()
        {
            db = new OnlineShopDbContext();
        }
        public Contact GetActiveContact()
        {
            return db.Contacts.Single(x => x.Status == true);
        }
        // chen them khach hang
        public int InsertFeedBack(Feedback feedback)
        {
            db.Feedbacks.Add(feedback);
            db.SaveChanges();
            return feedback.ID;
        }
    }
}
