using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public int WoodPiece=500;
    public int Money=500;
    public Text WoodText;
    public Text MoneyText;
    public void SetWood(int piece)
    {
        WoodPiece += piece;
        WoodText.text = WoodPiece.ToString();
    }
    public void SetMoney(int amount)
    {
        Money += amount;
        MoneyText.text = Money.ToString();
    }
}
