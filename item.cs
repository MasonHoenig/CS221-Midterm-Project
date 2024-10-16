namespace Store
{
    public class Item
    {
        private string name;
        private double price;
        private int stock;
        private int numInCart;

        public Item(string name, double price, int stock, int numInCart)
        {
            Name = name;
            Price = price;
            Stock = stock;
            CartNumber = numInCart;
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
                if(String.IsNullOrWhiteSpace(value)) { throw new Exception("Name cannot be null or whitespace."); }

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

        public void DecreaseStock(int DecreaseAmount) { stock -= DecreaseAmount; }
        public void IncreaseStock(int IncreaseAmount) { stock += IncreaseAmount; }
        public void AddToCart(int AddAmount) { CartNumber += AddAmount; }
        public void RemoveFromCart(int RemoveAmount) { CartNumber -= RemoveAmount; }

    }
}