using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShooting : GunsShoot
{
    public bool Pistol;
    [SerializeField] private WeaponData weaponData;

    void OnEnable()
    {
        Pistol = true;
    }
    void OnDisable()
    {
        Pistol = false;
    }
    public override void TakeBulletsFromPool()
    {
        var BulletObject = Instantiate(BulletPrefab, BulletSpawner.position, Quaternion.identity, ParentBullets);
        BulletObject.transform.forward = OurPlayer.transform.forward;
        NextTimeToFire = Time.time + 1 / weaponData.FireRate;
      
        Destroy(BulletObject, 3);
    }
}
