using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M16Shooting : GunsShoot
{
    public bool M16;
    [SerializeField] WeaponData weaponData;

    void OnEnable()
    {
        M16 = true;
    }
    void OnDisable()
    {
        M16 = false;
    }
    public override void TakeBulletsFromPool()
    {
        var BulletObject = Instantiate(BulletPrefab, BulletSpawner.position, Quaternion.identity, ParentBullets);
        BulletObject.transform.forward = OurPlayer.transform.forward;
        NextTimeToFire = Time.time + 1 / weaponData.FireRate;
    
        Destroy(BulletObject, 3);
    }
}
