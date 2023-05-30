using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class FormMgr:AbstractMgr
    {
        public void ReadForm()
        {
            Console.WriteLine("\n\n\nPlease complete the following form carefully: ");
            Console.WriteLine("\nName (required): ");
            string name = Console.ReadLine();
            Console.WriteLine("\nAddress (required): ");
            string address = Console.ReadLine();
            Console.WriteLine("\nDistance in km (required): ");
            int distance = int.Parse(Console.ReadLine());
            Console.WriteLine("\nOrder mentions (optional): ");
            string orderMentions= Console.ReadLine();
            Form form = new Form(name, address, distance, orderMentions);
            elements.Add(form);
        }

        public int GetUserDistance()
        {
            int userDistance = 0;
            foreach (var item in elements)
            {
                if(item is Form form)
                    userDistance = item.Distance;
            }
            return userDistance;
        }
    }
}
