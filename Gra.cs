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
            catch
            {
                
                return PobierzLiczbeRund();
            }



        }
        private void pytanieNowaGra()
        {
            Console.WriteLine("Czy chcesz grac dalej: Tak/Nie ");
            string odp = Console.ReadLine();
            if (odp == "Tak")
            {
                RozpocznijGre(PobierzLiczbeRund());
            }
            else if (odp == "Nie")
            {
                Console.WriteLine($"Koniec skonczyles z nastepujacymi wynikami ");
                for (int i = 0; tablicaPunktow.Count > 0; i++)
                {
                    Console.Write($"{tablicaPunktow[i]} punkty na {iloscRund[i]} rundy ");
                    Console.ReadKey();
                }

            }


        }
        private void sprawdzOdp(string odp,int prawOdp,int punkty)
        {
            if (int.Parse(odp) == prawOdp)
            {
                Console.WriteLine("Brawo prawidlowa odpowiedz");
                punkty++;
            }
            else
            {
                Console.WriteLine("Niestety to zla odpowiedz");
            }
        }
        private void Dzialanie(char znak,int x , int y,int punkty)
        {
            Console.Write($"Podaj wynik dzialania  {x}{znak}{y}: ");
            string odp;
            int prawOdp = 0;
            switch (znak.ToString())
            {
                case "*":
                    {prawOdp = x *y;break;}
                case "/":
                    {
                        prawOdp = x / y;
                        break;
                    }
                case "+":
                    {
                        prawOdp = x + y;
                        break;
                    }
                case"-":
                    {
                        prawOdp = x - y;
                        break;
                    }
            }
            odp = Console.ReadLine();
            sprawdzOdp(odp, prawOdp, punkty);
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
                            Dzialanie('+', x, y, punkty);
                            break;
                        }
                        catch
                        {
                            goto case 0;
                        }
                    case 1:
                        try
                        {
                            Dzialanie('-', x, y, punkty);
                            break;
                            ;
                        }
                        catch
                        {
                            goto case 1;
                        }
                    case 2:
                        try
                        {
                            Dzialanie('*', x, y, punkty);
                            break;
                        }
                        catch
                        {
                          goto case 2;
                        }

                        
                    case 3:
                        try
                        {

                            Dzialanie('/', x, y, punkty);
                            break;
                        }
                        catch
                        {
                            goto case 3;
                        }
                }
                
            }
            Console.WriteLine($"Skonczyles gre z {punkty} punktami");
            tablicaPunktow.Add(punkty);
            pytanieNowaGra();
        }
    }
}
