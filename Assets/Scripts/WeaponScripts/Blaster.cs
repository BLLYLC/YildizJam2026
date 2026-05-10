using UnityEngine;

public class Blaster : WeaponBase
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float distance = 1f;
    [SerializeField] private float knockback = 1f;
    [SerializeField] private float vAngle = 15f; 

    public override void Activate1(GameObject owner)
    {
        PlayerStats target = FindTarget(owner);
        Quaternion shootRotation = owner.transform.rotation; 

        if (target != null)
        {
            Vector3 directionToTarget = target.transform.position - owner.transform.position;
            directionToTarget.y = 0f;
            shootRotation = Quaternion.LookRotation(directionToTarget);
        }
        Vector3 spawnPos = owner.transform.position + owner.transform.forward * distance;
        GameObject b = Instantiate(bullet, spawnPos, shootRotation);

        // Mermiye hedefi ver
        if (target != null && b.TryGetComponent<BlasterBullet>(out BlasterBullet bb))
        {
            bb.SetTarget(target.transform);
        }

        owner.transform.position -= owner.transform.forward * knockback;
    }

    public override void Activate2(GameObject owner)
    {
        PlayerStats target = FindTarget(owner);

        Quaternion baseRotation = owner.transform.rotation;

        if (target != null)
        {
            Vector3 directionToTarget = target.transform.position - owner.transform.position;
            directionToTarget.y = 0f;
            baseRotation = Quaternion.LookRotation(directionToTarget);
        }

        Quaternion leftRotation = baseRotation * Quaternion.Euler(0, -vAngle, 0);
        Quaternion rightRotation = baseRotation * Quaternion.Euler(0, vAngle, 0);

        Vector3 spawnPos = owner.transform.position + owner.transform.forward * distance;

        Instantiate(bullet, spawnPos, leftRotation);
        Instantiate(bullet, spawnPos, rightRotation);

        owner.transform.position -= owner.transform.forward * knockback;
    }

    private PlayerStats FindTarget(GameObject owner)
    {
        PlayerStats[] allPlayers = FindObjectsByType<PlayerStats>(FindObjectsSortMode.None);
        

        foreach (PlayerStats p in allPlayers)
        {
            if (p.gameObject != owner) 
            {
                return p;
            }
        }

        return null;
    }
}