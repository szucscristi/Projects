using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Entities;
using Microsoft.VisualBasic;

namespace Application
{
    public class RestaurantsMgr : AbstractMgr
    {
        public void InitListfromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RestaurantsAndMenus.xml"));
            XmlNodeList restaurantNodes = doc.SelectNodes("/restaurantsAndMenus/Restaurant");
            foreach (XmlNode node in restaurantNodes)
            {
                string name = node["Name"].InnerText;
                string openingTime = node["OpeningTime"].InnerText;
                string closingTime = node["ClosingTime"].InnerText;
                DateTime openingT = DateTime.Parse(openingTime);
                DateTime closingT = DateTime.Parse(closingTime);
                int minimumOrder = int.Parse(node["MinimumOrder"].InnerText);
                int maximumDistance = int.Parse(node["StandardDeliveryMaxDistance"].InnerText);
                int standardDeliveryPrice = int.Parse(node["StandardDeliveryPrice"].InnerText);
                int extraDeliveryFee = int.Parse(node["ExtraDeliveryFee"].InnerText);

                Restaurant restaurant = new Restaurant(elements.Count, name, openingT, closingT, minimumOrder, maximumDistance, standardDeliveryPrice, extraDeliveryFee);
                elements.Add(restaurant);
            }
        }

        public void CheckRestaurant(string choice, ref bool checkSchedule)
        {
            bool checkName = false;
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            foreach (var item in elements)
            {
                if(item is Restaurant restaurant && item.Name== choice)
                {
                    checkName = true;
                    TimeSpan openingTime = restaurant.OpeningTime.TimeOfDay;
                    TimeSpan closingTime = restaurant.ClosingTime.TimeOfDay;

                    if (currentTime >= openingTime && currentTime <= closingTime)
                    {
                        Console.WriteLine("\nThe restaurant is currently open!");
                        checkSchedule = true;
                    }
                    else
                    {
                        Console.WriteLine("\nThe restaurant is currently closed.");
                    }
                }
            }
            if(checkName==false)
                Console.WriteLine("\nRestaurant not found.");
        }

        public void CheckMinimumOrder(string name, int checkPrice, ref bool minReached)
        {
            foreach(var item in elements)
            {
                if(item is Restaurant restaurant && item.Name== name) 
                {
                    if (item.MinimumOrder <= checkPrice)
                        minReached = true;
                }
            }
        }
        public bool CheckDistance(string name)
        {
            int maxDistance=0;
            int userDistance = 0;
            foreach(var item in elements)
            {
                if (item is Restaurant restaurant && item.Name == name)
                    maxDistance=item.MaximumDistance;
            }
            foreach(var item in elements)
            {
                if(item is Form form)
                {
                    userDistance = item.Distance;
                }
            }
            if (userDistance <= maxDistance)
                return true;
            else
                return false;
        }
        public int GetDeliveryPrice(string name)
        {
            int deliveryPrice = 0;
            foreach(var item in elements)
            {
                if (item is Restaurant restaurant && item.Name == name)
                    deliveryPrice = item.StandardDeliveryPrice;

            }
            return deliveryPrice;
        }
        public int GetMaxDistance(string name)
        {
            int maxDistance = 0;
            foreach(var item in elements)
            {
                if(item is Restaurant restaurant && item.Name == name)
                    maxDistance = item.MaximumDistance;
            }
            return maxDistance;
        }
        public int GetExtraFee(string name)
        {
            int extraFee = 0;
            foreach(var item in elements)
            {
                if (item is Restaurant restaurant && item.Name == name)
                    extraFee = item.ExtraDeliveryFee;
            }
            return extraFee;
        }
    }
}
