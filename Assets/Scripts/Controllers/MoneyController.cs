#region
using System;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class MoneyController : MonoBehaviour
{
    public void BindModel(Player model)
    {
        model.MoneyChanged += OnMoneyChanged;
    }

    private void OnMoneyChanged(object sender, Player.MoneyChangedEventArgs e)
    {
        GetComponent<Text>().text = e.Money.ToString("N0");
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