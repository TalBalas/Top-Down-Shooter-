using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public  class  Ammo : MonoBehaviour
{

    public int CurrentAmmo;
    [SerializeField] Text AmmoCountUI;
    public  bool IsReloading;
    [SerializeField] WeaponData weaponData;
    [SerializeField] GameObject CartridgePrefab;
    void OnEnable()
    {
        ShowAmmoUI();
    }
    void Awake()
    {
        CurrentAmmo = weaponData.StartAmmo;      
    }
   
    public  void  UpdateAmmo()
    {
        CurrentAmmo -= weaponData.HowManyBulletsToDegresse;
        if (CurrentAmmo <= 0 && !IsReloading)
        {
            IsReloading = true;
            StartCoroutine(Reload());
        }
        
        ShowAmmoUI();
    }
    void ShowAmmoUI()
    {
        AmmoCountUI.text = " Ammo :  " + CurrentAmmo.ToString("F0");
        if (IsReloading)
        {
            StartCoroutine(Reload());
        }
    }

    public IEnumerator  Reload()
    {
        Instantiate(CartridgePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(weaponData.RealodTime);
        CurrentAmmo = weaponData.StartAmmo;
        ShowAmmoUI();
        IsReloading = false;

    }
    
  

}
