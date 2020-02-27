using CustomGenerics.Structures;
using System;
namespace CustomGenerics.Interfaces
{
    public interface IDataStructureBase <T>
    {
        void Insert(BinaryTreeNode<T> currentNode, BinaryTreeNode<T> newNode, Comparison<BinaryTreeNode<T>> Comparison);
        void Delete(BinaryTreeNode<T> currentNode, T value, Comparison<T> Comparison);
        T GetT();
    }
}
