namespace BitsAndBites;

public class Ticket : Posten
{
    private string name;
    private double preis;
    private TimeOnly startzeit;
    private int minuten; 
    public Ticket(string name, double preis, TimeOnly startzeit, int minuten)
    {
        this.name = name;
        this.preis = preis;
        this.startzeit = startzeit;
        this.minuten = minuten;
    }
    protected override string Name => name;
    protected override double Preis => preis;
    public override double BerechnePreis()
    {
        return Math.Round(Preis * minuten, 2);
        //Liefert den Grundpreis multipliziert mit der Anzahl der Minuten.
    }

    public override string GetDetails()
    {
        return $"Ticket: {Name}, Preis: {BerechnePreis():C}, Startzeit: {startzeit}, Dauer: {minuten} Minuten";
    }
}
