using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Model
{
    public class LineItem
    {
        public int LineItemId { get; set; } 
        public int LineItemQuantity {  get; set; }
        public Product LineItemproduct = null;

        public LineItem(int id, int quantity, Product product)
        {
            LineItemId = id;
            LineItemQuantity = quantity;
            LineItemproduct = product;
        }

        public double TotalCostLineItem()
        {
            return LineItemQuantity * LineItemproduct.ProductAfterDiscount;
        }
    }
}
