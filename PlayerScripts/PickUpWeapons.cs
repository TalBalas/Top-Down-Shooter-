using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PickUpWeapons : MonoBehaviour
{
    [Serializable]
    public struct RealWeaponsData
    {
        public WeaponData weaponData;
        public GameObject RealWeapon;
    }
    public RealWeaponsData[] RealWeapons;
    [SerializeField] PlayerWeapons playerWeapons;
    void OnTriggerEnter(Collider other)
    {
        var pickweapon = other.GetComponent<WeaponPickUp>();
        if (pickweapon == null) return;
    
        foreach (var weapon in RealWeapons)
        {
            if (weapon.weaponData == pickweapon.weaponData)
            {
                playerWeapons.CurrentWeapons.Add(weapon.RealWeapon);
                Destroy(other.gameObject);
                break;
            }
        }
        
       DeafultPickUpBehavior();
        ActivateWeapon(playerWeapons.CurrentIndex);

    }
    public void ActivateWeapon(int index)
    {
        for (int i = 0; i < playerWeapons.CurrentWeapons.Count; i++)
        {
            playerWeapons.CurrentWeapons[i].SetActive(i == index);
        }
    }
    private void DeafultPickUpBehavior()
    {
        playerWeapons.CurrentIndex = playerWeapons.CurrentWeapons.Count - 1;
        playerWeapons.CurrentWeapons[0].SetActive(false);

    }
  
}
