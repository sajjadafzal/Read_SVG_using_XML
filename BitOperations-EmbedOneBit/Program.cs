using System;

namespace BitOperations_EmbedOneBit
{
    class Program
    {
        static void Main(string[] args)
        {
            //uint A = 0b_0000_0000;
            //uint One = 0b_0000_0001;
            uint A = 0;
            uint One = 1;
            uint Zero = 0;

            EmbedAinBFirstShift(One,ref A);
            EmbedAinBFirstShift(Zero, ref A);
            EmbedAinBFirstShift(One, ref A);
            EmbedAinBFirstShift(Zero, ref A);
            Console.WriteLine(A + " : " + Convert.ToString(A, toBase: 2));

            Console.ReadLine();
            
        }

        static public void EmbedAinBFirstShift(uint a ,ref uint b)
        {
            b = b << 1;
            b =  a | b;
        }
    }
}
