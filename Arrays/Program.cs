using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] myFamiliy = new string[4];// bu tek boyutlu bir dizidir
            myFamiliy[0] = "murat";
            myFamiliy[1] = "ayse";
            myFamiliy[2] = "mustafa";
            myFamiliy[3] = "fatma";

            //kodu oluşturuken 2 kere tab tuşuna seri basarsan otomatik oluşturur
            //foreach dizileri gezmek için kullanılır bi çeşit döngüdür
            foreach (var item in myFamiliy)
            {
                Console.WriteLine(item);
            }

            int[,] numbers =// bu 2 boyutlu dizidir koordinat sistemiyle çalışır dizileri gruplar halinde tutmaya yarar, işime yarar mı bilemiyorum
            {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            };


            //for, foreach gibi çalışır detayları tek tek verirsiniz daha hassas çalışma sağlar, sık kullanılan bir döngüdür
            //.GetUpperBound - (0) satırsayısını döndürür, (1) sütun sayısını döndürür
            // for döngüsüne ilk girildiğinde koşul sağlandığı sürece döngü tekrarlanır koşul sağlanmadığında çıkar
            // küçüktür işaretinin yanına eşittir konulmazsa son koordinatları okumaz yani çıkış 1,2,4,5 olur
            for (int i = 0; i <= numbers.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= numbers.GetUpperBound(1); j++)
                {
                    Console.WriteLine(numbers[i, j]);//tüm koordinatların tüm elemanlarını dolaşarak konsola yazdıracak döngü
                }
            }

                

            Console.ReadLine();
        }
    }
}
