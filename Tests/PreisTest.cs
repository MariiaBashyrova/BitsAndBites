using BitsAndBites;

namespace Tests;

public class PreisTest
{
    private const int GENAUIGKEIT = 2;

    [Theory]
    [InlineData("Cola", 3.00, false, true, 3.00)]
    [InlineData("Bier", 4.00, true, false, 4.00)]
    [InlineData("Bier", 4.00, true, true, 3.00)]
    public void TestGetraenke(string name, double preis, bool alkoholisch, bool happyhour, double erwartet)
    {
        Getraenk getraenk = new Getraenk(name, preis, alkoholisch, happyhour);

        double ergebnis = getraenk.BerechnePreis();

        Assert.Equal(erwartet, ergebnis, GENAUIGKEIT);
    }

    [Theory]
    [InlineData("Pizza", 8.50, false, 8.50)]
    [InlineData("Pizza", 8.50, true, 10.20)]
    public void TestEssen(string name, double preis, bool extragross, double erwartet)
    {
        Essen essen = new Essen(name, preis, extragross);

        double ergebnis = essen.BerechnePreis();

        Assert.Equal(erwartet, ergebnis, GENAUIGKEIT);
    }

    [Theory]
    [InlineData("Kurzticket", 0.05, "14:00", 60, 3.00)]
    public void TestTicket(string name, double preis, string startzeit, int minuten, double erwartet)
    {
        TimeOnly startzeitTimeOnly = TimeOnly.Parse(startzeit);
        Ticket ticket = new Ticket(name, preis, startzeitTimeOnly, minuten);

        double ergebnis = ticket.BerechnePreis();

        Assert.Equal(erwartet, ergebnis, GENAUIGKEIT);
    }

    [Theory]
    [InlineData(true, false, 16.20)]
    [InlineData(true, true, 15.39)]
    [InlineData(false, true, 0.00)]
    public void TestBestellung(bool mitPosten, bool BonusCard, double erwartet)
    {
        Bestellung bestellung = new Bestellung(BonusCard);
        if (mitPosten)
        {
            bestellung.FuegePostenHinzu(new Getraenk("Bier", 4.00, true, true)); //3.00
            bestellung.FuegePostenHinzu(new Essen("Pizza", 8.50, true)); //10.20
            bestellung.FuegePostenHinzu(new Ticket("Kurzticket", 0.05, new TimeOnly(14, 0), 60)); //3.00
        }

        double ergebnis = bestellung.BerechneBestellung();
        Assert.Equal(erwartet, ergebnis, GENAUIGKEIT);
    }

}
