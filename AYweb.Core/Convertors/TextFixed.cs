using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Core.Convertors;

public class TextFixed
{
    public static string FixFormat(string text)
    {
        return text.Trim().ToLower();
    }
}
