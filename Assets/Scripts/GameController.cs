#region
using System.Linq;
using Assets.Scripts.Constants;
using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class GameController : MonoBehaviour
{
    // 헝가리안 표기법 (iAge, sName) txtName, btnRun

    private GameObject[] gobCards;
    private GameObject[] gobMoney;
    private GameObject[] gobPlayerPanels;

    private GameObject txtRound;

    private Game _game;

    private void Start()
    {
        gobCards = GameObjectHelper.FindByTagInOrder(Tags.Card);
        gobMoney = GameObjectHelper.FindByTagInOrder(Tags.Money);
        gobPlayerPanels = GameObjectHelper.FindByTagInOrder(Tags.PlayerPanel);

        txtRound = GameObject.Find("txtRound");

        _game = new Game();
        _game.StartNewRound();

        txtRound.GetComponent<Text>().text = $"Round {_game.RoundCount}";



//        for (int i = 0; i < gobCards.Length; i++)
//            gobCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + (i + 1));
    }

    public void ScorerButton_Click(int scorerType)
    {
        _game.SelectScorer((ScorerType) scorerType);

        _game.DistributeCards();

        for (int i = 0; i < gobCards.Length; i++)
        {
            Card card = _game[i/2][i%2];

            gobCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/{card}");
        }

        Debug.Log((ScorerType)scorerType);
    }
}