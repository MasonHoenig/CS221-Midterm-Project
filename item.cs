namespace Store
{
    public class Item
    {
        private string name;
        private double price;
        private int stock;

        public Item(string name, double price, int stock, int numInCart, int stockNum, bool checkDate, bool checkAge)
        {
            Name = name;
            Price = price;
            Stock = stock;
            CartNumber = numInCart;
            StockNum = stockNum;
            CheckDate = checkDate;
            CheckAge = checkAge;
        }

        public override string ToString()
        {
            return $"{name}(${price}). Remaining stock: {stock}.";
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if(string.IsNullOrWhiteSpace(value)) { throw new Exception("Name cannot be null or whitespace."); }
                name = value;
            }
        }
        public double Price
        {
            get { return price; }

            set
            {
                if(value < 0) { throw new Exception("Price cannot be negative."); }
                price = value;
            }
        }
        public int Stock
        {
            get { return stock; }

            private set
            {
                if (value < 0) { throw new Exception("Stock cannot be negative"); }
                stock = value;
            }
        }
        public int CartNumber { get; set; }
        public int StockNum { get; set; }
        public bool CheckDate { get; set; }
        public bool CheckAge { get; set; }


        public void DecreaseStock(int DecreaseAmount) { stock -= DecreaseAmount; }
        public void IncreaseStock(int IncreaseAmount) { stock += IncreaseAmount; }
        public void AddToCart(int AddAmount) { CartNumber += AddAmount; }
        public void RemoveFromCart(int RemoveAmount) { CartNumber -= RemoveAmount; }
    }
}