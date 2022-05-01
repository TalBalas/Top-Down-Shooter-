using UnityEngine;

public class CollectorData : MonoBehaviour
{
    private float LevelStartTime;
    private bool WasHit;
    private int kills;
    void Awake()
    {
        LevelStartTime = Time.time;
        GameEvents.AlienDead += OnAlienDead;
        GameEvents.takeDamage += OntakeDamage;
        GameEvents.AlienHit += OnAlienHit;
    }
    void OnDestroy()
    {
        GameEvents.AlienDead -= OnAlienDead;
        GameEvents.takeDamage -= OntakeDamage;
        GameEvents.AlienHit -= OnAlienHit;
        OntakeDamage(0);

    }
    
    private void OnAlienHit(GameEvents.AlienHitData alienHitData)
    {

        if (alienHitData.AlienHealth > 0) return;
         KillsWithShotGun(alienHitData);



    }
    private void OntakeDamage(float damage)
    {
        if (WasHit) return;
        WasHit = true;
        NotTakingDamageChallange();
        KillsWithoutTakingDamage();
    }
    private void OnAlienDead(AliensDie.AliensDieData aliendata)
    {
        kills++;
        KillsSpiderChallange(aliendata);
        KillsInJeneralChallange();
        KillMuntantsChallange(aliendata);
        //   KillsInJeneralChallangeWithOutGetHit();
     
        CoinsFromChallange(aliendata);
       
  
    }
    private void CoinsFromChallange(AliensDie.AliensDieData aliendata)
    {
        var collectCoin = PlayerPrefs.GetInt("CoinToCollect", 0);
        collectCoin += aliendata.enemysData.MoneyToAdd;

        PlayerPrefs.SetInt("CoinToCollect", collectCoin);
        PlayerPrefs.Save();
    }
    private void KillsSpiderChallange(AliensDie.AliensDieData aliendata)
    {
        var killSpiders = PlayerPrefs.GetInt("SpiderToKillDaily", 0);
        if (aliendata.enemysData.name == "SpiderData")
        {
            killSpiders++;
        }
        PlayerPrefs.SetInt("SpiderToKillDaily", killSpiders);
        PlayerPrefs.Save();
    }
    private void KillsInJeneralChallange()
    {
        var killSpiders = PlayerPrefs.GetInt("EnemyDailyValue", 0);
            killSpiders++;
        PlayerPrefs.SetInt("EnemyDailyValue", killSpiders);
        PlayerPrefs.Save();
    }
   
    private void KillMuntantsChallange(AliensDie.AliensDieData aliendata)
    {
        var killMuntants = PlayerPrefs.GetInt("MuntantToKillDaily", 0);
        if (aliendata.enemysData.Name == "Muntant")
        {
            killMuntants++;
        }
        PlayerPrefs.SetInt("MuntantToKillDaily", killMuntants);
        PlayerPrefs.Save();
    }
    private void KillsWithShotGun(GameEvents.AlienHitData alienHitData)
    {
        if (alienHitData.damageType == DamageTypePlayer.DamageType.ShotGun)
        {
            var killWithShotGUN = PlayerPrefs.GetInt("KillsWithShotGun", 0);
            killWithShotGUN++;
            PlayerPrefs.SetInt("KillsWithShotGun", killWithShotGUN);
            PlayerPrefs.Save();
        }
    }
    private void NotTakingDamageChallange()
    {
        var timePass = Time.time - LevelStartTime;
        Debug.Log(timePass);
        var notTakingDamage = PlayerPrefs.GetInt("NotTakingDamage", 0);

        if (timePass > notTakingDamage)
        {
            PlayerPrefs.SetInt("NotTakingDamage", Mathf.FloorToInt(timePass));
            PlayerPrefs.Save();
        }

    }
    private void KillsWithoutTakingDamage()
    {
        var killInGeneral = PlayerPrefs.GetInt("EnemyDailyValueWithOutHit", 0);
         if(kills > killInGeneral)
         {
            PlayerPrefs.SetInt("EnemyDailyValueWithOutHit", kills);
            PlayerPrefs.Save();
         }
           
       
    }

    
}
