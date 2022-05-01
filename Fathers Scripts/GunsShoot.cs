using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunsShoot : MonoBehaviour
{

    // public float FireRate;
    public Ammo ammo;
    public float NextTimeToFire;
    public Animator Anim;
    public ParticleSystem MuzzleFlash;
    public GameObject OurPlayer;
    public AudioSource GunSound;
    public Transform BulletSpawner;
    public bool IsFiring;
    public GameObject BulletPrefab;
    public Transform ParentBullets;
   
    public virtual void Start()
    {
        ammo = GetComponent<Ammo>();
    }
    public virtual void GunsSoundsAndAnim()
    {
        Anim.SetTrigger("Shoot");
        GunSound.Play();
       
    }
    public abstract void TakeBulletsFromPool();
  
}
