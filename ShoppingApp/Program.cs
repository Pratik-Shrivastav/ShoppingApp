using ShoppingApp.Model;

namespace ShoppingApp
{
    public class Program
    {
        public static void PrintAllBills(Person person)
        {
            foreach (Orders order in person.ordersList)
            {
                PrintCurrentBill(order);
            }
        }

        public static void PrintCurrentBill(Orders order)
        {
            Console.WriteLine($"Order ID: {order.OrdersId}");
            Console.WriteLine(new string('-', 115));

            Console.WriteLine(String.Format("| {0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-15} | {5,-10} | {6,-10} | {7,-10} |", "Line ID", "Product ID",
                "Product Name", "Cost", "Discount", "Dis cost", "Quantity", "Item Cost"));
            Console.WriteLine(new string('-', 115));

            foreach (LineItem lineItem in order.OrderLineList)
            {
                Console.WriteLine(String.Format("| {0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-15} | {5,-10} | {6,-10} | {7,-10} |",
                    lineItem.LineItemId,
                    lineItem.LineItemproduct.ProductId,
                    lineItem.LineItemproduct.ProductName,
                    lineItem.LineItemproduct.ProductCost,
                    lineItem.LineItemproduct.ProductDiscount,
                    lineItem.LineItemproduct.ProductAfterDiscount,
                    lineItem.LineItemQuantity,
                    lineItem.LineItemproduct.ProductAfterDiscount * lineItem.LineItemQuantity));
            }
            Console.WriteLine(new string('-', 115));
            Console.WriteLine(String.Format("{0,-10}  {1,-10} {2,-15}  {3,-10} {4,-15}  {5,-10}  {6,-10}  {7,-10}  |", "|", "", "", "", "", "", "  The Total cost is:", $" {order.TotalCost()}"));
            Console.WriteLine(new string('-', 115));
            Console.WriteLine();
        }

        public static void AddItems(Orders order, Person person)
        {
                Console.WriteLine("Enter Product Id");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Product Cost");
                double cost = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product Discount");
                double discount = double.Parse(Console.ReadLine());

                Product product = new Product(id, name, cost, discount);

                Console.WriteLine("Enter Product Quantity");
                int quantity = int.Parse(Console.ReadLine());

                LineItem lineItem = new(id, quantity, product);
                order.AddLineItemOrder(lineItem);
        }

        public static void LineItemAdd(Orders order, Person person)
        {
            int userInput = -1;
            while (userInput != 2)
            { 
                Console.WriteLine("1. Add Item" +
                    "\n0. Exit");
                userInput = int.Parse(Console.ReadLine());
                if (userInput == 1)
                {
                    
                    AddItems(order, person);
                }
                else if (userInput == 0)
                {
                    PrintCurrentBill(order);
                    person.AddOrders(order);
                    SerialDeserial.Serialization(person);                                                                
                    userInput = 2;
                }

            }
        }

        public  static void ShoppingOptions(Person person)
        {
            int userInput = -1;
            while (userInput != 0)
            {
                Console.WriteLine("0. Exit" +
                    "\n1. Create New Order" +
                    "\n2. Print All Orders");
                userInput = int.Parse(Console.ReadLine());
                switch (userInput) 
                {
                    case 1: 
                        Orders order = new Orders(); LineItemAdd(order, person); break;
                    case 2: PrintAllBills(person); break;
                }
            }
        }
        static void Main(string[] args)
        {
            Person person = new Person();
            person = SerialDeserial.Deserialization();
            ShoppingOptions(person);
        }
    }
}