using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Form:Abstract
    {
        public Form(string name, string address, int distance, string mentions):base(0, name, String.Empty, 0,0,0,0,0,address,distance,mentions)
        {

        }

        public override string WriteDescription()
        {
            return "\nName (required): " + this.Name
                + "\nAddress (required): " + this.Address
                + "\nDistance in km (required): " + this.Distance + " km"
                + "\nOrder mentions (optional): " + this.Mentions;
        }
    }
}
