using System;
using System.Collections.Generic;
using static No_Sense_Task.IEnumerableExtensions;

namespace No_Sense_Task
{
    class Program
    {
        public static int[] input = new int[] { };
        public static string clientInput = null;
        public static string[] strings = new string[] { };

        public static int test = 0;

        public static Func<int, bool> predicate = delegate (int x)
        {
            return test == x;
        };

        public static Func<IEnumerable<int>, IEnumerable<int>> func = delegate (IEnumerable<int> source)
        {
            int[] array = source as int[];
            Array.Resize(ref array, array.Length + 1);
            array[^1] = test;
            return array;
        };


        static void Main(string[] args)
        {
            HandleInput();
            Random rnd = new Random();

            try
            {
                //First Task
                Console.WriteLine("First Task:");
                test = input[rnd.Next(0, input.Length)];
                OutputResult(input.ThisDoesntMakeAnySense(predicate, func));

                //Second Task
                Console.WriteLine("Second Task:");

                Predicate<int> secondTaskPredicate = delegate (int x)
                {
                    foreach (int item in input)
                    {
                        if (item == x) { return false; }
                    }

                    return true;
                };

                do
                {
                    test = rnd.Next(0, 1000);
                } while (!secondTaskPredicate(test));

                OutputResult(input.ThisDoesntMakeAnySense(predicate, func));

                //Third Task
                Console.WriteLine("Third Task:");
                input = null;
                OutputResult(input.ThisDoesntMakeAnySense(predicate, func));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void OutputResult(IEnumerable<int> result)
        {
            if (result == default) { Console.WriteLine(NullToString(result)); }
            else
            {
                foreach (int item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static void HandleInput()
        {
            do
            {
                Console.WriteLine("Enter integers separated with ',' symbol");
                clientInput = Console.ReadLine();
            } while (string.IsNullOrEmpty(clientInput));

            strings = clientInput.Split(',');

            if (!strings.IsNumbers())
            {
                Console.WriteLine("Please enter only integers!");
                HandleInput();
            }

            Array.Resize(ref input, strings.Length);

            for (int i = 0; i < strings.Length; i++)
            {
                input[i] = Int32.Parse(strings[i].Trim());
            }
        }

        public static string NullToString(object Value)
        {
            return Value == null ? "null" : Value.ToString();
        }
    }
}
