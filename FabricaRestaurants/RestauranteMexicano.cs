namespace FabricasRestaurantes
{
    public class RestauranteMexicano : RestauranteFactory
    {
        public override PlatoFuerte CrearPlatoFuerte() => new TacosCarneAsada();
        public override Bebida CrearBebida() => new AguaJamaica();
        public override Postre CrearPostre() => new PastelTresLeches();
    }

    class TacosCarneAsada : PlatoFuerte
    {
        public override string Servir() => "Tacos de carne asada";
    }

    class AguaJamaica : Bebida
    {
        public override string Servir() => "Agua de Jamaica";
    }

    class PastelTresLeches : Postre
    {
        public override string Servir() => "Pastel de tres leches";
    }
}