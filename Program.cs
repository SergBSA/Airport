using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {
        class Airplane
        {
            public enum statusReisa
            {
                registracia,
                posadka,
                zakryt,
                pribyl,
                vylet,
                neizvestno,
                otmenen,
                ozhydanie,
                zaderzhka
            }
            DateTime startTime = new DateTime(2015, 12, 12);
            private string punktNaznachenia;
            private string nomerReisa;
            private DateTime vremyaPribytiya;
            private string aviakompany;
            private byte terminal;
            private byte gate;
            

            public string PunktNaznachenia
            {
                get { return punktNaznachenia; }
                set { punktNaznachenia = value; }
            }
            public string NomerReisa
            {
                get { return nomerReisa; }
                set { nomerReisa = value; }
            }
            public DateTime VremyaPribytiya
            {
                get { return vremyaPribytiya; }
                set { vremyaPribytiya = value; }
            }
            public string Aviacompany
            {
                get { return aviakompany; }
                set { aviakompany = value; }
            }
            public byte Terminal
            {
                get { return terminal; }
                set { terminal = value; }
            }
            public byte Gate
            {
                get { return gate; }
                set { gate = value; }
            }
            public Airplane(string punkt, string nomer, DateTime vremya, string company, byte termin, byte gates)
            {
                
                punktNaznachenia = punkt;
                nomerReisa = nomer;
                vremyaPribytiya = vremya;
                aviakompany = company;
                terminal = termin;
                gate = gates;

            }
        }
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2020, 1, 1);
            

            Airplane A1 = new Airplane("b", "D", date1, "Airvais", 10, 35);
            
            A1.Terminal = 20;
            Console.WriteLine("Gate is {0}", A1.Gate);
            Console.WriteLine("Terminal is {0}", A1.Terminal);

            Airplane[100] = new Airplane("b", "D", date1, "Airvais", 10, 35);


            // Не могу понять как использовать статус рейса, да и вообще завтык...




        }

    }
    
    
}
