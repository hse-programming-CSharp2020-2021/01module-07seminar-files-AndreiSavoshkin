using System;
using System.IO;

/*
 * По массиву A целых чисел со значениями из диапазона (1; 10000] создать массив целых чисел B,
 * в котором на каждой позиции стоит ближайшая степень двойки меньшая значения из массива A у той же позиции.
 * Например, A = {30, 100, 300} B = {16, 64, 256}.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 3 10 20
 *
 * Пример выходных данных:
 * 2 8 16
 */

namespace Task02
{
    class Program
    {
        private const string inputPath = "input.txt";
        private const string outputPath = "output.txt";
        private const int left = 1;
        private const int right = 10000;

        static int[] ReadFile(string path)
        {
            string[] elements = File.ReadAllText(path).Split(' ');
            int[] array = new int[elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                array[i] = int.Parse(elements[i]);
            }
            return array;
        }

        static bool CheckArray(int[] array)
        {
            bool isInclude = true;
            foreach (var item in array)
            {
                if (item > right || item <= left)
                {
                    isInclude = false;
                    break;
                }
            }
            return isInclude;
        }

        static int[] ConvertArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GetPowerTwo(array[i]);
            }
            return array;
        }

        static int GetPowerTwo(int n)
        {
            int result = 1;
            while (result * 2 < n)
            {
                result *= 2;
            }
            return result;
        }

        static void WriteFile(string path, int[] array)
        {
            string output = "";
            for (int i = 0; i < array.Length; i++)
            {
                output += array[i].ToString() + " ";
            }
            File.WriteAllText(path, output);
        }

        // you do not need to fill your file manually, you can work with console input
        static void Main(string[] args)
        {
            // do not touch
            FillFile();

            int[] A;
            int[] B;

            try
            {
                A = ReadFile(inputPath);

                if (!CheckArray(A))
                {
                    Console.WriteLine("Incorrect Input");
                    return;
                }

                B = ConvertArray(A);
                WriteFile(outputPath, B);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // do not touch
            ConsoleOutput();
        }

        #region Testing methods for Github Classroom, do not touch!

        static void FillFile()
        {
            try
            {
                File.WriteAllText(inputPath, Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ConsoleOutput()
        {
            try
            {
                Console.WriteLine(File.ReadAllText(outputPath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}