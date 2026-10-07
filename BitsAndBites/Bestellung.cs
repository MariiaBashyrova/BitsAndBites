namespace BitsAndBites;

public class  Bestellung
{
    private bool bitandbitecard;
    private List<Posten> bestellposten;
    public Bestellung(bool bitandbitecard)
    {
        this.bitandbitecard = bitandbitecard;
        bestellposten = new List<Posten>();
    }
    
    public void FuegePostenHinzu(Posten posten)
    {
        bestellposten.Add(posten);
    }

    public double BerechneBestellung()
        {
        double summe = 0;
        foreach (var posten in bestellposten)
        {
            summe += posten.BerechnePreis();
        }
        if (bitandbitecard)
        {
            summe *= 0.95; // 5% Rabatt
        }
        return summe;
    }
}