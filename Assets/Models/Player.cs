#region
using System;
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

    internal void IncreaseMoney(int prize)
    {
        Money += prize;
        OnMoneyChanged(Money);
    }

    internal void DecreaseMoney(int prize)
    {
        Money -= prize;
        OnMoneyChanged(Money);
    }

    internal void PrepareNewRound()
    {
        _cards.Clear();
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

    public void RaiseWon()
    {
        OnWon();
    }

    public void RaiseDefeated()
    {
        OnDefeated();
    }

    #region MoneyChanged event things for C# 3.0
    public event EventHandler<MoneyChangedEventArgs> MoneyChanged;

    protected virtual void OnMoneyChanged(MoneyChangedEventArgs e)
    {
        if (MoneyChanged != null)
            MoneyChanged(this, e);
    }

    private MoneyChangedEventArgs OnMoneyChanged(int money )
    {
        MoneyChangedEventArgs args = new MoneyChangedEventArgs(money );
        OnMoneyChanged(args);

        return args;
    }

    private MoneyChangedEventArgs OnMoneyChangedForOut()
    {
        MoneyChangedEventArgs args = new MoneyChangedEventArgs();
        OnMoneyChanged(args);

        return args;
    }

    public class MoneyChangedEventArgs : EventArgs
    {
        public int Money { get; set;} 

        public MoneyChangedEventArgs()
        {
        }
	
        public MoneyChangedEventArgs(int money )
        {
            Money = money; 
        }
    }
    #endregion

    #region Won event things for C# 3.0
    public event EventHandler<WonEventArgs> Won;

    protected virtual void OnWon(WonEventArgs e)
    {
        if (Won != null)
            Won(this, e);
    }

    private WonEventArgs OnWon()
    {
        WonEventArgs args = new WonEventArgs();
        OnWon(args);

        return args;
    }

/*private WonEventArgs OnWonForOut()
{
	WonEventArgs args = new WonEventArgs();
    OnWon(args);

    return args;
}*/

    public class WonEventArgs : EventArgs
    {
	

        /*public WonEventArgs()
        {
        }
        
        public WonEventArgs()
        {
            
        }*/
    }
    #endregion

    #region Defeated event things for C# 3.0
    public event EventHandler<DefeatedEventArgs> Defeated;

    protected virtual void OnDefeated(DefeatedEventArgs e)
    {
        if (Defeated != null)
            Defeated(this, e);
    }

    private DefeatedEventArgs OnDefeated()
    {
        DefeatedEventArgs args = new DefeatedEventArgs();
        OnDefeated(args);

        return args;
    }

/*private DefeatedEventArgs OnDefeatedForOut()
{
	DefeatedEventArgs args = new DefeatedEventArgs();
    OnDefeated(args);

    return args;
}*/

    public class DefeatedEventArgs : EventArgs
    {
	

        /*public DefeatedEventArgs()
        {
        }
        
        public DefeatedEventArgs()
        {
            
        }*/
    }
    #endregion
}