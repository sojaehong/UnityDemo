#region
using UnityEngine;
using UnityEngine.UI;
#endregion

public class PlayerPanelController : BindableMonoBehaviour<Player>
{
    public override void BindModel(Player model)
    {
        model.Won += OnWon;
        model.Defeated += OnDefeated;
    }

    private Color _loserColor;

    private void OnDefeated(object sender, Player.DefeatedEventArgs e)
    {
        Image.color = _loserColor;
    }

    private void OnWon(object sender, Player.WonEventArgs e)
    {
        Image.color = Color.green;
    }

    protected override void Start()
    {
        _loserColor = GetComponent<Image>().color;
    }
}