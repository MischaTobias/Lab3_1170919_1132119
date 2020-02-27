namespace CustomGenerics.Structures
{
    public class BinaryTreeNode <T>
    {
        public BinaryTreeNode<T> leftSon { get; set; }
        public BinaryTreeNode<T> rightSon { get; set; }
        public T medicine { get; set; }
        public T docLine { get; set; }
    }
}
