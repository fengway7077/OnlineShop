using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using Model.EF;

namespace OnlineShop.Models
{
    [Serializable]// de tu tu hoa, session
    public class CartItem
    {
       //// public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}