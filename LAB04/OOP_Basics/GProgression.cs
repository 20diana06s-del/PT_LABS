using System;

namespace OOP_SAMPLE
{
    public class GProgression
    {
        // Приватные поля
        private double _first;
        private double _step;

        // Конструктор класса
        public GProgression(double first, double step)
        {
            this.First = first;  // Используем свойство для валидации
            this.Step = step;    // Используем свойство для валидации
        }

        // Свойство для первого члена с валидацией
        public double First
        {
            get { return _first; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("First Element cannot be zero in geometric progression");
                }
                _first = value;
            }
        }

        // Свойство для шага с валидацией (шаг не может быть 0)
        public double Step
        {
            get { return _step; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Step cannot be zero in geometric progression");
                }
                _step = value;
            }
        }

        // Метод для вычисления суммы членов в заданном интервале индексов
        public double GetSumInRange(int start, int end)
        {
            if (start < 1 || end < start)
            {
                throw new ArgumentException("Invalid range: start must be >= 1 and end must be >= start");
            }

            if (_step == 1)
            {
                // Для шага = 1 все члены равны первому
                return _first * (end - start + 1);
            }

            double sum = 0;
            for (int i = start; i <= end; i++)
            {
                sum += GetNthTerm(i);
            }
            return sum;
        }

        // Вспомогательный метод для получения n-го члена прогрессии
        private double GetNthTerm(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException("n must be >= 1");
            }
            return _first * Math.Pow(_step, n - 1);
        }

        // Метод для вывода первых n членов прогрессии
        public void PrintFirstN(int n)
        {
            if (n < 1)
            {
                Console.WriteLine("Number of terms must be at least 1");
                return;
            }

            Console.Write($"First {n} terms: ");
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"{GetNthTerm(i):F2}");
                if (i < n) Console.Write(", ");
            }
            Console.WriteLine();
        }

        // Метод для представления объекта в читаемом виде
        public void PrintInfo()
        {
            Console.WriteLine($"Geometric Progression: First term = {_first}, Step = {_step}");
        }
    }
}