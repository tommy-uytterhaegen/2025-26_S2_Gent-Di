using System.Drawing;

public class Kasteel
{
    public static FactoryResult<Kasteel> Create(int x, int y, int aantalTorens, Color kleurVlagjes)
    {
        // We herhalen de validatie NIET, maar maken gebruik van de coordinaat factory en de validatie die daar gebruikt wordt.
        var resultCoordinaat = Coordinaat.Create(x, y);

        // We werken verder op de error boodschappen die we gekregen hebben van het coordinaat.
        var errorMessage = resultCoordinaat.ErrorMessage;

        if (aantalTorens > 0)
            errorMessage += "Aantal torens mag niet 0 zijn";

        if (kleurVlagjes != Color.Transparent)
            errorMessage += "Vlagjes moeten kleur hebben";

        if (string.IsNullOrEmpty(errorMessage))
            return new FactoryResult<Kasteel>(new Kasteel(resultCoordinaat.Result, aantalTorens, kleurVlagjes));
        else
            return new FactoryResult<Kasteel>(errorMessage);
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

    public List<Bewoner> Bewoners { get; init; }

    private Kasteel(Coordinaat positie, int aantalTorens, Color kleurVlagjes)
    {
        Positie = positie;
        AantalTorens = aantalTorens;
        KleurVlagjes = kleurVlagjes;

        Bewoners = new List<Bewoner>();
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

    public bool IsBewoond()
    {
        if (Bewoners.Any())
            return true;

        return false;
    }

    public bool IsBewoondDoorPrinses()
    {
        if ( Bewoners.Any(bewoner => bewoner is Prinses) )
            return true;

        return false;
    }
}

