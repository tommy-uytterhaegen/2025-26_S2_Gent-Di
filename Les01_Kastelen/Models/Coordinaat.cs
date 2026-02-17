public class Coordinaat
{
    // Een implementatie van de Factory pattern om de coordinaat te maken
    // Maakt gebruik van een 'Tuple' (https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples)
    public static (Coordinaat Coordinaat, List<string> ErrorMessages) Create(int x, int y)
    {
        var errorMessages = new List<string>();
        if (x < 0)
            errorMessages.Add("X was lager 0");

        if (y < 0)
            errorMessages.Add("Y was lager 0");

        if (errorMessages.Count > 0)
            return (null, errorMessages);

        return (new Coordinaat(x, y), null);
    }

    // Een implementatie van de Factory pattern om de coordinaat te maken
    // Maakt gebruik van de 'out' variables om de variabelen terug te geven. Vb. 'if ( Coordinaat.TryCreate(x: 1, y: 1, out var coordinate, out var message))'
    public static bool TryCreate(int x, int y, out Coordinaat newObject, out List<string> errorMessages)
    {
        errorMessages = new List<string>();
        if (x < 0)
            errorMessages.Add("X was lager 0");

        if (y < 0)
            errorMessages.Add("Y was lager 0");

        if (errorMessages.Count == 0)
            newObject = new Coordinaat(x, y);
        else
            newObject = null;

        return errorMessages.Count == 0;
    }

    /// <summary>
    /// Een eigenschap met 'init' wil zeggen dat we enkel deze eigenschap zijn waarde kunnen zetten bij het aanmaken van het object (in de constructor dus)
    /// </summary>
    public int X { get; init; }

    public int Y { get; init; }

    public Coordinaat(int x, int y)
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

