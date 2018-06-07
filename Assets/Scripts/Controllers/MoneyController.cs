#region
using System;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class MoneyController : BindableMonoBehaviour<Player>
{
    public override void BindModel(Player model)
    {
        model.MoneyChanged += OnMoneyChanged;
    }

    private void OnMoneyChanged(object sender, Player.MoneyChangedEventArgs e)
    {
        Text.text = e.Money.ToString("N0");
    }
}