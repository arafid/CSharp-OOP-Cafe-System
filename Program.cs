using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteSizedBrews
{
    public class Drink
    {
        protected string DrinkName;
        protected double BasePrice;
        private static double _taxRate = 0.085;

        public Drink(string drinkName, double basePrice)
        {
            DrinkName = drinkName;
            BasePrice = basePrice;
        }

        public string GetDrinkName()
        {
            return DrinkName;
        }

        public virtual double CalculatePrice()
        {
            string[] discountDrinks = { "Cherry Blossom Latte", "Peach Summer Special" };

            if (discountDrinks.Contains(DrinkName))
                return BasePrice * (1 + _taxRate) * 0.9;
            else
                return BasePrice * (1 + _taxRate);
        }

        public virtual void ShowReceipt()
        {
            Console.WriteLine($"Your {DrinkName} ${CalculatePrice():F2}");
        }
    }

    public class Coffee : Drink
    {
        private int _sugarGrams;
        private string _milkType;

        public Coffee(string drinkName, double basePrice, int sugarGrams, string milkType)
            : base(drinkName, basePrice)
        {
            _sugarGrams = sugarGrams;
            _milkType = milkType;
        }

        public void AddSugar()
        {
            Console.WriteLine($"Adding {_sugarGrams}g sugar to the {DrinkName}.");
        }

        public void SteamMilk()
        {
            Console.WriteLine($"Steaming {_milkType} for the {DrinkName}.");
        }
    }

    public class Tea : Drink
    {
        private int _steepTime;
        private string _teaLeafType;

        public Tea(string drinkName, double basePrice, int steepTime, string teaLeafType)
            : base(drinkName, basePrice)
        {
            _steepTime = steepTime;
            _teaLeafType = teaLeafType;
        }

        public void Steep()
        {
            Console.WriteLine($"Steeping {_teaLeafType} for {_steepTime} minutes.");
        }

        public void RemoveBag()
        {
            Console.WriteLine($"Removing tea bag from the {DrinkName}.");
        }
    }

    public class Juice : Drink
    {
        private int _pulpLevel;
        protected bool IsFreshPressed;

        public Juice(string drinkName, double basePrice, int pulpLevel, bool isFreshPressed)
            : base(drinkName, basePrice)
        {
            _pulpLevel = pulpLevel;
            IsFreshPressed = isFreshPressed;
        }

        public void PressFruit()
        {
            Console.WriteLine($"Pressing fruit for the {DrinkName}.");
        }

        public void Strain()
        {
            Console.WriteLine($"{DrinkName} with pulp level {_pulpLevel}.");
        }
    }

    public class Smoothie : Drink
    {
        private string _baseLiquid;
        public string FruitType;

        public Smoothie(string drinkName, double basePrice, string fruitType, string baseLiquid)
            : base(drinkName, basePrice)
        {
            FruitType = fruitType;
            _baseLiquid = baseLiquid;
        }

        public void Blend()
        {
            Console.WriteLine($"Blending {FruitType} with a {_baseLiquid} base for the {DrinkName}.");
        }

        public void AddProtein()
        {
            Console.WriteLine($"Add protein for the {DrinkName}.");
        }
    }

    public class SeasonalSpecial : Drink
    {
        private static int _limitedQuantity = 50;
        private string _expirationDate;

        public SeasonalSpecial(string drinkName, double basePrice, string expirationDate)
            : base(drinkName, basePrice)
        {
            _expirationDate = expirationDate;
        }

        public void CheckAvailability()
        {
            if (_limitedQuantity > 0)
                Console.WriteLine($"{DrinkName} is available! {_limitedQuantity} remaining (expires {_expirationDate}).");
            else
                Console.WriteLine($"{DrinkName} is sold out.");
        }

        public void ApplySeasonalDiscount()
        {
            if (_limitedQuantity > 0)
            {
                _limitedQuantity--;
                Console.WriteLine($"Seasonal discount applied to {DrinkName}!");
                Console.WriteLine($"Discounted price: ${CalculatePrice():F2} | Stock remaining: {_limitedQuantity}");
            }
            else
            {
                Console.WriteLine($"{DrinkName} is sold out. No discount can be applied.");
            }
        }
    }

    public class Employee
    {
        public string EmployeeName;
        private int _employeeID;
        private static int _totalStaff = 0;

        public Employee(string employeeName, int employeeID)
        {
            EmployeeName = employeeName;
            _employeeID = employeeID;
            _totalStaff++;
        }

        public Drink TakeOrder(string selection)
        {
            switch (selection)
            {
                case "MorningJoe":
                    return new Coffee("House Blend", 2.50, 0, "None");
                case "FancyLatte":
                    return new Coffee("Vanilla Oat Latte", 4.75, 4, "Oat Milk");
                case "EarlGrey":
                    return new Tea("London Fog", 3.50, 3, "Earl Grey / Bergamot");
                case "GreenTea":
                    return new Tea("Zen Matcha", 4.00, 2, "Ceremonial Matcha");
                case "ClassicJuice":
                    return new Juice("Classic Orange", 3.00, 2, false);
                case "GreenPower":
                    return new Juice("Emerald Squeeze", 6.50, 1, true);
                case "BerryBlast":
                    return new Smoothie("Wild Berry", 5.50, "Mixed Berries", "Coconut Water");
                case "BulkUp":
                    return new Smoothie("Protein Power", 7.00, "Banana", "Almond Milk");
                case "CherryBlossom":
                    return new SeasonalSpecial("Cherry Blossom Latte", 5.50, "2026-05-01");
                case "PeachSummer":
                    return new SeasonalSpecial("Peach Summer Special", 5.95, "2026-08-31");
                default:
                    return null;
            }
        }

        public void Prepare(Drink purchase)
        {
            if (purchase is Juice juice)
            {
                juice.PressFruit();
                juice.Strain();
            }
            else if (purchase is Smoothie smoothie)
            {
                smoothie.Blend();
                smoothie.AddProtein();
            }
            else if (purchase is SeasonalSpecial special)
            {
                special.CheckAvailability();
                special.ApplySeasonalDiscount();
            }
            else if (purchase is Coffee coffee)
            {
                coffee.AddSugar();
                coffee.SteamMilk();
            }
            else if (purchase is Tea tea)
            {
                tea.Steep();
                tea.RemoveBag();
            }
        }

        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"{EmployeeName} processing payment of ${amount:F2}...");
            Console.WriteLine("Payment accepted. Thank you!");
        }
    }

    public class Customer
    {
        public string CustomerName;
        private double _walletBalance;
        protected int LoyaltyPoints;
        public List<Drink> PurchasedItems;

        public Customer(string customerName, double walletBalance, int loyaltyPoints)
        {
            CustomerName = customerName;
            _walletBalance = walletBalance;
            LoyaltyPoints = loyaltyPoints;
            PurchasedItems = new List<Drink>();
        }

        public void OrderDrink(Drink purchase, Employee barista)
        {
            if (purchase == null)
                return;

            double price = purchase.CalculatePrice();

            if (_walletBalance >= price)
            {
                _walletBalance -= price;
                LoyaltyPoints += 25;
                PurchasedItems.Add(purchase);
                Console.WriteLine($"Success! Wallet: ${_walletBalance:F2} | Points: {LoyaltyPoints}");
            }
            else
            {
                Console.WriteLine($"Insufficient funds for {purchase.GetDrinkName()}.");
            }
        }

        public void ViewBag()
        {
            foreach (Drink item in PurchasedItems)
            {
                Console.WriteLine($"Your {item.GetDrinkName()} ${item.CalculatePrice():F2}");
            }
        }

        public double CalculateGrandTotal()
        {
            double total = 0;

            foreach (Drink item in PurchasedItems)
            {
                total += item.CalculatePrice();
            }

            return total;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee bob = new Employee("Bob Jones", 102);
            Customer jane = new Customer("Jane Smith", 50.00, 500);

            Drink greenPower = bob.TakeOrder("GreenPower");
            Drink berryBlast = bob.TakeOrder("BerryBlast");
            Drink cherryBlossom = bob.TakeOrder("CherryBlossom");

            Console.WriteLine("SCENE 2 - Customer Jane Smith orders three drinks from Bob Jones");
            jane.OrderDrink(greenPower, bob);
            jane.OrderDrink(berryBlast, bob);
            jane.OrderDrink(cherryBlossom, bob);

            Console.WriteLine();
            Console.WriteLine("Barista Bob Jones Prepares the Drinks:");
            Console.WriteLine();

            Console.WriteLine("Preparing GreenPower:");
            bob.Prepare(greenPower);
            Console.WriteLine();

            Console.WriteLine("Preparing BerryBlast:");
            bob.Prepare(berryBlast);
            Console.WriteLine();

            Console.WriteLine("Preparing CherryBlossom:");
            bob.Prepare(cherryBlossom);
            Console.WriteLine();

            Console.WriteLine("Customer Jane Smith views the bag:");
            jane.ViewBag();
            Console.WriteLine();

            Console.WriteLine($"Grand Total: ${jane.CalculateGrandTotal():F2}");
            Console.WriteLine();

            Console.WriteLine("Item Details:");
            jane.ViewBag();
            Console.WriteLine();

            bob.ProcessPayment(jane.CalculateGrandTotal());
        }
    }
}