using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] float Damage;
    [SerializeField] float Speed;
     Transform OurPlayer;
    Vector3 offset;
    void Awake()
    {
        OurPlayer = PlayerLocator.Instance.transform;
        offset = transform.position - OurPlayer.position;
    }
    void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
        transform.position = new Vector3(OurPlayer.position.x + offset.x, transform.position.y, OurPlayer.position.z + offset.z);
    }
   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            var dmg = other.gameObject.GetComponent<EnemyTakingDamage>();
            dmg.Damage(Damage,DamageTypePlayer.DamageType.Meteors);
            
          
         
        }
    }
}
