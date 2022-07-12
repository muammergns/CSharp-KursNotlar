using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(35);
            //(); parantez classın constructorının parametresiz bir şekilde çalışacağı anlamına gelir
            //class constructor parametre istiyorsa parantez parametresiz bırakılırsa program hata verecektir
            customerManager.Add();

            Product product = new Product(1,"pc");
            // bu yalnızca parametre yollamak için nesne özelliği değil
            //nesne özelliği oluşturulurken bu parametrelerle işlem yapılabilir

            EmployeManager employeManager = new EmployeManager(new DatabaseLogger());
            //employeeManager için parametre olarak DatabaseLogger() verdik
            //parametre vermezsek derleme bile yapmayacaktır
            //bunu property yani nesnenin bir özelliği olarak isteseydik
            //nesnenin özelliği verilmedende oluşturulabildiği için hata vermeyecekti ancak program talep ettiğinde hata verecekti
            //buda istenmeyen bir durum

            Teacher.Name = "Base send done";//static property

            PersonManager personManager = new PersonManager(Teacher.Name);
            personManager.Message();

            Utilities.Validate(Teacher.Name);

            Manager.DoSomething();//manager nesne static method
            Manager manager = new Manager();
            manager.DoSomething2();//manager nesne method

            SingletonExample singletonExample = SingletonExample.GetSingleton();
            //tek nesnemizi newleyerek değilde sınıfın kendisinden talep ediyoruz

            //SingletonExample singletonExample = new SingletonExample(); //yazmaya çalışırsak hata verecektir

            singletonExample.Name = "Singleton crated done";

            Utilities.Validate(singletonExample.Name);


            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private int _count;
        //private bir field '_' ile başlar, bu bir isimlendirme standartıdır
        //eğer method halindeyse '_' kullanılmaz

        //constructors oluşturmak için ctor yazılır tab tuşuna 2 kere basılır
        public CustomerManager(int count)//constructor, bu sınıftan bir obje oluşturulduğunda çağırılacak ilk method
            //bir sınıfın ihtiyaç duyduğu farklı parametreler varsa ve bu parametreler kullanıma göre değişkenlik gösteriyorsa 
            //o parametreyi constructors ile set edersiniz
            //onuda new ledikten sonra parantez içinde gönderirsiniz
        {
            _count = count;
        }

        public CustomerManager()
            //constructors overload edilebilir
            //örneğin burada parametresiz newlenirse bu method çalışacak
            //parametre eklenirse yukarıdaki
        {
            _count = 15;
        }

        public void List()
        {
            Console.WriteLine("Listed!!"+_count);
            
        }

        public void Add()
        {
            Console.WriteLine("Added!"+_count);
        }
    }

    class Product
    {
        int _Id;
        string _Name;
        public Product(int id,string name)
        {
            _Id = id;
            _Name = name;
        }

        public Product()//ctor yazıp constructor oluşturduk
        {

        }
        public int Id { get; set; }//prop yazıp property oluşturduk yani nesneni bir özelliği
        public string Name { get; set; }
    }

    interface ILogger
    {
        void Log();
    }

    class DatabaseLogger : ILogger
    {
        void ILogger.Log()
        {
            Console.WriteLine("Logged to database");
        }
    }

    class FileLogger : ILogger
    {
        void ILogger.Log()
        {
            Console.WriteLine("Logged to file");
        }
    }

    class EmployeManager
    {
        ILogger _logger;
        public EmployeManager(ILogger logger)
            //bu işlemi property ile yapmakda mümkün ancak hatayı programın çalışması sırasında alırdık
            //constructor ile yapıldığında derleme sırasında hata vereceğinden programcının unutma şansı yok
        {
            _logger = logger;
        }
        public void Add()
        {

        }

    }

    //____________________________________________________
    //base sınıfa parametre yollamak
    //bunu pek çözemedim ama önemli görünüyor
    //yani inheritanse nesne oluşturduk ama base classımız parametre istiyor
    //bu şekilde alt class üzerinden base classa parametre gönderme tekniği budur
    //personmanager bir nesne oluşturup çalıştıralım

    class BaseClass
    {
        string _entity;
        public BaseClass(string entity)
        {
            _entity = entity;
        }
        public void Message()
        {
            Console.WriteLine(_entity+" message");
        }
    }

    class PersonManager : BaseClass
    {
        public PersonManager(string entity):base(entity)
            //bu constructor aslında veriyi base göndermek için aracılık ediyor
            //veriye asıl ihtiyacı olan yer base
        {

        }
    }


    //__________________________________________________
    //static nesneler
    //şimdiye kadar bir class ı kullanmak zorunda olduğumuzda onu her zaman new ledik
    //ama static nesnelerde hiçbir zaman o nesnenin instanceını oluşturamazsınız yani newleyemezsiniz
    //static nesneler sitem tarafından otomatik 1 defa newleniyor ve o nesne herkes tarafından 1 tane olarak kullanılıyor
    //static nesnenin tüm elemanlarıda static olmak zorundadır
    //kısaca static nesneler ortak nesnelerdir ve herkes tarafından kullanılabilir

    //genellikle static nesnelerden uzak durmaya çalışırız ancak duramadığımız zamanlarda oluyor
    
    static class Teacher
    {
        public static int Number { get; set; }
        public static string Name { get; set; }
    }

    static class Utilities
    {
        static Utilities()//static constructor, parametre alamaz
        {
            Console.WriteLine("Utilities is done!");
        }
        public static void Validate(string Message)
        {
            Console.WriteLine("Validation is done!"+Message);
        }
    }

    class Manager
    {
        public static void DoSomething()
        {
            Console.WriteLine("DoSomething is done!");
            double x = 150;
            double sn = 1 / x;
            double dn = sn*1000;
            int an = Convert.ToInt16(dn);
            
            Console.WriteLine("deneme: " + an);
        }

        public void DoSomething2()
        {
            Console.WriteLine("DoSomething2 is done!");
        }
    }

    //_____________________________________________
    //singleton yapısı
    //tek bir objeye sahip sınıf anlamına gelir
    
    class SingletonExample
    {
        private SingletonExample()
        {
            //bunu yazmanın normalde hiçbir anlamı yok ancak
            //singleton yapısında sınıfı başka sınıflardan newlenemez hale getirmek için gerekli
        }
        static SingletonExample singletonExample;
        //dışardan newlenemez yaptık ama bir objeye ihtiyacımız var onu direk buradan oluşturuyoruz
        //ve oluşturduğumuz nesnenin instanceını GetSingleton() methoduyla çağıracağız
        public static SingletonExample GetSingleton()
        {
            if (singletonExample==null)
            {
                singletonExample = new SingletonExample();
            }
            return singletonExample;
        }

        public string Name { get; set; }
        //ve artık propertys ile oluşturduğumuz tek nesnenin özelliklerini kullanabiliriz
    }
}
