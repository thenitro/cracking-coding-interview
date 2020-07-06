using System;

namespace CrackingCodingInterview.Hard
{
    public class Task1712
    {
        public Task1712()
        {
            var root = new BiNode()
            {
                Value = 4,
                Node1 = new BiNode()
                {
                    Value = 2,
                    Node1 = new BiNode()
                    {
                        Value = 1,
                        Node1 = new BiNode()
                        {
                            Value = 0,
                        },
                    },
                    Node2 = new BiNode()
                    {
                        Value = 3
                    }
                },
                Node2 = new BiNode()
                {
                    Value = 5,
                    Node2 = new BiNode()
                    {
                        Node2 = new BiNode()
                        {
                            Value = 6,
                        }
                    }
                }
            };

            var head = Solution(root);

            while (head != null)
            {
                Console.WriteLine(head.Value);
                head = head.Node2;
            }
        }

        private class BiNode
        {
            public BiNode Node1;
            public BiNode Node2;
            public int Value;
        }

        private BiNode Solution(BiNode root)
        {
            var head = ConvertToCircular(root);
                head.Node1.Node2 = null;
                head.Node1 = null;

            return head;
        }

        private BiNode ConvertToCircular(BiNode root)
        {
            if (root == null)
            {
                return null;
            }

            var part1 = ConvertToCircular(root.Node1);
            var part3 = ConvertToCircular(root.Node2);

            if (part1 == null && part3 == null)
            {
                root.Node1 = root;
                root.Node2 = root;
                return root;
            }

            var tail3 = part3 == null ? null : part3.Node1;

            if (part1 == null)
            {
                Concat(part3.Node1, root);
            }
            else
            {
                Concat(part1.Node1, root);
            }

            if (part3 == null)
            {
                Concat(root, part1);
            }
            else
            {
                Concat(root, part3);
            }

            if (part1 != null && part3 != null)
            {
                Concat(tail3, part1);
            }

            return part1 == null ? root : part1;
        }

        private void Concat(BiNode x, BiNode y)
        {
            x.Node2 = y;
            y.Node1 = x;
        }
    }
}