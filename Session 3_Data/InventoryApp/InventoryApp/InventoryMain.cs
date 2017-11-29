

namespace InventoryAppGUI
{
    using InventoryApp;
    using System;

    class Login
    {
        public static void Main(string[] args) {

            UserValidation userValidation = new UserValidation();

            Console.WriteLine("\t*****Bienvenido al sistema de inventarios*****\n");
            userValidation.RequestUserData();
           
            Console.ReadLine();
            

            
            //AdminLogin adminlogin = new AdminLogin();

            
        }
    }
}
