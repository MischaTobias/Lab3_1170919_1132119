namespace CustomGenerics.Structures
{
    public class BinaryTreeNode <T>
    {
        public BinaryTreeNode<T> leftSon { get; set; }
        public BinaryTreeNode<T> rightSon { get; set; }
        public BinaryTreeNode<T> father { get; set; }
        public string medicine { get; set; }
        public int docLine { get; set; }
    }
}
