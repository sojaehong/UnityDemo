#region
using UnityEngine;
using UnityEngine.UI;
#endregion

public class RoundController : BindableMonoBehaviour<Game>
{
    public override void BindModel(Game model)
    {
        model.RoundNoIncreased += OnRoundNoIncreased;
    }

    private void OnRoundNoIncreased(object sender, Game.RoundNoIncreasedEventArgs e)
    {
        Text.text = $"Round {e.RoundNo:N0}";
    }
}