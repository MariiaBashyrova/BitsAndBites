namespace BitsAndBites;

public class Getraenk : Posten
{
    private string name;
    private double preis;
    private bool alkoholisch;
    private bool happyhour;     
    const double HAPPYHOUR_DISCOUNT = 0.75; // 25% Rabatt während der Happy Hour
    public Getraenk(string name, double preis, bool alkoholisch, bool happyhour)
    {
        this.name = name;
        this.preis = preis;
        this.alkoholisch = alkoholisch; 
        this.happyhour = happyhour;
    }
    protected override string Name => name;
    protected override double Preis => preis;
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
