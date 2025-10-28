using System;               // Подключаем базовую библиотеку .NET
using System.Text;          // Подключаем поддержку кодировок текста

namespace CS_Basics
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; // Устанавливаем кодировку консоли UTF-8 для корректного вывода русского текста

            bool exit = false; // Флаг выхода из программы
            while (!exit)      // Основной цикл программы — повторяем меню, пока пользователь не выйдет
            {
                Console.Clear(); // Очищаем экран перед выводом меню
                Console.WriteLine("========================================");
                Console.WriteLine("   Лабораторная работа - CS_Basics");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Блок 1. Переменные и операторы (1, 3, 5)");
                Console.WriteLine("2. Блок 2. Условные операторы (1, 3, 5)");
                Console.WriteLine("3. Блок 3. Циклы (1, 3, 5)");
                Console.WriteLine("4. Блок 4. Массивы (1, 3, 5)");
                Console.WriteLine("5. Блок 5. Функции (1, 3, 5, 7)");
                Console.WriteLine("9. Выход");
                Console.Write("\nВыберите блок: "); // Просим пользователя выбрать номер блока

                string? choice = Console.ReadLine(); // Считываем выбор пользователя как строку
                switch (choice) // Обрабатываем выбор пользователя
                {
                    case "1": Block1(); break; // Запускаем блок 1
                    case "2": Block2(); break; // Запускаем блок 2
                    case "3": Block3(); break; // Запускаем блок 3
                    case "4": Block4(); break; // Запускаем блок 4
                    case "5": Block5(); break; // Запускаем блок 5
                    case "9": exit = true; break; // Устанавливаем флаг выхода
                    default: Console.WriteLine("Неправильный ввод. Нажмите любую клавишу."); Console.ReadKey(true); break; // Сообщаем об ошибке выбора
                }
            }
        }

        // ====================== БЛОК 1: Переменные и операторы (1, 3, 5) ======================
        static void Block1()
        {
            bool back = false; // Флаг возврата в главное меню
            while (!back)      // Цикл подменю блока 1
            {
                Console.Clear(); // Очищаем экран
                Console.WriteLine("Блок 1. Переменные и операторы");
                Console.WriteLine("1. Конвертация температуры (C → F)");
                Console.WriteLine("3. Конвертация валюты (RUB → USD)");
                Console.WriteLine("5. Среднее арифметическое трёх чисел");
                Console.WriteLine("9. Вернуться в главное меню");
                Console.Write("\nВыберите задачу: "); // Просим выбрать задачу

                string? choice = Console.ReadLine(); // Считываем выбор задачи
                switch (choice)
                {
                    case "1": // Задача 1: конвертация температуры
                        Console.Write("Введите температуру в градусах Цельсия: "); // Запрашиваем значение температуры
                        if (TryReadDouble(out double celsius)) // Пытаемся считать корректное число с плавающей точкой
                        {
                            double fahrenheit = celsius * 9.0 / 5.0 + 32.0; // Применяем формулу F = C × 9/5 + 32
                            Console.WriteLine($"Температура в Фаренгейтах: {fahrenheit:F1}"); // Выводим результат с округлением до 1 знака
                        }
                        else Console.WriteLine("Ошибка ввода температуры."); // Сообщаем об ошибке ввода
                        Pause(); break; // Ждём нажатие клавиши

                    case "3": // Задача 3: конвертация валюты
                        const decimal rate = 0.011m; // Фиксированный курс RUB→USD как десятичный тип для финансовых расчётов
                        Console.Write("Введите сумму в рублях: "); // Запрашиваем сумму
                        if (TryReadDecimalNonNegative(out decimal rub)) // Пытаемся считать неотрицательное число
                        {
                            decimal usd = rub * rate; // Переводим рубли в доллары по фиксированному курсу
                            Console.WriteLine($"Сумма в долларах: {usd:F2}"); // Выводим результат с 2 знаками после запятой
                        }
                        else Console.WriteLine("Ошибка ввода суммы в рублях."); // Сообщаем об ошибке ввода
                        Pause(); break; // Пауза

                    case "5": // Задача 5: среднее арифметическое трёх чисел
                        Console.Write("Введите три числа через пробел: "); // Просим ввести три числа
                        string input = Console.ReadLine() ?? ""; // Считываем строку, заменяя null на пустую
                        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Разбиваем по пробелам, убирая пустые элементы
                        if (parts.Length == 3 && double.TryParse(parts[0], out double a) && double.TryParse(parts[1], out double b) && double.TryParse(parts[2], out double d)) // Проверяем корректность всех трёх чисел
                        {
                            double avg = (a + b + d) / 3.0; // Вычисляем среднее арифметическое
                            Console.WriteLine($"Среднее арифметическое: {avg:F2}"); // Выводим среднее с 2 знаками
                        }
                        else Console.WriteLine("Ошибка ввода трёх чисел."); // Сообщаем об ошибке ввода
                        Pause(); break; // Пауза

                    case "9": back = true; break; // Возврат в главное меню
                    default: Console.WriteLine("Неправильный ввод."); Pause(); break; // Ошибка выбора задачи
                }
            }
        }

        // ====================== БЛОК 2: Условные операторы (1, 3, 5) ======================
        static void Block2()
        {
            bool back = false; // Флаг возврата
            while (!back)      // Цикл подменю блока 2
            {
                Console.Clear(); // Очищаем экран
                Console.WriteLine("Блок 2. Условные операторы");
                Console.WriteLine("1. Определение времени года по номеру месяца");
                Console.WriteLine("3. Определение координатной четверти точки (x, y)");
                Console.WriteLine("5. Определение времени суток по часам (0-23)");
                Console.WriteLine("9. Вернуться в главное меню");
                Console.Write("\nВыберите задачу: ");

                string? choice = Console.ReadLine(); // Считываем выбор задачи
                switch (choice)
                {
                    case "1": // Задача 1: время года
                        Console.Write("Введите номер месяца (1-12): "); // Запрашиваем номер месяца
                        if (TryReadIntInRange(1, 12, out int month)) // Проверяем, что значение в диапазоне 1..12
                        {
                            string season = month switch // Определяем время года через switch expression
                            {
                                12 or 1 or 2 => "Зима",
                                3 or 4 or 5 => "Весна",
                                6 or 7 or 8 => "Лето",
                                9 or 10 or 11 => "Осень",
                                _ => "Неизвестно" // Сюда не попадём благодаря проверке диапазона
                            };
                            Console.WriteLine($"Время года: {season}"); // Выводим результат
                        }
                        else Console.WriteLine("Ошибка ввода месяца."); // Сообщаем об ошибке
                        Pause(); break; // Пауза

                    case "3": // Задача 3: координатная четверть
                        Console.Write("Введите X: "); // Запрашиваем X
                        bool okX = TryReadDouble(out double x); // Пытаемся считать число
                        Console.Write("Введите Y: "); // Запрашиваем Y
                        bool okY = TryReadDouble(out double y); // Пытаемся считать число
                        if (!okX || !okY) { Console.WriteLine("Ошибка ввода координат."); Pause(); break; } // Если ввод неверный — сообщаем
                        // Определяем положение точки относительно осей и четвертей
                        if (x == 0 && y == 0) Console.WriteLine("Точка в начале координат.");
                        else if (x == 0) Console.WriteLine("Точка на оси Y.");
                        else if (y == 0) Console.WriteLine("Точка на оси X.");
                        else if (x > 0 && y > 0) Console.WriteLine("I четверть.");
                        else if (x < 0 && y > 0) Console.WriteLine("II четверть.");
                        else if (x < 0 && y < 0) Console.WriteLine("III четверть.");
                        else Console.WriteLine("IV четверть.");
                        Pause(); break; // Пауза

                    case "5": // Задача 5: время суток
                        Console.Write("Введите часы (0-23): "); // Запрашиваем часы
                        if (TryReadIntInRange(0, 23, out int hour)) // Проверяем диапазон
                        {
                            string dayPart = hour switch // Определяем время суток
                            {
                                >= 5 and <= 11 => "Утро",
                                >= 12 and <= 16 => "День",
                                >= 17 and <= 22 => "Вечер",
                                _ => "Ночь" // Остальные значения — ночь (0-4 и 23)
                            };
                            Console.WriteLine($"Время суток: {dayPart}"); // Выводим результат
                        }
                        else Console.WriteLine("Ошибка ввода часов."); // Сообщаем об ошибке
                        Pause(); break; // Пауза

                    case "9": back = true; break; // Возврат
                    default: Console.WriteLine("Неправильный ввод."); Pause(); break; // Ошибка выбора
                }
            }
        }

        // ====================== БЛОК 3: Циклы (1, 3, 5) ======================
        static void Block3()
        {
            bool back = false; // Флаг возврата
            while (!back)      // Цикл подменю блока 3
            {
                Console.Clear(); // Очищаем экран
                Console.WriteLine("Блок 3. Циклы");
                Console.WriteLine("1. Минимальная и максимальная цифра числа");
                Console.WriteLine("3. Первые n чисел Фибоначчи");
                Console.WriteLine("5. Среднее арифметическое n введённых чисел");
                Console.WriteLine("9. Вернуться в главное меню");
                Console.Write("\nВыберите задачу: ");

                string? choice = Console.ReadLine(); // Считываем выбор задачи
                switch (choice)
                {
                    case "1": // Задача 1: минимальная и максимальная цифра
                        Console.Write("Введите целое число: "); // Запрашиваем число
                        if (!long.TryParse(Console.ReadLine(), out long num)) { Console.WriteLine("Ошибка ввода числа."); Pause(); break; } // Проверяем корректность ввода
                        num = Math.Abs(num); // Берём модуль числа, чтобы работать с цифрами без знака
                        int min = 9, max = 0; // Инициализируем минимальную и максимальную цифры
                        if (num == 0) { min = 0; max = 0; } // Отдельный случай: число 0
                        while (num > 0) // Перебираем все цифры числа
                        {
                            int digit = (int)(num % 10); // Получаем последнюю цифру
                            if (digit < min) min = digit; // Обновляем минимум при необходимости
                            if (digit > max) max = digit; // Обновляем максимум при необходимости
                            num /= 10; // Удаляем последнюю цифру
                        }
                        Console.WriteLine($"Минимальная цифра: {min}, максимальная цифра: {max}"); // Выводим результат
                        Pause(); break; // Пауза

                    case "3": // Задача 3: числа Фибоначчи
                        Console.Write("Введите n (количество чисел): "); // Запрашиваем n
                        if (!int.TryParse(Console.ReadLine(), out int n) || n < 0) { Console.WriteLine("Ошибка ввода n."); Pause(); break; } // Проверяем ввод
                        long f1 = 0, f2 = 1; // Инициализируем первые два числа Фибоначчи
                        Console.Write("Последовательность: "); // Начинаем вывод
                        for (int i = 0; i < n; i++) // Цикл вывода n чисел
                        {
                            Console.Write(f1 + (i < n - 1 ? " " : "")); // Печатаем текущий элемент, отделяя пробелом
                            long next = f1 + f2; // Вычисляем следующий элемент
                            f1 = f2; f2 = next;  // Сдвигаем пару чисел
                        }
                        Console.WriteLine(); // Перевод строки после вывода последовательности
                        Pause(); break; // Пауза

                    case "5": // Задача 5: среднее арифметическое n чисел
                        Console.Write("Введите количество чисел n: "); // Запрашиваем n
                        if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0) { Console.WriteLine("Ошибка ввода n."); Pause(); break; } // Проверяем ввод
                        double sum = 0.0; // Инициализируем сумму
                        for (int i = 1; i <= count; i++) // Цикл ввода n чисел
                        {
                            Console.Write($"Число {i}: "); // Просим ввести очередное число
                            if (double.TryParse(Console.ReadLine(), out double val)) sum += val; // Если ввод корректный, добавляем к сумме
                            else { Console.WriteLine("Некорректное число. Повторите ввод."); i--; } // Если ошибка — уменьшаем i, чтобы повторить ввод
                        }
                        double avg = sum / count; // Вычисляем среднее как сумма / количество
                        Console.WriteLine($"Среднее арифметическое: {avg:F2}"); // Выводим результат
                        Pause(); break; // Пауза

                    case "9": back = true; break; // Возврат
                    default: Console.WriteLine("Неправильный ввод."); Pause(); break; // Ошибка выбора
                }
            }
        }

        // ====================== БЛОК 4: Массивы (1, 3, 5) ======================
        static void Block4()
        {
            bool back = false; // Флаг возврата
            Random rand = new Random(); // Создаём генератор случайных чисел один раз для блока
            while (!back)      // Цикл подменю блока 4
            {
                Console.Clear(); // Очищаем экран
                Console.WriteLine("Блок 4. Массивы");
                Console.WriteLine("1. Суммы строк и столбцов в матрице (1..100)");
                Console.WriteLine("3. Обратный порядок одномерного массива (1..100)");
                Console.WriteLine("5. Разделение массива на положительные и отрицательные (−100..100)");
                Console.WriteLine("9. Вернуться в главное меню");
                Console.Write("\nВыберите задачу: ");

                string? choice = Console.ReadLine(); // Считываем выбор задачи
                switch (choice)
                {
                    case "1": // Задача 1: суммы строк и столбцов
                        Console.Write("Введите количество строк r (>0): "); // Запрашиваем число строк
                        bool okR = TryReadIntPositive(out int r); // Пытаемся считать положительное целое
                        Console.Write("Введите количество столбцов c (>0): "); // Запрашиваем число столбцов
                        bool okC = TryReadIntPositive(out int c); // Пытаемся считать положительное целое
                        if (!okR || !okC) { Console.WriteLine("Ошибка ввода размеров матрицы."); Pause(); break; } // Проверяем ввод
                        int[,] matrix = new int[r, c]; // Создаём двумерный массив с заданными размерами
                        int[] rowSums = new int[r];    // Массив для сумм по строкам
                        int[] colSums = new int[c];    // Массив для сумм по столбцам

                        Console.WriteLine("Матрица:"); // Печатаем заголовок матрицы
                        for (int i = 0; i < r; i++) // Проходим по строкам
                        {
                            for (int j = 0; j < c; j++) // Проходим по столбцам
                            {
                                matrix[i, j] = rand.Next(1, 101); // Генерируем случайное число от 1 до 100
                                Console.Write(matrix[i, j] + "\t"); // Выводим значение с табуляцией для читаемости
                                rowSums[i] += matrix[i, j]; // Накапливаем сумму строки
                                colSums[j] += matrix[i, j]; // Накапливаем сумму столбца
                            }
                            Console.WriteLine(); // Переходим на новую строку после вывода строки матрицы
                        }

                        // Ищем минимальные и максимальные суммы по строкам и столбцам
                        int minRowIdx = 0, maxRowIdx = 0, minColIdx = 0, maxColIdx = 0; // Индексы минимальных и максимальных
                        for (int i = 1; i < r; i++) // Идём со второй строки
                        {
                            if (rowSums[i] < rowSums[minRowIdx]) minRowIdx = i; // Обновляем индекс минимальной строки
                            if (rowSums[i] > rowSums[maxRowIdx]) maxRowIdx = i; // Обновляем индекс максимальной строки
                        }
                        for (int j = 1; j < c; j++) // Идём со второго столбца
                        {
                            if (colSums[j] < colSums[minColIdx]) minColIdx = j; // Обновляем индекс минимального столбца
                            if (colSums[j] > colSums[maxColIdx]) maxColIdx = j; // Обновляем индекс максимального столбца
                        }

                        // Выводим суммы и индексы (человеко-ориентированные индексы начинаются с 1)
                        for (int i = 0; i < r; i++) Console.WriteLine($"Сумма строки {i + 1}: {rowSums[i]}"); // Печатаем суммы строк
                        for (int j = 0; j < c; j++) Console.WriteLine($"Сумма столбца {j + 1}: {colSums[j]}"); // Печатаем суммы столбцов
                        Console.WriteLine($"Минимальная сумма в строке #{minRowIdx + 1} = {rowSums[minRowIdx]}"); // Минимальная строка
                        Console.WriteLine($"Максимальная сумма в строке #{maxRowIdx + 1} = {rowSums[maxRowIdx]}"); // Максимальная строка
                        Console.WriteLine($"Минимальная сумма в столбце #{minColIdx + 1} = {colSums[minColIdx]}"); // Минимальный столбец
                        Console.WriteLine($"Максимальная сумма в столбце #{maxColIdx + 1} = {colSums[maxColIdx]}"); // Максимальный столбец
                        Pause(); break; // Пауза

                    case "3": // Задача 3: обратный порядок массива
                        Console.Write("Введите размер массива n (>0): "); // Запрашиваем размер массива
                        if (!TryReadIntPositive(out int n)) { Console.WriteLine("Ошибка ввода размера."); Pause(); break; } // Проверяем ввод
                        int[] arr = new int[n]; // Создаём массив заданного размера
                        for (int i = 0; i < n; i++) arr[i] = rand.Next(1, 101); // Заполняем массив случайными числами 1..100
                        Console.WriteLine("Исходный массив: " + string.Join(", ", arr)); // Выводим исходный массив
                        // Меняем элементы местами с концами без вспомогательных структур
                        for (int i = 0, j = n - 1; i < j; i++, j--) // Двигаемся к центру массива с двух сторон
                        {
                            int tmp = arr[i];  // Сохраняем левый элемент во временную переменную
                            arr[i] = arr[j];   // Перезаписываем левый элемент правым
                            arr[j] = tmp;      // Ставим сохранённый левый элемент вправо
                        }
                        Console.WriteLine("Перевёрнутый массив: " + string.Join(", ", arr)); // Выводим итоговый массив
                        Pause(); break; // Пауза

                    case "5": // Задача 5: разделение массива на положительные и отрицательные
                        Console.Write("Введите размер массива n (>0): "); // Запрашиваем размер
                        if (!TryReadIntPositive(out int sz)) { Console.WriteLine("Ошибка ввода размера."); Pause(); break; } // Проверяем ввод
                        int[] src = new int[sz]; // Исходный массив
                        for (int i = 0; i < sz; i++) src[i] = rand.Next(-100, 101); // Заполняем числами из диапазона -100..100

                        // Считаем количества положительных (включая ноль) и отрицательных, чтобы создать массивы нужного размера
                        int posCount = 0, negCount = 0; // Счётчики
                        for (int i = 0; i < sz; i++) // Обходим исходный массив
                        {
                            if (src[i] >= 0) posCount++; // Увеличиваем счётчик положительных
                            else negCount++;             // Увеличиваем счётчик отрицательных
                        }

                        int[] positives = new int[posCount]; // Создаём массив положительных нужного размера
                        int[] negatives = new int[negCount]; // Создаём массив отрицательных нужного размера
                        int pi = 0, ni = 0; // Индексы текущей записи в каждом массиве
                        for (int i = 0; i < sz; i++) // Повторно проходим исходный массив
                        {
                            if (src[i] >= 0) { positives[pi] = src[i]; pi++; } // Кладём число в массив положительных
                            else { negatives[ni] = src[i]; ni++; }             // Кладём число в массив отрицательных
                        }

                        // Выводим результаты
                        Console.WriteLine("Исходный:      " + string.Join(", ", src));       // Исходный массив
                        Console.WriteLine("Положительные: " + string.Join(", ", positives)); // Массив положительных
                        Console.WriteLine("Отрицательные: " + string.Join(", ", negatives)); // Массив отрицательных
                        Pause(); break; // Пауза

                    case "9": back = true; break; // Возврат
                    default: Console.WriteLine("Неправильный ввод."); Pause(); break; // Ошибка выбора
                }
            }
        }

        // ====================== БЛОК 5: Функции (1, 3, 5, 7) ======================
        static void Block5()
        {
            bool back = false; // Флаг возврата
            while (!back)      // Цикл подменю блока 5
            {
                Console.Clear(); // Очищаем экран
                Console.WriteLine("Блок 5. Функции");
                Console.WriteLine("1. Факториал n!");
                Console.WriteLine("3. Сумма массива (рекурсия)");
                Console.WriteLine("5. Деление с остатком (out-параметры)");
                Console.WriteLine("7. Фильтрация чётных чисел (params)");
                Console.WriteLine("9. Вернуться в главное меню");
                Console.Write("\nВыберите задачу: ");

                string? choice = Console.ReadLine(); // Считываем выбор задачи
                switch (choice)
                {
                    case "1": // Задача 1: факториал
                        Console.Write("Введите n (0..20): "); // Запрашиваем n (ограничиваем до 20, чтобы не было переполнения long)
                        if (TryReadIntInRange(0, 20, out int n)) // Проверяем диапазон
                        {
                            long f = Factorial(n); // Вызываем функцию факториала
                            Console.WriteLine($"Факториал n! = {f}"); // Выводим результат
                        }
                        else Console.WriteLine("Ошибка ввода n."); // Сообщаем об ошибке
                        Pause(); break; // Пауза

                    case "3": // Задача 3: сумма массива (рекурсия)
                        Console.Write("Введите элементы массива через пробел: "); // Просим ввести элементы
                        string data = Console.ReadLine() ?? ""; // Считываем строку
                        string[] tok = data.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Разбиваем по пробелам
                        int[] arr = new int[tok.Length]; // Создаём массив нужной длины
                        bool ok = true; // Флаг корректности парсинга
                        for (int i = 0; i < tok.Length; i++) // Парсим каждый токен
                        {
                            if (int.TryParse(tok[i], out int v)) arr[i] = v; // Если число — записываем
                            else { ok = false; break; } // Иначе отмечаем ошибку
                        }
                        if (!ok) { Console.WriteLine("Ошибка ввода массива."); Pause(); break; } // Если ошибка — выходим
                        int sum = SumRecursive(arr, 0); // Вычисляем сумму рекурсивно, начиная с индекса 0
                        Console.WriteLine($"Сумма элементов массива: {sum}"); // Выводим сумму
                        Pause(); break; // Пауза

                    case "5": // Задача 5: деление с остатком
                        Console.Write("Введите делимое (целое): "); // Запрашиваем делимое
                        bool okA = TryReadInt(out int dividend); // Пытаемся считать целое
                        Console.Write("Введите делитель (целое, ≠ 0): "); // Запрашиваем делитель
                        bool okB = TryReadInt(out int divisor); // Пытаемся считать целое
                        if (!okA || !okB || divisor == 0) { Console.WriteLine("Ошибка ввода (делитель должен быть ≠ 0)."); Pause(); break; } // Проверяем условия
                        Divide(dividend, divisor, out int q, out int r); // Вызываем функцию деления с остатком
                        Console.WriteLine($"Частное: {q}, остаток: {r}"); // Выводим результат
                        Pause(); break; // Пауза

                    case "7": // Задача 7: фильтрация чётных чисел
                        Console.Write("Введите целые числа через пробел: "); // Просим ввести список чисел
                        string s = Console.ReadLine() ?? ""; // Считываем строку
                        string[] toks = s.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Разбиваем на токены
                        int[] inputs = new int[toks.Length]; // Подготавливаем массив входных чисел
                        bool okAll = true; // Флаг корректности
                        for (int i = 0; i < toks.Length; i++) // Парсим каждое число
                        {
                            if (int.TryParse(toks[i], out int v)) inputs[i] = v; // Записываем корректное число
                            else { okAll = false; break; } // Если ошибка — прерываем
                        }
                        if (!okAll) { Console.WriteLine("Ошибка ввода чисел."); Pause(); break; } // Сообщаем об ошибке
                        int[] evens = FilterEven(inputs); // Фильтруем только чётные числа
                        Console.WriteLine("Чётные числа: " + (evens.Length > 0 ? string.Join(", ", evens) : "нет")); // Выводим результат
                        Pause(); break; // Пауза

                    case "9": back = true; break; // Возврат
                    default: Console.WriteLine("Неправильный ввод."); Pause(); break; // Ошибка выбора
                }
            }
        }

        // ====================== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ======================

        // Безопасное чтение целого числа
        static bool TryReadInt(out int value)
        {
            string? s = Console.ReadLine(); // Считываем строку
            return int.TryParse(s, out value); // Пытаемся преобразовать в целое
        }

        // Чтение положительного целого ( > 0 )
        static bool TryReadIntPositive(out int value)
        {
            if (TryReadInt(out value) && value > 0) return true; // Проверяем, что число положительное
            value = 0; return false; // Иначе возвращаем false
        }

        // Чтение целого в диапазоне [min, max]
        static bool TryReadIntInRange(int min, int max, out int value)
        {
            if (TryReadInt(out value) && value >= min && value <= max) return true; // Проверка диапазона
            value = 0; return false; // Иначе false
        }

        // Безопасное чтение вещественного числа double
        static bool TryReadDouble(out double value)
        {
            string? s = Console.ReadLine(); // Считываем строку
            return double.TryParse(s, out value); // Пытаемся преобразовать в double
        }

        // Чтение неотрицательного decimal (для денежных сумм)
        static bool TryReadDecimalNonNegative(out decimal value)
        {
            string? s = Console.ReadLine(); // Считываем строку
            if (decimal.TryParse(s, out value) && value >= 0) return true; // Проверяем, что число неотрицательное
            value = 0; return false; // Иначе false
        }

        // Факториал с типом long (ограничиваем n ≤ 20, чтобы избежать переполнения)
        static long Factorial(int n)
        {
            long res = 1;              // Инициализируем результат как 1
            for (int i = 2; i <= n; i++) res *= i; // Перемножаем числа от 2 до n
            return res;                // Возвращаем результат
        }

        // Рекурсивная сумма массива от индекса index до конца
        static int SumRecursive(int[] array, int index)
        {
            if (array == null || index >= array.Length) return 0; // Базовый случай: конец массива или null
            return array[index] + SumRecursive(array, index + 1); // Рекурсивно суммируем текущий элемент и хвост
        }

        // Деление с остатком через out-параметры
        static void Divide(int dividend, int divisor, out int quotient, out int remainder)
        {
            quotient = dividend / divisor; // Вычисляем целую часть деления
            remainder = dividend % divisor; // Вычисляем остаток от деления
        }

        // Фильтрация чётных чисел без LINQ: сначала считаем количество, потом создаём массив
        static int[] FilterEven(params int[] numbers)
        {
            if (numbers == null) return Array.Empty<int>(); // Если null — возвращаем пустой массив
            int count = 0; // Счётчик чётных чисел
            for (int i = 0; i < numbers.Length; i++) if (numbers[i] % 2 == 0) count++; // Считаем количество чётных
            int[] evens = new int[count]; // Создаём массив нужного размера
            int k = 0; // Текущий индекс записи
            for (int i = 0; i < numbers.Length; i++) if (numbers[i] % 2 == 0) { evens[k] = numbers[i]; k++; } // Заполняем массив чётных
            return evens; // Возвращаем массив чётных
        }

        // Пауза ожидания клавиши для удобства пользователя
        static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить..."); // Сообщение о паузе
            Console.ReadKey(true); // Ждём нажатие любой клавиши без отображения символа
        }
    }
}
