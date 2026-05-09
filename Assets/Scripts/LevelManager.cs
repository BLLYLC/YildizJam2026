using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    private string p1WeaponName;
    private string p2WeaponName;
    [SerializeField] private List<WeaponBase> weaponList;
    private void Start()
    {   
        PlayerController pc1 = player1.GetComponent<PlayerController>();
        PlayerController pc2 = player2.GetComponent<PlayerController>();

        p1WeaponName =GameManager.Instance.GetWeaponName(0);
        p2WeaponName = GameManager.Instance.GetWeaponName(1);
        foreach (WeaponBase weapon in weaponList)
        {
            if (weapon.name == p1WeaponName)
            {
                pc1.SetWeapon(weapon);
            }
            if (weapon.name == p2WeaponName)
            {
                pc2.SetWeapon(weapon);
            }
        }
    }
}
