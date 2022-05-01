using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class XiconHandler : MonoBehaviour
{
    [SerializeField] GameObject UI_Options;
    [SerializeField] GameObject UI_Shop;
    [SerializeField] GameObject UI_LoadOut;
    [SerializeField] GameObject UI_NotEnoughMoneyMassage;
    public void XIconUI_Options()
    {
        UI_Options.SetActive(false);
    }
    public void XIconUI_Shop()
    {
        UI_Shop.SetActive(false);
    }
    public void XIconUI_LoadOut()
    {
        UI_LoadOut.SetActive(false);
    }
    public void XIconUI_NotEnoughMoneyMassage()
    {
        UI_NotEnoughMoneyMassage.SetActive(false);
    }
}
