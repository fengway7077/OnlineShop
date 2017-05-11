using Common;
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Dao
{
   public class ContentDao
    {
        private OnlineShopDbContext db = null;
      
        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }
        //phan trang content
        public IEnumerable<Content> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Content> model = db.Contents;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));//Contains tim chuoi gan dung
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        //get id
        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }
        //xu ly tags
        public long Create(Content content)
        {
            
            //xu ly alias
            if (string.IsNullOrEmpty(content.MetaTitle))
            {
                content.MetaTitle = StringHelper.ToUnsignString(content.Name);//xy bo dau name
            }
            content.CreateDate = DateTime.Now;
           
            db.Contents.Add(content);
            db.SaveChanges();
            if (!string.IsNullOrEmpty(content.Tags))//tags trong
            {
                string[] tags = content.Tags.Split(',');//cat tags cach nhau dau phay
                foreach(var tag in tags)
                {
                    var tagId = StringHelper.ToUnsignString(tag);
                    var existedTag = this.CheckTag(tagId);
                    //chen tag 
                    if (!existedTag)
                    {
                        this.InsertTag(tagId, tag);
                    }
                    //insert to content tag
                    this.InsertContentTag(content.ID, tagId);
                }
            }
            return content.ID;
        }
        //kiem tra
        public bool CheckTag(string id)
        {
            return db.Tags.Count(x => x.ID == id) > 0;//true ton tai
        }
        //chen tag
        public void InsertTag(string id,string name)
        {
            var tag = new Tag();
            tag.ID = id;
            tag.Name = name;
            db.Tags.Add(tag);
            db.SaveChanges();
        }
        //chen contenttag
        public void InsertContentTag(long contentId,string tagId)
        {
            var contentTag = new ContentTag();
            contentTag.ContentID = contentId;
            contentTag.TagID = tagId;
            db.ContentTags.Add(contentTag);
            db.SaveChanges();

        }
    }
}

