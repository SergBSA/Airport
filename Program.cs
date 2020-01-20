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
            enum statusReisa
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
            private int nomerReisa;
            private DateTime vremyaPribytiya;
            private string aviakompany;
            private int terminal;
            private int gate;
            private int nomerPP;


            public string PunktNaznachenia
            {
                get { return punktNaznachenia; }
                set { punktNaznachenia = value; }
            }
            public int NomerPP
            {
                get { return nomerPP; }
                set { nomerPP = value; }
            }
            public int NomerReisa
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
            public int Terminal
            {
                get { return terminal; }
                set { terminal = value; }
            }
            public int Gate
            {
                get { return gate; }
                set { gate = value; }
            }
          


            /* public Airplane(string punkt, string nomer, DateTime vremya, string company, byte termin, byte gates)
             {

                 punktNaznachenia = punkt;
                 nomerReisa = nomer;
                 vremyaPribytiya = vremya;
                 aviakompany = company;
                 terminal = termin;
                 gate = gates;

             } */
             //public Airplane[] airplanes;
        };
        private static void ShowList(int i, int count)
        {
            
        }
        private static int CheckInput()
        {
            int Punkt;
            while (!int.TryParse(Console.ReadLine(), out Punkt))
            {
                Console.WriteLine("Введите доступный пункт");
            }
            return Punkt;
        }
        private static int CheckInput(string str)
        {
            int Punkt;
            while (!int.TryParse(Console.ReadLine(), out Punkt))
            {
                Console.WriteLine(str);
            }
            return Punkt;
        }
        private int newcount;
        public int NewCount;
        /*{
            get
            { 
                return newcount;
            }
            set
            {
                newcount = value;
            }
                
        } */
        

        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2020, 1, 1);
            const int AirplaneCount = 100;
            Airplane[] airplanes = new Airplane[AirplaneCount];

            Random rnd = new Random();
            string g;
            string[] Dest = { "Киев", "Нью-Йорк", "Варшава", "Рига", "Сидней", "Антананириву", "Стокгольм", "Берлин", "Пекин" };
            string[] Aviacompania = { "Aerostar", "Anda Air", "Azur", "FANair", "SkyUp", "YanAir", "VegaAir", "UM Air", "KhorsAir" };
            for (int i = 0; i < AirplaneCount; i++)
            {
                airplanes[i] = new Airplane();
                airplanes[i].NomerPP = i + 1;
                airplanes[i].PunktNaznachenia = Dest[rnd.Next(0,Dest.Length)];
                airplanes[i].NomerReisa = rnd.Next(20,1000);
                airplanes[i].VremyaPribytiya = DateTime.Now.AddMinutes(rnd.Next(1, 1440)); //-rnd.Next(1, 100);
                airplanes[i].Aviacompany = Aviacompania[rnd.Next(0, Dest.Length)];
                airplanes[i].Terminal = rnd.Next(1, 10);
                airplanes[i].Gate = rnd.Next(1, 35);
                
            };
           
            string Pass = "1234";
            
            AdminPass:
            Console.WriteLine("Выполнить вход как\r\n1 - Администратор");
            Console.WriteLine("2 - Полозователь");
            /*while (!int.TryParse(Console.ReadLine(), out Punkt))
           {
               Console.WriteLine("Введите доступный пункт");
           } */
            int Punkt = CheckInput();
            switch (Punkt)
            {
                case 1:
                    Console.WriteLine("Введите пароль администратора");
                    string PassTemp = Console.ReadLine();
                    if (Pass == PassTemp)
                    {
                    ProverkaAdmin:
                        Console.WriteLine("Введите пункт меню\r\n1-изменение информации по рейсу");
                        Console.WriteLine("2-удаление рейса\r\n3-ввод нового рейса");
                        Punkt = CheckInput();
                        switch (Punkt)
                        {
                            case 1:
                                for (int i = 0; i < AirplaneCount; i++)
                                {
                                    Console.WriteLine("НомерПП - {0};Номер рейса -{1};Пункт назначения - {2};Прибытие - {3};Авиакомпания -{4};" +
                                    "Терминал -{5};Ворота - {6}",
                                    airplanes[i].NomerPP, airplanes[i].NomerReisa, airplanes[i].PunktNaznachenia, airplanes[i].VremyaPribytiya,
                                    airplanes[i].Aviacompany, airplanes[i].Terminal, airplanes[i].Gate);
                                }
                                
                                Console.WriteLine(x);
                                Console.WriteLine("Введите НомерПП интересующего рейса");
                                int NomerPP = CheckInput("Введите доступный номерПП для рейса");
                                
                                Console.WriteLine("Вы Выбрали:");
                                Console.WriteLine("{0};Номер рейса -{1}; Пункт назначения - {2}; Прибытие - {3}; Авиакомпания -{4};" + 
                                    "Терминал -{5};Ворота - {6}",
                                    airplanes[NomerPP -1].NomerPP, airplanes[NomerPP -1].NomerReisa, airplanes[NomerPP -1].PunktNaznachenia, airplanes[NomerPP -1].VremyaPribytiya,
                                    airplanes[NomerPP -1].Aviacompany, airplanes[NomerPP -1].Terminal, airplanes[NomerPP -1].Gate);
                                Console.WriteLine("1- Изменить пункт назначения\r\n2-Изменить Авиакомпанию");
                                Console.WriteLine("3- Изменить Ворота\r\n4- Изменить терминал");
                                Console.ReadLine();

                                break;

                            case 2:

                                for (int i = 0; i < AirplaneCount; i++)
                                {
                                    Console.WriteLine("НомерПП - {0};Номер рейса -{1};Пункт назначения - {2};Прибытие - {3};Авиакомпания -{4};" +
                                    "Терминал -{5};Ворота - {6}",
                                    airplanes[i].NomerPP, airplanes[i].NomerReisa, airplanes[i].PunktNaznachenia, airplanes[i].VremyaPribytiya,
                                    airplanes[i].Aviacompany, airplanes[i].Terminal, airplanes[i].Gate);
                                }
                                Console.WriteLine("Два");
                                break;
                            case 3:
                                Console.WriteLine("Три");
                                break;
                            default:
                                Console.WriteLine("Введите доступный пункт");
                                goto ProverkaAdmin;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не верный пароль администратора");
                        goto AdminPass;
                    }
                    break;
                case 2:
                    Console.WriteLine("Юзер");
                    Console.WriteLine("Введите пункт меню\r\n1-");
                    Console.WriteLine("2-\r\n3-");

                ProverkaUser:
                    while (!int.TryParse(Console.ReadLine(), out Punkt))
                    {
                        Console.WriteLine("Введите доступный пункт");
                    }
                    switch (Punkt)
                    {
                        case 1:
                            Console.WriteLine("Один");
                            // Console.WriteLine("Введите пункт меню\r\n1-изменение информации по рейсу");
                            break;

                        case 2:
                            Console.WriteLine("Два");
                            break;
                        case 3:
                            Console.WriteLine("Три");
                            break;
                        default:
                            Console.WriteLine("Введите доступный пункт");
                            goto ProverkaUser;
                    }
                    break;
                default:
                    Console.WriteLine("Введите доступный пункт");
                    goto AdminPass;
            }
            

            Console.ReadLine();
        }
            




        

    }
    
    
}
