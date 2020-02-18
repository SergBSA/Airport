using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Airport
{
    class Program
    {
        class CountArray
        {
            public int NewArrayCount;
            public CountArray(int newarraycount)
            {
                this.NewArrayCount = newarraycount;
            }
        }
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
            private string destination;
            private int flynumber;
            private DateTime timeArrival;
            private string aviakompany;
            private int terminal;
            private int gate;
            private int serialNumber;


            public string Destination
            {
                get { return destination; }
                set { destination = value; }
            }
            public int SerialNumber
            {
                get { return serialNumber; }
                set { serialNumber = value; }
            }
            public int FlyNumber
            {
                get { return flynumber; }
                set { this.flynumber = value; }
            }
            public DateTime TimeArrival
            {
                get { return timeArrival; }
                set { timeArrival = value; }
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

        };
        class Person : Airplane 
        {
            
        }

        private static int CheckInput(string str = "Insert Correct Password")
        {
            int Paragraph;
            while (!int.TryParse(Console.ReadLine(), out Paragraph))
            {
                Console.Clear();
                Console.WriteLine(str);
            }
            return Paragraph;
        }
        private static DateTime CheckInputDateTime(string str = "Incorect Date")
        {
            DateTime Paragraph;
            while (!DateTime.TryParse(Console.ReadLine(), out Paragraph))
            {
                Console.Clear();
                Console.WriteLine(str);
            }
            return Paragraph;
        }
        private static string CheckAdminPass(string str = "Insert Correct Password")
        {
            string pass = "1234";
            string input = Console.ReadLine();
            while (input != pass)
            {
                Console.Clear();
                Console.WriteLine(str);
                input = Console.ReadLine();
            }
            return input;
        }
        enum ParagraphPassword
        {
            AdminPass = 1,
            UserPass = 2
        }
        enum AdminAction
        {
            Modify = 1,
            Delete = 2,
            Add = 3
        }
        enum UserAction
        {
            NumSearch = 1,
            DateSearch = 2,
            GateSearch = 3
        }
        private static TEnum GetUserInput<TEnum>() where TEnum : struct, Enum
        {
            string userInputString = Console.ReadLine();
            Enum.TryParse(userInputString, true, out TEnum resultInputType);
            if (Enum.IsDefined(typeof(TEnum), resultInputType))
            {
                return resultInputType;
            }
            throw new ArgumentException("Wrong!");
        }
        /*private static void ListAirplanes(int AirplaneCount)
       {
           int k;
           for (int i = 0; i<AirplaneCount; i++)
                                   {
                                       Console.WriteLine("НомерПП - {0};Номер рейса -{1};Пункт назначения - {2};Прибытие - {3};Авиакомпания -{4};" +
                                       "Терминал -{5};Ворота - {6}",
                                       airplanes[i].SerialNumber, airplanes[i].FlyNumber, airplanes[i].Destination, airplanes[i].TimeArrival,
                                       airplanes[i].Aviacompany, airplanes[i].Terminal, airplanes[i].Gate);
                                       k = i;
                                   }
       }
       */

        static void Main(string[] args)
        {
            //string Pass = "1234";
            const int AirplaneCount = 100;
            Airplane[] airplanes = new Airplane[AirplaneCount];
            Random rnd = new Random();
            string[] Dest = { "Киев", "Нью-Йорк", "Варшава", "Рига", "Сидней", "Антананириву", "Стокгольм", "Берлин", "Пекин" };
            string[] Aviacompania = { "Aerostar", "Anda Air", "Azur", "FANair", "SkyUp", "YanAir", "VegaAir", "UM Air", "KhorsAir" };
            for (int i = 0; i < AirplaneCount; i++)
            {
                airplanes[i] = new Airplane();
                airplanes[i].SerialNumber = i + 1;
                airplanes[i].Destination = Dest[rnd.Next(0, Dest.Length)];
                airplanes[i].FlyNumber = rnd.Next(20, 1000);
                airplanes[i].TimeArrival = DateTime.Now.AddMinutes(rnd.Next(1, 1440)); //-rnd.Next(1, 100);
                airplanes[i].Aviacompany = Aviacompania[rnd.Next(0, Dest.Length)];
                airplanes[i].Terminal = rnd.Next(1, 10);
                airplanes[i].Gate = rnd.Next(1, 35);

            };
            // AdminPass:
            Console.WriteLine("Login as...\r\n1 - Admin");
            Console.WriteLine("2 - User");
            // int Paragraph = CheckInput();
            ParagraphPassword input = GetUserInput<ParagraphPassword>();
            switch (input)
            {
                case ParagraphPassword.AdminPass:
                    {
                        Console.WriteLine("Input Admin Pass");
                        string verifypass = CheckAdminPass();
                        Console.Clear();
                        Console.WriteLine("Select... \r\n1- Modify flight");
                        Console.WriteLine("2- Delete flight\r\n3- Add flight");
                        AdminAction admininput = GetUserInput<AdminAction>();
                        Console.Clear();
                        switch (admininput)
                        {
                            case AdminAction.Modify:
                                {
                                    Console.WriteLine("{0,-10}| {1,-10}| {2,-20}| {3,-20}| {4,-10}| {5,-10}| {6,-10}",
                                        "Serial", "FlyNumber", "Destination", "TimeArrival", "Aviacompany",
                                        "Terminal", "Gate");
                                    for (int i = 0; i < AirplaneCount; i++)
                                    {
                                        Console.WriteLine("{0,-10}| {1,-10}| {2,-20}| {3,-20}| {4,-10}| {5,-10}| {6,-10}",
                                        airplanes[i].SerialNumber, airplanes[i].FlyNumber, airplanes[i].Destination,
                                        airplanes[i].TimeArrival,
                                        airplanes[i].Aviacompany, airplanes[i].Terminal, airplanes[i].Gate);
                                    }
                                    Console.WriteLine("Input SerialNum");
                                    // int Numchoise = 0;
                                    int Numchoise = CheckInput("Insert Correct Serial");
                                    Console.WriteLine("Insert FlyNumber and press Enter");
                                    airplanes[Numchoise].FlyNumber = CheckInput("Insert Correct FlyNumber");
                                    Console.WriteLine("Insert Destination and press Enter");
                                    airplanes[Numchoise].Destination = Console.ReadLine();
                                    Console.WriteLine("Insert Aviacompany and press Enter");
                                    airplanes[Numchoise].Aviacompany = Console.ReadLine();
                                    Console.WriteLine("Insert Terminal and press Enter");
                                    airplanes[Numchoise].Terminal = CheckInput("Insert Correct Terminal");
                                    Console.WriteLine("Insert Gate and press Enter");
                                    airplanes[Numchoise].Gate = CheckInput("Insert Correct Gate");
                                    
                                    Console.WriteLine("{0,-10}| {1,-10}| {2,-20}| {3,-20}| {4,-10}| {5,-10}| {6,-10}",
                                        airplanes[Numchoise].SerialNumber, airplanes[Numchoise].FlyNumber, 
                                        airplanes[Numchoise].Destination,
                                        airplanes[Numchoise].TimeArrival,
                                        airplanes[Numchoise].Aviacompany, 
                                        airplanes[Numchoise].Terminal, 
                                        airplanes[Numchoise].Gate);
                                    break;
                                }
                            case AdminAction.Delete:
                                {
                                    Console.WriteLine("{0,-10}| {1,-10}| {2,-20}| {3,-20}| {4,-10}| {5,-10}| {6,-10}",
                                        "Serial", "FlyNumber", "Destination", "TimeArrival", "Aviacompany",
                                        "Terminal", "Gate");
                                    for (int i = 0; i < AirplaneCount; i++)
                                    {
                                        Console.WriteLine("{0,-10}| {1,-10}| {2,-20}| {3,-20}| {4,-10}| {5,-10}| {6,-10}",
                                        airplanes[i].SerialNumber, airplanes[i].FlyNumber, airplanes[i].Destination,
                                        airplanes[i].TimeArrival,
                                        airplanes[i].Aviacompany, airplanes[i].Terminal, airplanes[i].Gate);
                                    }
                                    Console.WriteLine("Input SerialNum");
                                    int Numchoise = CheckInput("Insert Correct Serial");
                                    List<string> listairportDest = new List<string>();
                                    for (int i = 0; i < AirplaneCount; i++)
                                    {
                                        listairportDest.Add(airplanes[i].SerialNumber.ToString());
                                    }
                                    for (int d = 0;d < listairportDest.Count; d++)
                                    {
                                        if (Numchoise.ToString() == listairportDest[d])
                                        {
                                            listairportDest.RemoveAt(d); // listairportDest.ElementAt(d);
                                            //listairportDest.Remove(k);
                                        }
                                    }
                                    for (int d = 0; d < listairportDest.Count; d++)
                                    {
                                        if (Numchoise.ToString() == listairportDest[d])
                                        {
                                            listairportDest.RemoveAt(d);
                                        }
                                    }
                                    foreach (string s in listairportDest)
                                    {
                                        Console.Write("{0}, ", s);
                                    }
                                    Console.WriteLine();
                                    // Или двойной цикл, или метод, который не помню...
                                    break;
                                }
                            case AdminAction.Add:
                                {
                                    Console.WriteLine("AddFlight");
                                    break;
                                }
                        }
                        break;
                    }
                case ParagraphPassword.UserPass:
                    {
                        Console.Clear();
                        Console.WriteLine("{0,-10}| {1,-10}| {2,-20}| {3,-20}| {4,-10}| {5,-10}| {6,-10}",
                                        "Serial", "FlyNumber", "Destination", "TimeArrival", "Aviacompany",
                                        "Terminal", "Gate");
                        for (int i = 0; i < AirplaneCount; i++)
                        {
                            Console.WriteLine("{0,-10}| {1,-10}| {2,-20}| {3,-20}| {4,-10}| {5,-10}| {6,-10}",
                            airplanes[i].SerialNumber, airplanes[i].FlyNumber, airplanes[i].Destination,
                            airplanes[i].TimeArrival,
                            airplanes[i].Aviacompany, airplanes[i].Terminal, airplanes[i].Gate);
                        }
                        Console.WriteLine("Select... \r\n1- Search by the Number");
                        Console.WriteLine("2- Search by the Date\r\n3- Search by the Gate");
                        UserAction userinput = GetUserInput<UserAction>();
                        switch (userinput)
                        {
                            case UserAction.NumSearch:
                                {
                                    Console.WriteLine("Input FlyNumber");
                                    int Numchoise = CheckInput("Insert Correct Serial");
                                    Console.Clear();
                                    for (int i = 0; i < AirplaneCount; i++)
                                    {
                                        if (Numchoise == airplanes[i].FlyNumber)
                                        {
                                            Console.WriteLine("{0,-10}| {1,-10}| {2,-20}| {3,-20}| {4,-10}| {5,-10}| {6,-10}",
                                             airplanes[i].SerialNumber, airplanes[i].FlyNumber, airplanes[i].Destination,
                                             airplanes[i].TimeArrival,
                                             airplanes[i].Aviacompany, airplanes[i].Terminal, airplanes[i].Gate);    
                                        }

                                    }
                                    break;
                                }
                            case UserAction.DateSearch:
                                {
                                    Console.WriteLine("Input Date");
                                    DateTime dateinput = CheckInputDateTime();
                                    DateTime tempmaxdate = dateinput.AddHours(1);
                                    DateTime tempmindate = dateinput.AddHours(-1);
                                    //Console.Clear();
                                    for (int i = 0; i < AirplaneCount; i++)
                                    {
                                        
                                        if (tempmindate < airplanes[i].TimeArrival &&
                                            tempmaxdate > airplanes[i].TimeArrival)
                                        {
                                            Console.WriteLine("{0,-10}| {1,-10}| {2,-20}| {3,-20}| {4,-10}| {5,-10}| {6,-10}",
                                             airplanes[i].SerialNumber, airplanes[i].FlyNumber, airplanes[i].Destination,
                                             airplanes[i].TimeArrival,
                                             airplanes[i].Aviacompany, airplanes[i].Terminal, airplanes[i].Gate);
                                        }

                                    }
                                    break;
                                }
                            case UserAction.GateSearch:
                                {
                                    Console.WriteLine("Input Gate");
                                    int Numchoise = CheckInput("Insert Correct Gate");
                                    Console.Clear();
                                    for (int i = 0; i < AirplaneCount; i++)
                                    {
                                        if (Numchoise == airplanes[i].Gate)
                                        {
                                            Console.WriteLine("{0,-10}| {1,-10}| {2,-20}| {3,-20}| {4,-10}| {5,-10}| {6,-10}",
                                             airplanes[i].SerialNumber, airplanes[i].FlyNumber, airplanes[i].Destination,
                                             airplanes[i].TimeArrival,
                                             airplanes[i].Aviacompany, airplanes[i].Terminal, airplanes[i].Gate);
                                        }

                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }

    }

}
