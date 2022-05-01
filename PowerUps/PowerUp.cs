using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class PowerUp :MonoBehaviour
{
    private float Timer;
    public float CoolDown = 3;
    public Image ImageColor;
    public Button PowerUpButton;
    public Color EnableColor = Color.white;
    public Color DisableColor = Color.grey;
    public ParticleSystem PowerupPartical;
    public LayerMask Enemy;
    //public GameObject LightHit;
    protected virtual void Update()
    {
        SetTimer();
       
    }
    public  void ActivatetPowerUp()
    {
        Timer = 0;
        ActivatePowerUpInternal();
    }
    protected abstract void ActivatePowerUpInternal();
    
    
    private  void SetTimer()
    {
        if(Timer >= CoolDown)
        {
            ImageColor.color = EnableColor;
            PowerUpButton.interactable = true;
        }
        else
        {
            ImageColor.color = DisableColor;
            PowerUpButton.interactable = false;
            Timer += Time.deltaTime;
          
        }
    }

}
