using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Model
{
    public class Orders
    {
        public int OrdersId { get; set; }
        public DateTime OrdersDateTime { get; set; }
        public List<LineItem> OrderLineList = new List<LineItem>();
        public static int orderCount = 1;
        
        public Orders()
        {
            OrdersId = orderCount;
            OrdersDateTime = DateTime.Now;
            orderCount = orderCount + 1;
        }
        public void AddLineItemOrder(LineItem lineItem) 
        { 
            this.OrderLineList.Add(lineItem);
        }

        public double TotalCost()
        {
            double sum = 0;
            foreach (LineItem item in OrderLineList)
            {
                sum = sum + item.TotalCostLineItem();
            }
            return sum;
        }
    }
}
