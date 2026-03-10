public class Prinses : Bewoner
{
    public string Beschrijving { get; init; }

    public Prinses(string naam, string beschrijving) 
        : base(naam)
    {
        Beschrijving = beschrijving;
    }
}
