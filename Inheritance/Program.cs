using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance //inheritance kalıtım yada miras
    //interfaceler inheritance gibi çalışırlar ve yeni nesil dillerde inheritance gibi kullanılırlar
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[3]
            {
                new Customer{FirstName="mustafa",LastName="turan" },
                new Student{FirstName="fatma",LastName="kilic" },
                new Person{FirstName="kemal",LastName="kilic" }
                //burada dikkat edilmesi gereken interfacede nesne oluşturulamazken,
                //inheritance bir sınıf olduğu için tek başına bir anlam ifade eder ve nesnesi oluşturulabilir
                //aynı interface gibi kullandık
            };
            foreach (var item in people)
            {
                Console.Write(item.FirstName+" ");
                Console.WriteLine(item.LastName);
            }


            Console.ReadLine();
            
        }
    }

    class Person
        //interface den farkı şudur
        //bir sınıfa birden fazla interface implement edilebilirken 
        //yalnızca bir tane inheritanse yapılablir çünkü bir kişinin bir tane babası olabilir diye düşünülebilir
        //ancak interfacedeki gibi tüm özelliklerin yazılma zorunluluğu yoktur
        //hatta ebeveyne ait bir özellik eklenirse hata verecektir
        //inherit edildiğinde devamına interface implementasyonu yapılabilir
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    interface IPerson
    {

    }

    class Customer:Person
        //bu tanımlama customer ın ebeveyni yani babası person dur anlamına gelir
        //customer aslında persondan dünyaya gelmiş bir nesnedir
        //bir customer nesnesi oluşturduğumda bu person özelliklerini taşır
        //customer a ait bir özellik varsa burada tanımlanabilir
        //sonuçta bir çocuk yalnızca ebeveyninin özelliklerini taşır diye bir kural yoktur
        //kendine ait özellikleride olabilir
    {
        public string City { get; set; }
    }
    

    class Student : Person, IPerson//görüldüğü gibi hiç hata vermiyor
        //burada dikkat edilmesi gereken kısım, inheritance önce yazılır sonra interfaceler eklenir
        //bu gibi durumlarda işlevsellik anlamında interfaceler daha esnektir
        //iheritance ihtiyaç yoksa interface üzerinden proje oluşturulmalıdır
        //peki inheritance ne zaman kullanacağız?
        //abstract sınıflarda inheritance önemli bir yer teşkil eder
        
    {
        public string Departmant { get; set; }
    }
}
