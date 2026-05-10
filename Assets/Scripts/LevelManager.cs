using NUnit.Framework;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] private List<GameObject> weaponPrefabList;

    public WeaponBase lightsaberObject;
    public WeaponBase blasterObject;
    public WeaponBase shieldObject;

    // private string p1WeaponName;
    // private string p2WeaponName;

    // private WeaponBase p1Weapon;
    // private WeaponBase p2Weapon;
    private void Start()
    {
        AssignWeapon(player1, GameManager.Instance.GetWeaponName(0));
        AssignWeapon(player2, GameManager.Instance.GetWeaponName(1));

        //PlayerController pc1 = player1.GetComponent<PlayerController>();
        //PlayerController pc2 = player2.GetComponent<PlayerController>();

        //p1WeaponName =GameManager.Instance.GetWeaponName(0);
        //p2WeaponName = GameManager.Instance.GetWeaponName(1);
        //foreach (GameObject weapon in weaponPrefabList)
        //{
        //    if (p1Weapon != null && p2Weapon != null) break;

        //    if(weapon.GetComponent<WeaponBase>().name == p1WeaponName)
        //    {
        //        var t = Instantiate(weapon);
        //        p1Weapon = t.GetComponent<WeaponBase>();
        //    }
        //    else if(weapon.GetComponent<WeaponBase>().name == p2WeaponName)
        //    {
        //        var t = Instantiate(weapon);
        //        p2Weapon = t.GetComponent<WeaponBase>();
        //    }

        //}
        //pc1.SetWeapon(p1Weapon);
        //pc2.SetWeapon(p2Weapon);
    }

    private void AssignWeapon(GameObject player, string weaponName)
    {
        foreach (GameObject prefab in weaponPrefabList)
        {
            WeaponBase wb = prefab.GetComponent<WeaponBase>();
            if (wb != null && wb.WeaponName == weaponName)
            {
                var instance = Instantiate(prefab).GetComponent<WeaponBase>();
                player.GetComponent<PlayerController>().SetWeapon(instance);
                return;
            }
        }
        Debug.LogWarning($"silah bulunamadý: {weaponName} ");
    }
    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            if (lightsaberObject == null) {
                Debug.Log("lightsaber created");
                var lightsaberObj = Instantiate(weaponPrefabList[0]).GetComponent<WeaponBase>();
                lightsaberObject = lightsaberObj;
                player1.GetComponent<PlayerController>().SetWeapon(lightsaberObj);
            }

            if (blasterObject == null)
            {
                Debug.Log("lightsaber created");
                var blasterObj = Instantiate(weaponPrefabList[1]).GetComponent<WeaponBase>();
                blasterObject = blasterObj;
                player2.GetComponent<PlayerController>().SetWeapon(blasterObj);
            }


            //var t2 = Instantiate(weaponPrefabList[1]).GetComponent<WeaponBase>();
            //player2.GetComponent<PlayerController>().SetWeapon(t2);
        }
    }
}
