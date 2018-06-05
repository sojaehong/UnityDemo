using NUnit.Framework;
using UnityDemo.Models;
using UnityDemo.Models.Scorers;
using UnityEngine;

namespace Assets.Tests
{
    public class SimpleScorerTest_남민우
    {
        [SetUp]
        public void Init()
        {
//            Deck.Instance.PrepareNewRound();
        }

        [Test]
        public void 게임_생성하고_StartNewRound_Ringo입장했는지_테스트()
        {
            Game game = new Game();
            game.StartNewRound();

            Assert.AreEqual("Ringo", game[1].Name);
            Assert.AreEqual(1, game.RoundCount);
        }

        [Test]
        public void Simple스코어_승자_맞게나오는지_테스트()
        {
            Game game = new Game();
            game.StartNewRound();
            game.SelectScorer(ScorerType.Simple);

            SimpleScorer scorer = new SimpleScorer();

            for (int i = 0; i < 100; i++)
            {
                game.DistributeCards();
                int winnerIndex = game.GetWinnerIndex();

                Debug.Log($"{game[0].Name} : {game[0, 0]}, {game[0, 1]} : {game[0, 0].No + game[0, 1].No} \t// {game[1].Name} : {game[1, 0].No}, {game[1, 1].No} : {game[1, 0].No + game[1, 1].No} \t// 승자 : {game[winnerIndex].Name}");

                Assert.AreEqual(scorer.GetWinner(game[0], game[1]), game[winnerIndex]);

            }

        }

        [Test]
        public void Basic스코어_승자_맞게나오는지_테스트()
        {
            Game game = new Game();
            game.StartNewRound();
            game.SelectScorer(ScorerType.Basic);

            BasicScorer scorer = new BasicScorer();

            for (int i = 0; i < 100; i++)
            {
                game.DistributeCards();
                int winnerIndex = game.GetWinnerIndex();

                // 무승부시에 2번째 플레이어가 이긴다는 사실을 발견 //

                Debug.Log($"{game[0].Name} : {game[0, 0]}, {game[0, 1]} \t// {game[1].Name} : {game[1, 0].No}, {game[1, 1].No} : \t// 승자 : {game[winnerIndex].Name}");

                Assert.AreEqual(scorer.GetWinner(game[0], game[1]), game[winnerIndex]);

            }

            Player first = new Player("first");
            first.AddCard(new Card(1, false));
            first.AddCard(new Card(1, false));

            Player second = new Player("second");
            second.AddCard(new Card(1, false));
            second.AddCard(new Card(1, false));

            // 무승부시에 2번째 플레이어가 이긴다는 사실을 발견 //
            Assert.AreEqual("second", scorer.GetWinner(first, second).Name);

        }

        [Test]
        public void 파산_제대로_작동하는지_테스트()
        {
            Game game = new Game();
            game.SelectScorer(ScorerType.Basic);
            Player bankrupter;
            while (true)
            {
                game.DistributeCards();
                int winnerIndex = game.GetWinnerIndex();
                Debug.Log($"승 : {game[winnerIndex].Name} // {game[0].Name} : {game[0].Money} | {game[0].Name} : {game[0].Money}");

                 bankrupter = game.CheckBankrupt();

                if (bankrupter != null)
                    break;
            }

            Debug.Log($"파산 : {bankrupter.Name}");
            Assert.AreEqual(0, bankrupter.Money);
        }
    }
}