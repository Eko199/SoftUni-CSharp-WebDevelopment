namespace Collections.Tests;

[TestFixture]
public class CollectionTests
{
    private Collection<int> collection;

    [SetUp]
    public void SetUp()
    {
        collection = new Collection<int>();
    }

    [Test]
    public void Test_EmptyConstructor()
    {
        Assert.AreEqual(0, collection.Count);
        Assert.AreEqual(16, collection.Capacity);
    }

    [Test]
    public void Test_ConstructorSingleItem()
    {
        collection = new Collection<int>(1);
        Assert.AreEqual(1, collection[0]);
    }

    [Test]
    public void Test_ConstructorMultipleItems()
    {
        collection = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);

        Assert.AreEqual(9, collection.Count);
        Assert.AreEqual(18, collection.Capacity);
        Assert.AreEqual(9, collection[8]);
    }

    [Test]
    public void Test_CountAndCapacity()
    {
        collection = new Collection<int>(1);

        Assert.AreEqual(1, collection.Count);
        Assert.AreEqual(16, collection.Capacity);

    }

    [Test]
    public void Test_Add()
    {
        collection.Add(1);
        
        Assert.AreEqual(1, collection.Count);
        Assert.AreEqual(1, collection[0]);
    }

    [Test]
    public void Test_AddWithGrow()
    {
        collection = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);
        collection.AddRange(1, 2, 3, 4, 5, 6, 7, 8);
        collection.Add(1);

        Assert.AreEqual(17, collection.Count);
        Assert.AreEqual(32, collection.Capacity);
    }

    [Test]
    public void Test_AddRange()
    {
        collection.AddRange(1, 2, 3);

        Assert.AreEqual(3, collection.Count);
        Assert.AreEqual(3, collection[2]);
    }

    [Test]
    public void Test_AddRangeWithGrow()
    {
        collection.AddRange(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

        Assert.AreEqual(17, collection.Count);
        Assert.AreEqual(32, collection.Capacity);
    }

    [Test]
    public void Test_GetByIndex()
    {
        collection.AddRange(1, 2, 3, 4, 5);
        Assert.AreEqual(3, collection[2]);
    }

    [Test]
    public void Test_GetByInvalidIndex()
    {
        collection.AddRange(1, 2, 3);

        Assert.Throws<ArgumentOutOfRangeException>(() => collection[-1].ToString());
        Assert.Throws<ArgumentOutOfRangeException>(() => collection[collection.Count].ToString());
    }

    [Test]
    public void Test_SetByIndex()
    {
        collection.Add(1);
        collection[0] = 2;

        Assert.AreEqual(2, collection[0]);
    }

    [Test]
    public void Test_SetByInvalidIndex()
    {
        collection.Add(1);

        Assert.Throws<ArgumentOutOfRangeException>(() => collection[-1] = 2);
        Assert.Throws<ArgumentOutOfRangeException>(() => collection[collection.Count] = 2);
    }

    [Test]
    public void Test_InsertAtMiddle()
    {
        collection.AddRange(1, 2, 3);
        collection.InsertAt(1, 69);

        Assert.AreEqual(69, collection[1]);
        Assert.AreEqual(4, collection.Count);
    }

    [Test]
    public void Test_InsertAtStart()
    {
        collection.AddRange(1, 2, 3);
        collection.InsertAt(0, 69);

        Assert.AreEqual(69, collection[0]);
        Assert.AreEqual(4, collection.Count);
    }

    [Test]
    public void Test_InsertAtEnd()
    {
        collection.AddRange(1, 2, 3);
        collection.InsertAt(3, 69);

        Assert.AreEqual(69, collection[3]);
        Assert.AreEqual(4, collection.Count);
    }

    [Test]
    public void Test_InsertAtWithGrow()
    {
        collection.AddRange(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        collection.InsertAt(3, 69);

        Assert.AreEqual(69, collection[3]);
        Assert.AreEqual(17, collection.Count);
        Assert.AreEqual(32, collection.Capacity);
    }

    [Test]
    public void Test_InsertAtInvalidIndex()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => collection.InsertAt(-1, 69));
    }

    [Test]
    public void Test_ExchangeMiddle()
    {
        collection.AddRange(1, 2, 3, 4);
        collection.Exchange(1, 2);

        Assert.AreEqual(3, collection[1]);
        Assert.AreEqual(2, collection[2]);
        Assert.AreEqual(4, collection.Count);
    }

    [Test]
    public void Test_ExchangeFirstLast()
    {
        collection.AddRange(1, 2, 3, 4);
        collection.Exchange(0, 3);

        Assert.AreEqual(4, collection[0]);
        Assert.AreEqual(1, collection[3]);
        Assert.AreEqual(4, collection.Count);
    }

    [Test]
    public void Test_ExchangeInvalidIndexes()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => collection.Exchange(-1, 0));
    }

    [Test]
    public void Test_RemoveAtMiddle()
    {
        collection.AddRange(1, 2, 3);
        collection.RemoveAt(1);

        Assert.AreEqual(3, collection[1]);
        Assert.AreEqual(2, collection.Count);
    }

    [Test]
    public void Test_RemoveAtStart()
    {
        collection.AddRange(1, 2, 3);
        collection.RemoveAt(0);

        Assert.AreEqual(2, collection[0]);
        Assert.AreEqual(2, collection.Count);
    }

    [Test]
    public void Test_RemoveAtEnd()
    {
        collection.AddRange(1, 2, 3);
        collection.RemoveAt(2);
        
        Assert.AreEqual(2, collection.Count);
    }

    [Test]
    public void Test_RemoveAtInvalidIndex()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => collection.RemoveAt(-1));
    }


    [Test]
    public void Test_RemoveAll()
    {
        collection.AddRange(1, 2, 3, 4, 5);

        for (int i = 0; i < 5; i++)
        {
            collection.RemoveAt(0);
        }
        
        Assert.AreEqual(0, collection.Count);
    }

    [Test]
    public void Test_Clear()
    {
        collection.AddRange(1, 2, 3);
        collection.Clear();

        Assert.AreEqual(0, collection.Count);
    }

    [Test]
    public void Test_ToStringSingle()
    {
        collection.Add(1);
        Assert.AreEqual("[1]", collection.ToString());
    }

    [Test]
    public void Test_ToStringMultiple()
    {
        collection.AddRange(1, 2, 3);
        Assert.AreEqual("[1, 2, 3]", collection.ToString());
    }

    [Test]
    public void Test_ToStringEmpty()
    {
        Assert.AreEqual("[]", collection.ToString());
    }

    [Test]
    public void Test_ToStringCollectionOfCollections()
    {
        var collectionOfCollections = new Collection<Collection<int>>(
            collection, 
            new Collection<int>(1),
            new Collection<int>(1, 2), 
            new Collection<int>(1, 2, 3));

        Assert.AreEqual("[[], [1], [1, 2], [1, 2, 3]]", collectionOfCollections.ToString());
    }

    [Test]
    [Timeout(5000)]
    public void Test_1MillionItems()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            collection.Add(i);
        }

        Assert.AreEqual(1_000_000, collection.Count);
    }
}