using System;
using ClassesInterfaces;

namespace ClassesInterFaces
{
    public sealed class TwoDimensionalArray : HeirArray, ITwoDimentionalArray, IPrinter
    {
        private int[,] arr; //массив
        private float average = 0; //среднее арифметическое

        public TwoDimensionalArray(bool input_mode = false) : base(input_mode)
        {
        }
        private int VerifiedInput(out int n) //ввод количества строк и столбцов в двумерном массиве
        {
            int m;
            bool success;
            do
            {
                Console.Write("Введите количество строк в матрице: ");
                success = int.TryParse(Console.ReadLine(), out m);
            }
            while (!success || m <= 0);
            do
            {
                Console.Write("Введите количество столбцов в матрице: ");
                success = int.TryParse(Console.ReadLine(), out n);
            }
            while (!success || n <= 0);
            return m;
        }
        protected override void InputUser()
        {
            int row;
            int column;
            row = VerifiedInput(out column);
            arr = new int[row, column];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                    average += arr[i, j];
                }
            }
            average /= (arr.GetLength(0) * arr.GetLength(1));
        }
        protected override void InputRandom()
        {
            Random rnd = new Random();
            arr = new int[rnd.Next(2,11), rnd.Next(2,11)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(-200, 201);
                    average += arr[i, j];
                }
            }
            average /= (arr.GetLength(0) * arr.GetLength(1));
        }

        public void AlternativeInputMethod() //ввод элементов массива построчно через пробел
        {
            average = 0;
            Console.WriteLine("Вводите через пробел значения элементов массива по строкам:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine($"Введите через пробел элементы {i} строки:");
                string text = Console.ReadLine();
                string[] words = text.Split(' ');
                if (words.Length != arr.GetLength(1))
                {
                    if (words.Length < arr.GetLength(1))
                    {
                        Console.WriteLine("Вы ввели меньше элементов, в конце будут нули");
                        for (int j = 0; j < words.Length; j++)
                        {
                            arr[i, j] = int.Parse(words[j]);
                            average += arr[i, j];
                        }
                        for (int j = words.Length; j < arr.GetLength(1); j++)
                        {
                            arr[i, j] = 0;
                        }
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели больше элементов, лишние будут отброшены");
                    }
                }
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = int.Parse(words[j]);
                    average += arr[i, j];
                }
            }
            average /= (arr.GetLength(0) * arr.GetLength(1));
        }

        public override void Print() // вывод двумерного массива
        {
            Console.WriteLine("Вывод двумерного массива");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]}\t");
                }
                Console.Write("\n");
            }
        }

        public void OutArrEvenReverse() // вывод двумерного массива, четные строки в обратном порядке
        {
            Console.WriteLine("Вывод двумерного массива, четные строки в обратном порядке");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    int index = j;
                    if (i % 2 == 0)
                    {
                        index = arr.GetLength(1) - j - 1;

                    }
                    Console.Write($"{arr[i, index]}\t");
                }
                Console.Write("\n");
            }
        }

        public override float Average() //среднее арифметическое элементов массива
        {
            return average;
        }

        public void Det()
        {
            if (arr.GetLength(0) != arr.GetLength(1))
            {
                Console.WriteLine("Вычислить определитель можно только у квадратной матрицы");
                return;
            }
            else
            {
                double[,] matrix = new double[arr.GetLength(0), arr.GetLength(0)];
                double det = 1;
                // копируем матрицу в тип double для преобразования к треугольной
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        matrix[i, j] = arr[i, j];
                    }

                }
                // приводим матрицу к треугольному виду (алгоритм Гаусса)
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    for (int j = i + 1; j < matrix.GetLength(0); j++)
                    {
                        double koef = matrix[j, i] / matrix[i, i];
                        for (int k = i; k < matrix.GetLength(0); k++)
                            matrix[j, k] -= matrix[i, k] * koef;
                    }
                }
                // выводим треугольную матрицу, чтобы увидеть, что она треугольная, и считаем определитель
                Console.WriteLine("Треугольная матрица");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        Console.Write("{0:f1}\t", matrix[i, j]);
                    }
                    Console.WriteLine();
                    det *= matrix[i, i];
                }
                Console.WriteLine("Определитель матрицы равен {0:f0}", det);
            }
        }
    }

}
