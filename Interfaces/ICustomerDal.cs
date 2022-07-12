using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface ICustomerDal//aynı projede ayrı bir sınıf dosyasında yeni bir interface ekledik 
        //buna polimorphism deniyor
    {
        void Add();
        void Update();
        void Delete();
    }

    // aga burası çok ince iyi oku
    // bizim bir müşteri grubumuz var
    // bunlardan bazıları sql ile çalışmak istiyor bazıları oracle
    // yani grubumuz 2ye bölünmüş durumda 2 ayrı grup oldu
    // belki sonradan başka bir sunucu eklenmesi istenebilir 3 ayrı grup oluverirler
    // ama hepsi add,update,delete kullanacak bu kesin
    // biz naptık add,update,delete için interface oluşturduk yani arabirim
    // bunları sqlserver ve oracle içine implement ettik sonradan başka eklenebilir implement edilir iş biter
    // sonra customermanager diye bir sınıf oluşturduk müşterilerin tamamı için
    // ve her bir methodu parametre olarak ICustomerDal nesnesi istiyor
    // şimdi rahat rahat asıl iş yaptığımız kod üzerinden istediğimiz nesneyi oluşturup kolayca çağırma yapabiliriz asla karışmaz

    class SqlServer : ICustomerDal
    {
        public void Add()
        {
            Console.WriteLine("Sql Added!");
        }

        public void Delete()
        {
            Console.WriteLine("Sql Deleted!");
        }

        public void Update()
        {
            Console.WriteLine("Sql Updated!");
        }
    }

    class OracleServer : ICustomerDal
    {
        public void Add()
        {
            Console.WriteLine("Oracle Added!");
        }

        public void Delete()
        {
            Console.WriteLine("Oracle Deleted!");
        }

        public void Update()
        {
            Console.WriteLine("Oracle Updated!");
        }
    }

    class MySqlServer : ICustomerDal
    {
        public void Add()
        {
            Console.WriteLine("MySql Added!");
        }

        public void Delete()
        {
            Console.WriteLine("MySql Deleted!");
        }

        public void Update()
        {
            Console.WriteLine("MySql Updated!");
        }
    }

    class CustomerManager
    {
        public void Add(ICustomerDal customerDal)
        {
            customerDal.Add();
        }

        public void Delete(ICustomerDal customerDal)
        {
            customerDal.Delete();
        }

        public void Update(ICustomerDal customerDal)
        {
            customerDal.Update();
        }
    }
}
