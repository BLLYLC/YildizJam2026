using UnityEngine;
public abstract class WeaponBase : MonoBehaviour
{
    public string WeaponName;
    public string attackSpeed;
    public GameObject model;

    public abstract void Activate1(GameObject owner);
    public abstract void Activate2(GameObject owner);
}