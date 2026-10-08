using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitsAndBites;

namespace BitsAndBites.KonsolenApp;

public class KonsoleMenue
{
    
    public void Start()
    {
        

        bool laeuft = true;

        while (laeuft)
        {
            ZeigeMenue();

            int auswahl = LeseZahl(1, 8);

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

    private void ZeigeMenue() { }

    private void GetraenkHinzufuegen() { }
    private void EssenHinzufuegen() { }
    private void InternetticketHinzufuegen() { }

    private void PostenEntfernen() { }

    private void BestellungAnzeigen() { }

    private void CardUmschalten() { }
    private void BestellungUebermitteln() { }

    static int LeseZahl(int min, int max)
    {
        int zahl;

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
}
