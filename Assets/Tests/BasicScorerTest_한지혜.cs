using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityDemo.Models;
using UnityDemo.Models.Scorers;

namespace Assets.Tests
{
    class BasicScorerTest_한지혜
    {
        [Test]
        public void 광땡_으로_이긴_경우()
        {
            Scorer scorer = new BasicScorer();
            Player p1 = new Player("1");
            p1.AddCard(new Card(8, true));
            p1.AddCard(new Card(3, true));

            Player p2 = new Player("2");
            p2.AddCard(new Card(10, false));
            p2.AddCard(new Card(10, false));

            Player winner = scorer.GetWinner(p1, p2);

            Assert.AreEqual(p1, winner);
        }

        [Test]
        public void 땡_으로_이긴_경우()
        {
            Scorer scorer = new BasicScorer();
            Player p1 = new Player("1");
            p1.AddCard(new Card(8, false));
            p1.AddCard(new Card(3, false));

            Player p2 = new Player("2");
            p2.AddCard(new Card(9, false));
            p2.AddCard(new Card(9, false));

            Player winner = scorer.GetWinner(p1, p2);

            Assert.AreEqual(p2, winner);

        }

        [Test]
        public void 끗_으로_이긴_경우()
        {
            Scorer scorer = new BasicScorer();
            Player p1 = new Player("1");
            p1.AddCard(new Card(8, false));
            p1.AddCard(new Card(3, false));

            Player p2 = new Player("2");
            p2.AddCard(new Card(9, false));
            p2.AddCard(new Card(5, false));

            Player winner = scorer.GetWinner(p1, p2);

            Assert.AreEqual(p2, winner);

        }
    }
}
