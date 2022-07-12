using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;  // ArrayList sınıfnı kullanmak için
                           // System.Collection isimalanını eklemeliyiz..

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayLists();//tip güvenli olarak çalışamadık
            Lists();//tip güvenli çalışabildik
            Dictionaries();

            


            Console.ReadLine();
        }

        private static void ArrayLists()
        {
            //string[] Names = new string[2] { "murat", "ayse" };
            //Names[2] = "mustafa";//yazıp programı çalıştırdığımızda çökecektir,derleme hatası vermez ancak indexin sınırlarını aştık
            //Names = new string[3]; Names[2] = "mustafa";//yazmaya çalışırsakda bu sefer önceki oluşturduğumuz elemanlar yok olacaktır
            //yani arraylerde sonradan ekleme yapmak mümkün değil onun yerine collection yani ArrayList kullanırız

            ArrayList Names = new ArrayList();//arraylistler arraylerdeki index sınırı sorununu ortadan kaldırır

            Names.Add("murat");
            Names.Add("ayse");
            Names.Add("mustafa");
            Names.Add("fatma");
            //gibi istediğim kadar ekleme yapabilirim


            foreach (var item in Names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("*************");

            Names.Add("kemal");//sonradan eklendi
            Console.WriteLine(Names[4]);//hiç sorun çıkarmadan çalışacaktır
            Console.WriteLine("*************"); 
            Names.Add(123);//ancaaaaak!!! biz buna numarada verebildik bu güvenli değil

            //arraylistler ekleme yaparken veri tipi olarak object ister, tüm veri tiplerinin base i objecttir
            //yani isimlerden oluşan arrayliste 6.eleman olarak bir int değer verilebilir 
        }

        private static void Lists()
        {
            //tip güvenli çalışmak için generic collections tan yararlanırız
            List<string> Names = new List<string>();//tip güvenli collections tanımlama,sadece string alır
            Names.Add("murat");
            Names.Add("ayse");
            Names.Add("mustafa");
            Names.Add("fatma");
            //gibi istediğim kadar ekleme yapabilirim


            foreach (var item in Names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("*************");

            Names.Add("kemal");//sonradan eklendi
            Console.WriteLine(Names[4]);//hiç sorun çıkarmadan çalışacaktır
            Console.WriteLine("*************");
            //Names.Add(123);//hata verir çünkü bizden string istiyor artık daha güvenli

            List<Customer> customers = new List<Customer>();
            //nesnelerde base olarak object e bağlı olduğu için bu şekilde listelenebilir
            //veritabanlarında tabloların karşılığını nesne halinde tutarsınız
            customers.Add(new Customer { Id = 1, FirstName = "mustafa" });
            customers.Add(new Customer { Id = 2, FirstName = "sinan" });
            customers.Add(new Customer { Id = 3, FirstName = "murat" });
            customers.Add(new Customer { Id = 4, FirstName = "ayse" });
            customers.Add(new Customer { Id = 5, FirstName = "fatma" });
            customers.Add(new Customer { Id = 6, FirstName = "kemal" });

            customers.AddRange(new Customer[2] { new Customer(),new Customer()});//şeklinde bir seferde array aktarılabilir
            //genellikle elimizde bir liste varken başka yerden gelen bir listeyi elimizdeki listenin altına eklemek için kullanırız
            

            foreach (var item in customers)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.WriteLine("*************");

            var count = customers.Count;//customers listesinin kaç elemanı var
            Console.WriteLine(count);

            //__________________________________________
            //customer nesnesine ait bir özellik içinde arama yapılmak isteniyorsa kod
            //değer ve referans tipin farkı
            //https://docs.microsoft.com/tr-tr/dotnet/api/system.collections.generic.list-1?view=netcore-3.1
            //adresinde çok daha detaylı bilgiler mevcut
            
            List<string> firstNames = new List<string>();
            foreach (var item in customers)
            {
                firstNames.Add(item.FirstName);
            }
            string find = "sinan";
            Console.WriteLine("Find "+find+": " + firstNames.Contains(find));
            firstNames.Clear();
            Console.WriteLine("*************");

            customers.Clear();//listedeki tüm elemanları temizler
        }

        private static void Dictionaries()
        {
            //burada da sözlük mantığı var buda bir liste ama hiç işime yaramıcağını düşünüyorum, yinede notlarımda dursun
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("book", "kitap");
            dictionary.Add("computer", "bilgisayar");

            Console.WriteLine(dictionary["book"]);
        }
    }

    class Customer//nesne
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
