using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_7_Delegates
{
    public partial class Lesson
    {
        delegate int FunctionDelegate(int number1, int number2);

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Multiple(int a, int b)
        {
            return a * b;
        }

        public static void CreationExample()
        {
            FunctionDelegate myDel = new FunctionDelegate(Add);

            var myDel2 = new FunctionDelegate(Add);

            FunctionDelegate myDel3 = Add;

            //var myDel4 = Add;

            myDel3 = Multiple;
        }
    }

    /*
    public delegate void Action();
    public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
    public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);

    public delegate TResult Func<out TResult>();
    public delegate TResult Func<in T, out TResult>(T arg);
    public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
    */
}
