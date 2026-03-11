namespace FabricasRestaurantes
{
    public class RestauranteItaliano : RestauranteFactory
    {
        public override PlatoFuerte CrearPlatoFuerte() => new Pasta();
        public override Bebida CrearBebida() => new VinoTinto();
        public override Postre CrearPostre() => new Tiramisu();
    }

    class Pasta : PlatoFuerte
    {
        public override string Servir() => "Pasta";
    }

    class VinoTinto : Bebida
    {
        public override string Servir() => "Vino tinto";
    }

    class Tiramisu : Postre
    {
        public override string Servir() => "Tiramisú";
    }
}