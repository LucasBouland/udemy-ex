using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Exercise.SumN(5));
            Console.WriteLine(Exercise.Factorial(6));
            Console.WriteLine(Exercise.IsHappy(20));
        }
    }
    public class Exercise
    {
        //EX 1
        public static int PrintSum(int a, int b)
        {
            return a + b;
        }
        // EX 2
        public static string Hello(string name)
        {
            return $"Greetings, {name}. How are you today?";
        }
        // EX 3
        public static int SumN(int n)
        {
            if (n == 0) return 0;
            return n + SumN(n - 1);
        }
        // EX 4
        public static String Prime(int num)
        {
            if (num <= 1) return $"{num} is not prime";

            for (int i = 2; i < num; i++)
            {
                if ((num % i) != 0)
                {
                    return $"{num} is prime";
                }

            }
            return $"{num} is not prime";
        }
        // EX 5
        public static string Factorial(int num)
        {
            for (int i = num - 1; i > 1; i--)
            {
                num *= i;
            }
            return num.ToString();
        }
        // EX 6
        public static string Armstrong(int num)
        {
            string total = num.ToString();
            int armstrong = 0;

            foreach (char digit in total)
            {
                int dig = Int32.Parse(digit.ToString());

                for (int i = 1; i < total.Length; i++)
                {

                    dig *= Int32.Parse(digit.ToString());
                }
                armstrong += dig;
            }
            if (num == armstrong)
            {
                return total + " is an Armstrong number";
            }
            else
            {
                return total + " is not an Armstrong number";
            }
        }
        // EX 8
        public static int Lucas(int n)
        {
            if (n == 0) return 2;
            if (n == 1) return 1;
            return Lucas(n - 1) + Lucas(n - 2);
        }
        // EX 9
        public static string Abundant(int n)
        {
            int sum = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                }
            }
            if (sum > n)
            {
                return "Abudant Number";
            }
            else
            {
                return "Not Abundant Number";
            }
        }
        // EX 10
        public static bool IsKaprekar(int n)
        {
            /*if (n < 32 || n > 100)
            {
                return false;
            }*/
            int pow = n * n;
            bool isKaprekar = false;
            string str = pow.ToString();
            for (int i = 1; i < str.Length; i++)
            {
                string split_left = pow.ToString().Substring(0, i);
                string split_right = pow.ToString().Substring(i);
                if (Int32.Parse(split_left) + Int32.Parse(split_right) == n)
                {
                    isKaprekar = true;
                }
            }
            return isKaprekar;
        }
        // EX 11
        static int numSquareSum(int n)
        {
            int squareSum = 0;
            while (n != 0)
            {
                squareSum += (n % 10) * (n % 10);
                n /= 10;
            }
            return squareSum;
        }

        public static bool IsHappy(int n)
        {
            while (true)
            {
                n = numSquareSum(n);
                if (n == 4) { return false; }
                if (n == 1) return true;
            }
        }

        // Thread
        public void Thread()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            var finalTask = parent.ContinueWith(parentTask =>
            {
                foreach (int index in parentTask.Result)
                {
                    Console.WriteLine(index);
                }
            });
        }

    }
}
