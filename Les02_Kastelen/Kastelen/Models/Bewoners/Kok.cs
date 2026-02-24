public class Kok : Bewoner
{
    public string Specialiteit { get; init; }

    public Kok(string naam, string specialiteit)
        : base(naam)
    {
        Specialiteit = specialiteit;
    }
}
