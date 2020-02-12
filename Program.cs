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
            private int number;
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
            public int Number
            {
                get { return number; }
                set { this.number = value;}
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
     
        private static int CheckInput(string str = "Введите доступный пункт")
        {
            int Punkt;
            while (!int.TryParse(Console.ReadLine(), out Punkt))
            {
                Console.Clear();
                Console.WriteLine(str);
            }
            return Punkt;
        }
        enum ParagraphPassword
        { 
            Admin = 1,
            User = 2
        }
        enum AdminAction
        {
            ChangeInformation = 1,
            DeleteFlight = 2,
            InsertNewFlight 3
        }
        
        // Не понятно, как вызывать этот Енам в коде... Мне нужно выбрать из 3 значений: 1-изменить/2-удалить/3-ввести новый
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
        // Пример использования:
        switch(GetUserInput())
        {
        case ModifyInput:
        // ....

        }


    static void Main(string[] args)
        {
            string Pass = "1234";
            const int AirplaneCount = 100;
            Airplane[] airplanes = new Airplane[AirplaneCount];
            Random rnd = new Random();
            string[] Dest = { "Киев", "Нью-Йорк", "Варшава", "Рига", "Сидней", "Антананириву", "Стокгольм", "Берлин", "Пекин" };
            string[] Aviacompania = { "Aerostar", "Anda Air", "Azur", "FANair", "SkyUp", "YanAir", "VegaAir", "UM Air", "KhorsAir" };
            for (int i = 0; i < AirplaneCount; i++)
            {
                airplanes[i] = new Airplane();
                airplanes[i].SerialNumber = i + 1;
                airplanes[i].Destination = Dest[rnd.Next(0,Dest.Length)];
                airplanes[i].Number = rnd.Next(20,1000);
                airplanes[i].TimeArrival = DateTime.Now.AddMinutes(rnd.Next(1, 1440)); //-rnd.Next(1, 100);
                airplanes[i].Aviacompany = Aviacompania[rnd.Next(0, Dest.Length)];
                airplanes[i].Terminal = rnd.Next(1, 10);
                airplanes[i].Gate = rnd.Next(1, 35);
                
            };
            AdminPass:
            Console.WriteLine("Выполнить вход как\r\n1 - Администратор");
            Console.WriteLine("2 - Полозователь");
            int Punkt = CheckInput();
            if (Punkt == (int)ParagraphPassword.Admin)
            {
                Console.Clear();
                Console.WriteLine("Введите пароль администратора");
                string PassTemp = Console.ReadLine();
                if (Pass == PassTemp)
                {
                ProverkaAdmin:
                    Console.Clear();
                    Console.WriteLine("Введите пункт меню\r\n1-изменение информации по рейсу");
                    Console.WriteLine("2-удаление рейса\r\n3-ввод нового рейса");
                    Punkt = CheckInput();
                    if (Pass == PassTemp)

                        switch (Punkt)
                    {
                        case 1:
                            for (int i = 0; i < AirplaneCount; i++)
                            {
                                Console.WriteLine("НомерПП - {0};Номер рейса -{1};Пункт назначения - {2};Прибытие - {3};Авиакомпания -{4};" +
                                "Терминал -{5};Ворота - {6}",
                                airplanes[i].SerialNumber, airplanes[i].NomerReisa, airplanes[i].destination, airplanes[i].VremyaPribytiya,
                                airplanes[i].Aviacompany, airplanes[i].Terminal, airplanes[i].Gate);
                            }

                            Console.WriteLine("Введите НомерПП интересующего рейса");
                            int NomerPP = CheckInput("Введите доступный номерПП для рейса");

                            Console.WriteLine("Вы Выбрали:");
                            Console.WriteLine("{0};Номер рейса -{1}; Пункт назначения - {2}; Прибытие - {3}; Авиакомпания -{4};" +
                                "Терминал -{5};Ворота - {6}",
                                airplanes[NomerPP - 1].NomerPP, airplanes[NomerPP - 1].NomerReisa, airplanes[NomerPP - 1].destination, airplanes[NomerPP - 1].VremyaPribytiya,
                                airplanes[NomerPP - 1].Aviacompany, airplanes[NomerPP - 1].Terminal, airplanes[NomerPP - 1].Gate);
                            Console.WriteLine("1- Изменить пункт назначения\r\n2-Изменить Авиакомпанию");
                            Console.WriteLine("3- Изменить Ворота\r\n4- Изменить терминал");
                            Console.ReadLine();

                            break;

                        case 2:

                            for (int i = 0; i < AirplaneCount; i++)
                            {
                                Console.WriteLine("НомерПП - {0};Номер рейса -{1};Пункт назначения - {2};Прибытие - {3};Авиакомпания -{4};" +
                                "Терминал -{5};Ворота - {6}",
                                airplanes[i].NomerPP, airplanes[i].NomerReisa, airplanes[i].destination, airplanes[i].VremyaPribytiya,
                                airplanes[i].Aviacompany, airplanes[i].Terminal, airplanes[i].Gate);
                            }

                            NomerPP = CheckInput("Введите доступный номерПП для рейса") - 1;
                            if (NomerPP >= 0 && NomerPP < AirplaneCount)
                            {
                                Airplane[] airplanesNew = new Airplane[NomerPP];
                                for (int j = 0; j < airplanes.Length; j++)
                                {
                                    if (j < NomerPP)
                                    {
                                        airplanesNew[j] = airplanes[j];
                                    }
                                    else if (j > NomerPP)
                                    {
                                        airplanesNew[j - 1] = airplanes[j];
                                    }
                                }
                                var x = new CountArray(NomerPP);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Такого рейса не существует, выберете корректный\r\nEnter для продолжения");
                                Console.ReadKey();
                                goto case 2;
                            }
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
            }
            else if (Punkt == (int)ParagraphPassword.User)
            {
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
            }
            else
            {
                Console.WriteLine("Введите доступный пункт");
                goto AdminPass;
            }
                    
            }
            Console.ReadLine();
        }
         
    }
 
}
