using System;
using ClassesInterfaces;

namespace ClassesInterFaces
{
    public sealed class StepDimensionalArray : HeirArray, IStepDimentionalArray, IPrinter
    {
        private int[][] arr; //массив
        private float average = 0; //среднее арифметическое элементов массива
        private float[] average_line; //массив средних арифметических вложенных массивов

        public StepDimensionalArray(bool input_mode = false) : base(input_mode)
        {
        }
        private int VerifiedInput() //ввод количества ступенек массива
        {
            int n;
            bool success;
            do
            {
                Console.Write("Введите колмчество ступенек в массиве: ");
                success = int.TryParse(Console.ReadLine(), out n);
            }
            while (!success || n <= 0);
            return n;
        }
        protected override void InputUser()
        {
            int row = VerifiedInput();
            arr = new int[row][];
            average_line = new float[row];
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                average_line[i] = 0;
                Console.WriteLine($"Введите количество элементов для ступеньки {i}:");
                int n = int.Parse(Console.ReadLine());
                arr[i] = new int[n];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"Ступенька [{i}], элемент [{j}]: ");
                    arr[i][j] = int.Parse(Console.ReadLine());
                    count++;
                    average += arr[i][j];
                    average_line[i] += arr[i][j];
                }
                average_line[i] /= arr[i].Length;
            }
            average /= count;
        }
        protected override void InputRandom()
        {
            Random rnd = new Random();
            int row = rnd.Next(3,9);
            arr = new int[row][];
            average_line = new float[row];
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                average_line[i] = 0;
                int n = rnd.Next(1, 11);
                arr[i] = new int[n];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rnd.Next(-20, 21);
                    count++;
                    average += arr[i][j];
                    average_line[i] += arr[i][j];
                }
                average_line[i] /= arr[i].Length;
            }
            average /= count;
        }

        public void AlternativeInputMethod() //ввод элементов массива построчно через пробел
        {
            average_line = new float[arr.Length];
            average = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Введите через пробел {arr[i].Length} значений(я) для ступеньки {i}:");
                string text = Console.ReadLine();
                string[] words = text.Split(' ');
                arr[i] = new int[words.Length];
                for (int j = 0; j < words.Length; j++)
                {
                    arr[i][j] = int.Parse(words[j]);
                    count++;
                    average += arr[i][j];
                    average_line[i] += arr[i][j];
                }
                average_line[i] /= arr[i].Length;
            }
            average /= count;
        }

        public override void Print() // вывод ступеньчатого массива
        {
            Console.WriteLine("Вывод ступеньчатого массива");
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]}\t");
                }
                Console.Write("\n");
            }
        }
        public override float Average() //среднее арифметическое элементов массива
        {
            return average;
        }

        public void AverageLine() //среднее арифметическое элементов массива по ступенькам
        {
            Console.WriteLine("Среднее арифметическое элементов массива по ступенькам");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Ступенька {i} среднее арифметическое {average_line[i]}");
            }
        }

        public void ChangeEven()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] % 2 == 0)
                    {
                        arr[i][j] = i * j;
                    }
                }
            }
        }

    }
}

