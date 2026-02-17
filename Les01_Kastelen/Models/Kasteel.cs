using System.Drawing;

public class Kasteel
{
    public class FactoryResult
    {
        public List<string> Errors { get; init; }
        public Kasteel NewObject { get; init; }

        public FactoryResult(Kasteel newObject, List<string> errors)
        {
            Errors = errors;
            NewObject = newObject;
        }
    }

    // Een implementatie van de Factory pattern om het kasteel te maken
    // Deze maakt gebruik van een resultaat object om het object & error boodschappen terug te geven
    public static FactoryResult Create(int x, int y, int aantalVlagjes, Color kleurVlagjes)
    {
        var r = Coordinaat.Create(x, y);

        var errorMessages = r.ErrorMessages ?? new List<string>(); // Als r.ErrorMessages 'null' zou zijn, dan zal hij de 'new List<string>()' uitvoeren
        if (aantalVlagjes == 0)
            errorMessages.Add("Minstens 1 vlagje");

        if (kleurVlagjes != Color.Transparent)
            errorMessages.Add("Transparant is geen geldige kleur");

        if (errorMessages.Count > 0)
            return new FactoryResult(null, errorMessages);
        else
            return new FactoryResult(new Kasteel(r.Coordinaat, aantalVlagjes, kleurVlagjes), null);
    }

    /// <summary>
    /// We kunnen basis typen gebruiken als types voor eigenschappen (int, string, bool, etc.)
    /// </summary>
    public int AantalTorens { get; init; }

    /// <summary>
    /// We kunnen niet-basis typen gebruiken als types voor eigenschappen (DateTime, Color, etc.)
    /// </summary>
    public Color KleurVlagjes { get; init; }

    /// <summary>
    /// We kunnen onze eigen klassen gebruiken als types voor eigenschappen
    /// </summary>
    public Coordinaat Positie { get; init; }

    private Kasteel(Coordinaat positie, int aantalTorens, Color kleurVlagjes)
    {
        Positie = positie;
        AantalTorens = aantalTorens;
        KleurVlagjes = kleurVlagjes;
    }

    /// <summary>
    /// We gaan de methode doorsturen naar de coordinaat klasse. De coordinaat klasse heeft logischerwijs de verantwoordelijkheid om te weten of een coordinaat binnen een bepaald raster ligt of niet. 
    /// Door de methode door te sturen, kunnen we de code van de coordinaat klasse hergebruiken en vermijden we duplicatie van code.
    /// </summary>
    /// <param name="rasterBreedte"></param>
    /// <param name="rasterHoogte"></param>
    /// <returns></returns>
    public bool LigtBinnenRaster(int rasterBreedte, int rasterHoogte)
        => Positie.LigtBinnenRaster(rasterBreedte, rasterHoogte);
}

