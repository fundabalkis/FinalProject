using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Çıplak class kalmasın. İnheritance veya interface almayan.
    public class Category : IEntity  //işaretleme. Category bir veritabanı tablosu

    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
