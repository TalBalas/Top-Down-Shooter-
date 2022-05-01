using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public  class AlienMovment : MonoBehaviour
{

   [SerializeField] private EnemysData aliensData;
    private Transform PlayerAstronaut;
    private float DistnaceBetweenEenmies;
    private Vector3 TotalRejectionVector;
    private SpawnWaveSystem WaveSystem;
    void Start()
    {
        PlayerAstronaut = PlayerLocator.Instance.transform;
    }
    void Update()
    {
        RotateToPlayer();
        CheckIfEnemyNear();
      
    }
    public void AlienMove()
    {
         transform.position +=  (transform.forward + TotalRejectionVector.normalized) * aliensData.Speed * Time.deltaTime;
    }
    public void AlienRunning(float Speedrun)
    {
        transform.position += (transform.forward + TotalRejectionVector.normalized) * Speedrun * Time.deltaTime;
    }
    public void Init(SpawnWaveSystem spawner)
    {
        WaveSystem = spawner;
    }
   
    void RotateToPlayer()
    {
        var TargetFoward = PlayerAstronaut.position - transform.position;
        TargetFoward.y = 0f;
        var target = Quaternion.LookRotation(TargetFoward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, aliensData.RotationDegress);
    
    }
    public float CheckDistanceBetWeenPlayer()
    {
       return  Vector3.Distance(PlayerAstronaut.position, transform.position);
    }
     void  CheckIfEnemyNear()
    {
       
            TotalRejectionVector = Vector3.zero;
            foreach (var item in WaveSystem.AlienPosRefrences)
            {

                if (item == this.gameObject)
                {
                    continue;
                }
                DistnaceBetweenEenmies = Vector3.Distance(transform.position, item.transform.position);

                if (DistnaceBetweenEenmies <= 5)
                {
                    var RejectionVector = (transform.position - item.transform.position);
                    TotalRejectionVector += RejectionVector;
                }
            }
       
     }
          
       
       
   


}
