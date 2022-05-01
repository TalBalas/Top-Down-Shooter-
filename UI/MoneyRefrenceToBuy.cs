using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyRefrenceToBuy : MonoBehaviour
{
    public Text MoneyText;
    public Text ShopMoneyText;
    public int Moeny;
    public GameObject UI_NotEnoughMoneyMassage;
   
    void Update()
    {
        Moeny = PlayerPrefs.GetInt("Money",0);
        MoneyText.text = "Moeny " + Moeny;
        ShopMoneyText.text = "Moeny " + Moeny;

    }
}
