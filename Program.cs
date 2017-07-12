using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

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
                        int temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                        swaps++;
                        swapped = true;
                    }
                    comparisons++;
                }

                if (!swapped)
                    break;
                swapped = false;

                for (int i = result.Length - 2; i >= 0; i--)
                {
                    if (result[i] > result[i + 1])
                    {
                        int temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                        swaps++;
                        swapped = true;
                    }
                    comparisons++;
                }
            } while (swapped);

            return result;
        }

        static Random R = new Random();

        static void Main(string[] args)
        {
            WriteLine("Введите длину массива");
            int length = 0;
            while (!int.TryParse(ReadLine(),out length) || length <= 0)
                WriteLine(" Неправильный ввод, ожидалось положительное число");

            int[] array = new int[length];
            for (int i = 0; i < length; i++)
                array[i] = R.Next(-100, 101);
            WriteLine("Ваш массив: ");
            WriteLine(string.Join(" ",array.AsEnumerable()));
            WriteLine();

            WriteLine("Перемешивание:");
            int c1, s1;
            int[] arr1 = CocktailSort(array, out c1, out s1);
            WriteLine("Случайный массив:\n{0} сравнений\n{1} перестановок",c1,s1);
            arr1 = CocktailSort(arr1, out c1, out s1);
            WriteLine("Отсортированный массив:\n{0} сравнений\n{1} перестановок", c1, s1);
            Array.Reverse(arr1);
            arr1 = CocktailSort(arr1, out c1, out s1);
            WriteLine("Перевёрнутый массив:\n{0} сравнений\n{1} перестановок", c1, s1);
            WriteLine();

            WriteLine("Сортировка вставками");
            int c2, s2;
            int[] arr2 = InsertionSort(array, out c2, out s2);
            WriteLine("Случайный массив:\n{0} сравнений\n{1} перестановок", c1, s1);
            arr2 = InsertionSort(arr2, out c1, out s1);
            WriteLine("Отсортированный массив:\n{0} сравнений\n{1} перестановок", c1, s1);
            Array.Reverse(arr2);
            arr2 = InsertionSort(arr2, out c1, out s1);
            WriteLine("Перевёрнутый массив:\n{0} сравнений\n{1} перестановок", c1, s1);

            ReadKey(true);

        }
    }
}