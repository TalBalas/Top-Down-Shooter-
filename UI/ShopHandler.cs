using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopHandler : MonoBehaviour
{
    [SerializeField] GameObject SkinsCategory;
    [SerializeField] GameObject WepaonsCategory;
    [SerializeField] GameObject PowerUpsCategory;
    [SerializeField] GameObject BoomWeapon;
    [SerializeField] GameObject AntimateeWeapon;

    public void ChangeToSkinCategory()
    {
        WepaonsCategory.SetActive(false);
        SkinsCategory.SetActive(true);
        PowerUpsCategory.SetActive(false);
        BoomWeapon.SetActive(false);
        AntimateeWeapon.SetActive(false);
    }
    public void ChangeToWeaponsCategory()
    {
        WepaonsCategory.SetActive(true);
        SkinsCategory.SetActive(false);
        PowerUpsCategory.SetActive(false);
        BoomWeapon.SetActive(true);
        AntimateeWeapon.SetActive(true);
    }
    public void ChangeToPowerUpsCategory()
    {
        PowerUpsCategory.SetActive(true);
        WepaonsCategory.SetActive(false);
        SkinsCategory.SetActive(false);
        BoomWeapon.SetActive(false);
        AntimateeWeapon.SetActive(false);
    }
}