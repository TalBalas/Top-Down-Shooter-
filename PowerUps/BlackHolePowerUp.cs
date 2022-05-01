using System.Collections.Generic;
using UnityEngine;

public class BlackHolePowerUp : PowerUp
{
    private bool IsBoughtBlackHole;
    [SerializeField] GameObject BlackHoleButton;
    [SerializeField] float Radius;
    [SerializeField] float Damage;
    void Awake()
    {
            PlayerPrefs.GetInt("BlackHolePowerUp", 0);
        IsBoughtBlackHole = PlayerPrefs.GetInt("BlackHolePowerUp") == 1;
        if (IsBoughtBlackHole)
        {
            BlackHoleButton.SetActive(true);
        }
    }
    protected override void ActivatePowerUpInternal()
    {
        PowerupPartical.Play();
        Collider[] Enemies = Physics.OverlapSphere(transform.position, Radius, Enemy);
        foreach (Collider enemy in Enemies)
        {
            EnemyTakingDamage EnemyHP = enemy.GetComponent<EnemyTakingDamage>();

            EnemyHP.Damage(Damage,DamageTypePlayer.DamageType.BlackHole);
           

        } 
      
    }
}
