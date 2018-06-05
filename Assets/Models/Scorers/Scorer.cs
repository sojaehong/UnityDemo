#region
using System;
#endregion

namespace Tanstop.Models.Scorers
{
    public abstract class Scorer
    {
        public abstract Models.Player GetWinner(Models.Player p1, Models.Player p2);

        public static Scorer Create(ScorerType scorerType)
        {
            switch (scorerType)
            {
                case ScorerType.Basic:
                    return new BasicScorer();
                case ScorerType.Simple:
                    return new SimpleScorer();
                default:
                    throw new NotImplementedException("Scorer.Create");
            }
        }
    }

    public enum ScorerType
    {
        Basic,
        Simple
    }
}