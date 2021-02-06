
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category:IEntity//işaretleme
    {
        //ÇIPLAK CLASS KALMASIN
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
