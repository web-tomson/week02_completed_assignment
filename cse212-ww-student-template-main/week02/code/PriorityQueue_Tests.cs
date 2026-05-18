using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities.
    // Expected Result: Dequeue returns the value with the highest priority.
    // Defect(s) Found: Dequeue did not remove the highest-priority item from the queue.
    public void TestPriorityQueue_HighestPriorityReturned()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
        Assert.AreEqual("[Low (Pri:1), Medium (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same highest priority.
    // Expected Result: The first item with the highest priority is removed first (FIFO).
    // Defect(s) Found: Dequeue selected the last matching item instead of the first.
    public void TestPriorityQueue_FifoWhenSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 4);
        priorityQueue.Enqueue("Second", 4);
        priorityQueue.Enqueue("Third", 1);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
        Assert.AreEqual("[Second (Pri:4), Third (Pri:1)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None after fix.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
