using System.Collections.ObjectModel;
using System.Drawing;
using System.Runtime.CompilerServices;

public class Kasteel
{
    public static FactoryResult<Kasteel> Create(int x, int y, int aantalTorens, Color kleurVlagjes)
    {
        // We herhalen de validatie NIET, maar maken gebruik van de coordinaat factory en de validatie die daar gebruikt wordt.
        var resultCoordinaat = Coordinaat.Create(x, y);

        // We werken verder op de error boodschappen die we gekregen hebben van het coordinaat.
        var errors = resultCoordinaat.ErrorMessages;

        if (aantalTorens > 0)
            errors.Add("Aantal torens mag niet 0 zijn");

        if (kleurVlagjes != Color.Transparent)
            errors.Add("Vlagjes moeten kleur hebben");

        if (errors.Any())
            return new FactoryResult<Kasteel>(errors);
        else
            return new FactoryResult<Kasteel>(new Kasteel(resultCoordinaat.Result, aantalTorens, kleurVlagjes));
    }

    public static FactoryResult<Kasteel> Create(int x, int y, int aantalTorens, Color kleurVlagjes, string prinsesNaam, string prinsesBeschrijving)
    {
        // We herhalen de validatie NIET, maar maken gebruik van de coordinaat factory en de validatie die daar gebruikt wordt.
        var resultCoordinaat = Coordinaat.Create(x, y);
        var resultPrinses = Prinses.Create(prinsesNaam, prinsesBeschrijving);

        // We werken verder op de error boodschappen die we gekregen hebben van het coordinaat.
        var errors = resultCoordinaat.ErrorMessages;

        // We voegen de errors toe van de prinses
        errors.AddRange(resultPrinses.ErrorMessages);

        if (aantalTorens > 0)
            errors.Add("Aantal torens mag niet 0 zijn");

        if (kleurVlagjes != Color.Transparent)
            errors.Add("Vlagjes moeten kleur hebben");

        if (errors.Any())
        {
            return new FactoryResult<Kasteel>(errors);
        }
        else
        {
            var kasteel = new Kasteel(resultCoordinaat.Result, aantalTorens, kleurVlagjes);

            // We voegen de prinses toe
            kasteel.Bewoners.Add(resultPrinses.Result);
            return new FactoryResult<Kasteel>(kasteel);
        }
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

    // We willen niet dat de gebruiker van onze klasse de collectie kan aanpassen. We geven ze dus enkel 'ReadOnly' terug
    private List<Bewoner> _bewoners;
    public ReadOnlyCollection<Bewoner> Bewoners
        => _bewoners.AsReadOnly();

    private Kasteel(Coordinaat positie, int aantalTorens, Color kleurVlagjes)
    {
        Positie = positie;
        AantalTorens = aantalTorens;
        KleurVlagjes = kleurVlagjes;

        _bewoners = new List<Bewoner>();
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
    
    public bool VoegBewonerToe(Bewoner bewoner)
    {
        // Als de bewoner geen prinses is, dan mag hij toegevoegd worden. 
        // Als de bewoner een prinses is, en er is nog geen prinses in de lijst mag deze ook toegevoegd worden (Er mag max 1 prinses zijn)
        if (bewoner is not Prinses || !Bewoners.Any(bewoner => bewoner is Prinses))
        {
            _bewoners.Add(bewoner);
            return true;
        }
        else
            return false;
    }

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

