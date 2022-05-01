using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerUpsBuyHandler : MoneyRefrenceToBuy
{
    [SerializeField] int LightCirclePowerUpCost;
    [SerializeField] int BlackHolePowerUpCost;
    [SerializeField] Button LightCircleButton;
    [SerializeField] Button BlackHoleButton;
    public void LightCirclePowerUpBuy()
    {
        if (Moeny <= LightCirclePowerUpCost)
        {
            UI_NotEnoughMoneyMassage.SetActive(true);

            return;
        }
        else
        {
            Moeny -= LightCirclePowerUpCost;
            LightCircleButton.interactable = false;
            PlayerPrefs.SetInt("LightCirclePowerUp", 1);
            PlayerPrefs.SetInt("Money", Moeny);
            PlayerPrefs.Save();
        }
    }
    public void BlackHolePowerUpBuy()
    {
        if (Moeny <= BlackHolePowerUpCost)
        {
            UI_NotEnoughMoneyMassage.SetActive(true);

            return;
        }
        else
        {
            Moeny -= BlackHolePowerUpCost;
            BlackHoleButton.interactable = false;
            PlayerPrefs.SetInt("BlackHolePowerUp", 1);
            PlayerPrefs.SetInt("Money", Moeny);
            PlayerPrefs.Save();
        }
    }

}
