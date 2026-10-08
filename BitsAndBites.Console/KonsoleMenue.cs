using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitsAndBites;

namespace BitsAndBites.KonsolenApp;
public enum MenuePunkt { GetraenkHinzufuegen = 1, EssenHinzufuegen, TicketHinzufuegen, PostenEntfernen, Anzeigen, CardUmschalten, Uebermitteln, Beenden }
public class KonsoleMenue
{

    private Bestellung aktuelleBestellung = new Bestellung(false); // Standardmäßig wird eine Bestellung ohne Karte erstellt
    public void Start()
    {

        bool laeuft = true;

        while (laeuft)
        {
            ZeigeMenue();

            MenuePunkt auswahl = (MenuePunkt)LeseInt("Ihre Auswahl: ", 1, 8);

            switch (auswahl)
            {
                case MenuePunkt.GetraenkHinzufuegen:
                    GetraenkHinzufuegen();
                    break;

                case MenuePunkt.EssenHinzufuegen:
                    EssenHinzufuegen();
                    break;

                case MenuePunkt.TicketHinzufuegen:
                    InternetticketHinzufuegen();
                    break;

                case MenuePunkt.PostenEntfernen:
                    PostenEntfernen();
                    break;

                case MenuePunkt.Anzeigen:
                    BestellungAnzeigen();
                    break;

                case MenuePunkt.CardUmschalten:
                    CardUmschalten();
                    break;

                case MenuePunkt.Uebermitteln:
                    BestellungUebermitteln();
                    break;

                case MenuePunkt.Beenden:
                    laeuft = false;
                    break;

                default:
                    Console.WriteLine("Ungültige Eingabe.");
                    break;
            }
        }
    }

    private void ZeigeMenue()
    {
        Console.WriteLine();
        Console.WriteLine("=== Bits & Bites – Bestellung ===");
        Console.WriteLine("1. Getränk hinzufügen");
        Console.WriteLine("2. Essen hinzufügen");
        Console.WriteLine("3. Internetticket hinzufügen");
        Console.WriteLine("4. Posten entfernen");
        Console.WriteLine("5. Bestellung anzeigen");
        Console.WriteLine("6. Bits & Bites-Card an/aus");
        Console.WriteLine("7. Bestellung an die Theke übermitteln");
        Console.WriteLine("8. Beenden");

    }

    private void GetraenkHinzufuegen()
    {
        string name = LeseName();
        double preis = LesePreis();

        bool alkoholisch = LeseJaNein("Alkoholisch?");
        bool happyHour = LeseJaNein("Happy Hour?");
        try
        {
            Getraenk getraenk = new Getraenk(name, preis, alkoholisch, happyHour);
            aktuelleBestellung.FuegePostenHinzu(getraenk);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Hinzufügen des Getränks: {ex.Message}");
        }
    }
    private void EssenHinzufuegen()
    {
        string name = LeseName();
        double preis = LesePreis();

        bool extraGross = LeseJaNein("Extra groß?");
        try
        {
            Essen essen = new Essen(name, preis, extraGross);
            aktuelleBestellung.FuegePostenHinzu(essen);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Hinzufügen des Essens: {ex.Message}");
        }

        

    }
    private void InternetticketHinzufuegen()
    {
        string name = LeseName();
        double preis = LesePreis();
        TimeOnly startzeit = LeseStartzeit();
        int minuten = LeseInt("Minuten? ", 1, 1440);
        try 
        {   Ticket ticket = new Ticket(name, preis, startzeit, minuten);
            aktuelleBestellung.FuegePostenHinzu(ticket);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Hinzufügen des Tickets: {ex.Message}");
        }
    }

    private void PostenEntfernen()
    {
        int count = 0;
        foreach (var posten in aktuelleBestellung.Bestellposten)
        {
            Console.WriteLine($"{count + 1}. {posten.GetDetails()}");
            count++;
        }
        if (count == 0)
        {
            Console.WriteLine("Keine Posten in der Bestellung.");
            return;
        }
        int index = LeseInt("Welchen Posten möchten Sie entfernen? ", 1, aktuelleBestellung.Bestellposten.Count) - 1;
        if (LeseJaNein($"Sind Sie sicher, dass Sie {aktuelleBestellung.Bestellposten[index].GetDetails()} entfernen möchten?"))
            aktuelleBestellung.EntfernePosten(index);
    }

    private void BestellungAnzeigen()
    {
        if (aktuelleBestellung.Bestellposten.Count == 0)
        {
            Console.WriteLine("Keine Posten in der Bestellung.");
            return;
        }
        Console.WriteLine();
        Console.WriteLine("=========================================================");
        Console.WriteLine("               Internetcafé 'Bits & Bites'");
        Console.WriteLine("=========================================================");
        Console.WriteLine("Posten");
        Console.WriteLine("---------------------------------------------------------");

        foreach (Posten posten in aktuelleBestellung.Bestellposten)
        {
            Console.WriteLine($"{posten.GetDetails(),-43}  {posten.BerechnePreis(),8:F2} EUR");
        }
        Console.WriteLine("---------------------------------------------------------");
        if (aktuelleBestellung.Bitandbitecard)
        {
            double rabatt = aktuelleBestellung.BerechneCardRabatt();
            Console.WriteLine($"Card-Rabatt:                                -{rabatt,8:F2} EUR");
        }

        Console.WriteLine($"Gesamtbetrag:                                {aktuelleBestellung.BerechneBestellung(),8:F2} EUR");
        Console.WriteLine("=========================================================");
    }


    private void CardUmschalten()
    {
        Console.WriteLine($"Bits & Bites-Card ist jetzt {(aktuelleBestellung.KarteUmschalten() ? "aktiv" : "inaktiv")}");
    }
    private void BestellungUebermitteln()
    {
        if (aktuelleBestellung.Bestellposten.Count == 0)
        {
            Console.WriteLine("Keine Posten in der Bestellung.");
            return;
        }
        BestellungAnzeigen();
        Console.WriteLine($"Übermittelt am: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
        aktuelleBestellung = new Bestellung(false); // Neue Bestellung ohne Karte erstellen
    }

    static int LeseInt(string frage, int min, int max)
    {
        int zahl;
        Console.Write($"{frage}");

        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out zahl))
            {
                Console.Write("Ungültige Eingabe. Bitte eine Zahl eingeben: ");
            }
            else if (zahl < min || zahl > max)
            {
                Console.Write($"Ungültige Eingabe. Bitte eine Zahl zwischen {min} und {max} eingeben: ");
            }
            else
            {
                return zahl;
            }
        }
    }

    private string LeseName()
    {
        Console.Write("Name: ");
        return Console.ReadLine()!;
    }

    private double LesePreis()
    {
        Console.Write("Preis: ");
        //return double.Parse(Console.ReadLine()!);
        double zahl;
        while (true)
        {
            if (!double.TryParse(Console.ReadLine().Replace('.', ','), out zahl))
            {
                Console.Write("Ungültige Eingabe. Bitte eine Zahl eingeben: ");
            }

            else
            {
                return zahl;
            }
        }
    }

    private bool LeseJaNein(string frage)
    {
        Console.Write($"{frage} (j/n): ");
        return Console.ReadLine()?.ToLower() == "j";
    }

    private TimeOnly LeseStartzeit()
    {
        while (true)
        {
            Console.Write("Startzeit (HH:mm): ");

            if (TimeOnly.TryParse(Console.ReadLine(), out TimeOnly startzeit))
            {
                return startzeit;
            }

            Console.WriteLine("Ungültige Uhrzeit. Bitte z. B. 14:30 eingeben.");
        }
    }
}
