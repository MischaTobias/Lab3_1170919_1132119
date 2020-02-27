using System;
using CustomGenerics.Interfaces;
using CustomGenerics.Structures;

namespace CustomGenerics.Structures
{
    public class BinaryTree<T> : IDataStructureBase<T>
    {
        private BinaryTreeNode<T> root;

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

        public delegate BinaryTreeNode<T> GetReplacementNode();

        public void Delete(BinaryTreeNode<T> currentNode, T value, Comparison<T> Comparison)
        {
            if (Comparison(currentNode.medicine, value) == 0)
            {
                //Do something to replace the current node with the one with the most similar value of one of its sub-trees.
                if (currentNode.leftSon != null)
                {
                    GetReplacementLeft(currentNode.leftSon);
                }
                else if (currentNode.rightSon != null)
                {
                    GetReplacementRight(currentNode.rightSon);
                }
                //Pending correction of delete function.
            }
        }

        private BinaryTreeNode<T> GetReplacementLeft(BinaryTreeNode<T> currentNode)
        {
            if ((currentNode.rightSon).rightSon != null)
            {
                return GetReplacementLeft(currentNode.rightSon);
            }
            else
            {
                var returningNode = currentNode.rightSon;
                currentNode.rightSon = null;
                return returningNode;
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
                return currentNode;
            }
        }

        public T GetT()
        {
            throw new NotImplementedException();
        }
    }
}
