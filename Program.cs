using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    class Program
    {
        static int[] InsertionSort(int[] array, out int comparisons, out int swaps)
        {
            comparisons = 0;
            swaps = 0;
            int[] result = new int[array.Length];
            array.CopyTo(result, 0);

            for (int i = 1; i < result.Length; i++)
            {
                int temp = result[i];
                int j = i;

                while (j > 0 && result[j - 1] > temp)
                {
                    comparisons++;
                    result[j] = result[--j];
                    swaps++;
                }
                comparisons++;
                result[j] = temp;
            }

            return result;
        }

        static int[] CocktailSort(int[] array, out int comparisons, out int swaps)
        {
            comparisons = 0;
            swaps = 0;
            int[] result = new int[array.Length];
            array.CopyTo(result, 0);
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 0; i <= result.Length - 2; i++)
                {
                    if(result[i] > result[i + 1])
                    {
                        comparisons++;
                        int temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                        swaps++;
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
                swapped = false;

                for (int i = result.Length - 2; i >= 0; i--)
                {
                    if (result[i] > result[i + 1])
                    {
                        comparisons++;
                        int temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                        swaps++;
                        swapped = true;
                    }
                }
            } while (swapped);

            return result;
        }

        static void Main(string[] args)
        {
        }
    }
}
