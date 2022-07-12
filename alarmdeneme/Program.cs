using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alarmdeneme
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int fis;
            int basinc;
            string alarm="";
            Console.WriteLine("fiş durumu: ");
            fis = int.Parse(Console.ReadLine());
            Console.WriteLine("basınç durumu: ");
            basinc = int.Parse(Console.ReadLine());
            
            if (fis==1&&basinc>45)
            {
                alarm = "hava var";
            }
            else if (fis==0||basinc<=45)
            {
                alarm = "hava yok";
            }

            Console.WriteLine(alarm);

            Console.ReadLine();
            
        }
    }
}
