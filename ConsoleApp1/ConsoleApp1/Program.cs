using System;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp1
{
    
    class Program
    {
        double accountvalue = 0.0;
        decimal balance = 0;
        bool isactive = false;
        product p = new product();

        static void Main(string[] args)
        {
            Program VMObj = new Program();
            Console.WriteLine("Press 1. Want to Use Vending Machine \n");
            Console.WriteLine("Press 0. Want to Exit Vending Machine \n");
            VMObj.isactive = (Int32.Parse(Console.ReadLine())==1? true : false);

            if (VMObj.isactive == true)
            {
                VMObj.ShowProductMenu();
                Console.WriteLine(" Please Select the Product item and Enter the product number ");
                int productselected = Int32.Parse(Console.ReadLine());
                
                switch (productselected)
                {
                    case 1:
                        VMObj.SelectedProduct("Cola", 1.0);

                        while(VMObj.accountvalue< 1.0)
                        {
                            VMObj.InsertCoin();
                        }
                        break;
                    case 2:
                        VMObj.SelectedProduct("Chips", 0.5);
                        while (VMObj.accountvalue < 0.5)
                        {
                            VMObj.InsertCoin();
                        }
                        break;
                    case 3:
                        VMObj.SelectedProduct("Candy", 0.65);
                        while (VMObj.accountvalue < 0.65)
                        {
                            VMObj.InsertCoin();
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Product Selected, Please try again");
                        break;
                }
                VMObj.UpdateBalanceAndReturn(VMObj.accountvalue);

            }
            else
            {
                Console.WriteLine("Are you Sure you donot wish to Purchase? Press 0 to Exit ");

            }

            Console.ReadLine();
        }


        public product SelectedProduct(string name, double price)
        {
            p.AddProduct(name, price);
            return p;
        }

        public void ShowProductMenu()
        {
            Console.WriteLine("Product Menu");
            Dictionary<string, double> ProductList = new Dictionary<string, double>();
            ProductList.Add("Cola", 1.0);
            ProductList.Add("Chips", 0.5);
            ProductList.Add("Candy", 0.65);

            int count = 0;
            foreach (KeyValuePair<string, double> item in ProductList)
            {
                Console.WriteLine(" {0}. Product Name : {1}   Product Price: {2}",(count+1),item.Key, item.Value);
                count++;
            }

        }

        public void InsertCoin()
        {
            Console.WriteLine("Enter the Coin in Nickel,Dime and Quaters");
            double coin = double.Parse(Console.ReadLine());
            switch (coin)
            {
                case 0.05:
                accountvalue = accountvalue + 0.05;
                    break;
                case 0.1:
                    accountvalue = accountvalue + 0.1;
                    break;
                case 0.25:
                    accountvalue = accountvalue + 0.25;
                    break;
                default:
                    Console.WriteLine("Enter in Valid money");
                    break;
            }
        }

        public class product
        {
            public string ProductName { get; set; }
            public double ProductPrice { get; set; }

            public void AddProduct(String _name, double _price)
            {
                ProductName = _name;
                ProductPrice = _price;
            }
           
        }

        public void UpdateBalanceAndReturn(double amountpaid )
        {
            
            balance = (decimal)(amountpaid - p.ProductPrice);
            Console.WriteLine("You have purchased {0} : you paid {1} : your balance amount {2}", p.ProductName, amountpaid, balance);
           
        }


    }
}
