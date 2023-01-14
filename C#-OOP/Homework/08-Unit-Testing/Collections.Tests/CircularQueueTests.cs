namespace Collections.Tests;

[TestFixture]
public class CircularQueueTests
{
    private CircularQueue<int> queue;

    [SetUp]
    public void SetUp()
    {
        queue = new CircularQueue<int>();
    }

    [Test]
    public void Test_ConstructorDefault()
    {
        Assert.AreEqual(0, queue.Count);
        Assert.AreEqual(0, queue.StartIndex);
        Assert.AreEqual(0, queue.EndIndex);
        Assert.Less(0, queue.Capacity);
        CollectionAssert.AreEqual(Array.Empty<int>(), queue.ToArray());
    }

    [Test]
    public void Test_ConstructorWithCapacity()
    {
        queue = new CircularQueue<int>(2);
        Assert.AreEqual(2, queue.Capacity);
    }

    [Test]
    public void Test_Enqueue()
    {
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Assert.AreEqual(3, queue.Count);
    }

    [Test]
    public void Test_EnqueueWithGrow()
    {
        queue = new CircularQueue<int>(2);

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Assert.AreEqual(3, queue.Count);
        Assert.Less(2, queue.Capacity);
        CollectionAssert.AreEqual(new[] { 10, 20, 30 }, queue.ToArray());
    }

    [Test]
    public void Test_Dequeue()
    {
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Assert.AreEqual(10, queue.Dequeue());
        Assert.AreEqual(2, queue.Count);
        CollectionAssert.AreEqual(new[] { 20, 30 }, queue.ToArray());
    }

    [Test]
    public void Test_DequeueEmpty()
    {
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Test]
    public void Test_Enqueue_DequeueWithRangeCross()
    {
        queue = new CircularQueue<int>(5);

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        queue.Dequeue();
        queue.Dequeue();

        queue.Enqueue(40);
        queue.Enqueue(50);
        queue.Enqueue(60);

        Assert.AreEqual(4, queue.Count);
        Assert.AreEqual(5, queue.Capacity);
        Assert.Greater(queue.StartIndex, queue.EndIndex);
    }

    [Test]
    public void Test_Peek()
    {
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Assert.AreEqual(10, queue.Peek());
        Assert.AreEqual(3, queue.Count);
        CollectionAssert.AreEqual(new[] { 10, 20, 30 }, queue.ToArray());
    }

    [Test]
    public void Test_PeekEmpty()
    {
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Test]
    public void Test_ToArray()
    {
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        
        CollectionAssert.AreEqual(new[] { 10, 20, 30 }, queue.ToArray());
    }

    [Test]
    public void Test_ToArrayWithRangeCross()
    {

        queue = new CircularQueue<int>(5);

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        queue.Dequeue();
        queue.Dequeue();

        queue.Enqueue(40);
        queue.Enqueue(50);
        queue.Enqueue(60);
        
        CollectionAssert.AreEqual(new[] { 30, 40, 50, 60 }, queue.ToArray());
        Assert.Greater(queue.StartIndex, queue.EndIndex);
    }

    [Test]
    public void Test_ToString()
    {
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        CollectionAssert.AreEqual("[10, 20, 30]", queue.ToString());
    }

    [Test]
    public void Test_MultipleOperations()
    {
        queue = new CircularQueue<int>(2);

        int counter = 0, addedCount = 0, removedCount = 0;

        for (int i = 0; i < 300; i++)
        {
            queue.Enqueue(++counter);
            addedCount++;
            Assert.AreEqual(addedCount - removedCount, queue.Count);


            queue.Enqueue(++counter);
            addedCount++;
            Assert.AreEqual(addedCount - removedCount, queue.Count);

            Assert.AreEqual(removedCount + 1, queue.Peek());
            Assert.AreEqual(++removedCount, queue.Dequeue());
            Assert.AreEqual(addedCount - removedCount, queue.Count);

            var expectedElements = Enumerable.Range(removedCount + 1, addedCount - removedCount).ToArray();

            CollectionAssert.AreEqual(expectedElements, queue.ToArray());
            Assert.AreEqual($"[{string.Join(", ", expectedElements)}]", queue.ToString());
            Assert.GreaterOrEqual(queue.Capacity, queue.Count);
        }
    }

    [Test]
    [Timeout(500)]
    public void Test_1MillionItems()
    {
        int counter = 0, addedCount = 0, removedCount = 0;

        for (int i = 0; i < 1_000_000; i++)
        {
            queue.Enqueue(++counter);
            queue.Enqueue(++counter);
            addedCount += 2;

            queue.Dequeue();
            removedCount++;
        }

        Assert.AreEqual(addedCount - removedCount, queue.Count);
    }
}