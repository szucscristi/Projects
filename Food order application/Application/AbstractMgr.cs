using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Application
{
    public abstract class AbstractMgr
    {
        public static List<Abstract>elements=new List<Abstract>();

        public void WriteRestaurants()
        {
            Console.WriteLine("The list of available restaurants:");
            foreach (Abstract element in elements)
            {
                if(element is Restaurant restaurant)
                    Console.WriteLine(element.WriteDescription());
            }
        }

        public void WriteMenus(string restaurantName, ref int menuId)
        {
            menuId = -1;
            foreach (Abstract element in elements)
            {
                if (element is Restaurant restaurant && restaurantName == element.Name)
                {
                    menuId = element.Id;
                    break;
                }
            }

            if (menuId != -1)
            {
                Console.WriteLine("\nThe restaurant's menu: ");
                foreach (Abstract element in elements)
                {
                    if (element is Menu menu && element.Id == menuId)
                        Console.WriteLine(element.WriteDescription());
                }
            }
            else
            {
                Console.WriteLine("\nRestaurant not found!");
            }
        }
        public void WriteCart()
        {
            Console.WriteLine("\nYour shopping list: \n");
            bool shoppingCartDisplayed = false;

            foreach (Abstract element in elements)
            {
                if (element is ShoppingCart shoppingCart && !shoppingCartDisplayed)
                {
                    Console.WriteLine(shoppingCart.WriteDescription());
                    shoppingCartDisplayed = true;
                }
            }
        }

        public void WriteForm()
        {
            Random random = new Random();
            int uniqueCode = random.Next(1, 999);
            Console.WriteLine("\nOrder submited!\nHere is the completed form: ");
            foreach(Abstract element in elements)
            {
                if(element is Form form)
                {
                    Console.WriteLine(form.WriteDescription());
                }
            }
            Console.WriteLine("\nYour unique code is: " + "[" + uniqueCode + "]\nYou can check your order details and status by entering the code on our homepage.\nThank you for your order!");
        }

    }
}
