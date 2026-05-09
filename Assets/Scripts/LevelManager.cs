using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    private string p1WeaponName;
    private string p2WeaponName;
    [SerializeField] private List<GameObject> weaponPrefabList;
    private WeaponBase p1Weapon;
    private WeaponBase p2Weapon;
    private void Start()
    {   
        PlayerController pc1 = player1.GetComponent<PlayerController>();
        PlayerController pc2 = player2.GetComponent<PlayerController>();

        p1WeaponName =GameManager.Instance.GetWeaponName(0);
        p2WeaponName = GameManager.Instance.GetWeaponName(1);
        foreach (GameObject weapon in weaponPrefabList)
        {
            if (p1Weapon != null && p2Weapon != null) break;

            if(weapon.GetComponent<WeaponBase>().name == p1WeaponName)
            {
                var t = Instantiate(weapon);
                p1Weapon = t.GetComponent<WeaponBase>();
            }
            else if(weapon.GetComponent<WeaponBase>().name == p2WeaponName)
            {
                var t = Instantiate(weapon);
                p2Weapon = t.GetComponent<WeaponBase>();
            }
            
        }
        pc1.SetWeapon(p1Weapon);
        pc2.SetWeapon(p2Weapon);
    }
}
