using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //utilities isimlendirmesi sıklıkla kullanılır
            //araçlar gibi bişey, örneğin bir convert işlemi hızlı hızlı eklemek için
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<string>("istanbul","ankara","izmir");
            //ben sana böyle 3lü liste vereceğim, sen bana burada hangi tipte yazarsam bu tipte bir liste oluştur
            //yani bu datayı o tipte bir liste haline getir, methodun genericini yaptık
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Foreachs.Fors<string>(result);

            Console.ReadLine();

        }
    }

    class Utilities
    {
        //T hangi tipte çalışacaksam o tipte bişey döndür bana demek
        //List<T> döndüren method yazdık
        //methodun ismini BuildList yaptık
        //parametre olarak params array istedik
        //params neydi? method için parametre isterken sınırsız elemanlı parametre gönderebilirsin demek
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }

    static class Foreachs
    {
        public static void Fors<T>(List<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Product : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    class Customer : ICustomerDal
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }

    //______________________________________
    //generic interfaces farklı sınıflardan aynı görevleri yapacak işlemleri daha düzenli hale getiriyor

    interface IRepository<T>
        // where T:class,new() yazarak generic kısıtlaması yapabiliriz, sadece sınıf olabilir ve newlenebilmelidir
        // where T:struct yazarsak değer tipe karşılık gelir, örneğin int olabilir
        //T type dan gelir, bir isimlendirme standardıdır
        //farklı nesneleri implemente edebilir
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    interface IProductDal:IRepository<Product>
    {

    }

    interface ICustomerDal:IRepository<Customer>
    {

    }
}
