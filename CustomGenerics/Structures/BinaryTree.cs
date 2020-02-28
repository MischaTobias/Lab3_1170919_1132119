using System;
using System.Collections;
using System.Collections.Generic;
using CustomGenerics.Interfaces;
using CustomGenerics.Structures;

namespace CustomGenerics.Structures
{
    public class BinaryTree<T> : IDataStructureBase<T>, IEnumerable<T>
    {
        private BinaryTreeNode<T> root;
        private List<BinaryTreeNode<T>> returningList = new List<BinaryTreeNode<T>>();

        public BinaryTree()
        {
            root = null;
        }

        public void AddMedicine(T medicine, T docLine, Comparison<BinaryTreeNode<T>> Comparison)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T> { medicine = medicine, docLine = docLine, leftSon = null, rightSon = null };
            Insert(root, node, Comparison);
        }

        public void Insert(BinaryTreeNode<T> currentNode, BinaryTreeNode<T> newNode, Comparison<BinaryTreeNode<T>> Comparison)
        {
            if (currentNode == null)
            {
                currentNode = newNode;
            }
            else if (Comparison(currentNode, newNode) < 0)
            {
                currentNode = currentNode.leftSon;
                Insert(currentNode, newNode, Comparison);
            }
            else
            {
                currentNode = currentNode.rightSon;
                Insert(currentNode, newNode, Comparison);
            }
        }

        //public delegate BinaryTreeNode<T> GetReplacementNode();

        public void Delete(BinaryTreeNode<T> currentNode, T value, Comparison<T> Comparison)
        {
            if (Comparison(currentNode.medicine, value) == 0)
            {
                //Do something to replace the current node with the one with the most similar value to its,
                //beloinging to one of its sub-trees.
                if (currentNode.leftSon != null)
                {
                    GetReplacementLeft(currentNode.leftSon);
                }
                else if (currentNode.rightSon != null)
                {
                    GetReplacementRight(currentNode.rightSon);
                }
                else
                {
                    currentNode = null;//Pending to assign left and right subtrees to the new node; already returning the correct node.
                }
            }
        }

        private BinaryTreeNode<T> GetReplacementLeft(BinaryTreeNode<T> currentNode)
        {
            if (currentNode.rightSon != null)
            {
                if ((currentNode.rightSon).rightSon != null)
                {
                    return GetReplacementLeft(currentNode.rightSon);
                }
                else
                {
                    var replacementNode = currentNode.rightSon;
                    if ((currentNode.rightSon).leftSon != null)
                    {
                        currentNode.rightSon = (currentNode.rightSon).leftSon;
                    }
                    return replacementNode;
                }
            }
            else
            {
                return currentNode;
            }
        }

        private BinaryTreeNode<T> GetReplacementRight(BinaryTreeNode<T> currentNode)
        {
            if (currentNode.leftSon != null)
            {
                if ((currentNode.leftSon).leftSon != null)
                {
                    return GetReplacementLeft(currentNode.leftSon);
                }
                else
                {
                    var replacementNode = currentNode.leftSon;
                    if ((currentNode.leftSon).rightSon != null)
                    {
                        currentNode.leftSon = (currentNode.leftSon).rightSon;
                    }
                    return replacementNode;
                }
            }
            else
            {
                return currentNode;
            }
        }

        public T GetT()
        {
            throw new NotImplementedException();
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

        public IEnumerator<T> GetEnumerator()
        {
            if (returningList.Count > 0)
            {
                var current = returningList[0];
                while (returningList.Count > 0)
                {
                    yield return current.medicine;
                    returningList.RemoveAt(0);
                }
            }
            //Check that you cannot return a binarytreenode as a T value
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
