

namespace secondprogramm
{
    // Объявление класса Program
    internal class Program
    {
        // Метод для генерации случайного числа от 1 до max
        static int getRandomNumber(int max)
        {
            // Создание экземпляра генератора случайных чисел
            Random rnd = new Random();

            // Возврат случайного числа в диапазоне от 1 до max (исключая max)
            return rnd.Next(1, max);
        }

        // Метод для получения числа от пользователя с проверкой (максимум 3 попытки)
        static int getUserNumber(int max)
        {
            // Инициализация переменной для числа пользователя
            int userNumber = 0;

            
            for (int i = 0; i < 3; i++)
            {
                // Проверка, что пользователь ввел число в нужном диапазоне
                if (!int.TryParse(Console.ReadLine(), out userNumber) || userNumber > max || userNumber < 1)
                    
                    Console.WriteLine("");
                else
                    // Выход из цикла при успешном вводе
                    break;

                // Проверка на последнюю попытку 
                if (i == 2)
                {
                    // Вывод сообщения пользователю
                    Console.WriteLine("you are stupid");
                    // Генерация исключения для завершения программы
                    throw new Exception();
                }
            }

            // Возврат корректно введенного числа
            return userNumber;
        }

        // Метод проверки соответствия числа пользователя загаданному числу
        static bool isCorrectNumber(int userNumber, int correctNumber)
        {
            // Проверка: число пользователя больше загаданного
            if (userNumber > correctNumber)
            {
                // Подсказка, что число слишком большое
                Console.WriteLine("your number is greater");
               
                return false;
            }

            // Проверка: число пользователя меньше загаданного
            if (userNumber < correctNumber)
            {
                // Подсказка, что число слишком маленькое
                Console.WriteLine("your number is less");
               
                return false;
            }

            // Если число угадано (не больше и не меньше)
            Console.WriteLine("you are win!");
            
            return true;
        }

        // Метод для определения максимального значения (сохраняет наибольшее число попыток)
        static int getMaxValue(int max, int counter)
        {
            
            return max < counter ? counter : max;
        }

        // Метод для определения минимального значения (сохраняет наименьшее число попыток)
        static int getMinValue(int min, int counter)
        {
            
            return min == 0 || min > counter ? counter : min;
        }

        // Главный метод программы (точка входа)
        static void Main(string[] args)
        {
            
            int min = 0;

            
            int max = 0;

            
            int countAttempt = 0;

           
            int countGame = 0;

            // Константа: максимальное значение загадываемого числа
            int MAX_VALUE = 100;

            // Переменная для ответа пользователя (продолжить игру или нет)
            char answer;

            // Цикл do-while (выполняется хотя бы один раз)
            do
            {
                // Счетчик попыток в текущей игре
                int counter = 0;

                // Генерация случайного числа для текущей игры
                int number = getRandomNumber(MAX_VALUE);

               
                Console.WriteLine("try guess number?");

                // Бесконечный цикл для процесса угадывания
                while (true)
                {
                    
                    counter++;

                    
                    Console.WriteLine("input number from [1;{0}]", MAX_VALUE);

                    // Получение числа от пользователя
                    int userNumber = getUserNumber(MAX_VALUE);

                    // Проверка правильности числа
                    bool isCorrect = isCorrectNumber(userNumber, number);

                    // Если число угадано
                    if (isCorrect)
                    {
                        // Обновление минимального количества попыток
                        min = getMinValue(min, counter);

                        // Обновление максимального количества попыток
                        max = getMaxValue(max, counter);

                        // Добавление попыток текущей игры в общий счетчик
                        countAttempt += counter;

                        
                        countGame++;

                        
                        break;
                    }
                    // Если число не угадано, цикл продолжается
                }

                // Запрос на повторную игру
                Console.WriteLine("do you want play game");

                // Чтение одного символа ответа пользователя (Y или другое)
                answer = Convert.ToChar(Console.Read());

            } while (answer == 'Y'); // Проверка условия: если ответ 'Y', игра повторяется

            // Вывод статистики: минимальные, максимальные попытки и среднее арифметическое
            Console.WriteLine($"min = {min} max = {max} avg = {(double)countAttempt / countGame}");
        }
    }
}
// 1. методы класса. Разбить программу на методы, а в мейн все вызвать
// метод - должен нести одну SOLID -  S - single respon principle
// 2. GitHub аккаунт -  создать репозиторий с окрытой лицензией (public) с лицензией MIT с gitigore c VS имя репозитория AlgorithmAndDataStructures
// в описание что нибдуь полезное. Сделать push через MicrosoftVS домашнего задания, написать в комитт то что мы закодировали