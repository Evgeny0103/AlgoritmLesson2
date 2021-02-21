using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLesson2
{
    class Program
    {
        #region Пример №1
        static void Main(string[] args)
        {

            Node Testnode = new Node();
            Testnode.AddNode(12);
            Testnode.AddNode(-5);
            Testnode.AddNode(8);
            Testnode.AddNode(1231);
            Testnode.AddNode(11);
            Testnode.AddNode(-4);
            Testnode.AddNode(88);
            Testnode.AddNode(456);

            Console.WriteLine($"Количество элементов в списке: {Testnode.GetCount()}\n");
            PrintList(Testnode);
            Console.ReadLine();

           Node newnode = Testnode.FindNodeByIndex(4);
            Testnode.AddNodeAfter(newnode, 1000);
            Console.WriteLine("Добавлен элемент со значением 1000, после элемента с индексом 4");
            PrintList(Testnode);
            Console.ReadLine();

            Testnode.RemoveFirst();
            Testnode.RemoveLast();
            Console.WriteLine("Удалены первый и последний элементы списка");
            PrintList(Testnode);
            Console.ReadLine();

            Testnode.RemoveNode(5);
            Console.WriteLine("Удален элемент с индексом 5");
            PrintList(Testnode);
            Console.ReadLine();

            newnode = Testnode.FindNode(88);
            Testnode.RemoveNode(newnode);
            Console.WriteLine("Удален элемент со значением 88");
            PrintList(Testnode);
            Console.ReadLine();

            Testnode.ClearList();
            Console.WriteLine("Список полностью очищен");
            PrintList(Testnode);

            Console.ReadLine();

        }

        private static void PrintList(Node list)
        {
            Console.WriteLine("Полный список элементов по индексу:");
            for (int i = 0; i < list.GetCount(); i++)
            {
                Console.WriteLine(i + ":" + list.FindNodeByIndex(i).Value);
            }
            Console.WriteLine();
        }
        #endregion

        #region Пример № 2

        //Основной цикл проверки, будет выполнятся O(logN) раз, 
        //все что за его пределами, константные операции и могут быть отброшены.
        

    /*    public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


        */
        #endregion
    }

}

