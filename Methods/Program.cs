using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods 
{
    // method lar isimlendirme büyük harfle başlar her kelimenin başı büyük harf olur
    // tekrarlayan işlemleri defalarca yazmak yerine tek bir method yazıp onu çağırmak sonradan değişiklik gerektiğinde rahatlık sağlar
    // void git işlem yap demektir herhangi bir sonuç döndürmez
    //ctrl+k ctrl+d ile satırlar düzeltilir
    class Program
    {
        
        
        static void Main(string[] args)
        {
           
            Addx();// method çağırma işlemi
            var result = Add2(20, 30);//parametreli method çağırma işlemi, sonuç int dönecek
            Console.WriteLine(result);

            int numberx = 10;
            int numbery;
            result = Add3(ref numberx, out numbery);
            //ref keyword ile methoda bağlı olmayan bir değişkeni değiştirmek mümkündür. number1 değeri method içinde set edilen değer olarak kalacaktır
            //out keyword aynı ref gibi çalışır, ancak değişkene değer set etmek zorunlu değildir
            Console.WriteLine(result);
            Console.WriteLine(numberx);


            Console.WriteLine(Multiply(2, 4));
            Console.WriteLine(Multiply(2, 4, 5));
            //method overloading ile aynı isimli 2 methodu farklı parametreler ile çağırdık

            Console.WriteLine(Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));//method params değeri istediği için istediğiniz kadar parametre verebilirsiniz



            Console.ReadLine(); // konsolu gözlemleyebilmek için
        }

        static void Addx()
        {
            Console.WriteLine("Added!");
        }

        static int Add2(int number1, int number2=20)
            //number2 default parametreli oldu, number2 parametre olarak gönderilmezse default değeri 20 olarak program çalışır
            //normalde parametreli methodlarda istenen parametreler verilmezse program hata verecektir
            //parametreler sona alınmalıdır, yani number1 e default verip number2 ye default vermeyeceksen önce number2 yazıp sonra number1 in default değerini yazmalısın
        {
            var result = number1 + number2;
            return result;
        }

        static int Add3(ref int number1, out int number2)
            //method ref keyword ile parametre istiyorsa çağırma sırasında parametrenin başına ref eklenmelidir
            //method out keyword ile parametre istiyorsa method içinde değişkene değer set edilmelidir
            //pek işe yararmı bilmiyorum ama yinede bilgi bilgidir
        {
            number2 = 150;
            number1 = 30;
            return number1 + number2;
            
        }

        static int Multiply (int number1, int number2)
        {
            return number1 * number2;
        }
        static int Multiply (int number1, int number2, int number3)
            //method overloading
            // aynı methodu 2 defa oluşturabilirsiniz farklı parametreler için farklı işlem yapması gerektiğinde işe yarar
            // method çağırılırken 2 parametre verirseniz üstteki method çalışır 3 parametrede bu method çalışır
        {
            return number1 * number2 * number3;
        }

        static int Add(int number , params int[] numbers)
            // params ile dizideki tüm elemanları parametre olarak alır, 1 elmanlıda olabilir toplamın sonucu max int değeri olabilir
            // params methodun son parametresi olmalıdır
        {
            var result = numbers.Sum()+number;//.Sum() toplama işlemi fonksiyonu, dizideki tüm elemanları toplar sonucu kaydeder 
            return result;
        }

    }

   
}
