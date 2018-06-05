using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assets.Tests
{
    class BasicScorerTest_장우람
    {
        [Test]
        public void P1의_카드가_두장_다_킹이고_p2는_숫자가_같을때()
        {
            Scorer scorer = new BasicScorer();
            Player p1 = new Player("1");
            p1.AddCard(new Card(4, true));
            p1.AddCard(new Card(5, true));

            Player p2 = new Player("2");
            p2.AddCard(new Card(9, false));
            p2.AddCard(new Card(9, false));

            Player winner = scorer.GetWinner(p1, p2);

            Assert.AreEqual(p1, winner);
        }
        [Test]
        public void P1의_카드가_두장_다_같은_숫자이고_p2도_숫자가_같을때()
        {
            Scorer scorer = new BasicScorer();
            Player p1 = new Player("1");
            p1.AddCard(new Card(4, false));
            p1.AddCard(new Card(4, false));

            Player p2 = new Player("2");
            p2.AddCard(new Card(9, false));
            p2.AddCard(new Card(9, false));

            Player winner = scorer.GetWinner(p1, p2);

            Assert.AreEqual(p2, winner);
        }
        [Test]
        public void P1의_카드가_두장_다_같은_숫자이고_p2는_숫자가_다를때()
        {
            Scorer scorer = new BasicScorer();
            Player p1 = new Player("1");
            p1.AddCard(new Card(5, true));
            p1.AddCard(new Card(5, true));

            Player p2 = new Player("2");
            p2.AddCard(new Card(9, false));
            p2.AddCard(new Card(8, false));

            Player winner = scorer.GetWinner(p1, p2);

            Assert.AreEqual(p1, winner);
        }

        [Test]
        public void ROUND_확인_테스트()
        {
           Game game = new Game();

            game.StartNewRound();

            Assert.AreEqual(1, game.RoundCount);
        }
    }
}
