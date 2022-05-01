using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainManuHandeler : MonoBehaviour
{
    [SerializeField] GameObject UI_shop;
    [SerializeField] GameObject UI_MainMenu;
    [SerializeField] GameObject UI_LoadOut;
    [SerializeField] GameObject UI_DailyChallages;
    [SerializeField] GameObject UI_Missions;
    [SerializeField] GameObject UI_Options;
    public void UIshopHandler()
    {
      
        UI_shop.SetActive(true);
    }
    public void UILoadOutHandler()
    {
        
        UI_LoadOut.SetActive(true);
    }
    public void UILDailyChallagesHandler()
    { 
        UI_DailyChallages.SetActive(true);
    }
    public void UILMissonsHandler()
    {

        UI_Missions.SetActive(true);
    }
    public void UILOptionsHandler()
    {

        UI_Options.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
  
}
