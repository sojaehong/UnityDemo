#region
using UnityEngine;
using UnityEngine.UI;
#endregion

public class PlayerPanelController : MonoBehaviour
{
    public void BindModel(Player model)
    {
        model.Won += OnWon;
        model.Defeated += OnDefeated;
    }

    private Color _loserColor;

    private void OnDefeated(object sender, Player.DefeatedEventArgs e)
    {
        GetComponent<Image>().color = _loserColor;
    }

    private void OnWon(object sender, Player.WonEventArgs e)
    {
        GetComponent<Image>().color = Color.green;
    }

    void Start()
    {
        _loserColor = GetComponent<Image>().color;
    }

    void Update()
    {
    }
}