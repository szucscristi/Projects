using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Entities;

namespace Application
{
    public class MenusMgr : AbstractMgr
    {
        public void InitListfromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RestaurantsAndMenus.xml"));
            XmlNodeList menuItemsNodes = doc.SelectNodes("/restaurantsAndMenus/Restaurant/Menu/MenuItem");
            int restaurantIndex = 0;
            int menuIndex = 0;
            foreach (XmlNode node in menuItemsNodes)
            {
                
                int id=restaurantIndex;
                string name = node["Name"].InnerText;
                string description = node["Description"].InnerText;
                int price = int.Parse(node["Price"].InnerText);
                Menu menu = new Menu(id, name, description, price);
                elements.Add(menu);

                menuIndex++;
                if (menuIndex >= 5)
                {
                    menuIndex = 0;
                    restaurantIndex = (restaurantIndex + 1) % 5;
                }
            }
        }
    }
}
