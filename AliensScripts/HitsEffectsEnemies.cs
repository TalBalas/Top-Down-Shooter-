using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsEffectsEnemies : MonoBehaviour
{
    public EnemyTakingDamage EnemytakingDamage;
    [SerializeField] ParticleSystem PistolHIt;
    [SerializeField] ParticleSystem ShotGunHit;
    [SerializeField] ParticleSystem MidRangeHit;
    [SerializeField] ParticleSystem BoomLaserHit;
    [SerializeField] ParticleSystem AntimateeHit;
    public ParticleSystem LightHit;
    [SerializeField] ParticleSystem Hit_BloodPistol;
    [SerializeField] Animator HitAnim;
    void Awake()
    {
        EnemytakingDamage.Hits += OnHitsEffects;
        
    }
    void OnDestroy()
    {
        EnemytakingDamage.Hits -= OnHitsEffects;
        
    }
    public void OnHitsEffects(DamageTypePlayer.DamageType damageType)
    {

        if (damageType == DamageTypePlayer.DamageType.BoomLaser)
        {
            BoomHit();
        }
        else if (damageType == DamageTypePlayer.DamageType.Pistol)
        {
            PistolHit();
        }
        else if (damageType == DamageTypePlayer.DamageType.MidRange)
        {
            MidRangeHIt();
        }
        else if (damageType == DamageTypePlayer.DamageType.ShotGun)
        {
            ShotGunHIt();
        }
        else if (damageType == DamageTypePlayer.DamageType.Antimatee)
        {
            AntimateEhit();
        }
        else if (damageType == DamageTypePlayer.DamageType.LightCircle)
        {
            LightCIrclePowerUp();
        }

    }
    private void PistolHit()
    {
        PistolHIt.Play();
        HitsDefualtBehavior();
    }
    private void BoomHit()
    {
        BoomLaserHit.Play();
        HitsDefualtBehavior();

    }
    private void MidRangeHIt()
    {
        MidRangeHit.Play();
        HitsDefualtBehavior();
    }
    private void ShotGunHIt()
    {
        ShotGunHit.Play();
        HitsDefualtBehavior();
    }
    private void AntimateEhit()
    {
        AntimateeHit.Play();
        HitsDefualtBehavior();
    }
    private void HitsDefualtBehavior()
    {
        HitAnim.SetTrigger("Hit");
        Hit_BloodPistol.Play();
    }
    private void LightCIrclePowerUp()
    {
        HitsDefualtBehavior();
        LightHit.Play();
    }
}
