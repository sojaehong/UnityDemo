#region
using System.Collections;
using NUnit.Framework;
using Tanstop.Models;
using UnityEngine.TestTools;
#endregion

public class GameTest
{
    [Test]
    public void GameTest21()
    {
        Card card = new Card(1, true);
        Assert.AreEqual(1, card.No);
    }

    [Test]
    public void GameTest22()
    {
        Card card = new Card(1, true);
        Assert.AreEqual(2, card.No);
    }

    [Test]
    public void GameTest23()
    {
        Card card = new Card(1, true);
        Assert.AreEqual(true, card.IsKwang);
    }

    [Test]
    public void GameTest24()
    {
        Card card = new Card(1, true);
        Assert.AreEqual(true, card.IsKwang);
    }

    [Test]
    public void GameTest25()
    {
        Card card = new Card(1, true);
        Assert.AreEqual(true, card.IsKwang);
    }

    [Test]
    public void GameTest26()
    {
        Card card = new Card(1, true);
        Assert.AreEqual(true, card.IsKwang);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator NewEditModeTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }

    #region methods
    #endregion
}