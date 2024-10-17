namespace Store
{
    public static class Store
    {
        private static void Main()
        {
            int choiceInt = 0;

            int sodaStock = 20; int sandwichStock = 8; int appleStock = 7; int coffeeStock = 6; int chickenStock = 5; int donutStock = 4; int milkStock = 12; int alcStock = 15; int cigStock = 10; int gasStock = 40000;

            int sodaCart = 0; int sandwichCart = 0; int appleCart = 0; int coffeeCart = 0; int chickenCart = 0; int donutCart = 0; int milkCart = 0; int alcCart = 0; int cigCart = 0; int gasCart = 0;

            Item i1 = new("Soda", 2.99, sodaStock, sodaCart, 1, false, false);
            Item i2 = new("Ham and Cheese Sandwich", 3.99, sandwichStock, sandwichCart, 2, false, false);
            Item i3 = new("Apple", 0.69, appleStock, appleCart, 3, false, false);
            Item i4 = new("Coffee", 1.29, coffeeStock, coffeeCart, 4, false, false);
            Item i5 = new("Chicken Tenders", 4.49, chickenStock, chickenCart, 5, false, false);
            Item i6 = new("Cake Donut", 0.99, donutStock, donutCart, 6, false, false);
            Item i7 = new("Milk Gallon", 3.49, milkStock, milkCart, 7, false, false);
            Item i8 = new("Alcohol", 10.99, alcStock, alcCart, 8, true, true);
            Item i9 = new("Cigarette", 12.29, cigStock, cigCart, 9, false, true);
            Item i10 = new("87 Gasoline", 3.067, gasStock, gasCart, 10, false, false);

            Item[] ItemsList = { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10 };

            Console.WriteLine("Welcome to the store.");

            while (choiceInt != 5)
            {
                Console.WriteLine();
                Console.WriteLine("[1] Add Item to Cart");
                Console.WriteLine("[2] Remove Item from Cart");
                Console.WriteLine("[3] View Stock");
                Console.WriteLine("[4] View Cart");
                Console.WriteLine("[5] Check Out");
                Console.WriteLine("[6] Leave store");

                Int32.TryParse(Console.ReadLine(), out int choice);

                Console.WriteLine();

                switch (choice)
                {
                    //Add Item
                    case 1:
                        AddItemToCart(ItemsList);
                        break;

                    //Remove Item
                    case 2:
                        RemoveItemFromCart(ItemsList);
                        break;

                    //View stock + stort stock
                    case 3:
                        ViewStock(ItemsList);
                        break;

                    //View Cart
                    case 4:
                        ViewCart(ItemsList);
                        break;

                    //Check Out
                    case 5:
                        CheckOut(ItemsList);
                        break;

                    //Leave Store
                    case 6:
                        Console.WriteLine("Thank you for shopping with us!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
        private static bool CheckDate()
        {
            if (DateTime.Now.Hour > 6 || DateTime.Now.Hour < 21) { return true; }
            return false;
        }
        private static bool CheckAge()
        {
            Console.WriteLine("Enter the customers age.");
            Int32.TryParse(Console.ReadLine(), out int customerAge);
            if (customerAge >= 21 && customerAge < 150) { return true; }
            return false;
        }
        private static void AddItemToCart(Item[] itemsList)
        {
            Console.WriteLine("What would you like to add to your cart?");
            for (int i = 0; i < itemsList.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {itemsList[i]}");
            }

            Int32.TryParse(Console.ReadLine(), out int AddItemChoice);

            AddItem(itemsList[AddItemChoice - 1]);
        }
        private static void AddItem(Item item)
        {
            Console.WriteLine($"How many {item.Name} would you like to purchase?");
            Int32.TryParse(Console.ReadLine(), out int AddItemAmount);
            if (item.CheckDate && !CheckDate())
            {
                Console.WriteLine("Sorry, Customer is not old enough to purchase this item.");
                return;
            }
            if (item.CheckAge && !CheckAge())
            {
                Console.WriteLine("Customer is not old enough to purchase this item.");
                return;
            }

            if (AddItemAmount >= 0)
            {
                if (AddItemAmount <= item.Stock)
                {
                    item.DecreaseStock(AddItemAmount);
                    item.AddToCart(AddItemAmount);
                    Console.WriteLine($"{AddItemAmount} {item.Name}(s) added to your cart.");
                }
                else if (item.Stock == 0)
                {
                    Console.WriteLine($"Sorry, we are all out of {item.Name}");
                }
                else
                {
                    Console.WriteLine($"Sorry, we only have {item.Stock} {item.Name}s in stock.");
                }
            }
            else
            {
                Console.WriteLine("Number must be positive.");
            }
        }
        private static void RemoveItemFromCart(Item[] itemsList)
        {
            Console.WriteLine("What would you like to remove from your cart");
            Console.WriteLine("Your Cart:");
            for (int i = 0; i < itemsList.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {itemsList[i].CartNumber} {itemsList[i].Name}");
            }
            Int32.TryParse(Console.ReadLine(), out int RemoveItemChoice);

            RemoveItem(itemsList[RemoveItemChoice - 1]);
        }
        private static void RemoveItem(Item item)
        {
            Console.WriteLine($"How many {item.Name} would you like to remove from your cart?");
            Int32.TryParse(Console.ReadLine(), out int RemoveItemAmount);
            if(RemoveItemAmount >= 0)
            {
                if(RemoveItemAmount <= item.CartNumber)
                {
                    item.IncreaseStock(RemoveItemAmount);
                    item.RemoveFromCart(RemoveItemAmount);
                    Console.WriteLine($"{RemoveItemAmount} {item.Name}(s) have been removed from your cart");
                }
                else if(item.CartNumber == 0)
                {
                    Console.WriteLine($"Sorry, you have no {item.Name}(s) in your cart.");
                }
                else
                {
                    Console.WriteLine($"Sorry, you can only remove a maximum of {item.CartNumber} {item.Name} from your cart");
                }
            }
            else
            {
                throw new Exception("Number must be positive.");
            }
        }
        private static void ViewStock(Item[] itemsList)
        {
            for (int i = 0; i < itemsList.Length; i++)
            {
                Console.WriteLine(itemsList[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Press '1' to view stock ordered from cheapest to most expensive. Press '2' to view original stock layout. Press 3 to return to Main Menu");
            Int32.TryParse(Console.ReadLine(), out int StockChoice);
            Item temp;
            if (StockChoice == 1)
            {
                for (int i = 1; i < itemsList.Length; i++)
                {
                    int j = i;
                    temp = itemsList[j];

                    while (j > 0 && temp.Price < itemsList[j - 1].Price)
                    {
                        itemsList[j] = itemsList[j - 1];
                        j--;
                    }
                    itemsList[j] = temp;
                }
                Console.WriteLine("Items have been sorted from the lowest price to the highest price");
            }
            else if (StockChoice == 2)
            {
                for (int i = 1; i < itemsList.Length; i++)
                {
                    int j = i;
                    temp = itemsList[j];

                    while (j > 0 && temp.StockNum < itemsList[j - 1].StockNum)
                    {
                        itemsList[j] = itemsList[j - 1];
                        j--;
                    }
                    itemsList[j] = temp;
                }
                Console.WriteLine("Items have been returned to their original order");
            }
        }
        private static void ViewCart(Item[] ItemsList)
        {
            Console.WriteLine("Your Cart:");
            for (int i = 0; i < ItemsList.Length; i++)
            {
                if (ItemsList[i].CartNumber > 0)
                {
                    Console.WriteLine($"{ItemsList[i].CartNumber} {ItemsList[i].Name}");
                }
            }
        }
        private static void CheckOut(Item[] itemsList)
        {
            double LoyaltyPoints = 1;
            double TotalCost = 0;
            double Change;
            string LoyaltyPointsFilePath = "LoyaltyPoints";

            for (int i = 0; i < itemsList.Length; i++)
            {
                if (itemsList[i].CartNumber > 0)
                {
                    TotalCost += itemsList[i].Price * itemsList[i].CartNumber;
                }
            }

            Console.WriteLine("Do you have a coupon code you would like to use");
            string CouponCode = Console.ReadLine();

            TotalCost = CalculateCouponDiscount(itemsList, LoyaltyPoints, CouponCode);

            LoyaltyPoints = GetLoyaltyPoints(LoyaltyPoints, LoyaltyPointsFilePath);

            int LoyaltyDiscount = 0;
            //Applying loyalty points
            if (TotalCost > 10 && LoyaltyPoints > 100)
            {
                TotalCost -= 10;
                LoyaltyPoints -= 100;
                LoyaltyDiscount = 10;
            }
            Console.WriteLine();
            
            double Tax = TotalCost * 0.055;
            double TotalCostTax = TotalCost + Tax;
            double AmountDue = Math.Round(TotalCostTax, 2);

            LoyaltyPoints += Math.Round(TotalCost);
            if( LoyaltyPoints > 0 )
            {
                SaveLoyaltyPoints(LoyaltyPoints, LoyaltyPointsFilePath);
            }

            Console.WriteLine($"Your total is ${AmountDue}.");
            Console.WriteLine("How much would you like to pay?");
            Double.TryParse(Console.ReadLine(), out double Payment);
            if (Payment >= 0)
            {
                Change = Payment - AmountDue;
                if (Payment >= AmountDue)
                {
                    Console.WriteLine($"You have ${Math.Round(Change, 2)} in change. Thank you for shopping!");
                    Receipt(itemsList, CouponCode, LoyaltyDiscount, TotalCost, Tax, AmountDue, Payment, Change, LoyaltyPoints);
                    AmountDue = EmptyCart(itemsList);
                }
                else if (Payment < AmountDue)
                {
                    double AmountChange = AmountDue;
                    while(Payment < AmountChange)
                    {
                        AmountChange -= Payment;
                        Console.WriteLine($"You still owe ${Math.Round(AmountChange, 2)}.");
                        Payment = 0;
                        Double.TryParse(Console.ReadLine(), out Payment);
                    }
                    Change = Payment - AmountChange;
                    Console.WriteLine($"You have ${Math.Round(Change, 2)} in change. Thank you for shopping!");
                    Receipt(itemsList, CouponCode, LoyaltyDiscount, TotalCost, Tax, AmountDue, Payment, Change, LoyaltyPoints);
                    AmountDue = EmptyCart(itemsList);
                }
            }
            else
            {
                throw new Exception("Payment must be positive");
            }
        }
        private static double CalculateCouponDiscount(Item[] itemsList, double totalCost, string couponCode)
        {
            if (couponCode == "SAVE15")
            {
                totalCost *= 0.85;
            }
            else if (couponCode == "FREESAND")
            {
                //Check if Ham and Cheese sandwich is in users cart
                if (itemsList[1].CartNumber != 0)
                {
                    totalCost -= itemsList[1].Price;
                }
            }
            else if (couponCode == "DISCOUNT35")
            {
                totalCost *= 0.65;
            }
            return totalCost;
        }
        private static double GetLoyaltyPoints(double loyaltyPoints, string filePath)
        {
            if (File.Exists(filePath))
            {
                using StreamReader reader = new StreamReader(filePath);
                Double.TryParse(reader.ReadLine(), out loyaltyPoints);
            }
            return loyaltyPoints;
        }
        private static void SaveLoyaltyPoints(double loyaltyPoints, string filePath)
        {
            try
            {
                using StreamWriter AddPoints = new StreamWriter(filePath);
                AddPoints.WriteLine(loyaltyPoints);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error writing loyalty points: {e.Message}");
            }
        }
        private static void Receipt(Item[] itemsList, string CouponCode, int loyaltyDiscount, double totalCost, double tax, double totalCostRound, double payment, double change, double loyaltyPoints)
        {
            string FilePath = @"receipt.txt";
            try
            {
                using StreamWriter Writer = new StreamWriter(FilePath);
                Writer.WriteLine("----- Receipt -----");
                for (int i = 0; i < itemsList.Length; i++)
                {
                    if (itemsList[i].CartNumber > 0)
                    {
                        Writer.WriteLine($"{itemsList[i].CartNumber} {itemsList[i].Name} - ${itemsList[i].CartNumber * itemsList[i].Price}");
                    }
                }
                if (CouponCode == "DISCOUNT35" || CouponCode == "SAVE15" || CouponCode == "FREESAND")
                {
                    Writer.WriteLine($"Coupon Code: {CouponCode}");
                }
                Writer.WriteLine("-------------------");
                if (loyaltyDiscount > 0)
                {
                    Writer.WriteLine($"Loyalty Discount: -${loyaltyDiscount}");
                }
                Writer.WriteLine($"Sub Total: ${Math.Round(totalCost, 2)}");
                Writer.WriteLine($"Tax: ${Math.Round(tax, 2)}");
                Writer.WriteLine($"Total: ${totalCostRound}");
                Writer.WriteLine($"Payment: ${payment}");
                Writer.WriteLine($"Change: ${Math.Round(change, 2)}");
                Writer.WriteLine($"Loyalty Points: {loyaltyPoints}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static int EmptyCart(Item[] itemsList)
        {
            for (int i = 0; i < itemsList.Length; i++)
            {
                itemsList[i].CartNumber = 0;
            }
            return 0;
        }
    }
}