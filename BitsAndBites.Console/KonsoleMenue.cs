using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitsAndBites;

namespace BitsAndBites.KonsolenApp;

public class KonsoleMenue
{
    private Bestellung aktuelleBestellung = new Bestellung(false); // Standardmäßig wird eine Bestellung ohne Karte erstellt
    public void Start()
    {
        
        bool laeuft = true;

        while (laeuft)
        {
            ZeigeMenue();

            int auswahl = LeseInt("Ihre Auswahl: ",1, 8);

            switch (auswahl)
            {
                case 1:
                    GetraenkHinzufuegen();
                    break;

                case 2:
                    EssenHinzufuegen();
                    break;

                case 3:
                    InternetticketHinzufuegen();
                    break;

                case 4:
                    PostenEntfernen();
                    break;

                case 5:
                    BestellungAnzeigen();
                    break;

                case 6:
                    CardUmschalten();
                    break;

                case 7:
                    BestellungUebermitteln();
                    break;

                case 8:
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

        Getraenk getraenk = new Getraenk(name, preis, alkoholisch, happyHour);
        aktuelleBestellung.FuegePostenHinzu(getraenk);
    }
    private void EssenHinzufuegen() 
    {
        string name = LeseName();
        double preis = LesePreis();

        bool extraGross = LeseJaNein("Extra groß?");
        
        Essen essen = new Essen(name, preis, extraGross);
        aktuelleBestellung.FuegePostenHinzu(essen);

    }
    private void InternetticketHinzufuegen() 
    {
        string name = LeseName();
        double preis = LesePreis();
        TimeOnly startzeit = LeseStartzeit();
        int minuten = LeseInt("Minuten? ",1, 1440);

        Ticket ticket = new Ticket(name, preis, startzeit, minuten);
        aktuelleBestellung.FuegePostenHinzu(ticket);
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

    private void BestellungAnzeigen() { }

    private void CardUmschalten() 
    {
        Console.WriteLine($"Bits & Bites-Card ist jetzt {(aktuelleBestellung.KarteUmschalten() ? "aktiv" : "inaktiv")}");
    }
    private void BestellungUebermitteln() { }

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
            if (!double.TryParse(Console.ReadLine(), out zahl))
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
