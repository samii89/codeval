using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oct17T1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBuffer mb = new MyBuffer();
            String str = mb.StoringToBuffer();
            Scanner myScanner = new Scanner(str);
            myScanner.Strater();
            Console.ReadLine();
        }
    }
}
