namespace BitsAndBites;
public enum Bestellstatus { Offen, Uebermittelt, Bezahlt }
public class  Bestellung
{
    //const double CARD_RABATT = 0.05; // 5% Rabatt
    //private bool bitandbitecard;
    //public bool Bitandbitecard => bitandbitecard;
    
    private List<Posten> bestellposten;

    private Bestellstatus status;
    public Bestellstatus Status => status;

    private iRabattStrategie rabattStrategie; // nur eine Rabattstrategie zur Zeit

    public iRabattStrategie RabattStrategie => rabattStrategie;

    public Bestellung(bool bitandbitecard)
    {
       // this.bitandbitecard = bitandbitecard;
        if (bitandbitecard) 
        {
            rabattStrategie = new CardRabatt();
        }
        else
        {
            rabattStrategie = new KeinRabatt();
        }
        bestellposten = new List<Posten>();
        status = Bestellstatus.Offen;
    }
    
    public void SetzeRabattStrategie(iRabattStrategie strategie)
    {
        rabattStrategie = strategie ?? throw new ArgumentNullException(nameof(strategie));
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
        //summe *= bitandbitecard ?  1 - CARD_RABATT : 1; // 5% Rabatt, wenn bitandbitecard true ist
        if (rabattStrategie != null)
        {
            summe = rabattStrategie.WendeAn(summe);     // Rabattstrategie anwenden, wenn sie gesetzt ist
        }
        summe = Math.Max(0, summe);                     // Sicherstellen, dass die Summe nicht negativ ist
        return Math.Round(summe, 2);
    }

    public bool KarteUmschalten()
    {
        rabattStrategie = rabattStrategie is CardRabatt ? new KeinRabatt() : new CardRabatt();
        
        return rabattStrategie is CardRabatt;
    }

    public void EntfernePosten(int index)
    {
        if (status != Bestellstatus.Offen)
        {
            throw new InvalidOperationException("Bestellungen können nur im Status 'Offen' bearbeitet werden.");
        }
        if (index < 0 || index >= bestellposten.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index liegt außerhalb des gültigen Bereichs.");
        }
        bestellposten.RemoveAt(index);
    }

    public List<Posten> Bestellposten => new List<Posten>(bestellposten); // Gibt eine Kopie der Liste zurück, um die Kapselung zu wahren

    public double BerechneRabatt()
    {
        double summe = bestellposten.Sum(p => p.BerechnePreis());
        double summeR = summe; // Standardmäßig keine Rabattstrategie angewendet
        if (rabattStrategie != null)
        {
            summeR = Math.Max(0, rabattStrategie.WendeAn(summe));     // Rabattstrategie anwenden, wenn sie gesetzt ist
        }
        
        double rabatt = Math.Max(0, summe - summeR); 
        return Math.Round(rabatt, 2);
    }

    public void UebermittleBestellung()
    {
        if (bestellposten.Count == 0)
        {
            throw new InvalidOperationException("Keine Posten in der Bestellung.");
            
        }
        if (status != Bestellstatus.Offen)
        {
            throw new InvalidOperationException("Bestellungen können nur im Status 'Offen' übermittelt werden.");
        }
        status = Bestellstatus.Uebermittelt;
    }

    public void BezahleBestellung()
    {
        if (bestellposten.Count == 0)
        {
            throw new InvalidOperationException("Keine Posten in der Bestellung.");

        }
        if (status != Bestellstatus.Uebermittelt)
        {
            throw new InvalidOperationException("Bestellungen können nur im Status 'Übermittelt' bezahlt werden.");
        }
        status = Bestellstatus.Bezahlt;
    }
}