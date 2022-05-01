using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShoot : MonoBehaviour
{
    [SerializeField] Animator ShootAnim;
    private AlienMovment Alienmovment;
    private float TimerDeacreseToShoot;
    [SerializeField] Transform ProjectileSpawner;
    [SerializeField] EnemysData enemysData;
    void Awake()
    {
        Alienmovment = GetComponent<AlienMovment>();
    }
    void Update()
    {
        if (Alienmovment.enabled == false)
        {
            this.enabled = false;
        }

        float DistnaceBetweenPlayer = Alienmovment.CheckDistanceBetWeenPlayer();

        if (DistnaceBetweenPlayer >= enemysData.ShootDistance + 2)
        {
            TimerDeacreseToShoot = 0;
           
        }
        if (DistnaceBetweenPlayer < enemysData.ShootDistance)
        {
            TimerDeacreseToShoot -= Time.deltaTime;

            if (TimerDeacreseToShoot <= 0)
            {
                Shoot();

                TimerDeacreseToShoot = enemysData.ShootTimerSet;
            }

        }
        else
        {
            ShootAnim.SetBool("Shoot", false);
            Alienmovment.AlienMove();
        }
    }
    public void Shoot()
    {
        ShootAnim.SetBool("Shoot", true);
        var ProjectileRefrence = Instantiate(enemysData.ProjectilePrefab,ProjectileSpawner.position,Quaternion.identity);
        ProjectileRefrence.transform.position = ProjectileSpawner.position;
        ProjectileRefrence.transform.forward = transform.forward;
        Destroy(ProjectileRefrence,4);
    }
}
