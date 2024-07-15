using SamUtilities;

namespace LLRB_Tree;

public class RedBlackTree<T> where T : IComparable<T>
{
    /* root of the tree */
    public RBTreeNode<T> root;

    public class RBTreeNode<T> 
    {
        public readonly T item;
        public bool isBlack;
        public RBTreeNode<T> left;
        public RBTreeNode<T> right;

        /**
         * Creates a RBTreeNode with item ITEM and color depending on ISBLACK
         * value.
         * @param isBlack
         * @param item
         */
        public RBTreeNode(bool isBlack, T item)
        {
            this.isBlack = isBlack;
            this.item = item;
        }

        /**
         * Creates a RBTreeNode with item ITEM, color depending on ISBLACK
         * value, left child LEFT, and right child RIGHT.
         * @param isBlack
         * @param item
         * @param left
         * @param right
         */
        public RBTreeNode(bool isBlack, T item, RBTreeNode<T> left, RBTreeNode<T> right)
        {
            this.isBlack = isBlack;
            this.item = item;
            this.left = left;
            this.right = right;
        }
    }

    /**
     * Creates an empty RedBlackTree.
     */
    public RedBlackTree()
    {
        this.root = null;
    }

    /**
     * Flips the color of node and its children. Assume that NODE has both left
     * and right children
     * @param node
     */
    public virtual void flipColors(RBTreeNode<T> node) {
        // TODO: YOUR CODE HERE
    }

    /**
     * Rotates the given node to the right. Returns the new root node of
     * this subtree. For this implementation, make sure to swap the colors
     * of the new root and the old root!
     * @param node
     * @return
     */
    public virtual RBTreeNode<T> rotateRight(RBTreeNode<T> node) {
        // TODO: YOUR CODE HERE
        return null;
    }

    /**
     * Rotates the given node to the left. Returns the new root node of
     * this subtree. For this implementation, make sure to swap the colors
     * of the new root and the old root!
     * @param node
     * @return
     */
    public virtual RBTreeNode<T> rotateLeft(RBTreeNode<T> node) {
        // TODO: YOUR CODE HERE
        return null;
    }

    /**
     * Helper method that returns whether the given node is red. Null nodes (children or leaf
     * nodes) are automatically considered black.
     * @param node
     * @return
     */
    private bool isRed(RBTreeNode<T> node) {
        return node != null && !node.isBlack;
    }

    /**
     * Inserts the item into the Red Black Tree. Colors the root of the tree black.
     * @param item
     */
    public void insert(T item) {
        root = insert(root, item);
        root.isBlack = true;
    }

    /**
     * Inserts the given node into this Red Black Tree. Comments have been provided to help break
     * down the problem. For each case, consider the scenario needed to perform those operations.
     * Make sure to also review the other methods in this class!
     * @param node
     * @param item
     * @return
     */
    private RBTreeNode<T> insert(RBTreeNode<T> node, T item) {
        // TODO: Insert (return) new red leaf node.

        // TODO: Handle normal binary search tree insertion.

        // TODO: Rotate left operation

        // TODO: Rotate right operation

        // TODO: Color flip

        return null; //fix this return statement
    }
}

class Program
{
    static void Main(string[] args)
    {
        Helpers utils = new Helpers();
        Helpers.RunTest(testBasicRotateRight, "testBasicRotateRight");
        Helpers.RunTest(testInsertSimple, "testInsertSimple");
        Helpers.RunTest(testInsertFlipColor, "testInsertFlipColor");
        Helpers.RunTest(testInsertRotateLeft, "testInsertRotateLeft");
        Helpers.RunTest(testInsertRotateRight, "testInsertRotateRight");
        Helpers.RunTest(testInsertAllFixes, "testInsertAllFixes");
        Helpers.RunTest(testInsertUpwardPropagation, "testInsertUpwardPropagation");
    }

    /*
    Tests for a very basic case of rotating right. This does not check for color flips, but only if the nodes are in the proper
    place after rotating right. Note that we have not provided any basic tests for rotate left, but implementation details for
    rotate right and rotate left should be symmetrical.
     */
    public static bool testBasicRotateRight()
    {
        // Insert 10, 9, 8
        TestableRedBlackTree rbtree = new TestableRedBlackTree();
        if (rbtree.root is not null) return false;

        RedBlackTree<int>.RBTreeNode<int> node1 = new RedBlackTree<int>.RBTreeNode<int>(true, 10, null, null);
        RedBlackTree<int>.RBTreeNode<int> node2 = new RedBlackTree<int>.RBTreeNode<int>(true, 9, null, null);
        RedBlackTree<int>.RBTreeNode<int> node3 = new RedBlackTree<int>.RBTreeNode<int>(true, 8, null, null);
        node1.left = node2;
        node2.left = node3;

        RedBlackTree<int>.RBTreeNode<int> newRoot = rbtree.rotateRight(node1);

        if (newRoot.item != 9) return false;
        if (newRoot.right.item != 10) return false;
        if (newRoot.left.item != 8) return false;

        return true;
    }

    public static bool testInsertSimple()
    {
        TestableRedBlackTree rbtree = new TestableRedBlackTree();

        /*
        LLRB Tree representation:

         */
        if (rbtree.root is not null) return false;


        rbtree.insert(10);
        
        /*
        LLRB Tree representation:
           (10)

         */

        // root
        if (rbtree.root is null) return false;
        if (!rbtree.root.isBlack) return false;
        if (rbtree.root.item != 10) return false;

        // left
        if (rbtree.root.left is not null) return false;

        // right
        if (rbtree.root.right is not null) return false;

        rbtree.insert(5);

        /*
        LLRB Tree representation:
            (10)
            └── (5)*

         */


        // root
        if (rbtree.root is null) return false;
        if (!rbtree.root.isBlack) return false;
        if (rbtree.root.item != 10) return false;

        // left
        if (rbtree.root.left is null) return false;
        if (rbtree.root.left.isBlack) return false;
        if (rbtree.root.left.item != 5) return false;

        // left.left
        if (rbtree.root.left.left is not null) return false;

        // left.right
        if (rbtree.root.left.right is not null) return false;

        // right
        if (rbtree.root.right is not null) return false;

        Console.WriteLine("Number of Calls to Flip Colors after inserting (10, 5) in order");
        if (rbtree.callsToFlipColors != 0) return false;

        Console.WriteLine("Number of Calls to Rotate Left after inserting (10, 5) in order");
        if (rbtree.callsToRotateLeft != 0) return false;

        Console.WriteLine("Number of Calls to Rotate Right after inserting (10, 5) in order");
        if (rbtree.callsToRotateRight != 0) return false;

        return true;
    }

    public static bool testInsertFlipColor()
    {
        return false;
    }

    public static bool testInsertRotateLeft()
    {
        return false;
    }

    public static bool testInsertRotateRight()
    {
        return false;
    }

    public static bool testInsertAllFixes()
    {
        return false;
    }

    public static bool testInsertUpwardPropagation()
    {
        return false;
    }

    public class TestableRedBlackTree : RedBlackTree<int>
    {
        public override void flipColors(RBTreeNode<int> node)
        {
            callsToFlipColors++;
            base.flipColors(node);
        }

        public override RBTreeNode<int> rotateRight(RBTreeNode<int> node)
        {
            callsToRotateRight++;
            return base.rotateRight(node);
        }

        public override RBTreeNode<int> rotateLeft(RBTreeNode<int> node)
        {
            callsToRotateLeft++;
            return base.rotateLeft(node);
        }

        public int callsToFlipColors = 0;
        public int callsToRotateRight = 0;
        public int callsToRotateLeft = 0;
    }
}
