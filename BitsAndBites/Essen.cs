namespace BitsAndBites;

public class Essen : Posten
{
    private string name;
    private double preis;
    private bool extragross;
    const double EXTRAGROSS_AUFSCHLAG = 1.2; // 20% Aufschlag für Extra Groß
    public Essen(string name, double preis, bool extragross)
    {
        this.name = name;
        this.preis = preis;
        this.extragross = extragross;
    }
    protected override string Name => name;
    protected override double Preis => preis;
    public override double BerechnePreis()
    {
        //Liefert bei „Extra Groß" den Grundpreis zuzüglich 20 % Aufschlag, sonst den Grundpreis.
        if (extragross)
        {
            return Math.Round(Preis * EXTRAGROSS_AUFSCHLAG, 2);
        }
        return Preis;
    }

    public override string GetDetails()
    {
        return $"Essen: {Name}{(extragross ? ", Extra Groß" : "")}";
    }
}
