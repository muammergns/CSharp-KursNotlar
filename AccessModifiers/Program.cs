using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Customer
    {
        //int privateId;//bu default private
        private int privateId;//yukarıdakinin aynısı
        //private sadece tanımlandığı blok içerisinde geçerlidir yani {} bunun arasında

        protected int protectedId;//sınıf seviyesinde kullanılabilir method içine alınamaz
        //tanımlandığı sınıf bir başka sınıfa inherite edildiğinde bu değişken kullanılabilir
    }

    class Student:Customer
    {
        public void Save()
            //burada amaç erişim bildirgeçlerini öğrenmek
        {
            //privateId=0; //yazamayacağız, nedeni privateId private bir değişkendir
            //private sadece tanımlandığı blok içerisinde geçerlidir yani {} bunun arasında

            protectedId = 0;//iherite ettiğimiz için buna ulaşabiliriz

        }
    }

    internal class Course //classların default belirteci internal dır, yani hiçbir şey yazmadığımızda class internal dır 
        //internal belirteci bu classın başka classlar tarafından ulaşılabilir olduğunu gösterir
        //bir class private olamaz sistemin işleyişine aykırı ulaşılamaz bir sınıf yazmanın anlamı yoktur
        //bir class protected da olamaz yine sistemin işleyişine aykırı

        //bir class ya internal olur ya da public olur
        //internal aynı proje içerisinde hiç sıkıntı olmadan kullanılabilir
    {
        private class NestedClass//iç içe class, iç içe classlar private ya da protected olabilir
        {

        }
    }
}
