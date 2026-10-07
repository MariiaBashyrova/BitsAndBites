namespace BitsAndBites;

public class Getraenk : Posten
{
    private string name;
    private double preis;
    private bool alkoholisch;
    private bool happyhour;     
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
        return Preis;
    }
}
