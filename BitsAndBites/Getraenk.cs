namespace BitsAndBites;

public class Getraenk : Posten
{
    private string name;
    private double preis;
    private bool alkoholisch;
    private bool happyhour;     
    const double HAPPYHOUR_DISCOUNT = 0.75; // 25% Rabatt während der Happy Hour
    
    protected override string Name { get => name; set => name = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Name darf nicht leer sein.", nameof(value)) : value; }
    protected override double Preis
    {
        get => preis; set => preis = value <= 0 ? throw new ArgumentOutOfRangeException(nameof(value),
            $"Preis {value} ist ungültig.") : value;
    }

    public Getraenk(string name, double preis, bool alkoholisch, bool happyhour)
    {
        Name = name;
        Preis = preis;
        this.alkoholisch = alkoholisch;
        this.happyhour = happyhour;
    }
    public override double BerechnePreis()
    {
        //Liefert 75 % des Grundpreises, wenn das Getränk alkoholisch ist und während der Happy Hour bestellt wurde, sonst den Grundpreis.
        if (alkoholisch && happyhour)
        {
            return Math.Round(Preis * HAPPYHOUR_DISCOUNT, 2);
        }
        return Preis;
    }

    public override string GetDetails()
    {
        return $"Getränk: {Name}{(alkoholisch ? ", alkoholisch" : "")}{(happyhour ? ", Happy Hour" : "")}";
    }
}
