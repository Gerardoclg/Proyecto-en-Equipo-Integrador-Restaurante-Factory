# Proyecto-en-Equipo-Integrador-Restaurante-Factory
Evidencia 

## Diagrama UML - Patrón Abstract Factory

```mermaid
classDiagram

class IRestauranteFactory {
    <<interface>>
    +CrearPlatoFuerte()
    +CrearBebida()
    +CrearPostre()
}

class IPlatoFuerte {
    <<interface>>
    +Servir()
}

class IBebida {
    <<interface>>
    +Servir()
}

class IPostre {
    <<interface>>
    +Servir()
}

class RestauranteChinoFactory
class RestauranteJaponesFactory
class RestauranteMexicanoFactory
class RestauranteItalianoFactory
class RestauranteFrancesFactory

class ChowMein
class TeJazmin
class RollitoDulce

class Ramen
class Sake
class Dango

class TacoCarneAsada
class AguaJamaica
class PastelTresLeches

class Pasta
class VinoTinto
class Tiramisu

class CoqAuVin
class Champan
class CremeBrule

class Cliente {
    +MostrarMenu()
}

IRestauranteFactory <|.. RestauranteChinoFactory
IRestauranteFactory <|.. RestauranteJaponesFactory
IRestauranteFactory <|.. RestauranteMexicanoFactory
IRestauranteFactory <|.. RestauranteItalianoFactory
IRestauranteFactory <|.. RestauranteFrancesFactory

IPlatoFuerte <|.. ChowMein
IBebida <|.. TeJazmin
IPostre <|.. RollitoDulce

IPlatoFuerte <|.. Ramen
IBebida <|.. Sake
IPostre <|.. Dango

IPlatoFuerte <|.. TacoCarneAsada
IBebida <|.. AguaJamaica
IPostre <|.. PastelTresLeches

IPlatoFuerte <|.. Pasta
IBebida <|.. VinoTinto
IPostre <|.. Tiramisu

IPlatoFuerte <|.. CoqAuVin
IBebida <|.. Champan
IPostre <|.. CremeBrule

Cliente --> IRestauranteFactory

RestauranteChinoFactory --> ChowMein
RestauranteChinoFactory --> TeJazmin
RestauranteChinoFactory --> RollitoDulce

RestauranteJaponesFactory --> Ramen
RestauranteJaponesFactory --> Sake
RestauranteJaponesFactory --> Dango

RestauranteMexicanoFactory --> TacoCarneAsada
RestauranteMexicanoFactory --> AguaJamaica
RestauranteMexicanoFactory --> PastelTresLeches

RestauranteItalianoFactory --> Pasta
RestauranteItalianoFactory --> VinoTinto
RestauranteItalianoFactory --> Tiramisu

RestauranteFrancesFactory --> CoqAuVin
RestauranteFrancesFactory --> Champan
RestauranteFrancesFactory --> CremeBrule
