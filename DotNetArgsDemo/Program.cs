using DotNetArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetArgsDemo
{
    class Program
    {
        private static void PrintRes(string[] res)
        {
            Console.WriteLine("Args[{0}]: {{ {1} }}", res.Length, string.Join(", ", res));
        }
        private static void DefaultParserDemo()
        {
            var p = new DefaultParser();
            
            PrintRes(p.Parse("   123"));
            PrintRes(p.Parse("123"));
            PrintRes(p.Parse("123 456"));
            PrintRes(p.Parse("\"123\""));
            PrintRes(p.Parse("\"123\" \"456\""));
            PrintRes(p.Parse("\"123\" \"456\" \"789"));
        }

        static void Main(string[] args)
        {
            DefaultParserDemo();

            Console.ReadLine();
        }
    }
}
