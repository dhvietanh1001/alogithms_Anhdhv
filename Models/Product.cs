using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_Anhdhv.Model
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quality { get; set; }
        public int CategoryId { get; set; }

        public Product(string name, decimal price, int quality, int categoryId)
        {
            Name = name;
            Price = price;
            Quality = quality;
            CategoryId = categoryId;
        }

        public override string ToString()
        {
            return $"Product(Name: {Name}, Price: {Price}, Quality: {Quality}, CategoryId: {CategoryId})";
        }
    }
}
