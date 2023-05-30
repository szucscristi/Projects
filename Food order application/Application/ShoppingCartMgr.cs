using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application
{
    public class ShoppingCartMgr : AbstractMgr
    {
        public void FillShoppingCart(int menuId)
        {
            string choice = "Yes";
            while (choice=="Yes")
            {
                bool nameFound = false;
                Console.WriteLine("\nWrite down the name of the food to add it to the shopping cart: ");
                ShoppingCart cart = new ShoppingCart("", "", 0);
                while (nameFound == false)
                {
                    string foodName = Console.ReadLine();
                    var menuItem = elements.FirstOrDefault(x => x.Name == foodName);
                    if (menuItem == null || menuItem.Id != menuId)
                    {
                        Console.WriteLine("Name not found in the available menu. Please try again.");
                    }
                    else
                    {
                        nameFound = true;
                        cart.Name= menuItem.Name;
                        cart.Description= menuItem.Description;
                        cart.Price=menuItem.Price;
                        cart.AddMenuItem(menuItem);
                    }
                }
                Console.WriteLine("Your choice has been added succesfully! Do you want to buy anything else? (Yes/No)");
                choice = Console.ReadLine();
                while (choice != "Yes" && choice != "No")
                {
                    Console.WriteLine("Please choose between 'Yes' or 'No'.");
                    choice = Console.ReadLine();
                }
                elements.Add(cart);
            }
        }
        public int CalculateTotalPrice()
        {
            int totalPrice = 0;
            foreach (var item in elements)
            {
                if(item is ShoppingCart shoppingCart)
                    totalPrice += item.Price;
            }
            return totalPrice;
        }
    }
}
