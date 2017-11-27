

namespace InventoryAppGUI
{
    using InventoryApp;
    using System;

    class Login
    {
        public static void Main(string[] args) {

            UserValidation userValidation = new UserValidation();

            userValidation.RequestUserData();
           
            Console.ReadLine();
            

            
            //AdminLogin adminlogin = new AdminLogin();

            
        }
    }
}
