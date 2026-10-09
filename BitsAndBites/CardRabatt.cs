using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsAndBites;

public class CardRabatt : iRabattStrategie
{
    const double CARD_RABATT = 0.05; // 5% Rabatt

    public string Name => "Card Rabatt";
    public double WendeAn(double betrag)
    {
        return Math.Max(Math.Round(betrag * (1- CARD_RABATT), 2), 0); // 5% Rabatt
    }
}
