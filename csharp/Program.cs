using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication
{
    public class Program
    {

        [DllImport("libhellorust")]
        public static extern bool in_portland();

        public static void Main(string[] args)
        { 
            Console.WriteLine(in_portland() ? "Hello Portland!" : "Hello World!");
        }
    }
}
