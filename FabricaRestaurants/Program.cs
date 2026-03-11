using System;

namespace FabricasRestaurantes
{
    class Program
    {
        static void Main(string[] args)
        {
          

            Console.WriteLine("\n=== Restaurante Chino ===");
            Cliente cliente = new Cliente(new RestauranteChino());
            cliente.GenerarMenu();

            Console.WriteLine("\n=== Restaurante Japonés ===");
            cliente = new Cliente(new RestauranteJapones());
            cliente.GenerarMenu();

            Console.WriteLine("\n=== Restaurante Mexicano ===");
            cliente = new Cliente(new RestauranteMexicano());
            cliente.GenerarMenu();

            Console.WriteLine("\n=== Restaurante Italiano ===");
            cliente = new Cliente(new RestauranteItaliano());
            cliente.GenerarMenu();

            Console.WriteLine("\n=== Restaurante Francés ===");
            cliente = new Cliente(new RestauranteFrances());
            cliente.GenerarMenu();
        }
    }
}