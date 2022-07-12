using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    //yapmak istediğimiz işlemleri gruplara ayırmak işlemler için rahatlıkla o gruba ulaşmak için class lar kullanılır

    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();//bir müşteri nesnesi oluştururldu
            customerManager.Add();//bir müşteri nesnesine ait bir method çalıştırıldı

            ProductManager productManager = new ProductManager();//bir ürün nesnesi oluşturuldu
            productManager.Update();//bir ürün nesnesine ait bir method çalıştırıldı

            FuritsManager furitsManager = new FuritsManager();//başka bir sınıf dosyasından meyve nesnesi oluşturuldu
            furitsManager.Update();//başka bir sınıf dosyasından method çağırıldı
            //bunlar sınıflar için en temel kullanımdır!!!!!!!!!!!!!


            //bu şekilde bir nesne için bilgiler girilebilir
            // buradaki amaç dizilerle aynı tip değişkenleri tutmak yerine bir nesne için değişken grupları olarak düşünülebilir
            Customer customer = new Customer();
            customer.Id = 1;
            customer.FirstName = "mustafa";
            customer.LastName = "turan";
            customer.City = "İzmir";

            //Customer customer2 = new Customer { } yazdıktan sonra köşeli parantez içinde ctrl+space yapınca eklenebilecek veriler listelenir
            // buda farklı bir nesne ekleme şeklidir
            Customer customer2 = new Customer { Id = 2, FirstName = "ayse", LastName = "turan", City = "izmir" };

            // nesne ile method çağırdık karşılığında bize veri döndürebilir
            customer.Write(customer);




            Console.ReadLine();
        }
    }

    class CustomerManager // müşteri ile ilgili işlemleri buraya koyabilirim
    {
        public void Add()
        {
            Console.WriteLine("Customer Added!");
        }

        public void Update()
        {
            Console.WriteLine("Customer Updated!");
        }
    }

    class ProductManager // ürünlerimle ilgili işlemleri buraya koyabilirim
    {
        public void Add()
        {
            Console.WriteLine("Product Added!");
        }

        public void Update()
        {
            Console.WriteLine("Product Updated!");
        }
    }
}
