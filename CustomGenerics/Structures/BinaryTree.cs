using System;
using System.Collections;
using System.Collections.Generic;
using CustomGenerics.Interfaces;
using CustomGenerics.Structures;

namespace CustomGenerics.Structures
{
    public class BinaryTree<T> : IDataStructureBase<T>
    {
        public BinaryTreeNode<T> root;
        private List<BinaryTreeNode<T>> returningList = new List<BinaryTreeNode<T>>();

        public static int CompareByName(string med1, string med2)
        {
            return med1.CompareTo(med2);
        }

        public void AddMedicine(T medicine, T docLine, Comparison<T> Compare)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T> { medicine = medicine, docLine = docLine, leftSon = null, rightSon = null, father = null };
            Insert(root, node, Compare);
        }

        public void Insert(BinaryTreeNode<T> currentNode, BinaryTreeNode<T> newNode, Comparison<T> Compare)
        {
            if (currentNode == null)
            {
                currentNode = newNode;
            }
            else if (currentNode.leftSon == null && currentNode.rightSon == null)
            {
                newNode.father = currentNode;
                if (Compare(currentNode.medicine, newNode.medicine) < 0)
                {
                    currentNode.leftSon = newNode;
                }
                else
                {
                    currentNode.rightSon = newNode;
                }
            }
        }

        //public delegate BinaryTreeNode<T> GetReplacementNode();

        public void Delete(BinaryTreeNode<T> currentNode, T value, Comparison<T> Comparison)
        {
            if (Comparison(currentNode.medicine, value) == 0)
            {
                var left = currentNode.leftSon;
                var right = currentNode.rightSon;
                if (currentNode.leftSon != null)
                {
                    currentNode = GetReplacementLeft(currentNode.leftSon);
                }
                else if (currentNode.rightSon != null)
                {
                    currentNode = GetReplacementRight(currentNode.rightSon);
                }
                else
                {
                    currentNode = null;
                }
                currentNode.rightSon = right;
                currentNode.leftSon = left;
            }
            else if (Comparison(currentNode.medicine, value) < 0)
            {
                Delete(currentNode.leftSon, value, Comparison);
            }
            else 
            {
                Delete(currentNode.rightSon, value, Comparison);
            }
        }

        private BinaryTreeNode<T> GetReplacementLeft(BinaryTreeNode<T> currentNode)
        {
            if (currentNode.rightSon != null)
            {
                return GetReplacementLeft(currentNode.rightSon);
            }
            else
            {
                if (currentNode.leftSon != null)
                {
                    (currentNode.father).rightSon = currentNode.leftSon;
                    (currentNode.leftSon).father = currentNode.father;
                }
                else
                {
                    (currentNode.father).rightSon = null;
                }
                return currentNode;
            }
        }

        private BinaryTreeNode<T> GetReplacementRight(BinaryTreeNode<T> currentNode)
        {
            if (currentNode.leftSon != null)
            {
                return GetReplacementRight(currentNode.leftSon);
            }
            else
            {
                if (currentNode.rightSon != null)
                {
                    (currentNode.father).leftSon = currentNode.rightSon;
                    (currentNode.rightSon).father = currentNode.father;
                }
                else
                {
                    (currentNode.father).leftSon = null;
                }
                return currentNode;
            }
        }

        public BinaryTreeNode<T> Search(BinaryTreeNode<T> currentNode, T medicine, Comparison<T> Comparison)
        {
            if (Comparison(medicine, currentNode.medicine) < 0)
            {
                if (currentNode.leftSon != null)
                {
                    return Search(currentNode.leftSon, medicine, Comparison);
                }
            }
            else if (Comparison(medicine, currentNode.medicine) == 0)
            {
                return currentNode;
            }
            else
            {
                if (currentNode.rightSon != null)
                {
                    return Search(currentNode.rightSon, medicine, Comparison);
                }
            }
            return null;
        }

        public List<BinaryTreeNode<T>> GetList()
        {
            InOrder(root);
            return returningList;
        }

        public void InOrder(BinaryTreeNode<T> currentNode)
        {
            if (currentNode.leftSon != null)
            {
                InOrder(currentNode.leftSon);
            }
            returningList.Add(currentNode);
            if (currentNode.rightSon != null)
            {
                InOrder(currentNode.rightSon);
            }
        }
    }
}
