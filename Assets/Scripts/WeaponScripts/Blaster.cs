using UnityEngine;
[CreateAssetMenu(fileName = "Blaster", menuName = "ScriptableObjects/WeaponBase/Blaster")]

public class Blaster : WeaponBase
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float distance=1;
    [SerializeField] private float Knockback=5f;
    public override void Activate1(GameObject owner)
    {
       Instantiate(bullet,owner.transform.position + owner.transform.forward*distance,owner.transform.rotation);
        owner.transform.position -= owner.transform.forward * Knockback;
    }

    public override void Activate2(GameObject owner)
    {
        
    }
}
