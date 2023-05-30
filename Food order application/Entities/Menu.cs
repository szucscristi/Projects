using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Menu:Abstract
    {
        public Menu(int id, string name, string description, int price):base(id, name, description, price, 0, 0, 0, 0,String.Empty,0,String.Empty)
        {

        }
        public override string WriteDescription()
        {
            return "\nName: " + this.Name + "\nDescription: " + this.Description + "\nPrice: " + this.Price + " euros";
        }

    }
}
