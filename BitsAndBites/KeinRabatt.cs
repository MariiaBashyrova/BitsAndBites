using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsAndBites;

public class KeinRabatt : iRabattStrategie
{
    public string Name => "Kein Rabatt";
    public double WendeAn(double betrag)
    {
        return betrag;
    }
}
