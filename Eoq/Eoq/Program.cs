using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eoq
{
    class MyClass
    {
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var open = new ProcessStartInfo("paint.exe");
            
            Process.Start(open);
        }
    }
}
