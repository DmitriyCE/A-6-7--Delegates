using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_7_Delegates
{
    public class Practice
    {
        /// <summary>
        /// L7.P1. Переписать консольный калькулятор с использованием делегатов. 
        /// Используйте switch/case, чтоб определить какую математическую функцию.
        /// </summary>
        /// 
        delegate int del(int x, int y);
        public static void L7P1_Calculator()
        {
            int x = int.Parse (Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            del operation = null;
            switch (str)
            {
                case "plus":
                    {
                        operation = (int x1, int y2) => x + y;
                        break;
                    }
                case "minus":
                    {
                        operation = Minus;
                        break;
                    }
            }
            var result = operation?.Invoke(x, y);
            Console.WriteLine(result);
        }

        public static int Plus (int x, int y)
        {
            return x + y;
        }
        public static int Minus(int x,int y)
        {
            return x - y;
        }
        /// <summary>
        /// L7.P2. Создать расширяющий метод для коллекции строк.
        /// Метод должен принимать делегат форматирующей функции для строки.
        /// Метод должен проходить по всем элементам коллекции и применять данную форматирующую функцию к каждому элементу.
        /// Реализовать следующие форматирующие функции:
        /// Перевод строки в заглавные буквы.
        /// Замена пробелов на подчеркивание.
        /// Продемонстрировать работу расширяющего метода.
        /// </summary>
        public static void L7P2_StringFormater()
        {

        }
    }
}
