using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfaceIntro();//diğer denemeleri yapabilmek için kodları method içine aldık
            InterfaceNext();//diğer denemeleri yapabilmek için kodları method içine aldık
            InterfaceNext2(); ;//diğer denemeleri yapabilmek için kodları method içine aldık

            //S — Single - responsibility principle
                //Bir sınıf(nesne) yalnızca bir amaç uğruna değiştirilebilir, o da o sınıfa yüklenen sorumluluktur, 
                //yani bir sınıfın(fonksiyona da indirgenebilir) yapması gereken yalnızca bir işi olması gerekir.


            //O — Open - closed principle
                //Bir sınıf ya da fonksiyon halihazırda var olan özellikleri korumalı ve değişikliğe izin vermemelidir. 
                //Yani davranışını değiştirmiyor olmalı ve yeni özellikler kazanabiliyor olmalıdır.
            

            //L — Liskov substitution principle
                //Kodlarımızda herhangi bir değişiklik yapmaya gerek duymadan alt sınıfları, türedikleri(üst) sınıfların yerine kullanabilmeliyiz.
            

            //I — Interface segregation principle
                //Sorumlulukların hepsini tek bir arayüze toplamak yerine daha özelleştirilmiş birden fazla arayüz oluşturmalıyız.
            

            //D — Dependency Inversion Principle
                //Sınıflar arası bağımlılıklar olabildiğince az olmalıdır özellikle üst seviye sınıflar alt seviye sınıflara bağımlı olmamalıdır.


            Console.ReadLine();
        }

        private static void InterfaceIntro()
        {
            PersonManager personManager = new PersonManager();//PersonManager a ait bir nesne oluşturduk

            Customer customer = new Customer//customer a ait bir nesne oluşturduk
            {
                Id = 0,
                FirstName = "mustafa",
                LastName = "turan",
                City = "izmir"
            };

            Student student = new Student // student a ait bir nesne oluşturduk
            {
                Id = 1,
                FirstName = "fatma",
                LastName = "kilic",
                Departmant = "iktisat"
            };

            //interface nesnesi eklemenin diğer bir yolu
            //IPerson person = new IPerson(); yazamayız çünkü interfaceler soyut nesnelerdir tekbaşına bir anlam ifade etmezler
            IPersonDal person = new Customer
            {
                Id = 0,
                FirstName = "murat",
                LastName = "turan",
                City = "izmir"
            };

            IPersonDal person2 = new Student
            {
                Id = 1,
                FirstName = "kemal",
                LastName = "kilic",
                Departmant = "iktisat"
            };

            IPersonDal person3 = new Worker
            {
                Id = 2,
                FirstName = "ayse",
                LastName = "turan",
                Departmant = "home"
            };

            //personManager.Add() methodu çağırıldığında parametre olarak bizden IPerson istemektedir
            //customer ve student bizim için IPerson olduğundan dolayı parametre olarak ikisinide verebiliriz
            //sadece customer istedeydi student gönderemezdik
            //interfaceler sayesinde 2 ayrı grup için tutulacak benzer verileri tek bir noktadan kontrol edebiliyoruz
            personManager.Add(customer);
            personManager.Add(student);
        }

        private static void InterfaceNext()
        {
            //başka bir dosyadan oluşturduğum sınıfı çağırdım
            //kopyala yapıştır yaparak kolayca yazdım ve defalarca çağırabilirim
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new SqlServer());//benden bir ICustomerDal nesnesi istiyor
            customerManager.Add(new OracleServer());//benden bir ICustomerDal nesnesi istiyor
            customerManager.Update(new SqlServer());//benden bir ICustomerDal nesnesi istiyor
            customerManager.Update(new OracleServer());//benden bir ICustomerDal nesnesi istiyor
            customerManager.Delete(new SqlServer());//benden bir ICustomerDal nesnesi istiyor
            customerManager.Delete(new OracleServer());//benden bir ICustomerDal nesnesi istiyor

        }

        private static void InterfaceNext2()
        {
            //bu defa nesneleri array halinde oluşturdum, artık işlemleri array ile yapabilirim
            //InterfaceNext() methodumdaki işlemleri foreach ile çok daha basit bi şekilde hallettim
            // bu nezaman işime yarar diye düşünürsek 
            //2 ayrı gruptan bazıları tüm sunuculara veri atmak isterse tek tek uğraşmak yerine bu şekilde kullanılabilir
            ICustomerDal[] customerDals = new ICustomerDal[3] { new SqlServer(), new OracleServer(), new MySqlServer() };
            foreach (var item in customerDals)
            {
                item.Add();
                item.Update();
                item.Delete();
            }
        }
    }

    //isimlendirme standartı büyük I ile başlamalıdır
    // bir sınıf birden fazla interface implement edebilir
    // SOLID : single responsibility
    interface IInterface
    {

    }

    //interfacein amacı bir temel nesne oluşturup bütün nesneleri ondan implemete etmektir
    //buna soyut nesne denir ve tek başına bir anlam ifade etmez, classlar ise somut nesnedir
    interface IPersonDal//sona eklenen Dal : Data Access Layer veritabanı data işlemleri yapan sınıflarda isimlendirme tekniğidir
    {
        //burada public olamaz, yazılırken yalnızca methodun imzası olabilir
        //void veya dönüş değeri
        int Id { get; set; }//örneğin hem customer hemde student ait bir id olabilir
        string FirstName { get; set; }//hem customer hemde student ait bir isim
        string LastName { get; set; }//hem customer hemde student ait bir soyisim
    }

    //örneğin benim 2 tane nesnem var 
    //bunlara gelip derimki sende bir IPersonsın sende bir IPersonsın
    //bu şu anlama geliyor biz IPerson da tanımlanmış herşeyi hem customer da hem student da görebiliriz
    class Customer : IPersonDal//burada IPerson altı çizili görünecektir, bu elemanları eklemeniz gerektiğini vurgular
    {
        //public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //şeklinde ekleme yapılmalıdır ama bu çirkin bi görüntü aşağıdaki gibi aynısının public halleri eklenmelidir
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string LastName { get; set; }
    }

    class Student : IPersonDal
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Departmant { get; set; }
        public string LastName { get; set; }

    }

    //sonradan bir sınıf daha eklemek istediğimde yazılımı hiç bozmadan kolaylıkla ekleme yapmama olanak sağlıyor
    class Worker : IPersonDal
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Departmant { get; set; }
        public string LastName { get; set; }

    }


    class PersonManager
    {
        //bir sınıf oluşturduk,sınıfın içinde ekleme işlemi yapan bir method var, parametre olarak IPerson sınıfına ait bir nesne istiyor
        //buradaki önemli nokta parametre olarak interface istiyorsak sınıfa ait nesnenin kendine ait özelliğini çağıramayız
        //örneğin student a ait departmant değişkenini çağıramayız, denediğimizde hata verecektir
        //Console.WriteLine(person.Departmant); yazamayız çünkü IPerson için böyle bir özellik yok
        public void Add(IPersonDal person)
        {
            Console.WriteLine(person.FirstName);//konsola nesnenin firstnameini yazdırıyor
        }

        //Console.WriteLine(person.Departmant); yazabilmek için ayrıca şöyle bir method oluşturmak gerekir
        //buda saçma olur çünkü student hiçbir zaman IPerson olarak gelemicektir ayrı bir method olarak çağırılabilir
        //method overloading
        //public void Add(Student student)
        //{
        //    Console.WriteLine(student.Departmant);
        //}
    }

}
