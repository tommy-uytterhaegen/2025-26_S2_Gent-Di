using System.Runtime.InteropServices;

public class Prinses : Bewoner
{
    public static FactoryResult<Prinses> Create(string naam, string beschrijving)
    {
        var errors = new List<string>();
        if ( string.IsNullOrEmpty(naam))
        {
            if (!string.IsNullOrEmpty(beschrijving))
                errors.Add("Een prinses kan niet enkel een beschrijving hebben");
        }

        if (errors.Any())
            return new FactoryResult<Prinses>(errors);
        else
            return new FactoryResult<Prinses>(new Prinses(naam, beschrijving));
    }

    public string Beschrijving { get; init; }

    public Prinses(string naam, string beschrijving) 
        : base(naam)
    {
        Beschrijving = beschrijving;
    }
}
