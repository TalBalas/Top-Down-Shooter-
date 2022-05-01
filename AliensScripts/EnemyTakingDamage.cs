using UnityEngine;
using UnityEngine.UI;
using System;
public class EnemyTakingDamage : MonoBehaviour
{
     private float CurrentHealth;
    private Slider SliderEnemy;
    [SerializeField] GameObject SliderPrefab;
    [SerializeField] Vector3 SliderOffset;
    public Action<DamageTypePlayer.DamageType> HealthDepleted;
    public Action<DamageTypePlayer.DamageType> Hits;
    public Action<EnemyTakingDamage> InRowBehavior;
    private BoxCollider boxCollider;
    private bool IsHealthBarSpawned;
    [SerializeField] private EnemysData aliensData;
    public float Health => CurrentHealth;
   
    
    private void Awake()
    {
       
        boxCollider = GetComponent<BoxCollider>();
        CurrentHealth = aliensData.StartHealth;
    }
  
    private void OnTriggerEnter(Collider other)
    {
        var damageTypePlayer = other.GetComponent<DamageTypePlayer>();
       


        if (damageTypePlayer != null)
        {
          
            Damage(damageTypePlayer.Damage,damageTypePlayer.damageType);        
        }  
    }
    public void Damage(float DamageCount , DamageTypePlayer.DamageType damageType)
    {
        if (!IsHealthBarSpawned)
        {
            SliderEnemy = Instantiate(SliderPrefab, transform.position + SliderOffset, Quaternion.Euler(-90, 0, 0), transform.transform).transform.GetComponentInChildren<Slider>();
            SliderEnemy.maxValue = aliensData.StartHealth;
            SliderEnemy.value = aliensData.StartHealth;
            IsHealthBarSpawned = true;
        }
       

        CurrentHealth -= DamageCount;
           SliderEnemy.value = CurrentHealth;
           Hits?.Invoke(damageType);
        GameEvents.AlienHit?.Invoke(new GameEvents.AlienHitData {damageType = damageType,Damage = DamageCount , AlienHealth = CurrentHealth });
        if (CurrentHealth <= 0)
        {
          
            boxCollider.enabled = false;
            if (HealthDepleted != null)
            {
                HealthDepleted(damageType);


            }
            return;
        }

    }
   
}
