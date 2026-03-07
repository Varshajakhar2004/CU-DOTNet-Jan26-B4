namespace OOPs
{
    internal class Order
    {
        private int _orderId;
        private string _customerName;
        private decimal _totalAmount;
        private string _status;
        private bool _discountApplied;
        private DateTime _orderDate;
        public Order()
        {
            _orderId= 0;
            _customerName = "Unknown";
            _totalAmount = 0;
            _status = "New";
            _discountApplied = false;
            _orderDate = DateTime.Now;
        }

        public Order(int orderId, string customerName)
        {
            _orderId= orderId;
            _customerName= customerName;
            _totalAmount = 0;
            _status = "New";
            _discountApplied = false;
            _orderDate = DateTime.Now;
        }


        public int OrderId
        {
            get { return _orderId; }
        }

        public string customerName 
        { get { return _customerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Customer name can not be empty.");
                _customerName = value;
            }      
        }


        public decimal TotalAmount
        {
            get { return TotalAmount; }
        }

        public void AddItem(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("Price can not be -ve");

            _totalAmount += price;
        }

        public void ApplyDiscount(decimal percentage)
        {
            if (_discountApplied)
            {
                Console.WriteLine("Discount already applied");
                return;
            }
            if (percentage < 1 || percentage > 30)
                throw new ArgumentException("Discount must be between 1 to 30");

            decimal discount = _totalAmount * percentage / 100;
            _totalAmount -= discount;

            if(_totalAmount <0)
                _totalAmount = 0;

            _discountApplied= true;
        }

        public string GetOrderSummary()
        {
            return $"Order Id : {_orderId}\n" +
                $"Customer : {_customerName}\n" +
                $"Total Amount: {_totalAmount}\n" +
                $"Status: {_status}\n" +
                $"Date of Order : {_orderDate}";

        }
    }
    internal class OrderProcessing
    {
        static void Main(string[] args)
        {
            Order order1 = new Order(101, "Rahul");
            order1.AddItem(500);
            order1.AddItem(300);
            order1.ApplyDiscount(10);
            Console.WriteLine(order1.GetOrderSummary());

            Order order2 = new Order(102, "Ankit");
            order2.AddItem(1000);
            order2.AddItem(400);
            order2.ApplyDiscount(10);
            Console.WriteLine(order2.GetOrderSummary());
        }
    }
}
