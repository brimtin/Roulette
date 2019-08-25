using System;

namespace Roulette
{
    class Program
    {

        
        static void Main(string[] args)
        {


            Console.Clear();

            Console.Write("1.PICK WINNING NUMBER||2.EVEN/ODD||3.COLOR||4.LOWS/HIGHS||5.DOZENS" +
                          "||6.COLUMNS||7.STREET||8.DOUBLE ROWS||9.SPLIT||0.CORNER||Enter.PlaceBet");
            Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tCURRENT MONEY:1000");

            Console.ReadLine();

            //for (int i = 0; i < wheel.bin.Length; i++)

            //{ 
            //    Console.WriteLine($"{wheel.bin[i]}  {wheel.color[i]}");
            //}
        }
    }


    class Betting
    {

        RouletteWheel wheel = new RouletteWheel();
        (int, char) results;
        public int money = 1000;
        public int betAmount;
        public int winCount;

        int number;
        char color;
        int evenOdd;
        int row;
        int column;
        int highLow;
        int dozen;
        int doubleROw;
        int split;
        int corner;







        public void DisplayBets()
        {
            Console.Clear();
            
            Console.Write("1.PICK WINNING NUMBER||2.EVEN/ODD||3.COLOR||4.LOWS/HIGHS||5.DOZENS" +
                          "||6.COLUMNS||7.STREET||8.DOUBLE ROWS||9.SPLIT||0.CORNER||Enter.PlaceBet");
            Console.Write($"\t\t\t\t\t\t\t\t\t\t\t\t\t\tCURRENT MONEY:{money}");
            var bet = Console.ReadKey();

            switch (bet.Key)
            {
                case ConsoleKey.D1:
                    PickNumber();
                    break;

                case ConsoleKey.D2:
                    EvenOdd();
                    break;

                case ConsoleKey.D3:
                    Color();
                    break;

                case ConsoleKey.D4:
                    LowHigh();
                    break;

                case ConsoleKey.D5:
                    Dozens();
                    break;

                case ConsoleKey.D6:
                    Columns();
                    break;

                case ConsoleKey.D7:
                    Street();
                    break;

                case ConsoleKey.D8:
                    DoubleRows();
                    break;

                case ConsoleKey.D9:
                    Split();
                    break;

                case ConsoleKey.D0:
                    corner();
                    break;

                case ConsoleKey.Enter:
                    WinLoose();
                    break;

                default:
                    DisplayBets();
                    break;
            }
        }

        private void PickNumber()
        {

            Console.Clear();
            Console.Write("SELECT A NUMBER BETWEEN 0 - 36...............");
            var valid = int.TryParse(Console.ReadLine(), out number);

            while (!valid)
            {
                Console.WriteLine();
                Console.Write("PLEASE ENTER A VALID INPUT............");
                valid = int.TryParse(Console.ReadLine(), out number);
            }

            if (number == results.Item1)
            {
                money += betAmount;
                winCount++;
            }

            else
            {
                money -= betAmount;
                winCount--;
            }
        }

        private void EvenOdd()
        {
            Console.Clear();
            Console.WriteLine(");
        }

        public void Menu()
        {
            Console.WriteLine("\t\t\tWELCOME MY ROULETTE GAME");
            Console.WriteLine("__________________________________________________________");
            Console.WriteLine();
            Console.Write("Please enter the amount you'd like to bet.......");
            var ValidBetAmount = int.TryParse(Console.ReadLine(), out betAmount);

            while(!ValidBetAmount && betAmount <= money)
            {
                Console.WriteLine("YOU DO NOT HAVE ENOUGH MONEY TO PLACE THAT BET. PLEASE REENTER YOUR BET.......");
                ValidBetAmount = int.TryParse(Console.ReadLine(), out betAmount);
            }





        }
      


        

        public bool isLow()
        {
            if (results.Item1 < 19)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public bool FirstRow()
        {
            if (results.Item1 > 0 &&  results.Item1 < 13)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SecondRow()
        {
            if (results.Item1 > 12 && results.Item1 < 25)
            {
               return true;
            }

            else
            {
                return false;
            }
        }
        public bool ThirdRow()
        {
            if (results.Item1 > 24 && results.Item1 < 39)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
