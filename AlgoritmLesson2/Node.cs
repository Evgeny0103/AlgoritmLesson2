using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLesson2
{
    public class Node : ILinkedList
    {


        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        private int count = 0;
        private Node startNode;
        private Node endNode;

        public Node() 
        {

        }
        public Node(int value) 
        {
            Value = value;
        }
        public void AddNode(int value)
        {
          

            if (count != 0)
            {
                
                endNode.NextNode = new Node(value);
                endNode.NextNode.PrevNode = endNode;
                endNode = endNode.NextNode;
            }
            else 
            {

                startNode = new Node(value);
                startNode.Value = value;
                endNode = startNode;
            }
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (CheckNode(node))//Если заданный элемент в списке есть, то работаем
            {
                if (node == endNode)//Если элемент последний в списке, то просто добавляем его в конец
                {
                    AddNode(value);
                }
                else //Если не последний, то вставляем его между элементами
                {
                    Node nextNode = node.NextNode;//Сохраняем следующую ноду для дальнейшего использования
                    node.NextNode = new Node(value);//Создаем новую ноду после найденной
                    node.NextNode.NextNode = nextNode;//У новой ноды устанавливаем ссылку на следующую
                    node.NextNode.PrevNode = node;//И на предыдущую
                    nextNode.PrevNode = node.NextNode;//Обновляем ссылку на предыдущую ноду у ранее сохраненной
                    count++;//Обновляем количество
                }
            }
        }

        public Node FindNode(int searchValue)
        {
            Node currentNode = startNode;

            bool isSearchEnd = false;
            while (!isSearchEnd)
            {
                if (currentNode != null)
                    if (currentNode.Value == searchValue)
                        isSearchEnd = true;
                    else
                        currentNode = currentNode.NextNode;
                else
                    isSearchEnd = true;
            }

            return currentNode;
        }

        public int GetCount()
        {
            return count;
        }

        public void RemoveNode(int index)
        {
            
            RemoveNode(FindNodeByIndex(index));
            
        }

        public void RemoveNode(Node node)
        {
            if (node != null && CheckNode(node))
            {
                if (node == startNode) RemoveFirst();
                else if (node == endNode) RemoveLast();
                else
                {
                    node.PrevNode.NextNode = node.NextNode;
                    node.NextNode.PrevNode = node.PrevNode;
                    count--;
                }
            }
        }

        public bool CheckNode(Node node)
        {
            bool isNodeInList = false;
            if (count != 0)
            {
                int i = 0;
                Node currentNode = startNode;
                while (!isNodeInList && i < count)
                {
                    isNodeInList = currentNode == node;
                    currentNode = currentNode.NextNode;
                    i++;
                }
            }
            return isNodeInList;
        }

        public Node FindNodeByIndex(int index)
        {
            Node currentNode = null;
            if (index >= 0 && index < count)
            {
                if (index <= count / 2)
                {
                    currentNode = startNode;
                    int i = 0;
                    while (i < index)
                    {
                        currentNode = currentNode.NextNode;
                        i++;
                    }
                }
                else
                {
                    currentNode = endNode;
                    int i = count - 1;
                    while (i > index)
                    {
                        currentNode = currentNode.PrevNode;
                        i--;
                    }
                }
            }
            return currentNode;
        }

        public void RemoveFirst()
        {
            if (count > 1)
            {
                startNode.NextNode.PrevNode = null;
                startNode = startNode.NextNode;
                count--;
            }
            else if (count == 0)
            {
                ClearList();
            }
        }

        public void RemoveLast()
        {
            if (count > 1)
            {
                endNode.PrevNode.NextNode = null;
                endNode = endNode.PrevNode;
                count--;
            }
            else if (count == 0)
            {
                ClearList();
            }
        }

        public void ClearList()
        {
            startNode = null;
            endNode = null;
            count = 0;
        }

    }
}
    

