namespace Store
{
    public static class Store
    {
        public static void AddItem(Item item)
        {
            Console.WriteLine($"How many {item.Name} would you like to purchase?");
            Int32.TryParse(Console.ReadLine(), out int AddItemAmount);
            if (AddItemAmount >= 0)
            {
                if (AddItemAmount <= item.Stock)
                {
                    item.DecreaseStock(AddItemAmount);
                    item.AddToCart(AddItemAmount);
                    Console.WriteLine($"{AddItemAmount} {item.Name}(s) added to your cart.");
                }
                else if(item.Stock == 0)
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
                throw new Exception("Number must be positive.");
            }
        }

        public static void RemoveItem(Item item)
        {
            Console.WriteLine($"How many {item.Name} would you like to remove from your cart?");
            Int32.TryParse(Console.ReadLine(), out int RemoveItemAmount);
            if(RemoveItemAmount >= 0)
            {
                if(RemoveItemAmount <= item.Stock)
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
        private static void Main()
        {
            int choiceInt = 0;

            int sodaStock = 20; int sandwichStock = 8; int appleStock = 7; int coffeeStock = 6; int chickenStock = 5; int donutStock = 4; int milkStock = 12; int alcStock = 15; int cigStock = 10; int gasStock = 40000;

            int sodaCart = 0; int sandwichCart = 0; int appleCart = 0; int coffeeCart = 0; int chickenCart = 0; int donutCart = 0; int milkCart = 0; int alcCart = 0; int cigCart = 0; int gasCart = 0;

            Item i1 = new("Soda", 2.99, sodaStock, sodaCart);
            Item i2 = new("Ham and Cheese Sandwich", 3.99, sandwichStock, sandwichCart);
            Item i3 = new("Apple", 0.69, appleStock, appleCart);
            Item i4 = new("Coffee", 1.29, coffeeStock, coffeeCart);
            Item i5 = new("Chicken Tenders", 4.49, chickenStock, chickenCart);
            Item i6 = new("Cake Donut", 0.99, donutStock, donutCart);
            Item i7 = new("Milk Gallon", 3.49, milkStock, milkCart);
            Item i8 = new("Alcohol", 10.99, alcStock, alcCart);
            Item i9 = new("Cigarette", 12.29, cigStock, cigCart);
            Item i10 = new("87 Gasoline", 3.067, gasStock, gasCart);

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
                    case 1:
                        Console.WriteLine("What would you like to add to your cart?");
                        for (int i = 0; i < ItemsList.Length; i++)
                        {
                            Console.WriteLine($"[{i+1}] {ItemsList[i]}");
                        }

                        Int32.TryParse(Console.ReadLine(), out int AddItemChoice);

                        int CustomerAge;

                        switch (AddItemChoice)
                        {
                            case 1:
                                AddItem(i1);
                                break;
                            case 2:
                                AddItem(i2);
                                break;
                            case 3:
                                AddItem(i3);
                                break;
                            case 4:
                                AddItem(i4);
                                break;
                            case 5:
                                AddItem(i5);
                                break;
                            case 6:
                                AddItem(i6);
                                break;
                            case 7:
                                AddItem(i7);
                                break;
                            case 8:
                                if(DateTime.Now.Hour > 6 && DateTime.Now.Hour < 21)
                                {
                                    Console.WriteLine("Enter the customers age");
                                    Int32.TryParse(Console.ReadLine(), out CustomerAge);
                                    if (CustomerAge >= 21)
                                    {
                                        AddItem(i8);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Customer is not old enough to purchase this item");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, we can only sell alcohol between 6am and 9pm");
                                }
                                
                                break;
                            case 9:
                                Console.WriteLine("Enter the customers age");
                                Int32.TryParse(Console.ReadLine(), out CustomerAge);
                                if (CustomerAge >= 21)
                                {
                                    AddItem(i9);
                                }
                                else
                                {
                                    Console.WriteLine("Customer is not old enough to purchase this item");
                                }
                                break;
                            case 10:
                                AddItem(i10);
                                break;
                            default:
                                Console.WriteLine($"Please choose a number between 1 and {ItemsList.Length}");
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("What would you like to remove from your cart");
                        Console.WriteLine("Your Cart:");
                        for (int i = 0; i < ItemsList.Length; i++)
                        {
                            Console.WriteLine($"[{i + 1}] {ItemsList[i].CartNumber} {ItemsList[i].Name}");
                        }
                        Int32.TryParse(Console.ReadLine(), out int RemoveItemChoice);

                        //figure out why item 5-10 cannot be removed

                        switch(RemoveItemChoice)
                        {
                            case 1:
                                RemoveItem(i1);
                                break;
                            case 2:
                                RemoveItem(i2);
                                break;
                            case 3:
                                RemoveItem(i3);
                                break;
                            case 4:
                                RemoveItem(i4);
                                break;
                            case 5:
                                RemoveItem(i5);
                                break;
                            case 6:
                                RemoveItem(i6);
                                break;
                            case 7:
                                RemoveItem(i7);
                                break;
                            case 8:
                                RemoveItem(i8);
                                break;
                            case 9:
                                RemoveItem(i9);
                                break;
                            case 10:
                                RemoveItem(i10);
                                break;
                            default:
                                Console.WriteLine($"Please choose an number between 1 and {ItemsList.Length}");
                                break;
                        }
                        break;

                    case 3:
                        for (int i = 0; i < ItemsList.Length; i++)
                        {
                            Console.WriteLine(ItemsList[i]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press '1' to view stock ordered from cheapest to most expensive. Press '2' to return to the main menu");
                        Int32.TryParse(Console.ReadLine(), out int StockChoice);
                        Item temp;
                        if (StockChoice == 1)
                        {
                            for (int i = 1; i < ItemsList.Length; i++)
                            {
                                int j = i;
                                temp = ItemsList[j];

                                while (j > 0 && temp.Price < ItemsList[j - 1].Price)
                                {
                                    ItemsList[j] = ItemsList[j - 1];
                                    j--;
                                }

                                ItemsList[j] = temp;
                            }
                            for (int i = 0; i < ItemsList.Length; i++)
                            {
                                Console.WriteLine(ItemsList[i]);
                            }
                        }
                        else { }
                        break;

                    case 4:
                        Console.WriteLine("Your Cart:");
                        for (int i = 0; i < ItemsList.Length; i++)
                        {
                            if (ItemsList[i].CartNumber > 0)
                            {
                                Console.WriteLine($"{ItemsList[i].CartNumber} {ItemsList[i].Name}");
                            }
                        }
                        //add a sort items by price(lowest to highest)
                        break;

                    case 5:
                        double TotalCost = 0;
                        double Change;

                        for (int i = 0; i < ItemsList.Length; i++)
                        {
                            if (ItemsList[i].CartNumber > 0)
                            {
                                TotalCost += ItemsList[i].Price * ItemsList[i].CartNumber;
                            }
                        }

                        Console.WriteLine("Do you have a coupon code you would like to use");
                        string CouponCode = Console.ReadLine();
                        if (CouponCode == "SAVE15")
                        {
                            TotalCost *= 0.85;
                        }
                        else if (CouponCode == "FREESAND")
                        {
                            TotalCost -= ItemsList[1].Price;
                        }
                        else if (CouponCode == "DISCOUNT35")
                        {
                            TotalCost *= 0.65;
                        }
                        else if(CouponCode == "no" || CouponCode == "NO" || CouponCode == "No") { }
                        else
                        {
                            Console.WriteLine("Invalid Coupon Code");
                        }

                        Console.WriteLine();

                        double Tax = TotalCost * 0.055;
                        double TotalCostTax = TotalCost + Tax;
                        double TotalCostRound = Math.Round(TotalCostTax, 2);

                        Console.WriteLine($"Your total is ${TotalCostRound}.");
                        Console.WriteLine("How much would you like to pay?");
                        Double.TryParse(Console.ReadLine(), out double Payment);
                        if (Payment >= 0)
                        {
                            Change = Payment - TotalCostRound;
                            if (Payment > TotalCostRound)
                            {
                                Console.WriteLine($"Your Change is ${Math.Round(Change, 2)}. Thank you for shopping!");
                                
                                string FilePath = @"receipt.txt";
                                try
                                {
                                    using StreamWriter Writer = new StreamWriter(FilePath);
                                    Writer.WriteLine("----- Receipt -----");
                                    for (int i = 0; i < ItemsList.Length; i++)
                                    {
                                        if (ItemsList[i].CartNumber > 0)
                                        {
                                            Writer.WriteLine($"{ItemsList[i].CartNumber} {ItemsList[i].Name} - ${ItemsList[i].CartNumber * ItemsList[i].Price}");
                                        }
                                    }
                                    if (CouponCode == "DISCOUNT35" || CouponCode == "SAVE15" || CouponCode == "FREESAND")
                                    {
                                        Writer.WriteLine($"Coupon Code: {CouponCode}");
                                    }
                                    Writer.WriteLine("-------------------");
                                    //Add loyalty discount
                                    Writer.WriteLine($"Sub Total: ${Math.Round(TotalCost, 2)}");
                                    Writer.WriteLine($"Tax: ${Math.Round(Tax,2)}");
                                    Writer.WriteLine($"Total: ${TotalCostRound}");
                                    Writer.WriteLine($"Payment: ${Payment}");
                                    Writer.WriteLine($"Change: ${Math.Round(Change, 2)}");
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine("Error Writing to the file");
                                    Console.WriteLine(e.Message);
                                }

                                for (int i = 0; i < ItemsList.Length; i++) 
                                { 
                                    ItemsList[i].CartNumber = 0; 
                                }
                                TotalCostRound = 0;
                            }
                            else if (Payment < TotalCostRound)
                            {
                                TotalCostRound -= Payment;
                                Console.WriteLine($"You still owe ${Math.Round(TotalCostRound, 2)}.");
                            }
                            else
                            {
                                Console.WriteLine("You have no change. Thank you for shopping!");
                                TotalCostRound = 0;
                                for (int i = 0; i < ItemsList.Length; i++)
                                {
                                    ItemsList[i].CartNumber = 0;
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("Payment must be positive");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Thank you for shopping with us!");
                        break;

                    default:
                        throw new Exception("Invalid choice");
                }
            } 
        }
    }
}