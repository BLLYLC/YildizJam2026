using UnityEngine;

public class Blaster : WeaponBase
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float distance = 1f;
    [SerializeField] private float knockback = 1f;
    [SerializeField] private float vAngle = 15f;

    [SerializeField] private float dashForce = 5f;


    public override void Activate1(GameObject owner)
    {
        PlayerStats ps = owner.GetComponent<PlayerStats>();
        int pID = ps.GetPlayerId();
        
        Quaternion shootRotation = owner.transform.rotation; 

        Vector3 spawnPos = owner.transform.position + owner.transform.forward * distance;
        GameObject b = Instantiate(bullet, spawnPos, shootRotation);
        BlasterBullet bs = b.GetComponent<BlasterBullet>();
        bs.SetPlayer(pID);
        owner.transform.position -= owner.transform.forward * knockback;
        
        CharacterController cc = owner.GetComponent<CharacterController>();
        if (cc!=null)
        {
            cc.Move(owner.transform.forward * dashForce);
        }

    }

    public override void Activate2(GameObject owner)
    {
        

        Quaternion baseRotation = owner.transform.rotation;

       
        Quaternion leftRotation = baseRotation * Quaternion.Euler(0, -vAngle, 0);
        Quaternion rightRotation = baseRotation * Quaternion.Euler(0, vAngle, 0);

        Vector3 spawnPos = owner.transform.position + owner.transform.forward * distance;

        Instantiate(bullet, spawnPos, leftRotation);
        Instantiate(bullet, spawnPos, rightRotation);

        owner.transform.position -= owner.transform.forward * knockback;
    }
}