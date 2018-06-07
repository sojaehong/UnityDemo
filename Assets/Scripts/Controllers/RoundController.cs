#region
using UnityEngine;
using UnityEngine.UI;
#endregion

public class RoundController : MonoBehaviour
{
    public void BindModel(Game model)
    {
        model.RoundNoIncreased += OnRoundNoIncreased;
    }

    private void OnRoundNoIncreased(object sender, Game.RoundNoIncreasedEventArgs e)
    {
        GetComponent<Text>().text = $"Round {e.RoundNo:N0}";
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}