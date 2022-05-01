using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class LogPressShootButton : MonoBehaviour ,IPointerDownHandler,IPointerUpHandler
{
    
    public UnityEvent OnLongClick;
    [SerializeField] WeaponAntimateeShooting Antimateshooting;
    public bool PointerDown;
    [SerializeField] GunsShoot gunsShoot;
    public bool HasAmmo => gunsShoot.ammo.CurrentAmmo > 0;
    void Awake()
    {
        gunsShoot = GameObject.FindGameObjectWithTag("Guns").GetComponent<GunsShoot>();
    }
    public void OnPointerDown(PointerEventData evendata)
    {
        PointerDown = true;
        gunsShoot = GameObject.FindGameObjectWithTag("Guns").GetComponent<GunsShoot>();
    }
    public void OnPointerUp(PointerEventData evendata)
    {
        PointerDown = false;
    }
    void Update()
    {
        if (Time.time >= gunsShoot.NextTimeToFire)
        {
            if (OnLongClick != null)
                OnLongClick.Invoke();
        }
        if (PointerDown)
        {
            ButtonShoot();
        }    
    }
    public void ButtonShoot()
    {
        if (HasAmmo && Time.time >= gunsShoot.NextTimeToFire)
        {
            gunsShoot.GunsSoundsAndAnim();
            gunsShoot.TakeBulletsFromPool();
            gunsShoot.ammo.UpdateAmmo();
        }     
    }

}
