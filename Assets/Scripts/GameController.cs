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

    private Color _loserColor;

    private GameObject pnlScorer;
    private GameObject pnlNewRound;

    private void Show(GameObject gameObject)
    {
        gameObject.transform.localScale = Vector3.one;
    }

    private void Hide(GameObject gameObject)
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    private void Start()
    {
        pnlScorer = GameObject.Find("pnlScorer");
        pnlNewRound = GameObject.Find("pnlNewRound");

        Hide(pnlScorer);
        Hide(pnlNewRound);

        gobCards = GameObjectHelper.FindByTagInOrder(Tags.Card);
        gobMoney = GameObjectHelper.FindByTagInOrder(Tags.Money);
        gobPlayerPanels = GameObjectHelper.FindByTagInOrder(Tags.PlayerPanel);

        _loserColor = gobPlayerPanels[0].GetComponent<Image>().color;

        txtRound = GameObject.Find("txtRound");

        _game = new Game();

        StartNewRound();
    }

    private void StartNewRound()
    {
        _game.StartNewRound();
        txtRound.GetComponent<Text>().text = $"Round {_game.RoundCount}";

        Show(pnlScorer);
    }

    public void ScorerButton_Click(int scorerType)
    {
        Hide(pnlScorer);

        _game.SelectScorer((ScorerType) scorerType);

        _game.DistributeCards();

        for (int i = 0; i < gobCards.Length; i++)
        {
            Card card = _game[i/2][i%2];

            gobCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/{card}");
        }

        // [밑줄쫙] 여기서 플레이어의 돈을 이동하면 안됨
        int winnerIndex = _game.GetWinnerIndex();
        int loserIndex = winnerIndex == 0 ? 1 : 0;

        gobPlayerPanels[winnerIndex].GetComponent<Image>().color = Color.green;
        gobPlayerPanels[loserIndex].GetComponent<Image>().color = _loserColor;

        for (int i = 0; i < gobMoney.Length; i++)
            gobMoney[i].GetComponent<Text>().text = _game[i].Money.ToString("N0");

        Show(pnlNewRound);
    }

    public void NewRoundButton_Click(bool newRound)
    {
        Hide(pnlNewRound);

        if (newRound)
            StartNewRound();
    }
}