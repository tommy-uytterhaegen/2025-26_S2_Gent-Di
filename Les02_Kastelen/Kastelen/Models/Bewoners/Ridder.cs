public class Ridder : Bewoner, IStrijder
{
    public int ZwaardLengteInCm { get; init; }

    public Ridder(string naam, int zwaardLengteInCm)
        : base(naam)
    {
        ZwaardLengteInCm = zwaardLengteInCm;
    }

    public void Vecht()
    {
        Console.WriteLine("Steekt met zijn zwaard");
    }
}
