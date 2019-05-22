using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_7_Delegates
{
    public partial class Lesson
    {
        public delegate int ChildComparatorFunction(Child ch1, Child ch2);
        public delegate int ComparatorFunction<T>(T t1, T t2);

        public static void SortWithDelegatesExample()
        {
            Sort<Vector>(vectors, CompareVectors);

            PrintChildren(children);
            SortChild(children, new ChildComparator().Compare);
            PrintChildren(children);
            SortChild(children, new ChildAgeComparator().Compare);
            PrintChildren(children);
            SortChild(children, new ChildWeightComparator().Compare);
            PrintChildren(children);
        }

        public static void Sort<T>(T[] arr, ComparatorFunction<T> comparatorFunction)
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

        public static void SortChild(Child[] arr, ChildComparatorFunction childComparatorFunction)
        {
            Child temp = null;

            for (int iteration = 0; iteration < arr.Length; iteration++)
            {
                for (int index = 0; index < arr.Length - 1; index++)
                {
                   
                    if (childComparatorFunction(arr[index], arr[index + 1]) > 0)
                    {
                        temp = arr[index + 1];
                        arr[index + 1] = arr[index];
                        arr[index] = temp;
                    }
                }
            }
        }       

        public static void PrintChildren(Child[] children)
        {
            foreach (var item in children)
            {
                Console.WriteLine($"{item.Name}, ({item.Age}years, {item.Weight}kg)");
            }

            Console.WriteLine();
        }
    }
}
