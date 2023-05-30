

namespace Entities
{
    public class Restaurant:Abstract
    {
        public Restaurant(int id, string name, DateTime openingTime, DateTime closingTime, int minimumOrder, int maximumDistance, int standardDeliveryPrice, int extraDeliveryFee)
            : base(id, name, String.Empty, 0, minimumOrder, maximumDistance, standardDeliveryPrice, extraDeliveryFee, String.Empty, 0, String.Empty)
        {
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }

        public override string WriteDescription()
        {
            return "\n" + this.Name + "\nSchedule: " + this.OpeningTime.ToString("HH:mm") + " - " + this.ClosingTime.ToString("HH:mm")
                + "\nMinimum order (total food price without transportation fee): " + this.MinimumOrder + " euros"
                + "\nStandard delivery maximum distance (km): " + this.MaximumDistance + " km"
                + "\nStandard delivery price: " + this.StandardDeliveryPrice + " euros"
                + "\nExtra delivery fee (price/km): " + this.ExtraDeliveryFee + " euros/km";
        }

        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}