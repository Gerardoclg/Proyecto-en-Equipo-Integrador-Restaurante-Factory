using System;

namespace FabricasRestaurantes
{


    public class Cliente
    {
        private readonly RestauranteFactory _fabrica;


        public Cliente(RestauranteFactory fabrica)
        {
            _fabrica = fabrica;
        }


        public void GenerarMenu()
        {
            PlatoFuerte plato = _fabrica.CrearPlatoFuerte();
            Bebida bebida = _fabrica.CrearBebida();
            Postre postre = _fabrica.CrearPostre();


            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║         MENÚ DEL DÍA         ║");
            Console.WriteLine("╠══════════════════════════════╣");
            Console.WriteLine($"║  Plato fuerte : {plato.Servir(),-14}║");
            Console.WriteLine($"║  Bebida       : {bebida.Servir(),-14}║");
            Console.WriteLine($"║  Postre       : {postre.Servir(),-14}║");
            Console.WriteLine("╚══════════════════════════════╝");
        }
    }
}