#region
#endregion

using System;

public class Game
{
    public Game()
    {
        _players = new[] {new Player("George"), new Player("Ringo")};
    }

    private const int Prize = 100;

    private readonly Player[] _players;

    public int RoundNo { get; private set; }

    private Scorer _scorer;

    public void StartNewRound()
    {
        RoundNo++;

        OnRoundNoIncreased(RoundNo);
    }

    public void SelectScorer(ScorerType scorerType)
    {
        _scorer = Scorer.Create(scorerType);
    }

    public void DistributeCards()
    {
        Deck.Instance.PrepareNewRound();

        foreach (var player in _players)
            player.PrepareNewRound();

        foreach (var player in _players)
            for (int i = 0; i < 2; i++)
                player.AddCard(Deck.Instance.Draw());
    }

    public int GetWinnerIndex()
    {
        Player winner = _scorer.GetWinner(_players[0], _players[1]);
        winner.IncreaseMoney(Prize);
        winner.RaiseWon();

        Player loser = winner == _players[0] ? _players[1] : _players[0];
        loser.DecreaseMoney(Prize);
        loser.RaiseDefeated();

        return winner == _players[0] ? 0 : 1;
    }

    public Player CheckBankrupt()
    {
        foreach (var player in _players)
            if (player.Money == 0)
                return player;

        return null;
    }

    public Player this[int playerIndex] => _players[playerIndex];

    public Card this[int playerIndex, int cardIndex] => this[playerIndex][cardIndex];

    #region RoundNoIncreased event things for C# 3.0
    public event EventHandler<RoundNoIncreasedEventArgs> RoundNoIncreased;

    protected virtual void OnRoundNoIncreased(RoundNoIncreasedEventArgs e)
    {
        if (RoundNoIncreased != null)
            RoundNoIncreased(this, e);
    }

    private RoundNoIncreasedEventArgs OnRoundNoIncreased(int roundNo )
    {
        RoundNoIncreasedEventArgs args = new RoundNoIncreasedEventArgs(roundNo );
        OnRoundNoIncreased(args);

        return args;
    }

    private RoundNoIncreasedEventArgs OnRoundNoIncreasedForOut()
    {
        RoundNoIncreasedEventArgs args = new RoundNoIncreasedEventArgs();
        OnRoundNoIncreased(args);

        return args;
    }

    public class RoundNoIncreasedEventArgs : EventArgs
    {
        public int RoundNo { get; set;} 

        public RoundNoIncreasedEventArgs()
        {
        }
	
        public RoundNoIncreasedEventArgs(int roundNo )
        {
            RoundNo = roundNo; 
        }
    }
    #endregion
}