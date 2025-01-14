using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodExample
{
    public static class ExtendCalculator
    {
        public static int Sub(this Calculator C, int x, int y)
        {
            return x - y;
        }
        
        public static int Identifier1(this Calculator C)
        {

            return C.Identifier;
        }
    
    }
}
