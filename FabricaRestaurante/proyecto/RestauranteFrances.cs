namespace FabricasRestaurantes
{
    public class RestauranteFrances : RestauranteFactory
    {
        public override PlatoFuerte CrearPlatoFuerte() => new CoqAuVin();
        public override Bebida CrearBebida() => new Champan();
        public override Postre CrearPostre() => new CremeBrulee();
    }

    class CoqAuVin : PlatoFuerte
    {
        public override string Servir() => "Coq au Vin";
    }

    class Champan : Bebida
    {
        public override string Servir() => "Champán";
    }

    class CremeBrulee : Postre
    {
        public override string Servir() => "Crème Brûlée";
    }
}