using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PangaautomaatS
{
    class Konto
    {
        public string Name { get; set; }
        public string Pin { get; set; }
        public int Money { get; set; }

        string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Kontod");

        public void Deposit()
        {
            Console.WriteLine("Kui palju tahate arvele panna?");
            Money=Convert.ToInt32(Console.ReadLine());
            File.WriteAllText(path + "\\" + Name + ".txt", Pin + "\n" + Money);
            Console.WriteLine("Teie uus balanss: "+Money);
        }
        public void Withdraw()
        {
            Console.WriteLine("Kui palju tahate arvelt võtta?");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x <= Money)
            {
                Money = Money - x;
                File.WriteAllText(path + "\\" + Name + ".txt", Pin + "\n" + Money);
                Console.WriteLine("Teie uus balanss: "+Money);
            }
            else
            {
                Console.WriteLine("Teil pole nii palju raha");
            }
        }
    }
}
