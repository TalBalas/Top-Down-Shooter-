using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyingWeaponsHandler : MoneyRefrenceToBuy
{
    [SerializeField] int BoomGunCost;
    [SerializeField] int AntimateeGunCost;
    [SerializeField] Button BoomGunButton;
    [SerializeField] Button AntimateeGunButton;
    public void BoomGunBuy()
    {
        if (Moeny<= BoomGunCost)
        {
            UI_NotEnoughMoneyMassage.SetActive(true);

            return;
        }
        else
        {
            Moeny -= BoomGunCost;
            BoomGunButton.interactable = false;
            PlayerPrefs.SetInt("BoomGun", 1);
            PlayerPrefs.SetInt("Money", Moeny);
            PlayerPrefs.Save();
        }
    }
    public void AntimateeGunBuy()
    {
        if (Moeny <= AntimateeGunCost)
        {
            UI_NotEnoughMoneyMassage.SetActive(true);
        }
        else
        {
            Moeny -= AntimateeGunCost;
            AntimateeGunButton.interactable = false;
            PlayerPrefs.SetInt("AntimateeGun", 1);
            PlayerPrefs.SetInt("Money", Moeny);
            PlayerPrefs.Save();
        }
    }
}
