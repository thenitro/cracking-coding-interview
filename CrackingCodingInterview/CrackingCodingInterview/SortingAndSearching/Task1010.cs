using System;

namespace CrackingCodingInterview.SortingAndSearching
{
    public class Task1010
    {
        private RankNode _root;
        
        public Task1010()
        {
            Track(5);
            Track(1);
            Track(4);
            Track(4);
            Track(5);
            Track(9);
            Track(7);
            Track(13);
            Track(3);

            Console.WriteLine(0 == GetRankOfNumber(1));
            Console.WriteLine(1 == GetRankOfNumber(3));
            Console.WriteLine(2 == GetRankOfNumber(4));
        }

        private void Track(int value)
        {
            if (_root == null)
            {
                _root = new RankNode(value);
            }
            else
            {
                _root.Insert(value);
            }
        }

        private int GetRankOfNumber(int value)
        {
            return _root.GetRank(value);
        }
    }

    public class RankNode
    {
        public int Data;
        
        public int LeftSize = 0;

        public RankNode Left;
        public RankNode Right;
        
        public RankNode(int data)
        {
            Data = data;
        }

        public void Insert(int value)
        {
            if (value <= Data)
            {
                if (Left == null)
                {
                    Left = new RankNode(value);
                    LeftSize++;
                }
                else
                {
                    Left.Insert(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new RankNode(value);
                }
                else
                {
                    Right.Insert(value);
                }
            }
        }

        public int GetRank(int value)
        {
            if (value == Data)
            {
                return LeftSize;
            } 
            else if (value < Data)
            {
                if (Left == null)
                {
                    return -1;
                }
                else
                {
                    return Left.GetRank(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    return -1;
                }
                
                return LeftSize + 1 + Right.GetRank(value);
            }
        }
    }
}