#region
using System;
using Tanstop.Models.Scorers;
using UnityEngine.SocialPlatforms.Impl;
#endregion

namespace Tanstop.Models
{
    public class Game
    {
        public Game()
        {
            _players = new[] { new Player("George"), new Player("Ringo") };
        }

        private const int Prize = 100;

        private readonly Player[] _players;

        public int RoundCount { get; private set; }

        private Scorer _scorer;

        public void IncreaseRound()
        {
            RoundCount++;
        }

        public void SelectStrategy(ScorerType scorerType)
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
            Player loser = winner == _players[0] ? _players[1] : _players[0];
            loser.DecreaseMoney(Prize);

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
    }
}