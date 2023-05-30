using Application;

bool check = false;
string choice = "";
int menuId = -1;

string restaurantChoice="";
int restaurantMaxDistance = 0;
int restaurantExtraFee = 0;
int standardDelPrice = 0;

int userDistance = 0;
int cartPrice=0;
int extraFee = 0;
int totalPrice = 0;

RestaurantsMgr restaurantsMgr = new RestaurantsMgr();
MenusMgr menusMgr = new MenusMgr();
ShoppingCartMgr shoppingCartMgr = new ShoppingCartMgr();
FormMgr formMgr = new FormMgr();

restaurantsMgr.InitListfromXML();
menusMgr.InitListfromXML();
restaurantsMgr.WriteRestaurants();

while (menuId == -1)
{
    while (check == false)
    {
        Console.WriteLine("\n\nPlease select a restaurant from the list above.\nWrite down the restaurant's name to do so (example: Mediterana restaurant): ");
        restaurantChoice = Console.ReadLine();
        restaurantsMgr.CheckRestaurant(restaurantChoice, ref check);
    }
    menusMgr.WriteMenus(restaurantChoice, ref menuId);
}

check = false;
shoppingCartMgr.FillShoppingCart(menuId);
shoppingCartMgr.WriteCart();
cartPrice = shoppingCartMgr.CalculateTotalPrice();
Console.WriteLine("\nCart price: " + cartPrice + " euros");
restaurantsMgr.CheckMinimumOrder(restaurantChoice, cartPrice, ref check);
while (check == false)
{
    Console.WriteLine("\nYou didn't reach the minimum order. Do you want to add more items? (Yes/No):");
    choice = Console.ReadLine();
    if (choice == "Yes")
    {
        shoppingCartMgr.FillShoppingCart(menuId);
        shoppingCartMgr.WriteCart();
        cartPrice = shoppingCartMgr.CalculateTotalPrice();
        Console.WriteLine("\nCart price: " + cartPrice + " euros");
        restaurantsMgr.CheckMinimumOrder(restaurantChoice, cartPrice, ref check);
    }
    else
        if (choice == "No")
    {
        Console.WriteLine("\nWe're sorry! You can't submit an order if the minimum order isn't reached. Have a nice day!");
        Environment.Exit(0);
    }
    else
        Console.WriteLine("\nPlease choose between 'Yes' or 'No'.");

}

formMgr.ReadForm();

userDistance = formMgr.GetUserDistance();
restaurantMaxDistance = restaurantsMgr.GetMaxDistance(restaurantChoice);
restaurantExtraFee = restaurantsMgr.GetExtraFee(restaurantChoice);
standardDelPrice = restaurantsMgr.GetDeliveryPrice(restaurantChoice);

if (!restaurantsMgr.CheckDistance(restaurantChoice))
{
    extraFee = (userDistance - restaurantMaxDistance) * restaurantExtraFee;
}


totalPrice += cartPrice + standardDelPrice + extraFee;

Console.WriteLine("\nThe total price of your order (with extra fee if maximum delivery distance is exceeded) is: " + totalPrice
    + " euros" + "\nDo you want to submit your order? (Yes/No)");
choice = Console.ReadLine();
if (choice == "No")
    Console.WriteLine("Your order will not be submited.");
else
    formMgr.WriteForm();