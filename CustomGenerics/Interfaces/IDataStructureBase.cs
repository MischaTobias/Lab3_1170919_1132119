using CustomGenerics.Structures;
using System;
namespace CustomGenerics.Interfaces
{
    public interface IDataStructureBase <T>
    {
        void Insert(BinaryTreeNode<T> currentNode, BinaryTreeNode<T> newNode);
        void Delete(BinaryTreeNode<T> currentNode, string value);
        BinaryTreeNode<T> Search(BinaryTreeNode<T> currentNode, string medicine);
    }
}
