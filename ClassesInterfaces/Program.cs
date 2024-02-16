using System;
using ClassesInterfaces;
using ClassesInterFaces;

class Program
{
    static void Main()
    {
        // создаем массивы разных видов
        IHeirArray[] test = new IHeirArray[3];
        test[0] = new OneDimensionalArray();
        test[1] = new TwoDimensionalArray();
        test[2] = new StepDimensionalArray();
        // вывод массива и среднего
        for (int i = 0; i < test.Length; i++)
        {
            test[i].Print();
            Console.WriteLine($"Среднее значение элементов массива равно {test[i].Average()} \n");
        }
        // проверка работы интерфейсов
        OneDimensionalArray test_one = new OneDimensionalArray(true);
        test_one.Print();
        ((IOneDimentionalArray)test_one).DelRep();
        TwoDimensionalArray test_two1 = new TwoDimensionalArray();
        test_two1.Print();
        ((ITwoDimentionalArray)test_two1).OutArrEvenReverse();
        TwoDimensionalArray test_two2 = new TwoDimensionalArray(true);
        test_two2.Print();
        ((ITwoDimentionalArray)test_two2).Det();
        StepDimensionalArray test_three = new StepDimensionalArray();
        test_three.Print();
        ((IStepDimentionalArray)test_three).ChangeEven();
        Console.WriteLine("Четные элементы заменены на произведение индексов");
        test_three.Print();
        DaysOfWeek day = new DaysOfWeek();
        // собираем все вместе и печатаем
        IPrinter[] printers = new IPrinter[8];
        printers[0] = test[0];
        printers[1] = test[1];
        printers[2] = test[2];
        printers[3] = test_one;
        printers[4] = test_two1;
        printers[5] = test_two2;
        printers[6] = test_three;
        printers[7] = day;
        for (int i = 0; i < printers.Length; i++)
        {
            printers[i].Print();
        }
    }
}
