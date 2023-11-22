namespace _01.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T element)
        {
            root = Insert(root, element);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private static TreeNode<T> Insert(TreeNode<T> current, T element)
        {
            if (current == null)
            {
                return new TreeNode<T>(element);
            }

            if (current.IsLeaf())
            {
                return MergeNodes(current, new TreeNode<T>(element));
            }

            if (element.CompareTo(current.LeftKey) < 0)
            {
                TreeNode<T> result = Insert(current.LeftChild, element);

                if (current.LeftChild != result)
                {
                    return MergeNodes(current, result);
                }
            }
            else if (current.IsTwoNode() || element.CompareTo(current.RightKey) < 0)
            {
                TreeNode<T> result = Insert(current.MiddleChild, element);

                if (current.MiddleChild != result)
                {
                    return MergeNodes(current, result);
                }
            }
            else
            {
                TreeNode<T> result = Insert(current.RightChild, element);

                if (current.RightChild != result)
                {
                    return MergeNodes(current, result);
                }
            }

            return current;
        }

        private static TreeNode<T> MergeNodes(TreeNode<T> current, TreeNode<T> insertedNode)
        {
            if (current.IsTwoNode())
            {
                if (insertedNode.LeftKey.CompareTo(current.LeftKey) < 0)
                {
                    current.RightKey = current.LeftKey;
                    current.LeftKey = insertedNode.LeftKey;
                    current.RightChild = current.MiddleChild;
                    current.MiddleChild = insertedNode.MiddleChild;
                    current.LeftChild = insertedNode.LeftChild;
                }
                else
                {
                    current.RightKey = insertedNode.LeftKey;
                    current.MiddleChild = insertedNode.LeftChild;
                    current.RightChild = insertedNode.MiddleChild;
                }

                return current;
            }
            
            if (insertedNode.LeftKey.CompareTo(current.LeftKey) < 0)
            {
                var newNode = new TreeNode<T>(current.LeftKey)
                {
                    LeftChild = insertedNode,
                    MiddleChild = current
                };

                current.LeftKey = current.RightKey;
                current.LeftChild = current.MiddleChild;
                current.MiddleChild = current.RightChild;
                current.RightKey = default;
                current.RightChild = null;

                return newNode;
            }
            
            if (insertedNode.LeftKey.CompareTo(current.RightKey) < 0)
            {
                insertedNode.MiddleChild = new TreeNode<T>(current.RightKey)
                {
                    LeftChild = insertedNode.MiddleChild,
                    MiddleChild = current.RightChild
                };

                insertedNode.LeftChild = current;
                current.RightChild = null;
                current.RightKey = default;

                return insertedNode;
            }

            var newNode1 = new TreeNode<T>(current.RightKey)
            {
                LeftChild = current,
                MiddleChild = insertedNode
            };
            
            current.RightKey = default;
            current.RightChild = null;

            return newNode1;
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
