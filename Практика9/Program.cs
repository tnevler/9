using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика9
{
    public class Point
    {
        public int data;
        public Point next, pred;
        public Point()
        {
            data = 0;
            next = null;
            pred = null;
        }
        public Point(int d)
        {
            data = d;
            next = null;
            pred = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
    }

    public class Program
    {
        static public Point MakeList(int size) //добавление в начало
        {
            if (size < 100 && size > 0)
            {
                int info = size;
                Point beg = MakePoint(info);
                for (int i = size - 1; i > 0; i--)
                {
                    info = i;
                    Point p = MakePoint(info);
                    p.next = beg;
                    beg.pred = p;
                    beg = p;
                }
                return beg;
            }
            else
            {
                Console.WriteLine("Ошибка");
                Point beg = null;
                return beg;
            }
        }


        static public Point MakePoint(int d)
        {
            Point p = new Point(d);
            return p;
        }

        static public void ShowList(Point beg)
        {
            if (beg == null)
            {
                Console.WriteLine("Список пустой");
                return;
            }
            Point p = beg;
            while (p != null)
            {
                Console.Write(p.ToString());
                p = p.next;
            }
            Console.WriteLine();
        }

        static public void FindElementByIndex(Point beg, int size, int FindElem)
        {
            if (FindElem > size || FindElem <= 0) Console.WriteLine("В списке меньше элементов");
            else
            {
                Point p = beg;
                for (int i = 1; i <= size; i++)
                {
                    if (i == FindElem)
                    {
                        Console.WriteLine("В позиции {0} находится элемент {1}", i, p.data);
                        break;
                    }
                    if (p.next != null) p = p.next;
                }
            }
        }

        static public void FindElementByData(Point beg, int size, int FindElem)
        {
            Point p = beg;
            bool ok = false;
            for (int i = 0; i < size; i++)
            {
                if (p.data == FindElem)
                {
                    Console.WriteLine("Элемент {0} находится в {1} позиции", FindElem, i + 1);
                    ok = true;
                    break;
                }
                if (p.next != null) p = p.next;
            }
            if (ok == false) Console.WriteLine("Такого элемента в списке нет");
        }
        static public Point RemoveElement(Point beg, int size, int DelElem)
        {
            Point p = beg;
            if (DelElem > size || DelElem <= 0)
            {
                Console.WriteLine("Ошибка");
                return beg;
            }
            if (DelElem == size)
            {
                if (DelElem != 1)
                {
                    while (p.next.next != null) p = p.next;
                    p.next = null;
                    return beg;
                }
                else
                {
                    beg = null;
                    return beg;
                }
            }
            if (DelElem == 1)
            {
                beg = p.next;
                return beg;
            }
            for (int i = 1; i < size; i++)
            {
                if (i == DelElem)
                {
                    while (p.next != null)
                    {
                        p = p.next;
                        p.pred.data = p.data;
                    }
                    p = p.pred;
                    p.next = null;
                    return beg;
                }
                p = p.next;
            }
            return beg;
        }


        static public void RunMenu(Point beg)
        {
            int check = 0;
            int size = 0;
            do
            {
                Console.WriteLine(@"1. Сформировать двунаправленный список
2. Распечатать список
3. Удалить из списка элемент по индексу
4. Удалить весь список
5. Поиск элемента в списке по значению
6. Поиск элемента в списке по номеру
7. Выход");
                check = ReadIntNumber("", 1, 8);
                switch (check)
                {
                    case 1:
                        {
                            size = ReadIntNumber("Введите размер двунаправленного списка:", 1, 100);
                            beg = MakeList(size);
                            ShowList(beg);
                        }
                        break;
                    case 2:
                        if (beg == null) Console.WriteLine("Список пустой");
                        else ShowList(beg);
                        break;
                    case 3:
                        {
                            if (beg == null) Console.WriteLine("Список пустой");
                            else
                            {
                                int number = ReadIntNumber("Введите номер удаляемого элемента", 1, 100);
                                beg = RemoveElement(beg, size, number);
                                size--;
                                ShowList(beg);
                            }
                        }

                        break;
                    case 4:
                        if (beg == null) Console.WriteLine("Список пустой");
                        else
                        {
                            beg = null;
                            Console.WriteLine("Список удалён");
                        }
                        break;
                    case 5:
                        if (beg == null) Console.WriteLine("Список пустой");
                        else
                        {
                            int elem = ReadIntNumber("Введите число, которое вы хотите найти", 1, 100);
                            FindElementByData(beg, size, elem);
                        }
                        break;

                    case 6:
                        if (beg == null) Console.WriteLine("Список пустой");
                        else
                        {
                            int elem = ReadIntNumber("Введите номер элемента, который вы хотите найти", 1, 100);
                            FindElementByIndex(beg, size, elem);
                        }
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Ошибка!");
                        break;
                }
            } while (check < 7);
        }

        static public int ReadIntNumber(string stringForUser, int left, int right)
        {
            bool okInput = false;
            int number = -100;
            do
            {
                Console.WriteLine(stringForUser);
                try
                {
                    string buf = Console.ReadLine();
                    number = Convert.ToInt32(buf);
                    if (number >= left && number < right) okInput = true;
                    else
                    {
                        Console.WriteLine("Неверно введено число!");
                        okInput = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Неверно введено число!");
                    okInput = false;
                }
            } while (!okInput);
            return number;
        }

        static void Main(string[] args)
        {
            Point beg = null;
            RunMenu(beg);
        }
    }
}
