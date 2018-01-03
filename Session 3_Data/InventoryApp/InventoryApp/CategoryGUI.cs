

namespace InventoryApp
{

    using InventoryBC;
    using System;

    class CategoryGUI
    {
        static CategoryLogic CatData = new CategoryLogic();
        public void categorySelect() {
            
        
            
            var id = "Código Categoría";
            var nombre = "Nombre";
            var descripcion = "Precio";
            var catList = CatData.SelectCategoryLogic();

            Console.WriteLine("\t \t********** LISTA DE CATEGORÍAS **********\n");
            Console.WriteLine(AlignCentre(id, 10) + " | " + AlignCentre(nombre, 30) + " | " + AlignCentre(descripcion, 10) + " | ");
            Console.WriteLine("-----------------------------------------------------------------------");
            foreach (var x in catList)
            {
                Console.WriteLine(AlignCentre(x.CategoryId.ToString(), 10) + " | " + AlignCentre(x.CategoryName, 30) + " | " + AlignCentre(x.Description.ToString(), 10) + " | ");
            }
        }
        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }


        }

    }
}
