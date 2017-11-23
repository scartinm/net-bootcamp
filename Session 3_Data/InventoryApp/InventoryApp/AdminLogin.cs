using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppGUI
{
    class AdminLogin
    {
        public void adminLogin() {
            string user;

            Console.Write("Por favor ingrese su usuario: ");
            user = Console.ReadLine();
            Console.WriteLine("usuario: {0}", user);
        }
    }
}
