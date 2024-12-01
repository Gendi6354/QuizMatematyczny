using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace QuizMatematyczny
{
    internal class Gra
    {
        private List<int> tablicaPunktow = new List<int>();
        private List<int> iloscRund = new List<int>();
        private Random rnd = new Random();
        public int PobierzLiczbeRund()
        {
            Console.Write("Podaj ile ma byc rund: ");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch { return PobierzLiczbeRund(); }
        }
        private void pytanieNowaGra()
        {
            Console.Write("Czy chcesz grac dalej ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Tak");
            Console.ResetColor();
            Console.Write("/");
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Nie");
            Console.ResetColor();
            string odp = Console.ReadLine();
            if (odp.ToUpper() == "TAK")
            {
                RozpocznijGre(PobierzLiczbeRund());
            }
            else if (odp.ToUpper() == "NIE")
            {
                Console.WriteLine($"Koniec skonczyles z nastepujacymi wynikami ");
                for (int i = 0; i < tablicaPunktow.Count; i++)
                {
                    Console.WriteLine($"{tablicaPunktow[i]} punkty na {iloscRund[i]} rundy ");
                }
                Console.ReadKey();

            }
        }
        private void sprawdzOdp(string odp,int prawOdp,ref int punkty)
        {
            if (int.Parse(odp) == prawOdp)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Brawo prawidlowa odpowiedz");
                Console.ResetColor();
                punkty++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Niestety to zla odpowiedz");
                Console.ResetColor();
            }
        }
        private void Dzialanie(char znak,int x , int y,ref int punkty)
        {
            Console.Write($"Podaj wynik dzialania  {x}{znak}{y}: ");
            string odp;
            int prawOdp = 0;
            switch (znak.ToString())
            {
                case "*":
                    {
                        prawOdp = x *y; break;
                    }
                case "/":
                    {
                        prawOdp = x / y; break;
                    }
                case "+":
                    {
                        prawOdp = x + y; break;
                    }
                case"-":
                    {
                        prawOdp = x - y; break;
                    }
            }
            try
            {
                odp = Console.ReadLine();
                sprawdzOdp(odp, prawOdp,ref punkty);
            }
            catch 
            {
                Console.Write($"Podaj wynik dzialania  {x}{znak}{y}: ");
                odp = Console.ReadLine();
                sprawdzOdp(odp, prawOdp,ref punkty);
            }
        }

        public void RozpocznijGre(int liczbaRund)
        {
            iloscRund.Add(liczbaRund);
            int punkty = 0;
            for (int i = 0; i < liczbaRund; i++)
            {
                int x = rnd.Next(0, 10);
                int y = rnd.Next(1, 10);
                int rodzajDzialania = rnd.Next(0,3);
                switch(rodzajDzialania)
                {
                    case 0:
                        try
                        {
                            Dzialanie('+', x, y, ref punkty); break;
                        }
                        catch
                        {
                            goto case 0;
                        }
                    case 1:
                        try
                        {
                            Dzialanie('-', x, y, ref punkty); break;
                        }
                        catch
                        {
                            goto case 1;
                        }
                    case 2:
                        try
                        {
                            Dzialanie('*', x, y, ref punkty); break;
                        }
                        catch
                        {
                          goto case 2;
                        }
                    case 3:
                        try
                        {
                            Dzialanie('/', x, y, ref punkty); break;
                        }
                        catch
                        {
                            goto case 3;
                        }
                }
                
            }
            tablicaPunktow.Add(punkty);
            Console.WriteLine($"Skonczyles gre z {punkty} punktami");
            pytanieNowaGra();
        }
    }
}

