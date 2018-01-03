

namespace InventoryAppGUI
{
    using InventoryApp;
    using System;

    public class Login
    {
        public static void Main(string[] args) {

            UserGUI userGUI = new UserGUI();

            Console.WriteLine("\t*****Bienvenido al sistema de inventarios*****\n");
            userGUI.UserValidation();
           
            Console.ReadLine(); 
            
        }

        //esto es para tratar de devolverse al menú inicial, para luego!
        //public static void PressAnyKeyToContinue()
        //{
        //    Console.WriteLine();
        //    Console.WriteLine(">>> Press any key to continue...");
        //    Console.ReadKey();
        //    Console.Clear();
        //}
    }
}
