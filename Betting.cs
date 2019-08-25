using System;

namespace Roulette
{
    class Betting
    {

        RouletteWheel wheel = new RouletteWheel();
        private (int, char) results;
        public int money = 1000;
        public int betAmount;
        public int winCount;


        int [] firstColumn  = new int [12];
        int [] secondColumn = new int [12];
        int[] thirdColumn   = new int [12];
        int number;
        char color;
        int evenOdd;
        int columns;
        int streetID;
        int highLow;
        int dozen;
        int doubleRow;
        int split;
        int[,] corner = new int[22,4];

public void Menu()
        {
            Console.WriteLine("\t\t\tWELCOME MY ROULETTE GAME");
            Console.WriteLine("__________________________________________________________");
            Console.WriteLine();
            Console.WriteLine($"\t\t\t\t\t\t\tCURRENT MONEY:{money}");

            Console.WriteLine("Please enter the amount you'd like to bet.......");
            var ValidBetAmount = int.TryParse(Console.ReadLine(), out betAmount);

            while(!ValidBetAmount && betAmount <= money)
            {
                Console.WriteLine("YOU DO NOT HAVE ENOUGH MONEY TO PLACE THAT BET. PLEASE REENTER YOUR BET.......");
                ValidBetAmount = int.TryParse(Console.ReadLine(), out betAmount);
            }

            DisplayBets();

        }
 private void Win()
        {
            money += betAmount;
            winCount++;

            Console.WriteLine($"NUMBER ROLLED: {results.Item1} COLOR: {results.Item2}");
            Console.WriteLine($"CONGRATULATIONS YOU WON {betAmount}");
        }

        private void Lose()
        {
            money -= betAmount;
            winCount--;

            Console.WriteLine($"NUMBER ROLLED: {results.Item1} COLOR: {results.Item2}");
            Console.WriteLine($"YOU DID NOT WIN..... BETTER LUCK NEXT TIME!");
        }


        private void SetCornerValues()
        {
            corner[0, 0] = 1;
            corner[0, 1] = 2;
            corner[0, 2] = 4;
            corner[0, 3] = 5;


            corner[1, 0] = 2;
            corner[1, 1] = 3;
            corner[1, 2] = 5;
            corner[1, 3] = 6;



            corner[2, 0] = 4;
            corner[2, 1] = 5;
            corner[2, 2] = 7;
            corner[2, 3] = 8;

            corner[3, 0] = 5;
            corner[3, 1] = 6;
            corner[3, 2] = 8;
            corner[3, 3] = 9;

            corner[4, 0] = 7;
            corner[4, 1] = 8;
            corner[4, 2] = 10;
            corner[4, 3] = 11;

            corner[5, 0] = 8;
            corner[5, 1] = 9;
            corner[5, 2] = 11;
            corner[5, 3] = 12;

            corner[6, 0] = 10;
            corner[6, 1] = 11;
            corner[6, 2] = 13;
            corner[6, 3] = 14;


            corner[7, 0] = 11;
            corner[7, 1] = 12;
            corner[7, 2] = 14;
            corner[7, 3] = 15;

            corner[8, 0] = 13;
            corner[8, 1] = 14;
            corner[8, 2] = 16;
            corner[8, 3] = 17;

            corner[9, 0] = 14;
            corner[9, 1] = 15;
            corner[9, 2] = 17;
            corner[9, 3] = 18;

            corner[10, 0] = 16;
            corner[10, 1] = 17;
            corner[10, 2] = 19;
            corner[10, 3] = 20;

            corner[11, 0] = 17;
            corner[11, 1] = 18;
            corner[11, 2] = 20;
            corner[11, 3] = 21;


            corner[12, 0] = 19;
            corner[12, 1] = 20;
            corner[12, 2] = 22;
            corner[12, 3] = 23;

            corner[13, 0] = 20;
            corner[13, 1] = 21;
            corner[13, 2] = 23;
            corner[13, 3] = 24;


            corner[14, 0] = 22;
            corner[14, 1] = 23;
            corner[14, 2] = 25;
            corner[14, 3] = 26;

            corner[15, 0] = 23;
            corner[15, 1] = 24;
            corner[15, 2] = 26;
            corner[15, 3] = 27;

            corner[16, 0] = 25;
            corner[16, 1] = 26;
            corner[16, 2] = 28;
            corner[16, 3] = 29;

            corner[17, 0] = 26;
            corner[17, 1] = 27;
            corner[17, 2] = 29;
            corner[17, 3] = 30;

            corner[18, 0] = 28;
            corner[18, 1] = 29;
            corner[18, 2] = 31;
            corner[18, 3] = 32;

            corner[19, 0] = 29;
            corner[19, 1] = 30;
            corner[19, 2] = 32;
            corner[19, 3] = 33;

            corner[20, 0] = 31;
            corner[20, 1] = 32;
            corner[20, 2] = 34;
            corner[20, 3] = 35;

            corner[21, 0] = 32;
            corner[21, 1] = 33;
            corner[21, 2] = 35;
            corner[21, 3] = 36;

        }



        public void DisplayBets()
        {
            Console.Clear();
            
            Console.Write("1.PICK WINNING NUMBER||2.EVEN/ODD||3.COLOR||4.LOWS/HIGHS||5.DOZENS" +
                          "||6.COLUMNS||7.STREET||8.DOUBLE ROWS||9.SPLIT||0.CORNER||Enter.PlaceBet|| ESC.PREVIOUS MENU");
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
                    Corner();
                    break;

                //case ConsoleKey.Enter:
                //    WinLoose();
                //    break;

                case ConsoleKey.Escape:
                    Menu();
                    break;
                default:
                    DisplayBets();
                    break;
            }
        }

        private void Color()
        {
            Console.Clear();
            Console.WriteLine("PLEASE ENTER R.FOR RED NUMBERS ||B.FOR BLACK NUMBERS");
            color = Convert.ToChar( Console.ReadLine());

            if(color == results.Item2)
            {
                Win();
            }

            else
            {
                Lose();
            }

            DisplayBets();
        }

            private void LowHigh()
        {
            Console.Clear();
            Console.WriteLine("PLEASE ENTER 1.FOR LOW NUMBERS ||2.FOR HIGH NUMBERS");

            var valid = int.TryParse(Console.ReadLine(), out highLow);

            while (!valid || (highLow < 1 || highLow > 2))
            {
                Console.Clear();
                Console.WriteLine("INVALID INPUT");
                Console.WriteLine("PLEASE ENTER 1.FOR LOW NUMBERS ||2.FOR HIGH NUMBERS");

                valid = int.TryParse(Console.ReadLine(), out highLow);
            }
                if (highLow == 1 && results.Item1 < 13)
                {
                    Win();
                }

                else if (highLow == 2 && results.Item1 > 12)
                {
                    Win();
                }

                else
                {
                    Lose();
                }

            DisplayBets();
            
        }

        private void Dozens()
        {
            Console.Clear();
            Console.WriteLine("PLEASE ENTER 1.FOR NUMBERS 1-12||2.FOR NUMBERS 13-24||3.FOR NUMBERS 25-36");

            var valid = int.TryParse(Console.ReadLine(), out dozen);

            while (!valid || (dozen < 0 || dozen > 3))
            {
                Console.Clear();
                Console.WriteLine("INVALID INPUT");
                Console.WriteLine("PLEASE ENTER 1.FOR NUMBERS 1-12||2.FOR NUMBERS 13-24||3.FOR NUMBERS 25-36");

                valid = int.TryParse(Console.ReadLine(), out columns);
            }

            if (dozen == 1 && results.Item1 < 13 )
            {
                Win();
            }

            else if (dozen == 2 && results.Item1 < 25 && results.Item1 > 12)
            {

                Win();
            }
            
            else if (dozen == 3 && results.Item1 < 36 && results.Item1 > 24)
            {
                Win();
            }

            else
            {
                Lose();
            }

            DisplayBets();

        }

        private void Columns()
        {
            var c1 = 1;
            var c2 = 2;
            var c3 = 3;
            for (int i = 0; i < 12; i++)
            {
                firstColumn[i]  = c1;
                secondColumn[i] = c2;
                thirdColumn[i]  = c3;

                c1 += 3;
                c2 += 3;
                c3 += 3;

            }


            Console.Clear();
            Console.WriteLine();
            Console.Write("PLEASE ENTER COLUM NUMBER BETWEEN 0-2....");

            var valid = int.TryParse(Console.ReadLine(), out columns);

            while (!valid || (columns < 0 || columns > 2))
            {
                Console.Clear();
                Console.WriteLine("INVALID INPUT");
                Console.Write("PLEASE ENTER COLUM NUMBER BETWEEN 0-2....");
                valid = int.TryParse(Console.ReadLine(), out columns);
            }



            if (columns == 0)
            {
                foreach (var item in firstColumn)
                {
                    if (results.Item1 == item)
                    {
                        Win();
                    }
                }
            }

            else if (columns == 1)
            {
                foreach (var item in secondColumn)
                {
                    if (results.Item1 == item)
                    {
                        Win();
                    }
                }
            }

            else if (columns == 2)
            {
                foreach (var item in thirdColumn)
                {
                    if (results.Item1 == item)
                    {
                        Win();
                    }
                }

                
            }

            else
            {
                Lose();
            }

            DisplayBets();
        }

        private void Street()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("PLEASE ENTER A  STREET NUMBER....");
            var valid = int.TryParse(Console.ReadLine(), out streetID);

            while (!valid || (streetID < 1 || streetID > 12))
            {
                Console.Clear();
                Console.WriteLine("INVALID INPUT");
                Console.Write("PLEASE ENTER A NUMBER TO SPLIT ON....");
                valid = int.TryParse(Console.ReadLine(), out doubleRow);
            }

            int[,] street = new int[12,3];
            var count = 0;
            for (int i = 0; i < 12; i++)
            {
                street[i, 0] = count + 1;
                street[i, 1] = count + 2;
                street[i, 2] = count + 3;

                count += 3;
            }

            for (int i = 0; i < 4; i++)
            {
                if (results.Item1 == street[streetID, i])
                {
                    Win();
                }

            }

            DisplayBets();

        }

        private void DoubleRows()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("PLEASE ENTER A  ROW NUMBER....");
            var valid = int.TryParse(Console.ReadLine(), out doubleRow);

            while (!valid || (doubleRow < 1 || doubleRow > 12))
            {
                Console.Clear();
                Console.WriteLine("INVALID INPUT");
                Console.Write("PLEASE ENTER A NUMBER TO SPLIT ON....");
                valid = int.TryParse(Console.ReadLine(), out doubleRow);
            }

            for (int i = 0; i < 4; i++)
            {
                if ((results.Item1 == corner[doubleRow,i]) || (results.Item1 == corner[(doubleRow* 2) , i]))
                {
                    
                }
            }

            DisplayBets();
        }

        private void Split()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("PLEASE ENTER A NUMBER TO SPLIT ON....");
            var valid = int.TryParse(Console.ReadLine(), out split);

            while(!valid || (split < 1 || split > 36))
            {
                Console.Clear();
                Console.WriteLine("INVALID INPUT");
                Console.Write("PLEASE ENTER A NUMBER TO SPLIT ON....");
                 valid = int.TryParse(Console.ReadLine(), out split);
            }

            if (split == results.Item1 || split == results.Item1 - 3)
            {
                Win();
            }

            else
            {
                Lose();
            }

            DisplayBets();

        }

       
        private void Corner()
        {
            Console.Clear();
            SetCornerValues();
            int cornerIndex = 0;
            Console.Write("PLEASE ENTER A CORNER NUMBER BETWEEN 0 AMD 21........");
            var valid = int.TryParse(Console.ReadLine(), out cornerIndex);

            while(!valid || ( cornerIndex < 0 || cornerIndex > 21))
            {
                Console.Clear();

                Console.WriteLine("INVALID INPUT");
                Console.Write("PLEASE ENTER A CORNER NUMBER BETWEEN 0 AMD 21........");
                valid = int.TryParse(Console.ReadLine(), out cornerIndex);
            }


            for (int i = 0; i < 4; i++)
            {
                if (results.Item1 == corner[cornerIndex, i])
                {
                    Win();
                }
            }

            DisplayBets();
            
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
                Win();
            }

            else
            {
                Lose();
            }

            DisplayBets();
        }

        private void EvenOdd()
        {
            Console.Clear();
            Console.WriteLine("ENTER 1. FOR ODD||2.FOR EVEN");
            var valid = int.TryParse(Console.ReadLine(), out evenOdd);

            while (!valid && ((evenOdd !=1)|| (evenOdd != 2) ))
            {
                Console.Clear();
                Console.WriteLine("WRONG INPUT");
                Console.WriteLine("ENTER 1. FOR ODD||2.FOR EVEN");
                 valid = int.TryParse(Console.ReadLine(), out evenOdd);
            }

            if (evenOdd == 1 && !IsEven())
            {
                Win();
            }

            else if (evenOdd == 2 && IsEven())
            {
                Win();
            }
            else
            {
                Lose();
            }

            DisplayBets();
        }

        
      

        bool IsEven()
        {
            if (results.Item1 % 2 == 0 )
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
