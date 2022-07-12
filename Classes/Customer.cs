using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Customer
    {
        //public int MyProperty { get; set; } //prop yazıp tab tuşuna 2 kere basıldığında otomatik oluşur
        public int Id { get; set; }
        // bir nesnenin özelliklerini tutmak için oluşturulur, örneğin müşterinin id si
        // bu yaptığımız iş aslında bir field yani alan tanımlamak
        // burası public int Id; şeklinde de tanımlanabilirdi sorunsuz çalışırdı ancak,bu yaptığımız iş aslında bir field yani alan tanımlamak
        // public int MyProperty { get; set; } bu şekilde ise property yani sınıfın özelliklerini tanımlamış olduk
        // get; ve set; ayrı çalışan methodlardır, örneğin set edilirken bir işlem, get edilirken başka bir işlem yapmak isteyebiliriz
        private string _firstName;// bu {get; set;} yazmakla aynı şeydir , bu tarz kullanım çok az görülür
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return "x " + _lastName; //artık bu şekilde okunan tüm soyisimlerin başına x koyularak döndürülür
            }
            set
            {
                _lastName = value;
            }
        }
        public string City { get; set; }//aslında bu bir autopropertydir yukarıdakilerin kısaltılmış hali
        //bu yapılan işlemin tümünede temel kapsülleme (encapsulation) denir

        public void Write(Customer customer)
            //oluşturulan nesnenin nesnesini talep eden method oluşturduk
            //aldığımız nesnenin tüm bilgilerini konsola yazırdık
        {
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer.LastName);
            Console.WriteLine(customer.City);
        }
    }
}
