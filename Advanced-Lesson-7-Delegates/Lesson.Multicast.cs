using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_7_Delegates
{
    public partial class Lesson
    {
        public delegate void VoidDelegate(int a, int b);
        public delegate int ReturnDelegate(int a, int b);        
        
        public static void SingleAndMulticastExample()
        {
            VoidDelegate voidSingleDelegate = Log;

            VoidDelegate voidMultipleDelegate = Log;
            voidMultipleDelegate += LogSum;
            //voidMultipleDelegate = voidMultipleDelegate + LogSum;

            ReturnDelegate returnSingleDelegate = Mult;

            ReturnDelegate returnMultipleDelegate = Mult;
            returnMultipleDelegate += Minus;

            voidSingleDelegate(1, 2);
            Console.WriteLine();

            voidMultipleDelegate(2, 3);
            Console.WriteLine();

            var resultSingleDelegate = returnSingleDelegate(10, 5);
            Console.WriteLine($"resultSingleDelegate = {resultSingleDelegate}");
            Console.WriteLine();

            var resultMultipleDelegate = returnMultipleDelegate(23, 13);
            Console.WriteLine($"resultMultipleDelegate = {resultMultipleDelegate}");
        }

        public static int Mult(int a, int b)
        {
            Console.WriteLine($"Calling Mult({a}, {b}) = {a * b}");
            return a * b;
        }

        public static int Minus(int a, int b)
        {
            Console.WriteLine($"Calling Minus({a}, {b}) = {a - b}");
            return a - b;
        }

        public static void Log(int a, int b)
        {
            Console.WriteLine($"Log: a= {a}, b= {b}");
        }

        public static void LogSum(int a, int b)
        {
            Console.WriteLine($"LogSum: {a} + {b} = {a + b}");
        }

    }
}
