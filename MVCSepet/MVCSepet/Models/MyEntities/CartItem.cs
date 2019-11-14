using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSepet.Models.MyEntities
{
    public class CartItem
    {
        public CartItem()
        {

            Amount = 1;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public short Amount { get; set; }

        public decimal? Price { get; set; }

        public decimal? SubTotal

        {
            get
            {
                return  Price * Amount;
            }
        }

    }
}