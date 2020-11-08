using System;
using System.IO;

/*
 * По массиву A целых чисел со значениями из диапазона [-10;10] создать массив булевских значений L.
 * Количество элементов в массивах совпадает.
 * На местах неотрицательных элементов в массиве A
 * в массиве L стоят значения true, на месте отрицательных – false.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 0 -1
 *
 * Пример выходных данных:
 * true false
 */

namespace _01_07_Files
{
    class Program
    {
        private const string inputPath = "input.txt";
        private const string outputPath = "output.txt";
        private const int left = -10;
        private const int right = 10;

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
                if (item > right || item < left)
                {
                    isInclude = false;
                    break;
                }
            }
            return isInclude;
        }

        static bool[] IntToBoolArray(int[] array)
        {
            bool[] boolArray = new bool[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                boolArray[i] = array[i] >= 0;
            }
            return boolArray;
        }

        static void WriteFile(string path, bool[] array)
        {
            string output = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i])
                    output += "true ";
                else
                    output += "false ";
            }
            File.WriteAllText(path, output);
        }

        // you do not need to fill your file, you can work with console input
        static void Main(string[] args)
        {
            // do not touch
            FillFile();

            int[] A;
            bool[] L;

            try
            {
                A = ReadFile(inputPath);

                if (!CheckArray(A))
                {
                    Console.WriteLine("Incorrect Input");
                    return;
                }

                L = IntToBoolArray(A);
                WriteFile(outputPath, L);
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