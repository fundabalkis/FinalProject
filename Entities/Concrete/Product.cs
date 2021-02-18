using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity //bu class'a diğer katmanlar da ulaşabilsin diye public yaptık. DataAccess ürün ekleyecek, business ürünü kontrol edecek. ConsoleUI gösterecek.
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public short UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
