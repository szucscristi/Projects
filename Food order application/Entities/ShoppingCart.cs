using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ShoppingCart:Abstract
    {
        private static List<Abstract> shopping = new List<Abstract>();
        public ShoppingCart(string name, string description, int price):base(0, name, description, price, 0, 0, 0, 0, String.Empty, 0, String.Empty)
        {
            
        }
        public void AddMenuItem(Abstract elem)
        {
            shopping.Add(elem);
        }
        public override string WriteDescription()
        {
            string menuItemInfo = "";
            foreach(var elem in shopping)
            {
                menuItemInfo= menuItemInfo + elem.WriteDescription() + "\n";
            }
            return menuItemInfo;
        }

    }
}
