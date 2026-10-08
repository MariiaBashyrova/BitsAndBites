namespace BitsAndBites;

public class Ticket : Posten
{
    private string name;
    private double preis;
    private TimeOnly startzeit;
    private int minuten; 
    public Ticket(string name, double preis, TimeOnly startzeit, int minuten)
    {
        Name = name;
        Preis = preis;
        this.startzeit = startzeit;
        Minuten = minuten;
    }
    protected override string Name { get => name; set => name = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Name darf nicht leer sein.", nameof(value)) : value; }
    protected override double Preis
    {
        get => preis; set => preis = value <= 0 ? throw new ArgumentOutOfRangeException(nameof(value),
            $"Preis {value} ist ungültig.") : value;
    }

    private int Minuten
    {
        get => minuten; set => minuten = value <= 0 ? throw new ArgumentOutOfRangeException(nameof(value),
            $"Minuten {value} ist ungültig.") : value;
    }
    public override double BerechnePreis()
    {
        return Math.Round(Preis * Minuten, 2);
        //Liefert den Grundpreis multipliziert mit der Anzahl der Minuten.
    }

    public override string GetDetails()
    {
        return $"Ticket: {Name}, SZ: {startzeit}, {Minuten} Min";
    }
}
