using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using System;
public class TakeDamage : MonoBehaviour
{

    public bool IsTookDamage;
    private float Timer;
    [SerializeField] float SetTimer;
    public int StartHealth;
    public float CurrentHealth;
    [SerializeField] Slider slider;
    [SerializeField] bool IsPlayerDead;
    [SerializeField] bool CanDie;
    [SerializeField] GameManager gameManager;
    public float Health => CurrentHealth;
    public Action<AlienDamage.BulletType> Hits;
    void Awake()
    {
        CurrentHealth = StartHealth;
        slider.maxValue = StartHealth;
        slider.value = StartHealth;
        Timer = SetTimer;
        
    }
 
    private void Update()
    {
       
        if (IsTookDamage)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0)
        {
            Timer = SetTimer;
        }
        
    }

    private void PlayerDead(AlienDamage.BulletType bulletType)
    {
        Hits?.Invoke(bulletType);
        if (CurrentHealth > 0) return;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            IsPlayerDead = true;
        }
        else
        {
            if (CurrentHealth >= 100)
            {
                CurrentHealth = 100;
            }
            CurrentHealth = 100;
            IsPlayerDead = false;
        }
        if (CanDie)
        {
            if (IsPlayerDead)
            {
                gameManager.PlayerDead();
               // Time.timeScale = 0;
                CurrentHealth = 0;
            }
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
       
       
        if (other.gameObject.CompareTag("Heart"))
        {
                IncreasHealth(20);
                Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("AlienDamage"))
        {
            var damageTypePlayer = other.GetComponent<AlienDamage>();
            PlayerDead(damageTypePlayer.buletType);
            TakingDamage(damageTypePlayer.Damage);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("AlienAttackDamage"))
        {
            var damageTypePlayer = other.GetComponent<AlienDamage>();
            PlayerDead(damageTypePlayer.buletType);
            TakingDamage(damageTypePlayer.Damage);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("MuntantTrigger") && !IsTookDamage)
        {
            IsTookDamage = true;
            if (Timer <= 0)
            {
                var damageTypePlayer = other.GetComponent<AlienDamage>();
                TakingDamage(damageTypePlayer.Damage);
            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MuntantTrigger"))
        {
            IsTookDamage = false;
        }
    }
    public void TakingDamage(float damage)
    {
        
        CurrentHealth -= damage;
        GameEvents.takeDamage?.Invoke(damage);
        slider.value = CurrentHealth;
      
    }
    public void IncreasHealth(float AddHealth)
    {

        CurrentHealth += AddHealth;
        slider.value = CurrentHealth;
    }

    
}
