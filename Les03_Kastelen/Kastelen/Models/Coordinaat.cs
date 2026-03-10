public class Coordinaat
{
    // Het voordeel van de factory method in de domein klasse zelf te steken is dat we de constructor private kunnen maken.
    // Daardoor dwingen we iedereen die gebruik maakt van onze klasse om de factory methode (Create) te gebruiken
    public static FactoryResult<Coordinaat> Create(int x, int y)
    {
        string errorMessage = "";
        if (x < 0)
            errorMessage = "X moet groter dan 0";
        
        if (y < 0)
            errorMessage = errorMessage + "Y moet groter dan 0";

        if (errorMessage.Length > 0)
            return new FactoryResult<Coordinaat>(errorMessage);
        else
            return new FactoryResult<Coordinaat>(new Coordinaat(x, y));
    }

    // Een 'TryCreate' is een variant van de Factory Pattern die gemakkelijk in een if-structuur te gebruiken is. We gebruiken typisch een 'out' parameter om de
    // eigenlijk waarde terug te geven
    // Je kan dan gewoon hetvolgende doen: if ( TryCreate(1, 2, out var coordinaat) ). Indien x & y geldig waren dan zal de 'out' variable coordinaat een geldige 
    // coordinaat bevatten. Indien x & y niet geldig waren dan maakt het niet uit wat er in coordinaat zit
    // Hier geven we via de 'out' parameter het nieuwe object terug, maar stel dat je de errorMessages wil kan je hier ook de Factory result teruggeven, waar je 
    // in het geldige pad (x & y waren goed) een nieuwe instantie van Coordinaat zet, en in het ongeldige pad (x & y niet goed) zet je de error boodschap
    public static bool TryCreate(int x, int y, out Coordinaat coordinaat)
    {
        string errorMessage = "";
        if (x < 0)
            errorMessage = "X moet groter dan 0"; // Typisch zal je hier een code terug geven die je dan in de gebruikers interface vertaalt naar de eigenlijk tekst (in de gewenste taal van de gebruiker)

        if (y < 0)
            errorMessage = errorMessage + "Y moet groter dan 0";

        if (errorMessage.Length > 0)
        {
            coordinaat = null;
            return false;
        }
        else
        {
            coordinaat = new Coordinaat(x, y);
            return true;
        }
    }

    /// <summary>
    /// Een eigenschap met 'init' wil zeggen dat we enkel deze eigenschap zijn waarde kunnen zetten bij het aanmaken van het object (in de constructor dus)
    /// </summary>
    public int X { get; init; }

    public int Y { get; init; }

    private Coordinaat(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool LigtBinnenRaster(int rasterBreedte, int rasterHoogte)
    {
        // Als x negatief is, of groter of gelijk aan de breedte van het raster, dan ligt het coordinaat niet binnen het raster
        if ( X < 0 || rasterBreedte <= X)
            return false;

        // Als y negatief is, of groter of gelijk aan de hoogte van het raster, dan ligt het coordinaat niet binnen het raster
        if (Y < 0 || rasterHoogte <= Y)
            return false;

        return true;
    }
}

