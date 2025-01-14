using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodExamPractice
{
    public static class ExtendCalculator
    {
        public static int sub(this Calculator C, int x, int y)
        {

        return x - y;  
        
        }
        public static int showIdentifierValue(this Calculator C)
        {
            return C.identifier;
        }
    }
}
