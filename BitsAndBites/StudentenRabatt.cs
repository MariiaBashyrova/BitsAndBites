using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsAndBites;

public class StudentenRabatt : iRabattStrategie
{
    const double STUDENTEN_RABATT = 0.10; // 10% Rabatt
    public string Name => "Studenten Rabatt";
    public double WendeAn(double betrag)
    {
        return Math.Max(Math.Round(betrag * (1 - STUDENTEN_RABATT), 2), 0); // 10% Rabatt
    }
}
