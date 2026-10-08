using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsAndBites;

public class Gutschein: Posten
{
    private string name;
    private double preis;
    public Gutschein(string name, double preis)
    {
        Name = name;
        Preis = preis;
    }
    protected override string Name { get => name; set => name = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Name darf nicht leer sein.", nameof(value)) : value; }
    protected override double Preis
    {
        get => preis; set => preis = value >= 0 ? throw new ArgumentOutOfRangeException(nameof(value),
            $"Preis {value} ist ungültig.") : value;
    }
    public override double BerechnePreis()
    {
        return Preis;
        //Liefert den Grundpreis des Gutscheins.
    }
    public override string GetDetails()
    {
        return $"Gutschein: {Name}";
    }
}
