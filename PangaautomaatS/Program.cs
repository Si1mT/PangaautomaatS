using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PangaautomaatS
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,"Kontod");
            var konto = new Konto();

            Console.WriteLine("Sisestage number:\n1.Registreerimine\n2.Sisselogimine");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                Console.WriteLine("Sisestage nimi");
                konto.Name = Console.ReadLine();
                if (!File.Exists(path + "\\" + konto.Name + ".txt"))
                {
                    Console.WriteLine("Sisestage PIN");
                    konto.Pin = Console.ReadLine();
                    File.WriteAllText(path + "\\" + konto.Name + ".txt", konto.Pin + "\n0");
                    Console.WriteLine("Konto on registreeritud");
                }
                else
                {
                    Console.WriteLine("See nimi on võetud");
                }
            }
            else if (answer == "2")
            {
                Console.WriteLine("Sisestage konto nimi");
                konto.Name = Console.ReadLine();
                if (File.Exists(path + "\\" + konto.Name + ".txt"))
                {
                    Console.WriteLine("Sisestage PIN");
                    konto.Pin = Console.ReadLine();
                    string[] lines = File.ReadAllLines(path + "\\" + konto.Name + ".txt");
                    if (konto.Pin == lines[0])
                    {
                        konto.Money = int.Parse(lines[1]);
                        Console.WriteLine("Teil on "+konto.Money+" eurot");
                        Console.WriteLine("Kas tahate:\n    1.Raha sisestada\nvõi\n    2.Raha võtta");
                        string option = Console.ReadLine();
                        if (option == "1")
                        {
                            konto.Deposit();
                        }
                        else if (option == "2")
                        {
                            konto.Withdraw();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("See ei ole valik");
            }
            Console.ReadLine();
        }
    }
}
