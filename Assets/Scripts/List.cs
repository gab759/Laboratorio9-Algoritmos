using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    public class DoubleLinkedList<T>
    {
        class Node
        {
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public T Value { get; set; }
            public Node(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
            ~Node()
            {
                Next = null;
                Previous = null;
            }
        }

        private Node head;
        private int length = 0;

        public void InsertAtStart(T value)
        {
            if (head == null)
            {
                Node node = new Node(value);
                head = node;
                length = length + 1;
            }
            else
            {
                Node node = new Node(value);
                node.Next = head;
                head.Previous = node;
                head = node;
                length = length + 1;
            }
        }

        public void InsertAtEnd(T value)
        {
            if (head == null)
            {
                InsertAtStart(value);
            }
            else
            {
                Node lastNode = GetLastNode();
                Node newNode = new Node(value);
                lastNode.Next = newNode;
                newNode.Previous = lastNode;
                length = length + 1;
            }
        }

        public void InsertAtPosition(T value, int position)
        {
            if (position == 0)
            {
                InsertAtStart(value);
            }
            else if (position == length - 1)
            {
                InsertAtEnd(value);
            }
            else if (position >= length)
            {
                //throw new Exception("�ao �ao");
            }
            else
            {
                Node nodePosition = head;
                int iterator = 0;
                while (iterator < position)
                {
                    nodePosition = nodePosition.Next;
                    iterator = iterator + 1;
                }
                Node newNode = new Node(value);
                Node previusNode = nodePosition.Previous;
                previusNode.Next = newNode;
                newNode.Previous = previusNode;
                newNode.Next = nodePosition;
                nodePosition.Previous = newNode;
                length = length + 1;
            }
        }

        public void DeleteAtStart()
        {
            if (head == null)
            {
                //throw new Exception("Ie ie");
            }
            else
            {
                Node newHead = head.Next;
                newHead.Previous = null;
                head.Next = null;
                head = newHead;
                length = length - 1;
            }
        }

        public void DeleteAtEnd()
        {
            if (head == null)
            {
                DeleteAtStart();

            }
            else
            {
                Node lastNode = GetLastNode();
                Node newLastNode = lastNode.Previous;
                lastNode.Previous = null;
                newLastNode.Next = null;
                lastNode = null;
                length = length - 1;
            }
        }

        public void DeleteAtPosition(int position)
        {
            if (position == 0)
            {
                DeleteAtStart();
            }
            else if (position == length - 1)
            {
                DeleteAtEnd();
            }
            else if (position >= length)
            {
                //throw new Exception("Ji ji ja ja");
            }
            else
            {
                Node nodePosition = head;
                int iterator = 0;
                while (iterator < position)
                {
                    nodePosition = nodePosition.Next;
                    iterator = iterator + 1;
                }
                Node previousNode = nodePosition.Previous;
                Node nextNode = nodePosition.Next;
                previousNode.Next = nextNode;
                nextNode.Previous = previousNode;
                nodePosition.Previous = null;
                nodePosition.Next = null;
                nodePosition = null;
                length = length - 1;
            }
        }

        private Node GetLastNode()
        {
            Node lastNode = head;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }
            return lastNode;
        }

        public void PrintAllNodes()
        {
            Node tmp = head;
            //while (tmp.Next != null)
            while (tmp != null)
            {
                Debug.Log(tmp.Value + " ");
                tmp = tmp.Next;
            }
        }
        public T GetElementAt(int position)
        {
            if (position < 0 || position >= length)
            {
                //throw new IndexOutOfRangeException("Position out of range");
            }

            Node current = head;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }
        public int Count
        {
            get { return length; }
        }
        /*public T GetPreviousValue(T targetValue)
        {
            Node currentNode = head;
            dynamic value = targetValue;
            // Iterar sobre la lista hasta encontrar el nodo con el valor consultado
            while (currentNode != null && !(currentNode.Value == value))
            {
                currentNode = currentNode.Next;
            }

            // Si el nodo no se encontr� o es el primer nodo de la lista, lanzar una excepci�n
            if (currentNode == null || currentNode == head)
            {
                //throw new Exception("El valor no se encuentra en la lista o no tiene un nodo anterior.");
            }

            // Devolver el valor del nodo anterior
            return currentNode.Previous.Value;
        }
        public int CountOccurrences(T targetValue)
        {
            int count = 0;
            Node currentNode = head;

            // Iterar sobre la lista para contar las ocurrencias del valor
            while (currentNode != null)
            {
                dynamic value = targetValue;
                if (currentNode.Value == value)
                {
                    count++;
                }
                currentNode = currentNode.Next;
            }

            return count;
        }*/
    }
}
