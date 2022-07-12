using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            //aynı interfaceler gibi abstract sınıflarda newlenemez
            //Database database = new Database();//kodu hata verecektir
            Database database = new SqlServer();
            database.Add();
            database.Delete();
            Database database2 = new OracleServer();
            database2.Add();
            database2.Delete();

            Console.ReadLine();
        }
    }

    abstract class Database
    {
        //ekleme her veritabanında aynı ancak silme işlemi bütün veritabanlarında farklı olduğunu varsayalım
        //aynı interfaceler gibi abstract sınıflarda newlenemez
        public void Add()
            //buna tamamlanmış method deniyor
        {
            Console.WriteLine("Added by default");
        }

        //public void Add2();//yazmaya çalışırsanız hata verecektir, abstract eklendiğinde tamamlanmamış method yapılabilir
        //abstract methodlar içi dolu olmayan virtual methoddur
        public abstract void Delete();//buna tamamlanmamış methodlar deniyor
    }

    class SqlServer : Database
    {
        public override void Delete()
            //inherit ettiğinizde sizi bu methodu eklemeye zorlayacaktır
            //override olarak gelecektir
            //abstract methodlar içi dolu olmayan tamamlanmamış virtual methoddur
            //override ederek biz tamamlarız
        {
            Console.WriteLine("Deleted by SqlServer");
        }
    }

    class OracleServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by OracleServer");
        }
    }
}
