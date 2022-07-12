using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
    //inheritance kapsamında çok önemlidir
    //bu methodlar ne zaman interface ne zaman ihneritance kullancamıza karar vermede yardımcı olur
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();
            sqlServer.Add();
            MySqlServer mySqlServer = new MySqlServer();
            mySqlServer.Add();


            Console.ReadLine();
        }
    }

    class Database
    {
        public virtual void Add()
            //araya virtual eklendiğinde bu methodun üretilen sınıftan harici olarak çağırılabileceğini(override) belirler
        {
            Console.WriteLine("Added by default");
        }

        public virtual void Delete()
        {
            Console.WriteLine("Deleted by default");
        }
    }

    class SqlServer : Database
    {
        public override void Add()
            //harici cağırma işlemi bu şekilde yazılır
            //base.Add(); silinirse sadece bu kodlar çalışır
            //burada base methodtan farklı işlemler yapılabilir
            //bu işleme methodu ezmek de denilebiliyor
            //bu işlem interfaceler ile yapılamaz
        {
            Console.WriteLine("Added by SqlServer");
            base.Add();
        }
    }

    class MySqlServer : Database
    {

    }
}
