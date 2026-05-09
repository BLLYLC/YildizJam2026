using UnityEngine;
public abstract class WeaponBase : ScriptableObject
{
    public string WeaponName;
    public string attackSpeed;
    public GameObject GameObject;

    public abstract void Activate1(GameObject owner);
    public abstract void Activate2(GameObject owner);
}
