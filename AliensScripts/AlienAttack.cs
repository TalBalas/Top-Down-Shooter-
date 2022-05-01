using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlienAttack : MonoBehaviour 
{
    [SerializeField] EnemysData enemysData;
    [SerializeField] Animator AttackAlienAnim;
    [SerializeField] Animator RunAnim;
    private float DistnaceBetweenPlayer;
    private AlienMovment Alienmovment;
    private EnemyTakingDamage EnemytakingDamage;
    void Awake()
    {
        Alienmovment = GetComponent<AlienMovment>();
        EnemytakingDamage = GetComponent<EnemyTakingDamage>();
    }
    void FixedUpdate()
    {
        
        if (enemysData.CanRun)
        {
            if (DistnaceBetweenPlayer <= enemysData.AttackDistance)
            {
                Attack();
            }
            else if (EnemytakingDamage.Health <= enemysData.HealthStartRunning)
            {     
                AttackAlienAnim.SetBool("Attack", false);
                RunAnim.SetBool("Run", true);
                Alienmovment.AlienRunning(enemysData.AlienRunSpeed);
            }

        }
    }
    void Update()
    {
        if (Alienmovment.enabled == false)
        {
            this.enabled = false;
        }
        DistnaceBetweenPlayer = Alienmovment.CheckDistanceBetWeenPlayer();
        if (enemysData.CanAttack)
        {
            if (DistnaceBetweenPlayer <= enemysData.AttackDistance)
            {
                Attack();
            }
            else
            {
                Alienmovment.AlienMove();
                AttackAlienAnim.SetBool("Attack", false);
            }
            
        }
    }
    public void Attack()
    {
        AttackAlienAnim.SetBool("Attack", true);
        RunAnim.SetBool("Run", false);
    }
  
}
