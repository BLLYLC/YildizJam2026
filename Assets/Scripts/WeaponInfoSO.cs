using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="WeaponInfoSO",menuName = "ScriptableObjects/WeaponInfoSO")]
public class WeaponInfoSO : ScriptableObject
{
    public string weaponName;
    public string firstHalf;
    public string secondHalf;
    public GameObject gameObject;
    public Sprite weaponSprite;
}
