using CustomGenerics.Structures;
using System;
namespace CustomGenerics.Interfaces
{
    public interface IDataStructureBase <T>
    {
        void Insert(BinaryTreeNode<T> currentNode, BinaryTreeNode<T> newNode, Comparison<BinaryTreeNode<T>> comparison);
        void Delete(BinaryTreeNode<T> currentNode, T value, Comparison<T> comparison);
        T GetT();
    }
}
