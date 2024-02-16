using System;

namespace ClassesInterfaces
{
    public class DaysOfWeek : IPrinter
    {
        private DateTime birthday;
        public DaysOfWeek()
        {
            Console.Write("Input your year, month and day of birth via space: ");
            string text = Console.ReadLine();
            string[] words = text.Split(' ');
            birthday = new DateTime(int.Parse(words[0]), int.Parse(words[1]), int.Parse(words[2]));
        }
        public void Print()
        {
            DateTime today = DateTime.Today;
            Console.WriteLine($"You were born on  {birthday.DayOfWeek}");
            Console.WriteLine($"And today is {today.DayOfWeek}");
            Console.WriteLine("On Monday I am sleepy,\n" +
                "On Tuesday I am glad,\n" +
                "On Wednesday I am happy,\n" +
                "On Thursday I am sad,\n" +
                "On Friday I am tired, I don’t want to work,\n" +
                "On Saturday and Sunday I go for a walk.");
        }
    }
}
