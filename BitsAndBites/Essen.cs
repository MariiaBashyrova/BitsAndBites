namespace BitsAndBites;

public class Essen : Posten
{
    private string name;
    private double preis;
    private bool extragross;
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
        return Preis;
    }
}
