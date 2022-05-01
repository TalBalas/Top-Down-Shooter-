using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunShooting : GunsShoot
{
    [SerializeField] float shotgunAngleSpread;
    [SerializeField] WeaponData weaponData;

    public override void TakeBulletsFromPool()
    {
            for (int i = 0; i < 3; i++)
            {

                var BulletObject = Instantiate(BulletPrefab, BulletSpawner.position, Quaternion.identity,ParentBullets);
                BulletObject.transform.position = BulletSpawner.position;
                NextTimeToFire = Time.time + 1 / weaponData.FireRate;
               Quaternion deltaRotation = Quaternion.Euler(0f, i * shotgunAngleSpread, 0f);
               BulletObject.transform.rotation = deltaRotation * BulletSpawner.rotation;
                Destroy(BulletObject, 3);
           

            }
    }
}
