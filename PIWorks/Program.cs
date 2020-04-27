using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIWorks
{
    class Program
    {
        public static bool[] Erastosthenes(int max)
        {
            bool[] notPrime = new bool[max + 1];
            notPrime[0] = true;
            notPrime[1] = true;
            for (int i = 2; i <= max; i++)
            {
                if (notPrime[i] == false && i * i <= max)
                {
                    for (int j = i * i; j <= max; j = j + i)
                        notPrime[j] = true;
                }
            }
            return notPrime;
        }

        public static int Level(int i)
        {
            int kat = 1;
            int x = 0;
            while ((kat * kat + kat) / 2 != i)
            {
                x += kat;
                kat++;
            }
            return kat;

        }
        public static int[,] ConvertTo2D(int[] arr)
        {
            int layer = Level(arr.Length);
            int[,] ret = new int[layer, layer];
            bool[] notPrime = (Erastosthenes(arr.Max()));
            int curr = 0;
            for (int i = 0; i < layer; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (notPrime[arr[curr]] == true)
                    {
                        ret[i, j] = arr[curr];
                    }
                    curr++;
                }
            }
            for (int i = layer - 2; i > -1; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    ret[i, j] += Math.Max(ret[i + 1, j], ret[i + 1, j + 1]);
                }
            }
            return ret;
        }
        static void Main(string[] args)
        {
            string t = @"            215
                                     193 124
                                     117 237 442
                                     218 935 347 235
                                     320 804 522 417 345
                                     229 601 723 835 133 124
                                     248 202 277 433 207 263 257
                                     359 464 504 528 516 716 871 182
                                     461 441 426 656 863 560 380 171 923
                                     381 348 573 533 447 632 387 176 975 449
                                     223 711 445 645 245 543 931 532 937 541 444
                                     330 131 333 928 377 733 017 778 839 168 197 197
                                     131 171 522 137 217 224 291 413 528 520 227 229 928
                                     223 626 034 683 839 053 627 310 713 966 629 817 410 121
                                     924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";
            int[] inp = t.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
            var q = ConvertTo2D(inp);
            Console.WriteLine(q[0,0]);


        }
    }
}
