namespace BitsAndBites;
public enum Bestellstatus { Offen, Uebermittelt, Bezahlt }
public class  Bestellung
{
   
    const double CARD_RABATT = 0.05; // 5% Rabatt
    private bool bitandbitecard;
    public bool Bitandbitecard => bitandbitecard;
    
    private List<Posten> bestellposten;

    private Bestellstatus status;
    public Bestellstatus Status => status;

    public Bestellung(bool bitandbitecard)
    {
        this.bitandbitecard = bitandbitecard;
        bestellposten = new List<Posten>();
        status = Bestellstatus.Offen;
    }
    
    public void FuegePostenHinzu(Posten posten)
    {
        ArgumentNullException.ThrowIfNull(posten);
        if (status != Bestellstatus.Offen)
        {
            throw new InvalidOperationException("Bestellungen können nur im Status 'Offen' bearbeitet werden.");
        }
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
        summe *= bitandbitecard ?  1 - CARD_RABATT : 1; // 5% Rabatt, wenn bitandbitecard true ist
        summe = Math.Max(0, summe);                     // Sicherstellen, dass die Summe nicht negativ ist
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

    public double BerechneCardRabatt()
    {
        if (!bitandbitecard)
        {
            return 0;
        }
        double summe = bestellposten.Sum(p => p.BerechnePreis());
        double rabatt = summe * CARD_RABATT; // 5% Rabatt
        return Math.Round(rabatt, 2);
    }
}