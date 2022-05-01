using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
public  class AliensDie : MonoBehaviour
{
    public struct AliensDieData
    {
       public Vector3 pos;
       public EnemysData enemysData;
       public GameObject alien;
       
       
    }

    [Header("Refrence Scripts")]

    public EnemyTakingDamage EnemytakingDamage;
    public AlienMovment alienMovment;
    private LerpToRealMoneyUI lerpToRealMoenyUI;
    [SerializeField] EnemysData enemysData;

    [Header("Changes Variables")]

    [SerializeField] private Vector3 offsetBlackHole = new Vector3(0,5,0);
    [SerializeField] private float BlackHoleLerpSpeed = 20;
    [SerializeField] private float DeathLerpSpeedToSky;

    [Header("Attach Variables")]

    [SerializeField] private Animator AlienDeadAnim;
    [SerializeField] private GameObject BloodPistolDie;
    [SerializeField] private GameObject SplitAlien;
    void Awake()
    {
        EnemytakingDamage.HealthDepleted += OnHealthDepleted;
    }
    private void OnHealthDepleted(DamageTypePlayer.DamageType damageType)
    {
        switch (damageType)
        {
           
            case DamageTypePlayer.DamageType.BoomLaser:
                EnemyBoomDeath();
                break;
            case DamageTypePlayer.DamageType.BlackHole:
                DieToTransofrm(PlayerLocator.Instance.transform, offsetBlackHole, BlackHoleLerpSpeed);
                break;
            default:
                DieToSky();
                break;
        }
    }

    private void EnemyBoomDeath()
    {
        DeafultDeadBehavior();
        var SplitRefrence = Instantiate(SplitAlien, transform.position, Quaternion.identity);
        SplitAlien.SetActive(true);
        //WaveSystem.SpawnEnemy(this.gameObject);
        Destroy(SplitRefrence, 3);
        Debug.Log("BoomDead");
        StartCoroutine(ReturnToPoolEnemy(0.5f));
     
    }
    private  void DieToSky()
    {
        DeafultDeadBehavior();
        StartCoroutine(LerpUp());
        AlienDeadAnim.SetTrigger("Dead");
        StartCoroutine(ReturnToPoolEnemy(4));

      
    }
    private void DieToTransofrm(Transform target,Vector3 offset,float speed)
    {
      
        DeafultDeadBehavior();
        StartCoroutine(ReturnToPoolEnemy(2));
        StartCoroutine(LerpToTarget(target,offset,speed));
    }
    private void DeafultDeadBehavior()
    {
        alienMovment.enabled = false;
        BloodPistolDie.SetActive(true);
        GameEvents.AlienDead?.Invoke(new AliensDieData {pos=transform.position,enemysData = enemysData, alien =gameObject});
      

    }

    
    private IEnumerator LerpUp()
    {
        while (true)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up, DeathLerpSpeedToSky * Time.deltaTime);
        }
        
    }
    private IEnumerator LerpToTarget(Transform target ,Vector3 offset, float speed)
    {
        while (true)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position, target.position +offset ,speed * Time.deltaTime);
        }

    }

    private IEnumerator ReturnToPoolEnemy(float timetodie)
    {
        yield return new WaitForSeconds(timetodie);
        CleanUp();

    }
    private void CleanUp()
    {
        EnemytakingDamage.HealthDepleted -= OnHealthDepleted;
        Destroy(gameObject);
    }

}
