using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class Abstract
    {
        public Abstract(int id, string name, string description, int price, int minimumOrder, int maximumDistance, int standardDeliveryPrice, int extraDeliveryFee, string address, int distance, string mentions)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            MinimumOrder = minimumOrder;
            MaximumDistance = maximumDistance;
            StandardDeliveryPrice = standardDeliveryPrice;
            ExtraDeliveryFee = extraDeliveryFee;
            Address = address;
            Distance = distance;
            Mentions = mentions;

        }
        public abstract string WriteDescription();

        private string address;
        private int distance;
        private string mentions;
        private int id;
        private string name;
        private string description;
        private int price;
        private int minimumOrder;
        private int maximumDistance;
        private int standardDeliveryPrice;
        private int extraDeliveryFee;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Price { get => price; set => price = value; }
        public int MinimumOrder { get => minimumOrder; set => minimumOrder = value; }
        public int MaximumDistance { get => maximumDistance; set => maximumDistance = value; }
        public int StandardDeliveryPrice { get => standardDeliveryPrice; set => standardDeliveryPrice = value; }
        public int ExtraDeliveryFee { get => extraDeliveryFee; set => extraDeliveryFee = value; }
        public string Address { get => address; set => address = value; }
        public int Distance { get => distance; set => distance = value; }
        public string Mentions { get => mentions; set => mentions = value; }
    }
}
