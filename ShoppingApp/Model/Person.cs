using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Model
{
    public class Person
    {
        public int PersonId;
        public string PersonName;

        public List<Orders> ordersList = new List<Orders>();

        public Person() 
        {
            PersonId = 1;
            PersonName = "Pratik";
        }

        public void AddOrders(Orders orders)
        {
            ordersList.Add(orders);
        }
    }
}
