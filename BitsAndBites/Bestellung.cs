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
        ArgumentNullException.ThrowIfNull(posten);
        bestellposten.Add(posten);
    }

    public double BerechneBestellung()
        {
        //double summe = 0;
        //foreach (var posten in bestellposten)
        //{
        //    summe += posten.BerechnePreis();
        //}
        //if (bitandbitecard)
        //{
        //    summe *= 0.95; // 5% Rabatt
        //}
        //return summe;
        double summe = bestellposten.Sum(p => p.BerechnePreis());
        summe *= bitandbitecard ? 0.95 : 1; // 5% Rabatt, wenn bitandbitecard true ist
        return Math.Round(summe, 2);
    }

    public bool KarteUmschalten()
    {
        bitandbitecard = !bitandbitecard;
        return bitandbitecard;
    }

    public void EntfernePosten(int index)
    {
        if (index < 0 || index >= bestellposten.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index liegt außerhalb des gültigen Bereichs.");
        }
        bestellposten.RemoveAt(index);
    }

    public List<Posten> Bestellposten => new List<Posten>(bestellposten); // Gibt eine Kopie der Liste zurück, um die Kapselung zu wahren
}