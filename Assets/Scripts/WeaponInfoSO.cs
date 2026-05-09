using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="WeaponInfoSO",menuName = "ScriptableObjects/WeaponInfoSO")]
public class WeaponInfoSO : ScriptableObject
{
    public string WeaponName;
    public string FirstHalf;
    public string SecondHalf;
    public Sprite WeaponSprite;
}
