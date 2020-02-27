using CustomGenerics.Structures;
using System;
namespace CustomGenerics.Interfaces
{
    public abstract class DataStructureBase <T>
    {
        protected abstract void Insert(BinaryTreeNode<T> currentNode, BinaryTreeNode<T> newNode, Comparison<BinaryTreeNode<T>> comparison);
        protected abstract void Delete(BinaryTreeNode<T> currentNode, T value, Comparison<T> comparison);
        protected abstract T GetT();
    }
}
