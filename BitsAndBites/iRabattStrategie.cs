using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsAndBites;

public interface iRabattStrategie
{
    string Name { get; }
    double WendeAn(double betrag);
}
