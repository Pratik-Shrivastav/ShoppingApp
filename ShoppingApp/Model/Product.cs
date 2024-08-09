using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductCost {  get; set; }
        public double ProductDiscount { get; set; }
        public double ProductAfterDiscount { get; set; }

        public Product(int productId, string productName, double productCost, double productDiscount)
        {

        ProductId = productId;
        ProductName = productName;
        ProductCost = productCost;
        ProductDiscount = productDiscount;
        ProductAfterDiscount = AfterDiscount(productCost,productDiscount);
        }

        public double AfterDiscount(double productCost, double productDiscount)
        {
            return ProductCost -(ProductCost * productDiscount/100);
        }

    }

}
