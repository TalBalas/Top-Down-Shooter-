using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BloodyManager : MonoBehaviour
{
    [SerializeField] TakeDamage takeDamage;
    [SerializeField] Sprite[] BloodySprites;
    [SerializeField] Image image;
    [SerializeField] GameObject Canvas;
    void Update()
    {
        DeacreseBloodyBehavior();
    }

    
    private void DeacreseBloodyBehavior()
    {
        if (takeDamage.Health > 50)
        {
            Canvas.SetActive(false);
            return;
        }
        else
        {
            Canvas.SetActive(true);
        }

        if (takeDamage.Health<=50 && takeDamage.Health > 25)
        {
            image.sprite = BloodySprites[0];
        }
        else if (takeDamage.Health <= 25 && takeDamage.Health > 0)
        {
            image.sprite = BloodySprites[1];
        }

    }
}
