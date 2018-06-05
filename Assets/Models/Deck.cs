#region
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

public class Deck
{
    #region singleton
    private static Deck _instance;

    public static Deck Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Deck();
            return _instance;
        }
    }

    private Deck()
    {
        _cards = new List<Card>();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                int no = i + 1;
                bool isKwang = j == 1 && (no == 1 || no == 3 || no == 8);
                _cards.Add(new Card(no, isKwang));
            }
        }
    }
    #endregion

    private List<Card> _cards;

    private int _index = 0;

    public void PrepareNewRound()
    {
        _cards = _cards.OrderBy(x => Guid.NewGuid()).ToList();
        _index = 0;
    }

    public Card Draw()
    {
        return _cards[_index++];
    }
}