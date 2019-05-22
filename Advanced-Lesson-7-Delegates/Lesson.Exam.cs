using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced_Lesson_7_Delegates
{
    public partial class Lesson
    {
        public async static void ExamExample()
        {
            /*
            var ford = new Ford();
            ford.LowFuel += (int fuel) => Console.WriteLine($"Low fueld: {fuel}");

            var ford2 = new Ford2();
            ford2.LowFuel += (int fuel) => Console.WriteLine($"Low fueld: {fuel}");

            var ford3 = new Ford3();
            ford3.LowFuel += (int fuel) => Console.WriteLine($"Low fueld: {fuel}");
            */
            /*
            var page = new Page() { Title = "Login Page" };
            var page = new Page("Login Page");

            var page = Page.Instances("Login Page");
            var page = Page.CreatePage("Login Page");

            var page = Page.CreatePage() { Title = "Login Page" };*/
            /*
            var thread = new Thread(() =>
            {
                Console.WriteLine("Hello world");
            });

            

            ThreadPool.QueueUserWorkItem((object state) =>
            {
                Console.WriteLine("Hello world");
            });*/

            //var task = new Task(() =>
            //{
            //    Console.WriteLine("Hello world");
            //});
            //task.Start();
            /*
            Task.Run(() =>
            {
                Console.WriteLine("Hello world");
            });

            Action task = () =>
            {
                Console.WriteLine("Hello world");
            };

            var calc = Calculate(1, 1);
            calc.Wait();
            Console.WriteLine(calc.Result);

            var calc2 = Calculate(2, 2);
            calc2.ContinueWith((t) => Console.WriteLine(t.Result));

            var result = await Calculate(3, 3);
            Console.WriteLine(result);

            Console.WriteLine(Calculate(1, 1));*/

            //Calculate(1, 1, (result) => Console.WriteLine(result));
        }

        public static Task<int> Calculate(int a, int b)
        {
            return Task<int>.Run(() =>
            {
                return a + b;
            });
        }


        public class Ford
        {
            public event Action<int> LowFuel;         
        }

        public class Ford2
        {
            public delegate void LowFuelDelegate(int fuel);
            public LowFuelDelegate LowFuel;
        }

        public class Ford3
        {            
            public Action<int> LowFuel;
        }

        public class Page
        {
            public static int Instances { get; private set; }

            public string Title { get; set; }

            private Page()
            {
            }

            public static Page CreatePage(string title)
            {
                Instances++;
                return new Page() { Title = title };
            }            
        }
    }
}
