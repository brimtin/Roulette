using System;

namespace Roulette
{
    class RouletteWheel
    {


        public char[] color;
        public int[] bin = new int[38];
        public Random rnd = new Random();

        public RouletteWheel()
        {
            SetWheel();
            SetColor();
        }

        public void SetWheel()
        {
            bin[0] = 0;
            bin[1] = 00;
            for (int i = 2; i < bin.Length; i++)
            {
                bin[i] = i-1;
            }
            
        }

        public void SetColor()
        {
           color = new char []{ 'G','G', 'R','B','R','B','R','B',
                    'R','B','R','B','B','R',
                    'B','R','B','R','B','R',
                    'R','B','R','B','R','B',
                    'R','B','R','B','B','R',
                    'B','R','B','R','B','R'};
        }

        public (int, char) spinWheel()
        {
            var i = rnd.Next(0, 38);

            var c = rnd.Next(3, 38);

           return (bin[i], color[c]);
        }
    }
}
