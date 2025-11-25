using System;

namespace OOP_SAMPLE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Testing GProgression Class ===\n");

            // Тест 1: Создание объектов и проверка свойств
            Console.WriteLine("Test 1: Creating progressions and testing properties");
            try
            {
                GProgression prog1 = new GProgression(0, 3);


                prog1.PrintInfo();
                Console.WriteLine($"First term: {prog1.First}, Step: {prog1.Step}\n");

                GProgression prog2 = new GProgression(10, 0.5);
                prog2.PrintInfo();
                Console.WriteLine($"First term: {prog2.First}, Step: {prog2.Step}\n");

                // Тест валидации - попытка создать прогрессию с шагом 0
                try
                {
                    GProgression prog3 = new GProgression(1, 0);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Validation test passed: {ex.Message}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Тест 2: Проверка метода GetSumInRange
            Console.WriteLine("Test 2: Testing GetSumInRange method");
            GProgression prog4 = new GProgression(1, 2); // 1, 2, 4, 8, 16, ...
            prog4.PrintInfo();

            double sum1 = prog4.GetSumInRange(1, 3); // 1 + 2 + 4 = 7
            Console.WriteLine($"Sum from 1st to 3rd term: {sum1}");

            double sum2 = prog4.GetSumInRange(2, 4); // 2 + 4 + 8 = 14
            Console.WriteLine($"Sum from 2nd to 4th term: {sum2}\n");

            // Тест 3: Проверка метода PrintFirstN
            Console.WriteLine("Test 3: Testing PrintFirstN method");
            GProgression prog5 = new GProgression(3, 2); // 3, 6, 12, 24, 48, ...
            prog5.PrintInfo();
            prog5.PrintFirstN(5);
            Console.WriteLine();

            GProgression prog6 = new GProgression(100, 0.1); // 100, 10, 1, 0.1, 0.01, ...
            prog6.PrintInfo();
            prog6.PrintFirstN(4);
            Console.WriteLine();

            // Тест 4: Прогрессия с шагом 1
            Console.WriteLine("Test 4: Progression with step = 1");
            GProgression prog7 = new GProgression(5, 1); // 5, 5, 5, 5, ...
            prog7.PrintInfo();
            prog7.PrintFirstN(4);
            double sum3 = prog7.GetSumInRange(1, 10); // 5 * 10 = 50
            Console.WriteLine($"Sum from 1st to 10th term: {sum3}\n");

            // Тест 5: Обработка некорректных диапазонов
            Console.WriteLine("Test 5: Testing error handling");
            try
            {
                double invalidSum = prog4.GetSumInRange(3, 1); // start > end
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error handling test passed: {ex.Message}");
            }

            Console.WriteLine("\n=== All tests completed ===");
        }
    }
}