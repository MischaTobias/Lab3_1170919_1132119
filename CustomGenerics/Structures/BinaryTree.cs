using System;
using CustomGenerics.Interfaces;
using CustomGenerics.Structures;

namespace CustomGenerics.Structures
{
    public class BinaryTree<T> : DataStructureBase<T>
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

        protected override void Insert(BinaryTreeNode<T> currentNode, BinaryTreeNode<T> newNode, Comparison<BinaryTreeNode<T>> Comparison)
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


        protected override void Delete(BinaryTreeNode<T> currentNode, T value, Comparison<T> Comparison)
        {
            if (Comparison(currentNode.medicine, value) == 0)
            {
                //Do something to replace the current node with the one with the most similar value of one of its sub-trees.
            }
        }

        protected override T GetT()
        {
            throw new NotImplementedException();
        }
    }
}
