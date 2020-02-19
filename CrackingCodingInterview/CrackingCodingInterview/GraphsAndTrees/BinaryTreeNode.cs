namespace CrackingCodingInterview.GraphsAndTrees
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode Left;
        public BinaryTreeNode Right;
        public int Value;
        public BinaryTreeNode Parent;

        public BinaryTreeNode(int value = 0)
        {
            Value = value;
        }
    }
}