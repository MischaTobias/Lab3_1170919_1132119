using CustomGenerics.Structures;
using System;
namespace CustomGenerics.Interfaces
{
    public interface IDataStructureBase <T>
    {
        void Insert(BinaryTreeNode<T> currentNode, BinaryTreeNode<T> newNode, delegate int Compare);
        void Delete(BinaryTreeNode<T> currentNode, T value, Comparison<T> Compare);
        BinaryTreeNode<T> Search(BinaryTreeNode<T> currentNode, T medicine, delegate int Compare);
    }
}
