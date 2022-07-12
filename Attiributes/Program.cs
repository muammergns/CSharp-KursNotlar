using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attiributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.Id = 1;
            customer.LastName = "turan";
            customer.Age = 27;
            //burada first name eklemedik
            //bu yüzden çıktı olarak boş gelecektir
            //program hata vermez ancak biz o bilginin girilmesinin zorunlu olmasını sağlayabiliriz

            CustomerDal customerDal = new CustomerDal();
            customerDal.AddNew(customer);
        }
    }

    [ToTable("Customers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredPropery]//firstname için değer girilmesini zorunlu hale getirebiliriz
        public string FirstName { get; set; }
        [RequiredPropery]
        public string LastName { get; set; }
        [RequiredPropery]
        public int Age { get; set; }
    }

    class CustomerDal
    {
        [Obsolete("Add() kullanmanı tavsiye etmem, yerine AddNew kullan")]
        //bunu yazdığımızda bu method kullanılabilir ancak artık kullanılmıyor uyarısı çıkar
        //string ile yazdığımız uyarıyıda gösterir
        public void Add(Customer customer)
        {
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer.LastName);
            Console.WriteLine(customer.Age);

            Console.ReadLine();
        }

        public void AddNew(Customer customer)
        {
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer.LastName);
            Console.WriteLine(customer.Age);

            Console.ReadLine();
        }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class RequiredProperyAttribute : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Class)]
    class ToTableAttribute : Attribute
    {
        private string _tableName;

        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }
}
