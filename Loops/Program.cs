using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            ForLoop();//method çağırdık
            WhileLoop();//method çağırdık
            DoWhileLoop();//method çağırdık
            ForeachLoop();//method çağırdık         
            Console.WriteLine(IsPrimeNumber(13));//parametreli method çağırdık gönderilen sayı asal mı ?
            Console.WriteLine("---------------------");
            PrimeNumbers(2);//parametreli method çağırdık gönderilen sayıya kadar asal sayıları yaz

            Console.ReadLine();
        }

        private static void PrimeNumbers(int maxNumber)
        {
            bool findPrime = false;
            int min = 2;
            Console.Write("Prime numbers to {0}: ",maxNumber);
            if (maxNumber<min)
            {
                Console.WriteLine("Nothing");
            }
            else
            {
                for (int i = min; i <= maxNumber; i++)
                {
                    findPrime = false;
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            findPrime = true;
                        }
                    }
                    if (!findPrime)
                    {
                        Console.Write("|" + i);
                    }
                }
                Console.WriteLine("|");
            }
            
        }

        private static bool IsPrimeNumber(int number)
        {
            Console.Write("Divisors of a {0}: ", number);
            bool prime = true;
            for (int i = 2; i < number; i++)
            {
                if (number%i==0)
                {
                    prime = false;
                    Console.Write("|" + i);
                }
            }
            Console.WriteLine("|");
            Console.Write("-> {0} is a Prime: ", number);
            
            return prime;
        }
        

        private static void ForLoop()
        {
            //i=10 olana kadar yaz, '<=' yapmadığım için 10 değeri hariç olacaktır ama 0'dan başladığı için kod 10 kere çalışacaktır 
            // for için artış zorunludur yani i++ eklenmelidir,
            Console.Write("ForLoop: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("|"+i);
            }
            Console.WriteLine("|");
            Console.WriteLine("---------------------");
        }

        private static void WhileLoop()
        {
            //i=10 olana kadar yaz, '<=' yapmadığım için 10 değeri hariç olacaktır ama 0'dan başladığı için kod 10 kere çalışacaktır 
            // while için artış zorunlu değildir kodun içine eklenebilir, artış eklenmezse sonsuz döngüye girer yani while kullanımı tehlikelidir
            Console.Write("WhileLoop: ");
            int i = 0;
            while (i<10)
            {
                Console.Write("|" + i);
                i++;
            }
            Console.WriteLine("|");
            Console.WriteLine("---------------------");
        }

        private static void DoWhileLoop()
        {
            //çalışması while ile aynıdır ancak while koşulu sağlanmıyorsa 1 kez döngüye girer ve çıkar. işime yarar mı bilemiyorum
            //i<10 yerine i>10 yapsaydım çıkışa 0 yazıp i'yi 1 yapıp çıkardı
            //i=10 olana kadar yaz, '<=' yapmadığım için 10 değeri hariç olacaktır ama 0'dan başladığı için kod 10 kere çalışacaktır 
            Console.Write("DoWhileLoop: ");
            int i = 0;
            do
            {
                Console.Write("|" + i);
                i++;
            } while (i<10);
            Console.WriteLine("|");
            Console.WriteLine("---------------------");

        }

        private static void ForeachLoop()
        {
            //en sık kullanılan döngülerdendir. dizileri gezmek için çok fazla kullanılır
            //döngü çalıştığında her bir elemanı i değişkenine aktarıp konsola yazar
            //in numbers, numbers dizisindeki elemanların sayısı kadar döngüyü çalıştır anlamına gelir
            Console.Write("ForeachLoop: ");
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var i in numbers)
            {
                Console.Write("|" + i);
            }
            Console.WriteLine("|");
            Console.WriteLine("---------------------");

        }
    }
}
