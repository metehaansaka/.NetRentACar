using Business.Concrete;
using System.Linq;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ArabaManager ab = new ArabaManager(new ArabaDal());
            foreach (var item in ab.GetAll())
            {
                Console.Write(ab.GetMarka(item.ArabaId).Marka + " ");
                Console.Write(ab.GetMarka(item.ArabaId).Model + " ");
                Console.Write(ab.GetMarka(item.ArabaId).Sanziman + " ");
                Console.Write(ab.GetMarka(item.ArabaId).Vites + " ");
                Console.Write(ab.GetMarka(item.ArabaId).Yakit + " ");
                Console.WriteLine(ab.GetMarka(item.ArabaId).Fiyat);
            }
        }
    }
}
