using System;
using System.Text;

namespace CS_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("  Лабораторная работа №3 - CS_Basics");
                Console.WriteLine("  Основы языка программирования C#");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Блок 1. Переменные и операторы");
                Console.WriteLine("2. Блок 2. Условные операторы");
                Console.WriteLine("3. Блок 3. Циклы");
                Console.WriteLine("4. Блок 4. Массивы");
                Console.WriteLine("5. Блок 5. Функции");
                Console.WriteLine("9. Выход");
                Console.Write("\nВыберите блок: ");

                switch (Console.ReadLine())
                {
                    case "1": Block1(); break;
                    case "2": Block2(); break;
                    case "3": Block3(); break;
                    case "4": Block4(); break;
                    case "5": Block5(); break;
                    case "9": exit = true; break;
                    default: Console.WriteLine("Неправильный ввод."); Pause(); break;
                }
            }
        }

        // ===== Блок 1: Переменные и операторы (1, 3, 5) =====
        static void Block1()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Блок 1. Переменные и операторы");
                Console.WriteLine("1. Конвертация температуры (C→F)");
                Console.WriteLine("3. Конвертация валюты (RUB→USD)");
                Console.WriteLine("5. Среднее арифметическое трёх чисел");
                Console.WriteLine("9. Вернуться в меню");
                Console.Write("\nВыберите задачу: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Введите температуру в °C: ");
                        if (double.TryParse(Console.ReadLine(), out double c))
                            Console.WriteLine($"В Фаренгейтах: {c * 9 / 5 + 32:F1}");
                        else
                            Console.WriteLine("Ошибка ввода.");
                        Pause(); break;

                    case "3":
                        const double rate = 0.011;
                        Console.Write("Введите сумму в рублях: ");
                        if (double.TryParse(Console.ReadLine(), out double rub) && rub >= 0)
                            Console.WriteLine($"В долларах: {rub * rate:F2}");
                        else
                            Console.WriteLine("Ошибка ввода.");
                        Pause(); break;

                    case "5":
                        Console.Write("Введите три числа через пробел: ");
                        var parts = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length == 3 &&
                            double.TryParse(parts[0], out double a) &&
                            double.TryParse(parts[1], out double b) &&
                            double.TryParse(parts[2], out double d))
                        {
                            Console.WriteLine($"Среднее: {(a + b + d) / 3:F2}");
                        }
                        else
                            Console.WriteLine("Ошибка ввода.");
                        Pause(); break;

                    case "9": back = true; break;
                    default: Console.WriteLine("Неправильный ввод."); Pause(); break;
                }
            }
        }

        // ===== Блок 2: Условные операторы (1, 3, 5) =====
        static void Block2()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Блок 2. Условные операторы");
                Console.WriteLine("1. Определение времени года");
                Console.WriteLine("3. Координатная четверть");
                Console.WriteLine("5. Время суток по часам");
                Console.WriteLine("9. Вернуться в меню");
                Console.Write("\nВыберите задачу: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Введите номер месяца (1-12): ");
                        if (int.TryParse(Console.ReadLine(), out int m))
                        {
                            Console.WriteLine(m switch
                            {
                                12 or 1 or 2 => "Зима",
                                3 or 4 or 5 => "Весна",
                                6 or 7 or 8 => "Лето",
                                9 or 10 or 11 => "Осень",
                                _ => "Ошибка"
                            });
                        }
                        else Console.WriteLine("Ошибка ввода.");
                        Pause(); break;

                    case "3":
                        Console.Write("Введите X: ");
                        bool okX = double.TryParse(Console.ReadLine(), out double X);
                        Console.Write("Введите Y: ");
                        bool okY = double.TryParse(Console.ReadLine(), out double Y);
                        if (!okX || !okY) { Console.WriteLine("Ошибка ввода."); Pause(); break; }
                        if (X == 0 && Y == 0) Console.WriteLine("Начало координат");
                        else if (X == 0) Console.WriteLine("На оси Y");
                        else if (Y == 0) Console.WriteLine("На оси X");
                        else if (X > 0 && Y > 0) Console.WriteLine("I четверть");
                        else if (X < 0 && Y > 0) Console.WriteLine("II четверть");
                        else if (X < 0 && Y < 0) Console.WriteLine("III четверть");
                        else Console.WriteLine("IV четверть");
                        Pause(); break;

                    case "5":
                        Console.Write("Введите часы (0-23): ");
                        if (int.TryParse(Console.ReadLine(), out int h))
                        {
                            Console.WriteLine(h switch
                            {
                                >= 5 and <= 11 => "Утро",
                                >= 12 and <= 16 => "День",
                                >= 17 and <= 22 => "Вечер",
                                >= 0 and <= 23 => "Ночь",
                                _ => "Ошибка"
                            });
                        }
                        else Console.WriteLine("Ошибка ввода.");
                        Pause(); break;

                    case "9": back = true; break;
                    default: Console.WriteLine("Неправильный ввод."); Pause(); break;
                }
            }
        }

        // ===== Блок 3: Циклы (1, 3, 5) =====
        static void Block3()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Блок 3. Циклы");
                Console.WriteLine("1. Минимальная и максимальная цифра");
                Console.WriteLine("3. Числа Фибоначчи");
                Console.WriteLine("5. Среднее арифметическое n чисел");
                Console.WriteLine("9. Вернуться в меню");
                Console.Write("\nВыберите задачу: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Введите число: ");
                        if (!int.TryParse(Console.ReadLine(), out int num)) { Console.WriteLine("Ошибка ввода."); Pause(); break; }
                        num = Math.Abs(num);
                        int min = 9, max = 0;
                        if (num == 0) { min = 0; max = 0; }
                        while (num > 0)
                        {
                            int d = num % 10;
                            if (d < min) min = d;
                            if (d > max) max = d;
                            num /= 10;
                        }
                        Console.WriteLine($"Мин: {min}, Макс: {max}");
                        Pause(); break;

                    case "3":
                        Console.Write("Введите n: ");
                        if (!int.TryParse(Console.ReadLine(), out int n) || n < 0) { Console.WriteLine("Ошибка ввода."); Pause(); break; }
                        long f1 = 0, f2 = 1;
                        Console.Write("Фибоначчи: ");
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write(f1 + " ");
                            long next = f1 + f2;
                            f1 = f2; f2 = next;
                        }
                        Console.WriteLine();
                        Pause(); break;

                    case "5":
                        Console.Write("Введите количество чисел: ");
                        if (!int.TryParse(Console.ReadLine(), out int k) || k <= 0) { Console.WriteLine("Ошибка ввода."); Pause(); break; }
                        double sum = 0;
                        for (int i = 1; i <= k; i++)
                        {
                            Console.Write($"Число {i}: ");
                            if (double.TryParse(Console.ReadLine(), out double val))
                                sum += val;
                            else
                                Console.WriteLine("Пропущено (некорректный ввод).");
                        }
                        Console.WriteLine($"Среднее: {sum / k:F2}");
                        Pause(); break;

                    case "9": back = true; break;
                    default: Console.WriteLine("Неправильный ввод."); Pause(); break;
                }
            }
        }

        // ===== Блок 4: Массивы (1, 3, 5) =====
        static void Block4()
        {
            bool back = false;
            var rand = new Random();
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Блок 4. Массивы");
                Console.WriteLine("1. Суммы строк и столбцов");
                Console.WriteLine("3. Обратный порядок массива");
                Console.WriteLine("5. Разделение массива на положительные и отрицательные");
                Console.WriteLine("9. Вернуться в меню");
                Console.Write("\nВыберите задачу: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Строки: ");
                        bool okR = int.TryParse(Console.ReadLine(), out int r);
                        Console.Write("Столбцы: ");
                        bool okC = int.TryParse(Console.ReadLine(), out int c);
                        if (!okR || !okC || r <= 0 || c <= 0) { Console.WriteLine("Ошибка ввода."); Pause(); break; }

                        int[,] matrix = new int[r, c];
                        int[] rowSums = new int[r];
                        int[] colSums = new int[c];

                        Console.WriteLine("Матрица:");
                        for (int i = 0; i < r; i++)
                        {
                            for (int j = 0; j < c; j++)
                            {
                                matrix[i, j] = rand.Next(1, 101);
                                Console.Write(matrix[i, j] + "\t");
                                rowSums[i] += matrix[i, j];
                                colSums[j] += matrix[i, j];
                            }
                            Console.WriteLine();
                        }
                        for (int i = 0; i < r; i++) Console.WriteLine($"Сумма строки {i}: {rowSums[i]}");
                        for (int j = 0; j < c; j++) Console.WriteLine($"Сумма столбца {j}: {colSums[j]}");
                        Pause(); break;

                    case "3":
                        Console.Write("Размер массива: ");
                        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) { Console.WriteLine("Ошибка ввода."); Pause(); break; }
                        int[] arr = new int[n];
                        for (int i = 0; i < n; i++) arr[i] = rand.Next(1, 101);
                        Console.WriteLine("Исходный: " + string.Join(", ", arr));
                        for (int i = 0, j = n - 1; i < j; i++, j--)
                        {
                            int tmp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = tmp;
                        }
                        Console.WriteLine("Перевёрнутый: " + string.Join(", ", arr));
                        Pause(); break;

                    case "5":
                        Console.Write("Размер массива: ");
                        if (!int.TryParse(Console.ReadLine(), out int sz) || sz <= 0) { Console.WriteLine("Ошибка ввода."); Pause(); break; }
                        int[] src = new int[sz];
                        for (int i = 0; i < sz; i++) src[i] = rand.Next(-100, 101);

                        // Подсчёт размеров подмассивов
                        int posCount = 0, negCount = 0;
                        for (int i = 0; i < sz; i++)
                        {
                            if (src[i] >= 0) posCount++;
                            else negCount++;
                        }
                        int[] positives = new int[posCount];
                        int[] negatives = new int[negCount];
                        int pi = 0, ni = 0;
                        for (int i = 0; i < sz; i++)
                        {
                            if (src[i] >= 0) positives[pi++] = src[i];
                            else negatives[ni++] = src[i];
                        }
                        Console.WriteLine("Исходный:     " + string.Join(", ", src));
                        Console.WriteLine("Положительные: " + string.Join(", ", positives));
                        Console.WriteLine("Отрицательные: " + string.Join(", ", negatives));
                        Pause(); break;

                    case "9": back = true; break;
                    default: Console.WriteLine("Неправильный ввод."); Pause(); break;
                }
            }
        }

        // ===== Блок 5: Функции (1, 3, 5) =====
        static void Block5()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Блок 5. Функции");
                Console.WriteLine("1. Факториал");
                Console.WriteLine("3. Сумма массива (рекурсия)");
                Console.WriteLine("5. Деление с остатком (out-параметры)");
                Console.WriteLine("9. Вернуться в меню");
                Console.Write("\nВыберите задачу: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("n: ");
                        if (!int.TryParse(Console.ReadLine(), out int n) || n < 0) { Console.WriteLine("Ошибка ввода."); Pause(); break; }
                        Console.WriteLine($"n! = {Factorial(n)}");
                        Pause(); break;

                    case "3":
                        Console.Write("Введите элементы массива через пробел: ");
                        var tokens = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        int[] arr = new int[tokens.Length];
                        bool ok = true;
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            if (int.TryParse(tokens[i], out int v)) arr[i] = v;
                            else { ok = false; break; }
                        }
                        if (!ok) { Console.WriteLine("Ошибка ввода."); Pause(); break; }
                        Console.WriteLine($"Сумма: {SumRecursive(arr, 0)}");
                        Pause(); break;

                    case "5":
                        Console.Write("Делимое: ");
                        bool okA = int.TryParse(Console.ReadLine(), out int dividend);
                        Console.Write("Делитель: ");
                        bool okB = int.TryParse(Console.ReadLine(), out int divisor);
                        if (!okA || !okB || divisor == 0) { Console.WriteLine("Ошибка ввода (делитель ≠ 0)."); Pause(); break; }
                        Divide(dividend, divisor, out int q, out int r);
                        Console.WriteLine($"Частное: {q}, Остаток: {r}");
                        Pause(); break;

                    case "9": back = true; break;
                    default: Console.WriteLine("Неправильный ввод."); Pause(); break;
                }
            }
        }

        // ===== Вспомогательные методы =====
        static long Factorial(int n)
        {
            long res = 1;
            for (int i = 2; i <= n; i++) res *= i;
            return res;
        }

        static int SumRecursive(int[] array, int index)
        {
            if (index >= array.Length) return 0;
            return array[index] + SumRecursive(array, index + 1);
        }

        static void Divide(int dividend, int divisor, out int quotient, out int remainder)
        {
            quotient = dividend / divisor;
            remainder = dividend % divisor;
        }

        static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey(true);
        }
    }
}
