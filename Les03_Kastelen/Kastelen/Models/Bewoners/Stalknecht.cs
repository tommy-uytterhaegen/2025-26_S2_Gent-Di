public class Stalknecht : Bewoner, IStrijder
{
    public Stalknecht(string naam)
        : base(naam)
    {
    }

    public void Vecht()
    {
        Console.WriteLine("Gooit stenen");
    }
}