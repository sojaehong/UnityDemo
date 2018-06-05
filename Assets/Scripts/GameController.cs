#region
using System.Collections.Generic;
using System.Linq;
using Tanstop.Models;
using Tanstop.Models.Scorers;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class GameController : MonoBehaviour
{
    private Game _game;

    private GameObject[] gobCards;
    private GameObject[] gobMoneies;
    private GameObject[] gobPlayerPanels;

    private Color colLoserPanel;

    private GameObject plnScorer;
    private GameObject pnlNewRound;
    
    private GameObject txtRound;

    private void Awake()
    {
        gobCards = GameObject.FindGameObjectsWithTag(Tags.Card).OrderBy(x => x.name).ToArray();
        gobMoneies = GameObject.FindGameObjectsWithTag(Tags.Money).OrderBy(x => x.name).ToArray();
        gobPlayerPanels = GameObject.FindGameObjectsWithTag(Tags.PlayerPanel).OrderBy(x => x.name).ToArray();

        colLoserPanel = gobPlayerPanels[0].GetComponent<Image>().color;

        plnScorer = GameObject.Find("plnScorer");
        pnlNewRound = GameObject.Find("pnlNewRound");
        txtRound = GameObject.Find("txtRound");
    }

    private void Start()
    {
//        plnScorer.transform.localScale = Vector3.zero;
//        plnScorer.transform.localScale = Vector3.zero;

        _game = new Game();

        StartNewRound();
    }

    private void StartNewRound()
    {
        _game.IncreaseRound();

        txtRound.GetComponent<Text>().text = $"Round {_game.RoundCount}";

        plnScorer.transform.localScale = Vector3.one;
    }

    private void LoadCardImage()
    {
        for (int i = 0; i < gobCards.Length; i++)
        {
            Card card = _game[i / 2][i % 2];
            gobCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/" + card);
        }
    }

    public void ScorerButton_Click(int scorerType)
    {
        plnScorer.transform.localScale = Vector3.zero;

        _game.SelectStrategy((ScorerType)scorerType);

        _game.DistributeCards();

        LoadCardImage();

        int winnerIndex = _game.GetWinnerIndex();
        int loserIndex = winnerIndex == 0 ? 1 : 0;
        gobPlayerPanels[winnerIndex].GetComponent<Image>().color = Color.green;
        gobPlayerPanels[loserIndex].GetComponent<Image>().color = colLoserPanel;

        for (int i = 0; i < gobMoneies.Length; i++)
            gobMoneies[i].GetComponent<Text>().text = _game[i].Money.ToString("N0");

        pnlNewRound.transform.localScale = Vector3.one;
    }

    public void NewRoundButton_Click(bool newRound)
    {
        pnlNewRound.transform.localScale = Vector3.zero;

        if (newRound)
            StartNewRound();
    }
}