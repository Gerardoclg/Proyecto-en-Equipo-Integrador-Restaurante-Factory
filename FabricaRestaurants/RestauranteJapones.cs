namespace FabricasRestaurantes
{
    public class RestauranteJapones : RestauranteFactory
    {
        public override PlatoFuerte CrearPlatoFuerte() => new Ramen();
        public override Bebida CrearBebida() => new Sake();
        public override Postre CrearPostre() => new Dango();
    }

    class Ramen : PlatoFuerte
    {
        public override string Servir() => "Ramen";
    }

    class Sake : Bebida
    {
        public override string Servir() => "Sake";
    }

    class Dango : Postre
    {
        public override string Servir() => "Dango";
    }
}