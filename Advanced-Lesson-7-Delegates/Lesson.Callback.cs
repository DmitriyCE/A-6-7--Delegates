using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Advanced_Lesson_7_Delegates
{
    public partial class Lesson
    {      
        private static int[] numbers = new int[] { 4, 6, 3, 8, 9, 4 };

        private static Vector[] vectors = new Vector[] {
            new Vector { X = 1, Y = -5 },
            new Vector { X = -8, Y = 7 },
            new Vector { X = 0, Y = 9 },
            new Vector { X = 8, Y = 11 },
        };

        private static Child[] children = new Child[] {
            new Child { Name = "Olga", Age = 5, Weight = 16 },
            new Child { Name = "Lena", Age = 6, Weight = 15 },
            new Child { Name = "Kate", Age = 1, Weight = 11 }
        };

        public static void SortNumbersExample()
        {
            int[] arr = new int[numbers.Length];
            numbers.CopyTo(arr, 0);

            int temp = 0;

            for (int iteration = 0; iteration < arr.Length; iteration++)
            {
                for (int index = 0; index < arr.Length - 1; index++)
                {
                    if (arr[index] > arr[index + 1])
                    //if ((arr[index] - arr[index + 1]) > 0)
                    {
                        temp = arr[index + 1];
                        arr[index + 1] = arr[index];
                        arr[index] = temp;
                    }
                }
            }

            foreach (var item in arr)
            {
                Console.Write($"{item}, ");
            }
        }

        public static void SortVectorsExample()
        {
            Vector[] arr = new Vector[vectors.Length];
            vectors.CopyTo(arr, 0);

            Vector temp;

            for (int iteration = 0; iteration < arr.Length; iteration++)
            {
                for (int index = 0; index < arr.Length - 1; index++)
                {
                    //if ((arr[index] - arr[index + 1]) > 0)
                    if (CompareVectors(arr[index], arr[index + 1]) > 0)
                    {
                        temp = arr[index + 1];
                        arr[index + 1] = arr[index];
                        arr[index] = temp;
                    }
                }
            }

            foreach (var item in arr)
            {
                Console.Write($"{{{item.X}, {item.Y}}}, ");
            }
        }

        public static void SortVectorsGenericExample()
        {
            Vector[] arr = new Vector[vectors.Length];
            vectors.CopyTo(arr, 0);

            Sort<Vector>(arr, new VectorComparator());

            foreach (var item in arr)
            {
                Console.Write($"{{{item.X}, {item.Y}}}, ");
            }
        }

        public static void Sort(Object[] arr)
        {
            Object temp = null;

            for (int iteration = 0; iteration < arr.Length; iteration++)
            {
                for (int index = 0; index < arr.Length - 1; index++)
                {
                    //if ((arr[index] - arr[index + 1]) > 0)
                    //if (CompareVectors(arr[index], arr[index + 1]) > 0)
                    {
                        temp = arr[index + 1];
                        arr[index + 1] = arr[index];
                        arr[index] = temp;
                    }
                }
            }
        }

        public static void Sort<T>(T[] arr)
        {
            T temp = default(T);

            for (int iteration = 0; iteration < arr.Length; iteration++)
            {
                for (int index = 0; index < arr.Length - 1; index++)
                {
                    //if ((arr[index] - arr[index + 1]) > 0)
                    //if (CompareVectors(arr[index], arr[index + 1]) > 0)
                    {
                        temp = arr[index + 1];
                        arr[index + 1] = arr[index];
                        arr[index] = temp;
                    }
                }
            }
        }

        public static void Sort<T>(T[] arr, IComparator<T> comparator)
        {
            T temp = default(T);

            for (int iteration = 0; iteration < arr.Length; iteration++)
            {
                for (int index = 0; index < arr.Length - 1; index++)
                {                    
                    if (comparator.Compare(arr[index], arr[index + 1]) > 0)
                    {
                        temp = arr[index + 1];
                        arr[index + 1] = arr[index];
                        arr[index] = temp;
                    }
                }
            }
        }

        public static int CompareVectors(Vector v1, Vector v2)
        {
            return (v1.X * v1.X + v1.Y * v1.Y) - (v2.X * v2.X + v2.Y * v2.Y);
        }

        public struct Vector
        {
            public int X;
            public int Y;
        }

        public interface IComparator<T>
        {
            int Compare(T t1, T t2);
        }

        public class VectorComparator: IComparator<Vector>
        {
            public int Compare(Vector v1, Vector v2)
            {
                return (v1.X * v1.X + v1.Y * v1.Y) - (v2.X * v2.X + v2.Y * v2.Y);
            }
        }

        public class Child
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Weight { get; set; }
        }

        public class ChildComparator : IComparator<Child>
        {
            public int Compare(Child ch1, Child ch2)
            {
                return ch1.Name.CompareTo(ch2.Name);
            }
        }

        public class ChildAgeComparator : IComparator<Child>
        {
            public int Compare(Child ch1, Child ch2)
            {
                return ch1.Age - ch2.Age;
            }
        }

        public class ChildWeightComparator : IComparator<Child>
        {
            public int Compare(Child ch1, Child ch2)
            {
                return ch1.Weight - ch2.Weight;
            }
        }
    }
}
