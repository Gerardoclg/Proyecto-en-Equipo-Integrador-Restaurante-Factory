namespace FabricasRestaurantes
{
    public class RestauranteChino : RestauranteFactory
    {
        public override PlatoFuerte CrearPlatoFuerte() => new ChowMein();
        public override Bebida CrearBebida() => new TeJazmin();
        public override Postre CrearPostre() => new RollitoDulce();
    }

    class ChowMein : PlatoFuerte
    {
        public override string Servir() => "Chow Mein";
    }

    class TeJazmin : Bebida
    {
        public override string Servir() => "Té Jazmín";
    }

    class RollitoDulce : Postre
    {
        public override string Servir() => "Rollito dulce con nieve";
    }
}