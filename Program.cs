using static System.Runtime.InteropServices.JavaScript.JSType;

namespace secondprogramm
{
    internal class Program
    {
        static int getRandomNumber(int max)
        {
            Random rnd = new Random();

            return rnd.Next(1, max);
        }

        static int getUserNumber(int max)
        {
            int userNumber = 0;

            for (int i = 0; i < 3; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out userNumber) || userNumber > max || userNumber < 1)

                    Console.WriteLine("");
                else break;
                if (i == 2)
                {
                    Console.WriteLine("you are stupid");
                    throw new Exception();
                }
            }

            return userNumber;
        }

        static bool isCorrectNumber(int userNumber, int correctNumber)
        {
            if (userNumber > correctNumber)
            {
                Console.WriteLine("your number is greater");
                return false;
            }
            if (userNumber < correctNumber)
            {
                Console.WriteLine("your number is less");
                return false;
            }
            
            Console.WriteLine("you are win!");
            return true;
        }

        static int getMaxValue(int max, int counter)
        {
            return max < counter ? counter : max;
        }

        static int getMinValue(int min, int counter)
        {
            return min == 0 || min > counter ? counter : min;
        }

        static void Main(string[] args)
        {
            int min = 0;
            int max = 0;
            int countAttempt = 0;
            int countGame = 0;
            int MAX_VALUE = 100;
            char answer;
            
            do
            {
                int counter = 0;
                int number = getRandomNumber(MAX_VALUE);

                Console.WriteLine("try guess number?");
                while (true)
                {
                    counter++;
                    Console.WriteLine("input number from [1;{0}]", MAX_VALUE);

                    int userNumber = getUserNumber(MAX_VALUE);
                    bool isCorrect = isCorrectNumber(userNumber, number);


                    if (isCorrect)
                    {
                        min = getMinValue(min, counter);
                        max = getMaxValue(max, counter);

                        countAttempt += counter;
                        countGame++;
                        break;                    
                    }
                }

                Console.WriteLine("do you want play game");
                answer = Convert.ToChar(Console.Read());
            } while (answer == 'Y');

            Console.WriteLine($"min = {min} max = {max} avg = {(double)countAttempt / countGame}");
        }
    }
}

// 1. методы класса. Разбить программу на методы, а в мейн все вызвать
// метод - должен нести одну SOLID -  S - single respon principle
// 2. GitHub аккаунт -  создать репозиторий с окрытой лицензией (public) с лицензией MIT с gitigore c VS имя репозитория AlgorithmAndDataStructures
// в описание что нибдуь полезное. Сделать push через MicrosoftVS домашнего задания, написать в комитт то что мы закодировали