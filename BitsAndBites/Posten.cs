namespace BitsAndBites;

public abstract class Posten
{
    protected abstract string Name { get; }
    protected abstract double Preis { get; } //Grundpreis des Postens in Euro. Bei Tickets ist dies der Minutenpreis.
    public abstract double BerechnePreis();

    public abstract string GetDetails();

}
