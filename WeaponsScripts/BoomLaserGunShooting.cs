using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomLaserGunShooting : GunsShoot
{
   
    [SerializeField] float Timer;
    [SerializeField] float TimerBetween;
    public bool Boom;
    public GameObject BoomBulletRefrence;
    [SerializeField] WeaponData weaponData;
    void Awake()
    {
        PlayerPrefs.GetInt("BoomGun", 0);
    }
    void Start()
    {
        Timer = TimerBetween;
    }
    void Update()
    {
        if (IsFiring)
        {
            Timer -= Time.deltaTime;
            BoomBulletRefrence.transform.position = BulletSpawner.position;
            BoomBulletRefrence.transform.rotation = BulletSpawner.rotation;
        }
        if (Timer <= 0)
        {
            IsFiring = false;
            GunSound.Stop();
            Destroy(BoomBulletRefrence);
            Timer = TimerBetween;

        }
    }
    public override void TakeBulletsFromPool()
    {
       
        IsFiring = true;
        BoomBulletRefrence = Instantiate(BulletPrefab, BulletSpawner.transform.position, Quaternion.identity);
         NextTimeToFire = Time.time + 1 / weaponData.FireRate;
        BoomBulletRefrence.transform.forward = OurPlayer.transform.forward;
        
       
    }
    void OnEnable()
    {
        Boom = true;
    }
    void OnDisable()
    {
        Boom = false;
    }
}
