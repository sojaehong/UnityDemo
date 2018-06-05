#region
using System.Collections.Generic;
#endregion

public class Player
{
    public Player(string name)
    {
        Name = name;

        _cards = new List<Card>(2);

        Money = 300;
    }

    public string Name { get; private set; }

    private readonly List<Card> _cards;

    public int Money { get; private set; }

    public bool Won { get; set; }

    internal void IncreaseMoney(int prize)
    {
        Money += prize;
    }

    internal void DecreaseMoney(int prize)
    {
        Money -= prize;
    }

    internal void PrepareNewRound()
    {
        _cards.Clear();
        Won = false;
    }

    public Card AddCard(Card card)
    {
        _cards.Add(card);
        return card;
    }

    public Card this[int cardIndex]
    {
        get { return _cards[cardIndex]; }
    }
}