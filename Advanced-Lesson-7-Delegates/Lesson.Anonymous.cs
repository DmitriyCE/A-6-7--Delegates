using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_7_Delegates
{
    public partial class Lesson
    {
        public static void SortWithAnonymousFunction()
        {
            Func<Child, Child, int> sortFunc = delegate (Child ch1, Child ch2)
            {
                return ch1.Age - ch2.Age;
            };

            PrintChildren(children);

            SortAnonymous<Child>(children, sortFunc);

            PrintChildren(children);
        }

        public static void SortWithLambdaFunction()
        {
            Func<Child, Child, int> sortFunc = (Child ch1, Child ch2) => 
            {
                return ch1.Weight - ch2.Weight;
            };

            PrintChildren(children);

            SortAnonymous<Child>(children, sortFunc);

            PrintChildren(children);

            SortAnonymous<Child>(children, (Child ch1, Child ch2) =>
            {
                return ch1.Name.CompareTo(ch2.Name);
            });

            PrintChildren(children);
        }

        public static void SortAnonymous<T>(T[] arr, Func<T, T, int> comparatorFunction)
        {
            T temp = default(T);

            for (int iteration = 0; iteration < arr.Length; iteration++)
            {
                for (int index = 0; index < arr.Length - 1; index++)
                {
                    if (comparatorFunction(arr[index], arr[index + 1]) > 0)
                    {
                        temp = arr[index + 1];
                        arr[index + 1] = arr[index];
                        arr[index] = temp;
                    }
                }
            }
        }
    }    
}
