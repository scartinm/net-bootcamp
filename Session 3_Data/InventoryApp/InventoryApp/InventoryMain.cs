

namespace InventoryAppGUI
{
    using InventoryApp;
    using System;

    class Login
    {
        public static void Main(string[] args) {

            UserGUI userGUI = new UserGUI();

            Console.WriteLine("\t*****Bienvenido al sistema de inventarios*****\n");
            userGUI.UserValidation();
           
            Console.ReadLine();
            

            
            //AdminLogin adminlogin = new AdminLogin();

            
        }
    }
}
