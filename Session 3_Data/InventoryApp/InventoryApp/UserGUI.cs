
namespace InventoryApp
{
    using InventoryBC;
    using InventoryEntities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserGUI
    {
        //Solicita la información del usuario para luego validarla
        UserLogic userLogic = new UserLogic();
        AdminModule adminModule = new AdminModule();
      

        public void UserValidation() {
            string user;
            string password;
            
        
            Console.Write("Ingrese su usuario: ");
            user = Console.ReadLine();
            

            Console.Write("Ingrese su contraseña: ");
            password = ReadPassword();

            List<UserIsAdminResult> userResult = userLogic.UserValidationBC(user, password);
            bool hasElements = userResult.Any();

            if (hasElements == true)
            {
                foreach (var item in userResult)
                {
                    if (item.IsAdmin == true)
                    {
                        //aqui es donde debe llamar al menu de Administrador
                        Console.Clear();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Bienvenido Administrador: {0}\n",user);
                        adminModule.DisplayAdminModule();
                        
                    }
                    else if (item.IsAdmin == false)
                    {
                        //aqui debe llamar al menú de usuario
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Bienvenido Usuario");
                    }
                }
            }
            else
            {
                Console.WriteLine("Usuario o contraseña incorrecta. Intente de nuevo\n");
                UserValidation();
            }
            
            
            Console.ReadLine();
     
        }

        public static void UserAdd() {

            Console.Clear();

            UserLogic userLogic = new UserLogic();
            
            string userName;
            string password;
            bool isAdmin = false;
            var opcion = "x";
            Console.WriteLine("*****CREACIÓN DE USUARIO*****\n");
            Console.Write("Ingrese el nombre del usuario: ");
            userName = Console.ReadLine();
            Console.Write("Ingrese el password: ");
            password = ReadPassword();

            Console.WriteLine("Es el usuario administrador? si/no");
            opcion = Console.ReadLine();
            while (opcion != "si" && opcion != "no")
            {
                Console.WriteLine("Comando incorrecto, utilice las palabras reservadas si/no ");
                Console.WriteLine("Es el usuario administrador? si/no");
                opcion = Console.ReadLine();
            }
            switch (opcion)
            {
                case "si":
                    isAdmin = true;
                    break;
                case "no":
                    isAdmin = false;
                    break;
                default:
                    break;
            }

            userLogic.UserAddBC(userName, password, isAdmin);

        }

        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }

    }
}
