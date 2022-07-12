using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();

            //eğer bu değerlerden(Logger) herhangi birini ayarlamazsak program hata verecektir çünkü nesnenin özelliği belli değil
            customerManager.Logger = new DatabaseLogger();//propertyi databaseloggera eşitledik
            customerManager.Add();

            customerManager.Logger = new FileLogger();//propertyi fileloggera eşitledik
            customerManager.Add();

            customerManager.Logger = new SmsLogger();//propertyi smsloggera eşitledik
            customerManager.Add();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        public ILogger Logger { get; set; }//property tanımladık, property injection deniyor, bu işlem normalde constructor la yapılıyor
        //propertyler sınıflar arası veri taşımamızı sağlar
        //önce bir veriyi set ederiz, sonra başka bir sınıftan get dediğimizde veri bize gelecektir
        //yani biz başka bir sınıftan customerManager.Logger bu veriye ulaşabiliriz, bu bir nesnenin özelliği oluyor
        public void Add()
        {
            Logger.Log();//bunu interface bağladık
            Console.WriteLine("Customer Added!");
        }
    }

    class DatabaseLogger:ILogger
        //başlangıçta sadece bu vardı
    {
        public void Log()
        {
            Console.WriteLine("Logged to database!");
        }
    }

    class FileLogger : ILogger
        //bu sonradan eklendi
    {
        public void Log()
        {
            Console.WriteLine("Logged to file!");
        }
    }

    class SmsLogger : ILogger
        //aradan zaman geçtikten sonra bu eklendi ve ekleme işlemi bizim programımızı bozmadı
    {
        public void Log()
        {
            Console.WriteLine("Logged to sms!");
        }
    }

    interface ILogger
    {
        void Log();
    }

    //burada interface tercih etmemizin nedeni databasede loglama ayrı kullanılır fileda ayrı smste ayrı
    //herkesin ayrı ayrı implementasyon yapması gerektiği için interface kullandık

    //örneğin databasele filea yazarken kodlar aynı olsaydı sadece smste değişik olsaydı ozaman virtual yapardık

    //bir tane operasyonumu herkes değiştirecek diğeri her yerde aynı olsaydı abstract method yazardım


    //class Logger
    //    //bir sınıf bu şekilde çıplak yani interface yada inheritance kullanılmamışsa korkmalıyız
    //    //sonradan bir ekleme ya da değişiklik gerektiğinde büyük zorluklar karşımıza çıkacaktır
    //    //bir iş yapan sınıfın muhakkak base i olmalı
    //{
    //    public void Log()
    //    {
    //        Console.WriteLine("Logged to database!");
    //    }
    //}
}
