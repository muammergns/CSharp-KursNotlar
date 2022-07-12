using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesAndVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            bool boolean = true; //false - true
            byte byyte = 255;//0 - 255
            short shoort = 32767;//-32768 - 32767
            int integer = 2147483647;//-2147483648 - 2147483647
            long loong = 9223372036854775807;//-9223372036854775808 - 9223372036854775807
            double doouble = 10.4;
            decimal deecimal = 10.5m;
           
            Console.WriteLine("bool: {0}",boolean);
            Console.WriteLine("byte: {0}", byyte);
            Console.WriteLine("short: {0}", shoort);
            Console.WriteLine("int: {0}", integer);
            Console.WriteLine("long: {0}", loong);
            Console.WriteLine("double: {0}", doouble);
            Console.WriteLine("decimal: {0}", deecimal);
            Console.WriteLine("--------------------------------");
            
            Console.ReadLine();
        }
    }
}
