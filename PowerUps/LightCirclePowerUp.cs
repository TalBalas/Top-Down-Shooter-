using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightCirclePowerUp : PowerUp
{
    [SerializeField] bool IsBoughtCircleLight;
    [SerializeField] GameObject LightCircleButton;
    [SerializeField] float Radius;
    [SerializeField] float Damage;
    void Awake()
    {
        PlayerPrefs.GetInt("LightCirclePowerUp", 0);
        IsBoughtCircleLight = PlayerPrefs.GetInt("LightCirclePowerUp") == 1;
        if (IsBoughtCircleLight)
        {
            LightCircleButton.SetActive(true);
        }
    }
    protected override void ActivatePowerUpInternal()
    {
        PowerupPartical.Play();

        Collider[] Enemies = Physics.OverlapSphere(transform.position, Radius, Enemy);
        foreach (Collider enemy in Enemies)
        {
            EnemyTakingDamage EnemyHP = enemy.GetComponent<EnemyTakingDamage>();            
            EnemyHP.Damage(Damage, DamageTypePlayer.DamageType.LightCircle);
           
           
        }
       
    }
}
