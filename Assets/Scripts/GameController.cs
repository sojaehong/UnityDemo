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

    private GameObject txtRound;

    private Game _game;

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

        _game = new Game();

        gobCards = GameObjectHelper.FindByTagInOrder(Tags.Card);

        GameObject[] gobMoney = GameObjectHelper.FindByTagInOrder(Tags.Money);
        for (int i = 0; i < gobMoney.Length; i++)
            gobMoney[i].GetComponent<MoneyController>().BindModel(_game[i]);

        var gobPlayerPanels = GameObjectHelper.FindByTagInOrder(Tags.PlayerPanel);
        for (int i = 0; i < gobPlayerPanels.Length; i++)
            gobPlayerPanels[i].GetComponent<PlayerPanelController>().BindModel(_game[i]);

        txtRound = GameObject.Find("txtRound");

        StartNewRound();
    }

    private void StartNewRound()
    {
        _game.StartNewRound();
        txtRound.GetComponent<Text>().text = $"Round {_game.RoundNo}";

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

        _game.GetWinnerIndex();

        // [밑줄쫙] 여기서 플레이어의 돈을 이동하면 안됨
        
        Show(pnlNewRound);
    }

    public void NewRoundButton_Click(bool newRound)
    {
        Hide(pnlNewRound);

        if (newRound)
            StartNewRound();
    }
}