using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace baseClass
{
    public interface InterBase
    {
         string Name { get; set; }

         string ConsoleStr(string str = "");
      
    }
}
